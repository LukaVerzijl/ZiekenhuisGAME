using System;

namespace Code.ApiClient.Models
{
    public class Client
    {
        public string? OuderAccountId { get; set; }
        public string KindNaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime BehandelDatum { get; set; }
        public string DokterNaam { get; set; }
        public string ZiekenhuisNaam { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}