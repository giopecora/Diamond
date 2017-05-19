using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Diamond.Providers
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string rootPath)
            : base(rootPath)
        {

        }

        public CustomMultipartFormDataStreamProvider(string rootPath, int bufferSize) : 
            base(rootPath, bufferSize)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";

            return name.Trim('"').Replace("&", "and");
        }
    }
}