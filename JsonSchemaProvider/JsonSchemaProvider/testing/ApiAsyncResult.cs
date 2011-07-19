using System;
using System.Collections.Generic;
namespace CityIndex.JsonClient
{
    
}

namespace CIAPI.Rpc
{
    public class ApiAsyncResult<TDTO>
    {

    }
    public class ApiAsyncCallback<TDTO>
    {

    }
    public partial class Client
    {
        public TDTO Request<TDTO>(string target, string uriTemplate, string method, Dictionary<string, object> parameters, TimeSpan cacheDuration, string throttleScope)
        {
            return default(TDTO);
        }

        public TDTO Request<TDTO>(string target, string method)
        {
            return default(TDTO);
        }

        public TDTO Request<TDTO>(string target, string uriTemplate, string method, Dictionary<string, object> parameters)
        {
            return default(TDTO);
        }

        public void BeginRequest<TDTO>(ApiAsyncCallback<TDTO> cb, object state, string target, string uriTemplate,
                               string method, Dictionary<string, object> parameters, TimeSpan cacheDuration,
                               string throttleScope)
        {

        }

        public void BeginRequest<TDTO>(ApiAsyncCallback<TDTO> cb, object state, string target, string method)
        {
            BeginRequest(cb, state, target, null, method, null, TimeSpan.FromMilliseconds(0), "default");
        }

        public void BeginRequest<TDTO>(ApiAsyncCallback<TDTO> cb, object state, string target, string uriTemplate, string method, Dictionary<string, object> parameters)
        {
            BeginRequest(cb, state, target, uriTemplate, method, parameters, TimeSpan.FromMilliseconds(0), "default");
        }
        public virtual TDTO EndRequest<TDTO>(ApiAsyncResult<TDTO> asyncResult)
        // ReSharper restore MemberCanBeMadeStatic.Local
        {

            return default(TDTO);
        }

    }
}