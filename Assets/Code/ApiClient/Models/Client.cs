using System;

namespace Code.ApiClient.Models
{
    [Serializable]
    public class Client
    {
        public string? OuderAccountId { get; set; }
        public string KindNaam { get; set; }
        public string LeeftijdKind { get; set; }
        public string DokterNaam { get; set; }
        public string TypeBehandeling { get; set; }
        public DateTime BehandelDatum { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}