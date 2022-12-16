using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Server.Models;

public class Data
{
    public double PhiScrew { get; set; }
    public double SensFx { get; set; }
    public double SensFy { get; set; }
    public double SensFz { get; set; }
    public double SensTx { get; set; }
    public double SensTy { get; set; }
    public double SensTz { get; set; }
    public double Ta7 { get; set; }
    public double TcpFx { get; set; }
    public double TcpFy { get; set; }
    public double TcpFz { get; set; }
    public double TcpTx { get; set; }
    public double TcpTy { get; set; }
    public double TcpTz { get; set; }
    public int DataId { get; set; }
    public int ScrewId { get; set; }
    public long Time { get; set; }
    [JsonIgnore] [Ignore] public Screw? Screw { get; set; }
}
