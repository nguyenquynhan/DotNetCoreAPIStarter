
using AugenBookStore.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugenBookStore.Common.Utilities
{
    public interface IHttpClientUtility
    {
        Task<HttpResponseResult<List<TResult>>> Gets<TResult>(string url);
        Task<HttpResponseResult<TResult>> Get<TResult>(string url);
    }
}
