using System;
using System.Collections.Generic;

namespace DemoApp.Entities;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public string? SupplierInn { get; set; }

    public int? SupplierRating { get; set; }

    public DateTime? SupplierDate { get; set; }

    public int? SupplierType { get; set; }

    public virtual ICollection<MaterialSupplier> MaterialSuppliers { get; set; } = new List<MaterialSupplier>();

    public virtual SupplierType? SupplierTypeNavigation { get; set; }
}
