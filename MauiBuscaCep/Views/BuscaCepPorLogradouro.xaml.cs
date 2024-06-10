using MauiBuscaCep.Models;
using MauiBuscaCep.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiBuscaCep.Views;

public partial class BuscaCepPorLogradouro : ContentPage
{

	public BuscaCepPorLogradouro()
	{
		InitializeComponent();
	}

    private async void btn_search_Clicked(object sender, EventArgs e)
    {
        ldr_carregando.IsRunning = true;
        try
		{
			

			List<Cep> arr_ceps = await DataService.GetCepsByLogradouro(txt_cep.Text.ToLower());
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