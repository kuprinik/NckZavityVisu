using Newtonsoft.Json;

namespace Server.Models
{
    public class Data
    {
        public int DataId { get; set; }
        public double Time { get; set; }
        public double TcpFx { get; set; }
        public double TcpFy { get; set; }
        public double TcpFz { get; set; }
        public double TcpTx { get; set; }
        public double TcpTy { get; set; }
        public double TcpTz { get; set; }
        public double Ta7 { get; set; }
        public double PhiScrew { get; set; }
        [JsonIgnore]
        public Screw? Screw { get; set; }
        public int ScrewId { get; set; }

    }
}
