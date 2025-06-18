using System;
using System.Collections.Generic;

namespace DemoApp.Entities;

public partial class SupplierType
{
    public int SupplierTypeId { get; set; }

    public string? SupplierTypeName { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
