using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TabScores.ViewModels;
using Tab = Volt.Models.Tab;

namespace TabScores.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Tab> _albums;
    [ObservableProperty] private ObservableCollection<HomeViewModel> _views;
    [ObservableProperty] private object _selectedTab;

    public event EventHandler<object> OnTabChanged; 

    public MainViewModel()
    {

    }

    partial void OnSelectedTabChanged(object value)
    {
        OnTabChanged?.Invoke(this, value);
    }
}