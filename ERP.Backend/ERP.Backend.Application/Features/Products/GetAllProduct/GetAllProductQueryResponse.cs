﻿using ERP.Backend.Domain.Enums;

namespace ERP.Backend.Application.Features.Products.GetAllProduct
{
    public sealed record GetAllProductQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductTypeEnum Type { get; set; } = ProductTypeEnum.Product;
        public decimal stock { get; set; }
    }


}
