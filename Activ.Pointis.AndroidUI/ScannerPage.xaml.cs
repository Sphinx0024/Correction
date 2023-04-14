using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using ZXing.Net.Maui.Controls;
using Activ.Pointis.AndroidUI.Model;

namespace Activ.Pointis.AndroidUI;

public partial class ScannerPage : ContentPage
{
	public ScannerPage()
	{
		InitializeComponent();
	}

    public async Task Post(PointageModel pointageModel)
    {
        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
        
        //  using var client = new HttpClient();
        var content = new StringContent(JsonConvert.SerializeObject(pointageModel), Encoding.UTF8, "application/json");
        
        //var content = new StringContent(JsonSerializer.Serialize(employesModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Pointage/Post", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);
        }
    }

    public async void ValiderClick(object sender, EventArgs e)
    {
        DateTime maintenant = DateTime.Now;
        string heurestr = maintenant.ToString("hh:mm:ss");
        TimeSpan heure;
        heure = TimeSpan.ParseExact(heurestr, "hh\\:mm\\:ss", null);

        PointageModel pointage = new PointageModel
        {
            Jour = maintenant,
            HeureEntree = heure,
            EmployesID = 1
        };

        await Post(pointage);

    }


    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		Dispatcher.Dispatch(() =>
		{
			barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
		});
	}
}