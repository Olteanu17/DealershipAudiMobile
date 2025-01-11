using DealershipAudiMobile.Models;

namespace DealershipAudiMobile;

public partial class CarPage : ContentPage
{
    public CarPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadCarsAsync();
    }

    private async Task LoadCarsAsync()
    {
        CarListView.ItemsSource = await App.Database.GetCarsAsync();
    }

    private async void OnAddCarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarDetailPage(new Car()));
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        var car = (Car)((Button)sender).CommandParameter;
        await Navigation.PushAsync(new CarDetailPage(car));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var car = (Car)((Button)sender).CommandParameter;

        var confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {car.Model}?", "Yes", "No");
        if (confirm)
        {
            await App.Database.DeleteCarAsync(car);
            await LoadCarsAsync(); // Refresh the list
        }
    }

    private async void OnCarSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CarDetailPage(e.SelectedItem as Car));
        }
    }
}
