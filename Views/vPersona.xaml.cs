using cchuquitarcoT5.Models;

namespace cchuquitarcoT5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblEstatus.Text = "";
        App.personRepository.AddNewPerson(txtName.Text);
        lblEstatus.Text = App.personRepository.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblEstatus.Text = "";
        List<Persona> people = App.personRepository.getAllPeople();
        clvPersona.ItemsSource = people;
        lblEstatus.Text = App.personRepository.StatusMessage;
    }
}