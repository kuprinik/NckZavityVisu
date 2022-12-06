using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Screw
    {
        public int ScrewId { get; set; }
        public DateTime StartTs { get; set; }
        public DateTime EndTs { get; set; }
        public bool Ok { get; set; }
        public string? Note { get; set; }
        [JsonIgnore]
        public Data? Data { get; set; }
        [JsonIgnore]
        public Batch? Batch { get; set; }
        public int BatchId { get; set; }
    }
}
