namespace Data
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
    {
        //public UnitOfWork() : base()
        //{
        //}

        public UnitOfWork(Tools.Options options) : base(options)
        {
        }

        // **************************************************
        //private IXXXXXRepository _xXXXXRepository;

        //public IXXXXXRepository XXXXXRepository
        //{
        //	get
        //	{
        //		if (_xXXXXRepository == null)
        //		{
        //			_xXXXXRepository =
        //				new XXXXXRepository(DatabaseContext);
        //		}

        //		return _xXXXXRepository;
        //	}
        //}
        // **************************************************
        // **************************************************
        //private IXXXXXRepository _xXXXXRepository;
        //public IXXXXXRepository XXXXXRepository =>
        //   _xXXXXRepository=_xXXXXRepository ?? new XXXXXRepository(DatabaseContext);
        // **************************************************

        // **************************************************


        private IUserInfoRepository _userRepository;
        public IUserInfoRepository UserInfoRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository =
                        new UserInfoRepository(DatabaseContext);
                }

                return _userRepository;
            }
        }

        // **************************************************
        // **************************************************
        private IProvinceRepository _provinceRepository;
        public IProvinceRepository ProvinceRepository =>
            _provinceRepository = _provinceRepository ?? new ProvinceRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private IAreaInfoRepository _areaInfoRepository;
        public IAreaInfoRepository AreaInfoRepository =>
            _areaInfoRepository = _areaInfoRepository ?? new AreaInfoRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private IAreaGeoRepository _areaGeoRepository;
        public IAreaGeoRepository AreaGeoRepository =>
            _areaGeoRepository = _areaGeoRepository ?? new AreaGeoRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private ICustomerInfoRepository _customerInfoRepository;
        public ICustomerInfoRepository CustomerInfoRepository =>
            _customerInfoRepository = _customerInfoRepository ?? new CustomerInfoRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private ICustomerAddressRepository _customerAddressRepository;
        public ICustomerAddressRepository CustomerAddressRepository =>
           _customerAddressRepository = _customerAddressRepository ?? new CustomerAddressRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private ICustomerAttributeItemRepository _customerAttributeItemRepository;
        public ICustomerAttributeItemRepository CustomerAttributeItemRepository =>
           _customerAttributeItemRepository = _customerAttributeItemRepository ?? new CustomerAttributeItemRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private ICustomerAttributeRepository _customerAttributeRepository;
        public ICustomerAttributeRepository CustomerAttributeRepository =>
           _customerAttributeRepository = _customerAttributeRepository ?? new CustomerAttributeRepository(DatabaseContext);

        // **************************************************
        // **************************************************
        private ICustomerPhoneRepository _customerPhoneRepository;
        public ICustomerPhoneRepository CustomerPhoneRepository =>
           _customerPhoneRepository = _customerPhoneRepository ?? new CustomerPhoneRepository(DatabaseContext);
    }
}
