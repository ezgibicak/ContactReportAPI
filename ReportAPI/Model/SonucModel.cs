using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Model
{
    public class SonucModel<T>
    {
        public List<T> Data { get; set; }
        public string Mesaj { get; set; }
    }
}
