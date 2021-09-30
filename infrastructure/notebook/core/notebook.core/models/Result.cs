using System;
using System.Collections.Generic;
using System.Text;

namespace notebook.core.models
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public Result()
        {
            this.StatusCode = 200;
            this.Message = "Success";
        }


    }
}
