using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class ResultModel<T>
    {
        public List<T> DataList { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
