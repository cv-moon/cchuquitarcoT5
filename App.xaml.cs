namespace cchuquitarcoT5
{
    public partial class App : Application
    {
        public static PersonaRepository personRepository {  get; set; }
        public App(PersonaRepository personaRepository)
        {
            InitializeComponent();

            MainPage = new Views.vPersona();
            personRepository = personaRepository;
        }
    }
}
