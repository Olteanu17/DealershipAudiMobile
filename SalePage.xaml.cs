using DealershipAudiMobile.Models;

namespace DealershipAudiMobile;

public partial class SalePage : ContentPage
{
    public SalePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadSalesAsync();
    }

    private async Task LoadSalesAsync()
    {
        saleListView.ItemsSource = await App.Database.GetSalesAsync();
    }

    private async void OnAddSaleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SaleDetailPage(new Sale()));
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        var sale = (Sale)((Button)sender).CommandParameter;
        await Navigation.PushAsync(new SaleDetailPage(sale));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var sale = (Sale)((Button)sender).CommandParameter;

        var confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete this sale with total price {sale.TotalPrice}?", "Yes", "No");
        if (confirm)
        {
            await App.Database.DeleteSaleAsync(sale);
            await LoadSalesAsync(); // Refresh the list
        }
    }
}
