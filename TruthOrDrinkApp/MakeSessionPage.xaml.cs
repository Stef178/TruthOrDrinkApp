using QRCoder;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp
{
    public partial class MakeSessionPage : ContentPage
    {
        private readonly dynamic _selectedData;
        private readonly Constants _database;

        public MakeSessionPage(dynamic selectedData, Constants database)
        {
            InitializeComponent();
            _selectedData = selectedData;
            _database = database;


            // Toon de geselecteerde gegevens in de labels
            DaringLevelLabel.Text = $"Gewaagdheidsniveau: {_selectedData.DaringLevel}";
            CategoriesLabel.Text = "Geselecteerde categorieën: " + string.Join(", ", _selectedData.SelectedCategories);
            QuestionTypeLabel.Text = "Geselecteerde vraagtypes: ";
            switch (_selectedData.QuestionTypes)
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

            // Genereer de QR-code
            string sessioncode = Task.Run(async () => await CreateNewSession(_selectedData)).Result;
            GenerateQRCode(sessioncode);
        }

        private async Task<string> CreateNewSession(dynamic selectedData)
        {
            string sessionCode = Guid.NewGuid().ToString();

            var session = new Session
            {
                SessionCode = sessionCode,
                DaringLevel = selectedData.DaringLevel,
                Categories = selectedData.SelectedCategories,
                QuestionTypes = selectedData.QuestionTypes,

            };
            await _database.AddAsync(session);

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
            // Ga naar de volgende pagina
            await Navigation.PushAsync(new FillQuestionPool());
        }
    }
}
