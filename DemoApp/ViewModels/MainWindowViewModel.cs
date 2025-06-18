using Avalonia.Controls; 
using CommunityToolkit.Mvvm.ComponentModel; 
using DemoApp.Entities; 
using DemoApp.Views; 
namespace DemoApp.ViewModels; 
public partial class MainWindowViewModel : ViewModelBase 
{ 
private readonly DbiDemoFdbContext _context; 
[ObservableProperty] 
private Control? _content;

    public DbiDemoFdbContext Context => _context;

    public void ShowContent(Control content) 
{ 
Content = content; 
} 
public void ShowMaterialsList() 
{ 
Content = new MaterialView 
{ 
DataContext = new MaterialViewModel(Context, this) 
}; 
} 
public MainWindowViewModel() 
{ 
_context = new DbiDemoFdbContext(); 
ShowMaterialsList(); 
} 
public void ShowEditMaterial(EditMaterialView editControl) 
{ 
Content = editControl; 
} 
}