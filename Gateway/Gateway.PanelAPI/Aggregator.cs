using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;

namespace Gateway.PanelAPI
{
    public class Aggregator:Ocelot.Multiplexer.IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            throw new NotImplementedException();
        }
    }
}
