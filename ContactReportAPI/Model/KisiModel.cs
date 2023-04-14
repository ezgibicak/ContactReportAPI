using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Model
{
    public class KisiModel
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public List<İletisimModel> Iletisim { get; set; }
    }
}
