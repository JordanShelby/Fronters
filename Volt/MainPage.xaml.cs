using System.Diagnostics;
using TabScores.ViewModels;

namespace TabScores;

public partial class MainPage
{
    private bool _isInitialized;
    private MainViewModel _viewModel;

    public MainPage()
    {
        Loaded += OnLoaded;
        InitializeComponent();
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        TabLayout.SizeChanged += TabLayoutOnSizeChanged;
        Home.SizeChanged += ContentSizeChanged;
        _isInitialized = true;
    }

    private void ContentSizeChanged(object sender, EventArgs e)
    {
        Events.TranslateTo(Home.DesiredSize.Width, 0, 1, Easing.Linear);
    }

    private async void TabLayoutOnSizeChanged(object sender, EventArgs e)
    {
        AnimateTabIndicator();
    }

    private async Task OpenDrawer()
    {
        Backdrop.IsVisible = true;
        await Task.WhenAll(
            Backdrop.FadeTo(1, 100),
            BottomDrawer.TranslateTo(0, 0, 100));
        Backdrop.InputTransparent = false;
    }

    private async Task CloseDrawer()
    {
        await Task.WhenAll(
            Backdrop.FadeTo(0, 100),
            BottomDrawer.TranslateTo(0, 320, 100));
        Backdrop.IsVisible = false;
        Backdrop.InputTransparent = true;
    }

    private async void BackdropTapped(object sender, TappedEventArgs e)
    {
        await CloseDrawer();
    }

    private void BottomDrawerPanUpdated(object sender, PanUpdatedEventArgs e)
    {
    }

    private async void MenuButtonClicked(object sender, EventArgs e)
    {
        if (Backdrop.Opacity == 0)
        {
            await OpenDrawer();
        }
        else
        {
            await CloseDrawer();
        }
    }

    private async void TabChanged(object sender, CheckedChangedEventArgs e)
    {
        if ((sender as RadioButton) is RadioButton button && _isInitialized)
        {
            SetContent();
            AnimateTabIndicator();
        }
        else if (!_isInitialized)
        {
            Initialize((RadioButton)sender);
        }
    }

    private void Initialize(RadioButton sender)
    {
        if (sender.Content.ToString() == "Open Tabs")
        {
            sender.IsChecked = true;
        }
    }

    private void SetContent()
    {
        if (TabLayout.Children.OfType<RadioButton>().First(x => x.IsChecked) is RadioButton selectedButton)
        {
            if (selectedButton.Content.ToString() == "Open Tabs")
            {
                Events.TranslateTo(Home.DesiredSize.Width, 0, 120, Easing.Linear);
                Home.TranslateTo(0, 0, 120, Easing.Linear);
            }
            else
            {
                Events.TranslateTo(0, 0, 1, Easing.Linear);
                Home.TranslateTo(-Home.DesiredSize.Width, 0, 120, Easing.Linear);
            }
        }
    }

    private async void AnimateTabIndicator()
    {
        RadioButton selectedButton = TabLayout.Children.OfType<RadioButton>().First(x => x.IsChecked);
        double selectedWidth = selectedButton.DesiredSize.Width;
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Animation animation = new(v => Indicator.WidthRequest = v, Indicator.WidthRequest, selectedWidth);
            animation.Commit(this, "TabAnimation", 16, 120, Easing.Linear);
            Indicator.TranslateTo(selectedButton.X, 0, 120, Easing.SinInOut);
        });
    }
}