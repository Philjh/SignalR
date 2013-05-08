// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Owin;
using Microsoft.Owin;

namespace Microsoft.AspNet.SignalR.Hosting
{
    public class HostContext
    {
        // Exposed to user code
        public IRequest Request { get; private set; }

        // Owin environment dictionary
        public IDictionary<string, object> Environment { get; private set; }

        // Used by SignalR internally
        internal OwinResponse OwinResponse { get; private set; }
        internal OwinRequest OwinRequest { get; private set; }

        public HostContext(IDictionary<string, object> environment)
        {
            OwinRequest = new OwinRequest(environment);
            OwinResponse = new OwinResponse(environment);

            Request = new ServerRequest(OwinRequest);
            Environment = environment;
        }

        internal void DisableResponseBuffering()
        {
            var action = Environment.Get<Action>(OwinConstants.DisableResponseBuffering);

            if (action != null)
            {
                action();
            }
        }

        internal void DisableRequestCompression()
        {
            var action = Environment.Get<Action>(OwinConstants.DisableRequestCompression);

            if (action != null)
            {
                action();
            }
        }
    }
}
