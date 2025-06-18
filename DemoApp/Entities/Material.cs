using System;
using System.Collections.Generic;

namespace DemoApp.Entities;

public partial class Material
{
    public int MaterialId { get; set; }

    public string? MaterialName { get; set; }

    public decimal? UnitCost { get; set; }

    public decimal? QuantityInStock { get; set; }

    public decimal? MinimalQuantity { get; set; }

    public decimal? QuantityPerPackage { get; set; }

    public string? Unit { get; set; }

    public int? MaterialType { get; set; }

    public virtual ICollection<MaterialSupplier> MaterialSuppliers { get; set; } = new List<MaterialSupplier>();

    public virtual MaterialType? MaterialTypeNavigation { get; set; }
}
