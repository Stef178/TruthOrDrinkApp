using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp
{
    public partial class RegisterPage : ContentPage
    {
        private readonly Constants _database;

        public RegisterPage(Constants database)
        {
            InitializeComponent();
            _database = database;
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var name = NameEntry?.Text;
                var email = EmailEntry?.Text;
                var password = PasswordEntry?.Text;
                var phone = PhoneEntry?.Text;
                var address = AddressEntry?.Text;
                var ageText = AgeEntry?.Text;

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    ErrorLabel.Text = "Name, email, and password are required!";
                    ErrorLabel.IsVisible = true;
                    return;
                }

                int? age = null;
                if (!string.IsNullOrEmpty(ageText) && int.TryParse(ageText, out int parsedAge))
                {
                    age = parsedAge;
                }
                else if (!string.IsNullOrEmpty(ageText))
                {
                    ErrorLabel.Text = "Age must be a number!";
                    ErrorLabel.IsVisible = true;
                    return;
                }

                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    Phone = phone,
                    Address = address,
                    Age = age
                };

                await _database.AddAsync(user);
                await DisplayAlert("Success", "Registration successful!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = $"An error occurred: {ex.Message}";
                ErrorLabel.IsVisible = true;
            }
        }
    }
}
