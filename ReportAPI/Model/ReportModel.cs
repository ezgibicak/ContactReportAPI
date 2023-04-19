using System;

namespace ReportAPI.Model
{
    public class ReportModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int State { get; set; }
    }
}
