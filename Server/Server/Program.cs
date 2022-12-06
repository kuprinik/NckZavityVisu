using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerContext") ?? throw new InvalidOperationException("Connection string 'ServerContext' not found.")));
builder.Services.AddResponseCompression();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
    });
});
var app = builder.Build();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseResponseCompression();
app.UseCors();
app.Run();
