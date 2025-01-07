using QRCoder;

namespace TruthOrDrinkApp
{
    public partial class MakeSessionPage : ContentPage
    {
        private readonly dynamic _selectedData;

        public MakeSessionPage(dynamic selectedData)
        {
            InitializeComponent();
            _selectedData = selectedData;


            // Toon de geselecteerde gegevens in de labels
            DaringLevelLabel.Text = $"Gewaagdheidsniveau: {_selectedData.DaringLevel}";
            CategoriesLabel.Text = "Geselecteerde categorieën: " + string.Join(", ", _selectedData.SelectedCategories);
            QuestionTypeLabel.Text = $"Gepersonaliseerd: {_selectedData.Personalized}, Voorgestelde: {_selectedData.Suggested}";

            // Genereer de QR-code
            GenerateQRCode();
        }

        private void GenerateQRCode()
        {


            try
            {
                string sessionCode = "12345";
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
