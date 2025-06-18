using System;
using System.Collections.Generic;

namespace DemoApp.Entities;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string? ProductTypeName { get; set; }

    public decimal? ProductTypeCoefficient { get; set; }
}
