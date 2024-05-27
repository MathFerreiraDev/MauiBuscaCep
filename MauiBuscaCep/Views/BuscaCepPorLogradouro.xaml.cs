using MauiBuscaCep.Models;
using MauiBuscaCep.Services;

namespace MauiBuscaCep.Views;

public partial class BuscaCepPorLogradouro : ContentPage
{
	public BuscaCepPorLogradouro()
	{
		InitializeComponent();
	}

    private async void btn_search_Clicked(object sender, EventArgs e)
    {
		try
		{
			ldr_carregando.IsRunning = true;

			List<Cep> arr_ceps = await DataService.GetCepsByLogradouro(txt_logradouro.Text);

			lst_ceps.ItemsSource = arr_ceps;
		} catch (Exception ex)
		{
            await DisplayAlert("Eita!", ex.Message, "OK");
        }
		finally
		{
			ldr_carregando.IsRunning = false;
		}
    }
}