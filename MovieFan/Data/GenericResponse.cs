using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieFan.Data
{
    public class GenericResponse
    {
        public int Id { get; set; }
        public bool IsSuccessful { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Result { get; set; }
    }
}
