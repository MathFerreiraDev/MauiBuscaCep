using MauiBuscaCep.Models;
using MauiBuscaCep.Services;
using System.Collections.ObjectModel;

namespace MauiBuscaCep.Views;

public partial class BairrosPorCidade : ContentPage
{

    ObservableCollection<Cidade> list_cidades = new ObservableCollection<Cidade>();
    ObservableCollection<Bairro> list_bairros = new ObservableCollection<Bairro>();

    public BairrosPorCidade()
	{
		InitializeComponent();

        pck_cidade.ItemsSource = list_cidades;
        lst_bairros.ItemsSource = list_bairros;
	}

    private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        pck_cidade.Opacity = 0.3;
        pck_cidade.IsEnabled = false;
        
        try
        {
            Picker disp = sender as Picker;
            

            string? estado_select = disp.SelectedItem as string;

            List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(estado_select);

            
            list_cidades.Clear();
            
            arr_cidades.ForEach(i => list_cidades.Add(i));

            
        } 
        catch (Exception ex)
        {
            await DisplayAlert("Eita!", ex.Message, "OK");
        }
        finally
        {
            pck_cidade.Opacity = 1;
            pck_cidade.IsEnabled = true;
            
        }
    }

    private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
    {
        list_bairros.Clear();
        ldr_loader.IsVisible = true;
        try
        {
            Picker disp = sender as Picker;

            Cidade cidade_select = disp.SelectedItem as Cidade;

            
            if (cidade_select != null)
            {
                List<Bairro> arr_bairros = await DataService.GetBairrosByCidade(cidade_select.id_cidade);
                //list_bairros.Clear();

                arr_bairros.ForEach(i => list_bairros.Add(i));
            }

            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eita!", ex.Message, "OK");
        }
        finally
        {
            ldr_loader.IsVisible = false;
        }
    }
}