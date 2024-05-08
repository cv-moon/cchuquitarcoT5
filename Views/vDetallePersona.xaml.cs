using System.Diagnostics;

namespace cchuquitarcoT5.Views;

public partial class vDetallePersona : ContentPage
{
    public vDetallePersona(int Id)
    {
        InitializeComponent();
        GetDetailPerson(Id);
    }

    public void GetDetailPerson(int id)
    {
        var person = App.personRepository.GetPerson(id);
        lblCodigo.Text = Convert.ToString(person.Id);
        txtNombre.Text = person.Nombre;
        txtApellido.Text = person.Apellido;
        txtEdad.Text = Convert.ToString(person.Edad);
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (lblCodigo.Text != null)
        {
            bool op = await DisplayAlert(title: "Eliminar", message: "Está seguro de eliminar el registro?", accept: "Si", cancel: "No");
            if (op)
            {
                int id = Convert.ToInt32(lblCodigo.Text);
                App.personRepository.DeletePerson(id);
                Navigation.PushAsync(new vPersona());
            }
        }
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        bool op = await DisplayAlert(title: "Actualizar", message: "Está seguro de actualizar el registro?", accept: "Si", cancel: "No");
        if (op)
        {
            int id = Convert.ToInt32(lblCodigo.Text);
            App.personRepository.EditPerson(id, txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text));
            Navigation.PushAsync(new vPersona());
        }
    }
}