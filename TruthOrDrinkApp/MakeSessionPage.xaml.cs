using QRCoder;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;
using Microsoft.Maui.Devices;

namespace TruthOrDrinkApp
{
    public partial class MakeSessionPage : ContentPage
    {
        private readonly Constants _database;
        private readonly int _daringLevel;
        private readonly List<Category> _categories;
        private readonly QuestionTypes _questionTypes;
        private Session session;

        public MakeSessionPage(dynamic selectedData, Constants database)
        {
            InitializeComponent();
            _daringLevel = selectedData.DaringLevel;
            _questionTypes = selectedData.QuestionTypes;
            _database = database;
            _categories = selectedData.GetType().GetProperty("SelectedCategories") != null ? selectedData.SelectedCategories : new List<Category>();


            // Toon de geselecteerde gegevens
            DaringLevelLabel.Text = $"Gewaagdheidsniveau: {_daringLevel}";
            CategoriesLabel.Text = "Geselecteerde categorieën: " + string.Join(", ", _categories.Select(category => category.Label));
            QuestionTypeLabel.Text = "Geselecteerde vraagtypes: ";
            switch (_questionTypes)
            {
                case QuestionTypes.PERSONALIZED_AND_SUGGESTED:
                    QuestionTypeLabel.Text += "Gepersonaliseerd en Voorgesteld";
                    break;
                case QuestionTypes.PERSONALIZED:
                    QuestionTypeLabel.Text += "Gepersonaliseerd";
                    break;
                default:
                    QuestionTypeLabel.Text += "Voorgesteld";
                    break;
            }

            
            string sessioncode = Task.Run(async () => await CreateNewSession(_daringLevel, _categories, _questionTypes)).Result;
            GenerateQRCode(sessioncode);
        }

        private async Task<string> CreateNewSession(int daringLevel, List<Category> selectedCategories, QuestionTypes questionTypes)
        {
            string sessionCode = Guid.NewGuid().ToString();

              session = new Session
            {
                SessionCode = sessionCode,
                DaringLevel = daringLevel,
                Categories = selectedCategories,
                QuestionTypes = questionTypes,

            };
            await _database.AddAsync(session);

            List<SessionCategory> sessionCategories = new List<SessionCategory>();
            foreach (var category in session.Categories)
            {
                var sessionCategory = new SessionCategory
                {
                    CategoryId = category.Id,
                    SessionId = session.SessionID
                };
                sessionCategories.Add(sessionCategory);
            }
            await _database.AddAllAsync(sessionCategories);



            return sessionCode;
        }

       


        private void GenerateQRCode(string sessionCode)
        {

            try
            {
                // Generate QR Code
                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(sessionCode, QRCodeGenerator.ECCLevel.Q);

                PngByteQRCode QRCode = new PngByteQRCode(qrCodeData);
                byte[] QRCodeByte = QRCode.GetGraphic(20);
                ImageSource QRimageSource = ImageSource.FromStream(() => new MemoryStream(QRCodeByte));
                qrImage.Source = QRimageSource;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Failed to generate QR code: {ex.Message}", "OK");
            }
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
            await Navigation.PushAsync(new GameStartedxaml(session, _database, _questionTypes, _categories, _daringLevel));
        }
    }
}
