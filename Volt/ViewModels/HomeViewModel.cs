using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Volt.Models;

namespace TabScores.ViewModels;
public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<User> _users;
    [ObservableProperty] private ObservableCollection<string> _presets;

    public HomeViewModel()
    {
        Users = new ObservableCollection<User>();
        Presets = new ObservableCollection<string>();

        Users.Add(new User("Jordan", string.Empty, string.Empty));
        Users.Add(new User("Kelly", string.Empty, string.Empty));
        Users.Add(new User("Shelby", string.Empty, string.Empty));
        Users.Add(new User("Jordan", string.Empty, string.Empty));

        Presets.Add("Hotel");
        Presets.Add("Home Rental");
        Presets.Add("Lounge Section");
        Presets.Add("Ride Share");
    }

    [RelayCommand]
    public void SelectParticipant(object parameter)
    {

    }
}
