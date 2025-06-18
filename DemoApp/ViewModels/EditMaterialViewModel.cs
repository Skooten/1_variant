using System; 
using System.Collections.Generic; 
using System.Collections.ObjectModel; 
using System.Linq; 
using System.Threading.Tasks; 
using CommunityToolkit.Mvvm.ComponentModel; 
using CommunityToolkit.Mvvm.Input; 
using DemoApp.Entities; 
using DemoApp.Helpers; 
using MsBox.Avalonia; 
using MsBox.Avalonia.Enums; 
namespace DemoApp.ViewModels 
{ 
public partial class EditMaterialViewModel : ViewModelBase 
{ 
private readonly DbiDemoFdbContext _context; 
private readonly MaterialViewModel? _parentViewModel; 
private readonly Material _MaterialEntity; 
[ObservableProperty] 
private string? _materialName; 
[ObservableProperty] 
private decimal? _minimalQuantity; 
[ObservableProperty] 
private decimal? _quantityInStock; 
[ObservableProperty] 
private decimal? _unitCost; 
[ObservableProperty] 
private string? _unit; 
[ObservableProperty] 
private int? _MaterialRating; 
[ObservableProperty] 
private int? _selectedMaterialType; 
[ObservableProperty] 
private ObservableCollection<MaterialType> _MaterialTypes = new(); 
[ObservableProperty] 
private string? _errorMessage; 
public EditMaterialViewModel(DbiDemoFdbContext context, Material? Material = null, 
MaterialViewModel? parentViewModel = null) 
{ 
_context = context; 
_parentViewModel = parentViewModel; 
_MaterialEntity = Material ?? new Material(); 
LoadMaterialTypes(); 
LoadMaterialData(); 
} 
private void LoadMaterialTypes() 
{ 
var types = _context.MaterialTypes.ToList(); 
MaterialTypes = new ObservableCollection<MaterialType>(types); 
} 
private void LoadMaterialData() 
{ 
MaterialName = _MaterialEntity.MaterialName; 
MinimalQuantity = _MaterialEntity.MinimalQuantity; 
QuantityInStock = _MaterialEntity.QuantityInStock; 
UnitCost = _MaterialEntity.UnitCost; 
Unit = _MaterialEntity.Unit; 
SelectedMaterialType = _MaterialEntity.MaterialType; 
} 
[RelayCommand] 
private async Task SaveAsync() 
{ 
if (!ValidateData()) { 
var box = MessageBoxManager 
.GetMessageBoxStandard("Error", ErrorMessage, 
ButtonEnum.Ok); 
var result = await box.ShowAsync(); 
return;} 
_MaterialEntity.MaterialName = MaterialName; 
_MaterialEntity.MinimalQuantity = MinimalQuantity; 
_MaterialEntity.QuantityInStock = QuantityInStock; 
_MaterialEntity.UnitCost = UnitCost; 
_MaterialEntity.Unit = Unit; 
_MaterialEntity.MaterialType = SelectedMaterialType; 
if (_MaterialEntity.MaterialId == 0) 
{ 
_context.Materials.Add(_MaterialEntity); 
} 
_context.SaveChanges(); 
_parentViewModel?.LoadMaterials(); 
Cancel(); 
} 
[RelayCommand] 
private void Cancel() 
{ 
_parentViewModel?._mainViewModel.ShowMaterialsList(); 
} 
private bool ValidateData() 
{ 
/*if (string.IsNullOrWhiteSpace(MaterialName)) 
{ 
ErrorMessage = "Название партнера обязательно для заполнения"; 
return false; 
} 
if (!ValidationHelper.IsValidInn(MinimalQuantity)) 
{ 
ErrorMessage = "ИНН должен содержать 10 или 12 цифр"; 
return false; 
} 
if (string.IsNullOrWhiteSpace(QuantityInStock)) 
{ 
ErrorMessage = "Имя директора обязательно для заполнения"; 
return false; 
} 
if (!ValidationHelper.IsValidPhoneNumber(UnitCost)) 
{ 
ErrorMessage = "Неверный формат номера телефона. Пример: +7(999)999-99-99"; 
return false; 
} 
if (!ValidationHelper.IsValidEmail(SelectedMaterialType)) 
{ 
ErrorMessage = "Неверный формат электронной почты"; 
return false; 
} 
if (SelectedMaterialType == null) 
{ 
ErrorMessage = "Выберите тип партнера"; 
return false; 
} 
ErrorMessage = null;*/ 
return true; 
} 
} 
} 