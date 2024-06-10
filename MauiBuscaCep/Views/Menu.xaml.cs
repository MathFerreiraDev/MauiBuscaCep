namespace MauiBuscaCep.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void btn_buscacep_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync( new BuscaCepPorLogradouro() );
    }

    private void btn_buscacidades_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BairrosPorCidade());
    }

    private void btn_buscaruas_Clicked(object sender, EventArgs e)
    {
       
    }

    private void btn_buscaendereco_Clicked(object sender, EventArgs e)
    {
      
    }
}