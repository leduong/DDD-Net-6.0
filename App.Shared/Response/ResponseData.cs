using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Response
{
    public class ResponseData<T>
    {
        public ResponseData()
        {
            Success = false;
            ErrorMessage = string.Empty;
        }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
