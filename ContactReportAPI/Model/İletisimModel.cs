using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Model
{
    public class İletisimModel
    {
        public int Id { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
