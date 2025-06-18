using System.Collections.ObjectModel; 
using System.Linq; 
using CommunityToolkit.Mvvm.ComponentModel; 
using CommunityToolkit.Mvvm.Input; 
using DemoApp.Entities; 
using DemoApp.Views; 
using Microsoft.EntityFrameworkCore; 
 
namespace DemoApp.ViewModels 
{ 
public partial class MaterialViewModel : ObservableObject 
{ 
[ObservableProperty] 
private ObservableCollection<Models.Material> _materials = new(); 
[ObservableProperty] 
private Models.Material? _selectedMaterial; 
private readonly DbiDemoFdbContext _context; 
internal readonly MainWindowViewModel _mainViewModel; 
public MaterialViewModel(DbiDemoFdbContext context, MainWindowViewModel mainViewModel) 
{ 
_context = context; 
_mainViewModel = mainViewModel; 
LoadMaterials(); 
} 
public void LoadMaterials() 
{ 
var entities = _context.Materials.Include(p => p.MaterialTypeNavigation).ToList(); 
Materials = new ObservableCollection<Models.Material>( 
entities.Select(e => new Models.Material(e)) 
); 
} 
[RelayCommand] 
private void EditMaterial() 
{ 
if (SelectedMaterial == null) return; 
var MaterialEntity = _context.Materials.Find(SelectedMaterial._material.MaterialId); 
if (MaterialEntity == null) return; 
var viewModel = new EditMaterialViewModel(_context, MaterialEntity, this); 
var editControl = new EditMaterialView { DataContext = viewModel }; 
_mainViewModel.ShowEditMaterial(editControl); 
} 
[RelayCommand] 
private void AddMaterial() 
{ 
var viewModel = new EditMaterialViewModel(_context, parentViewModel: this); 
var editControl = new EditMaterialView { DataContext = viewModel }; 
_mainViewModel.ShowEditMaterial(editControl); 
} 
[RelayCommand] 
private void ViewSalesHistory(Material? Material) 
{ 
//история продаж 
} 
} 
} 
