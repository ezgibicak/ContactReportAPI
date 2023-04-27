using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ResultModel<T>
    {
        public List<T> Data { get; set; }
        public string Mesaj { get; set; }
    }
}
