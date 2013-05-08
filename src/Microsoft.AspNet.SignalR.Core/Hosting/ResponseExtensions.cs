// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Microsoft.AspNet.SignalR.Hosting
{
    internal static class ResponseExtensions
    {
        internal static Task Write(this OwinResponse response, string data)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            var bytes = Encoding.UTF8.GetBytes(data);
            response.Body.Write(bytes, 0, bytes.Length);

            return TaskAsyncHelper.Empty;
        }

        internal static void SetContentType(this OwinResponse response, string contentType)
        {
            response.SetHeader("Content-Type", contentType);
        }
    }
}
