using cchuquitarcoT5.Models;

namespace cchuquitarcoT5.Views;

public partial class vPersona : ContentPage
{
    private Persona personaSeleccionada;
    public vPersona()
    {
        InitializeComponent();
        clvPersona.SelectionChanged += OnPersonaSelected;
    }

    private void OnPersonaSelected(object sender, SelectionChangedEventArgs e)
    {
        personaSeleccionada = e.CurrentSelection.FirstOrDefault() as Persona;
        Navigation.PushAsync(new vDetallePersona(personaSeleccionada.Id));
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblEstatus.Text = "";
        App.personRepository.AddNewPerson(txtName.Text, txtLastname.Text, Convert.ToInt32(txtEdad.Text));
        lblEstatus.Text = App.personRepository.StatusMessage;
        ListarPersonas();
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblEstatus.Text = "";
        ListarPersonas();
        lblEstatus.Text = App.personRepository.StatusMessage;
    }


    private void ListarPersonas()
    {
        List<Persona> personas = App.personRepository.getAllPeople();
        clvPersona.ItemsSource = personas;
    }
}