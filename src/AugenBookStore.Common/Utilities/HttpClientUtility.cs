using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using AugenBookStore.Common.Dtos;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AugenBookStore.Common.Utilities
{
    public class HttpClientUtility : IHttpClientUtility
    {
        HttpClient _client = new HttpClient();
        
        public HttpClientUtility()
        {
            
        }

        public async Task<HttpResponseResult<List<TResult>>> Gets<TResult>(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                return await GetHttpResponseResults<TResult>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseResult<TResult>> Get<TResult>(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                return await GetHttpResponseResult<TResult>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<HttpResponseResult<TResult>> GetHttpResponseResult<TResult>(HttpResponseMessage response)
        {
            string returnValue = await response.Content.ReadAsStringAsync();
            return new HttpResponseResult<TResult>
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                ContentObject = JsonConvert.DeserializeObject<TResult>(returnValue)
            };
        }

        private async Task<HttpResponseResult<List<TResult>>> GetHttpResponseResults<TResult>(HttpResponseMessage response)
        {
            string returnValue = await response.Content.ReadAsStringAsync();
            return new HttpResponseResult<List<TResult>>
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                ContentObject = JsonConvert.DeserializeObject<List<TResult>>(returnValue)
            };
        }
    }
}
