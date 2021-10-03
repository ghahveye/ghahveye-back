﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestFeature
{
    public  class RequestParameters
    {
        private const int maxPageSize = 9;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 6;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
