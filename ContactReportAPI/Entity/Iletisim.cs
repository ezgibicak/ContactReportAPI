using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Entity
{
    public class Iletisim
    {
        public int Id { get; set; }
        public Guid KisiId { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
