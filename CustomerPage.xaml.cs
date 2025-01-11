using DealershipAudiMobile.Models;

namespace DealershipAudiMobile;

public partial class CustomerPage : ContentPage
{
    public CustomerPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadCustomersAsync();
    }

    private async Task LoadCustomersAsync()
    {
        customerListView.ItemsSource = await App.Database.GetCustomersAsync();
    }

    private async void OnAddCustomerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerDetailPage(new Customer()));
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        var customer = (Customer)((Button)sender).CommandParameter;
        await Navigation.PushAsync(new CustomerDetailPage(customer));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var customer = (Customer)((Button)sender).CommandParameter;

        var confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {customer.Name}?", "Yes", "No");
        if (confirm)
        {
            await App.Database.DeleteCustomerAsync(customer);
            await LoadCustomersAsync();
        }
    }
}
