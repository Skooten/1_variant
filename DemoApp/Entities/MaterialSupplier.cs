using System;
using System.Collections.Generic;

namespace DemoApp.Entities;

public partial class MaterialSupplier
{
    public int MaterialSupplierId { get; set; }

    public int? MaterialName { get; set; }

    public int? SupplierName { get; set; }

    public virtual Material? MaterialNameNavigation { get; set; }

    public virtual Supplier? SupplierNameNavigation { get; set; }
}
