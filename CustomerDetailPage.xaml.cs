using DealershipAudiMobile.Models;

namespace DealershipAudiMobile;

public partial class CustomerDetailPage : ContentPage
{
    public CustomerDetailPage()
    {
        InitializeComponent();
    }

    public CustomerDetailPage(Customer customer)
    {
        InitializeComponent();
        BindingContext = customer;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var customer = (Customer)BindingContext;

        if (string.IsNullOrWhiteSpace(customer.Name) ||
            string.IsNullOrWhiteSpace(customer.Email) ||
            string.IsNullOrWhiteSpace(customer.Phone))
        {
            await DisplayAlert("Error", "All fields must be filled!", "OK");
            return;
        }

        await App.Database.SaveCustomerAsync(customer);
        await Navigation.PopAsync();
    }
}
