using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Services.Reports;

namespace WebSites.Panles.Services
{
    public interface IReportFacad
    {
        Reports.IReportsService ReportsService { get; }
    }
    public class ReportFacad : Base.ServiceBase, IReportFacad
    {
        public ReportFacad(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private IReportsService _ReportsService;
        public IReportsService ReportsService =>
            _ReportsService = _ReportsService ?? new Reports.ReportsService(CacheService, ServiceCaller, ClientFactory, Mapper);
    }
}
