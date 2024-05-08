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
		lblId.Text = person.Id;
		txtName.Text = person.Name;
		txtLastname.Text = person.Lastname;
    }
}