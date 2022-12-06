using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public DateTime StartTs { get; set; }
        public DateTime EndTs { get; set; }
        public string? Note { get; set; }
        [JsonIgnore]
        public Screw? Screw { get; set; }

    }
}
