using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Entity
{
    
    public class Kisi
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public List<Iletisim> Iletisim { get; set; }

    }
}
