using Microsoft.Maui.Controls.Shapes;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using Activ.Pointis.AndroidUI.Model;
using Activ.Pointis.AndroidUI.Services.Employes;
using System.Text;
using System.Net.Http.Json;
using ZXing.QrCode.Internal;
using ZXing.QrCode;
using ZXing;

namespace Activ.Pointis.AndroidUI;

public partial class AddEmployePage : ContentPage
{

    public AddEmployePage()
	{
		InitializeComponent();
	}

    public async Task Post(EmployesModel employesModel)
    {
        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };
        HttpClient client = new HttpClient(httpClientHandler);
      //  using var client = new HttpClient();
        var content = new StringContent(JsonConvert.SerializeObject(employesModel), Encoding.UTF8, "application/json");
        //var content = new StringContent(JsonSerializer.Serialize(employesModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://face.activactions.net/api/Employes/Post", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Enregistrement reussi!");
            await Navigation.PushAsync(new UtilisateurPage());
        }
        else
        {
            Console.WriteLine("Echec de l'ajout: " + response.StatusCode);
        }
    }

    

    public async void AjouterClick(object sender, EventArgs e)
    {
        EmployesModel employes = new EmployesModel
        {
            Nom = txtnom.Text,
            Prenom = txtprenom.Text,
            Email = txtemail.Text,
            Telephone = txttelephone.Text,
            Sexe = (string)txtsexe.SelectedItem
        };
        await Post(employes);
    }
}