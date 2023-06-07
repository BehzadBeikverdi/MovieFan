using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFan.Model
{
    public class GenericResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public string Result { get; set; }
    }
}
