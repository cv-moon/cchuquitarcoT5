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
        App.personRepository.AddNewPerson(txtName.Text);
        lblEstatus.Text = App.personRepository.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblEstatus.Text = "";
        ListarPersonas();
        lblEstatus.Text = App.personRepository.StatusMessage;
    }
    //private void btnEditar_Clicked(object sender, EventArgs e)
    //{
    //    if (personaSeleccionada != null) // Usar la variable para verificar si hay selección
    //    {
    //        string nuevoNombre = txtNuevoNombre.Text;
    //        if (string.IsNullOrEmpty(nuevoNombre))
    //        {
    //            DisplayAlert("Editar", "Por favor, ingrese un nuevo nombre.", "OK");
    //            return;
    //        }

    //        App.pRepo.EditPerson(personaSeleccionada.Id, nuevoNombre);

    //        DisplayAlert("Editado", $"Persona {personaSeleccionada.Name} actualizada.", "OK");

    //        RefrescarLista(); // Refrescar la lista
    //    }
    //    else
    //    {
    //        DisplayAlert("Error", "Seleccione una persona para editar.", "OK");
    //    }
    //}

    private void ListarPersonas()
    {
        List<Persona> people = App.personRepository.getAllPeople();
        clvPersona.ItemsSource = people;
    }

    //private void btnEliminar_Clicked(object sender, EventArgs e)
    //{
    //    if (personaSeleccionada != null)
    //    {
    //        App.pRepo.DeletePerson(personaSeleccionada.Id);
    //        DisplayAlert("Eliminado", $"Persona {personaSeleccionada.Name} eliminada.", "OK");

    //        RefrescarLista();
    //    }
    //    else
    //    {
    //        DisplayAlert("Error", "Seleccione una persona para eliminar.", "OK");
    //    }
    //}
}