using System;

namespace ReportAPI.Entity
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int State { get; set; }
        public string Path { get; set; }
        //public int KayitliKisi { get; set; }
        //public int KayitliTelefonNo { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }

    }
}
