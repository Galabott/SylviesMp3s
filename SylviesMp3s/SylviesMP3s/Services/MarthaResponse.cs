using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthaService
{
    public class MarthaResponse
    {
        public bool Success { get; set; }
        public IList<object> Data { get; set; }

    }
}
