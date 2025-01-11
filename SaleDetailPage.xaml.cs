using DealershipAudiMobile.Models;

namespace DealershipAudiMobile;

public partial class SaleDetailPage : ContentPage
{
    public SaleDetailPage()
    {
        InitializeComponent();
    }

    public SaleDetailPage(Sale sale)
    {
        InitializeComponent();
        BindingContext = sale;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var customers = await App.Database.GetCustomersAsync();
        CustomerPicker.ItemsSource = customers;
        CustomerPicker.ItemDisplayBinding = new Binding("Name");

        var cars = await App.Database.GetCarsAsync();
        CarPicker.ItemsSource = cars;
        CarPicker.ItemDisplayBinding = new Binding("Model");
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var sale = (Sale)BindingContext;

        if (CustomerPicker.SelectedItem == null || CarPicker.SelectedItem == null || sale.TotalPrice <= 0)
        {
            await DisplayAlert("Error", "Please fill all fields correctly!", "OK");
            return;
        }

        sale.CustomerID = ((Customer)CustomerPicker.SelectedItem).ID;
        sale.CarID = ((Car)CarPicker.SelectedItem).ID;

        await App.Database.SaveSaleAsync(sale);
        await Navigation.PopAsync();
    }
}
