using DealershipAudiMobile.Models;

namespace DealershipAudiMobile
{
    public partial class CarDetailPage : ContentPage
    {
        public CarDetailPage(Car car)
        {
            InitializeComponent();
            BindingContext = car;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;

            if (string.IsNullOrEmpty(car.Model) || string.IsNullOrEmpty(car.Manufacturer))
            {
                await DisplayAlert("Error", "Please fill all fields.", "OK");
                return;
            }

            await App.Database.SaveCarAsync(car);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;

            var result = await DisplayAlert("Confirm", $"Are you sure you want to delete {car.Model}?", "Yes", "No");
            if (result)
            {
                await App.Database.DeleteCarAsync(car);
                await Navigation.PopAsync();
            }
        }
    }
}
