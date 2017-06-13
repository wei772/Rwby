using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Http
{
    public interface IResilientHttpClientFactory
    {
        ResilientHttpClient CreateResilientHttpClient();
    }
}
