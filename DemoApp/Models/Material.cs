using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
namespace DemoApp.Models 
{ 
public class Material : Entities.Material 
{ 
public Entities.Material _material { get; set; } 
public Material(Entities.Material material) 
{ 
_material = material; 
} 
public string? MaterialTypeDescription => _material.MaterialTypeNavigation?.MaterialTypeName; 
public string Minimal => $"{_material.MinimalQuantity}"; 
public string Quantity => $"{_material.QuantityInStock}"; 
public decimal Cost => _material.UnitCost ?? 0; 
public string Un => $"{_material.Unit}"; 
public decimal BatchCost => CalculatePartnerBatchCost(); 
public string BatchCostDisplay => $"Стоимость: {BatchCost:P0}"; 
public static decimal CalculatePartnerBatchCost() 
{ 
return 0; 
} 
} 
} 