using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using OperationCanceledException = System.OperationCanceledException;

namespace Server.Services;

public class Export : IHostedService
{
    private readonly CancellationTokenSource cts;
    private readonly ILogger<Export> logger;
    private readonly IServiceScopeFactory scopeFactory;
    private Task? runResult;

    public Export(ILogger<Export> logger, IServiceScopeFactory scopeFactory)
    {
        cts = new CancellationTokenSource();
        this.scopeFactory = scopeFactory;
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        runResult = Task.Run(() => Run(cts.Token), cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        try
        {
            cts.Cancel();
            runResult?.Wait(cts.Token);
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            logger.LogError(ex, "");
        }

        return Task.CompletedTask;
    }

    private async Task ExportScrewData()
    {
        using var scope = scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetService<ServerContext>();
        if (context == null)
        {
            logger.LogError($"{nameof(ServerContext)} was not provided.");
            cts.Cancel();
            return;
        }

        var pth = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "exports");
        if (!Directory.Exists(pth))
        {
            Directory.CreateDirectory(pth);
        }

        var lastId = 0;
        var existingExports = Directory.GetFiles(pth).ToList();
        if (existingExports.Count > 0)
        {
            existingExports.Sort();
            if (Regex.IsMatch(existingExports.Last(), @"screw-(\d+)"))
            {
                lastId = int.Parse(Regex.Match(existingExports.Last(), @"screw-(\d+)").Groups[1].Value);
            }
        }

        var screws = await (from d in context.Screw
            where d.ScrewId > lastId
            select d).ToListAsync();
        foreach (var screw in screws)
        {
            var data = await (from d in context.Data
                where d.ScrewId == screw.ScrewId
                select d).ToListAsync();
            await using var writer = new StreamWriter(Path.Combine(pth, $"screw-{screw.ScrewId:D5}.csv"));
            await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            await csv.WriteRecordsAsync(data);
        }
    }

    private async Task Run(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            //ct.ThrowIfCancellationRequested();
            await ExportScrewData();
            await Task.Delay(TimeSpan.FromMinutes(1), ct);
        }
    }
}