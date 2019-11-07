using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AugenBookStore.Common.Dtos
{
    public class HttpResponseResult<T>
    {
        public bool IsSuccessStatusCode { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public T ContentObject { get; set; }
    }
}
