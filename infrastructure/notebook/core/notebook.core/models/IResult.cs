using System;
using System.Collections.Generic;
using System.Text;

namespace notebook.core.models
{
   public interface IResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
}
