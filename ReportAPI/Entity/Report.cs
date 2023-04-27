using System;

namespace ReportAPI.Entity
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int State { get; set; }
        public string Path { get; set; }

    }
}
