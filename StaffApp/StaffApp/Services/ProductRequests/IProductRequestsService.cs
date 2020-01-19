﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public interface IProductRequestsService
    {
        Task<ProductRequestDTO> PushProductRequest(ProductRequestDTO productRequest);

        Task<IEnumerable<ProductRequestDTO>> GetProductRequest();
    }
}