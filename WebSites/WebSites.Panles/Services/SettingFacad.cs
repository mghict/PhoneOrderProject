﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Services.InActive;
using WebSites.Panles.Services.TimeSheet;

namespace WebSites.Panles.Services
{
    public interface ISettingFacad
    {
        TimeSheet.IGetTimeSheetService GetTimeSheetService { get; }
        TimeSheet.ITimeSheetService TimeSheetService { get; }
        InActive.IInActive InActiveService { get; }
    }
    public class SettingFacad :Base.ServiceBase, ISettingFacad
    {
        public SettingFacad(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }


        private IGetTimeSheetService _getTimeSheetService;
        public IGetTimeSheetService GetTimeSheetService =>
            _getTimeSheetService = _getTimeSheetService ?? new TimeSheet.GetTimeSheetService(CacheService, ServiceCaller, ClientFactory, Mapper);


        private ITimeSheetService _timeSheetService;
        public ITimeSheetService TimeSheetService =>
            _timeSheetService= _timeSheetService?? new TimeSheet.TimeSheetService(CacheService, ServiceCaller, ClientFactory, Mapper);

        private IInActive _InActiveService;
        public IInActive InActiveService =>
            _InActiveService= _InActiveService?? new InActive.InActiveService(CacheService, ServiceCaller, ClientFactory, Mapper);
    }
}
