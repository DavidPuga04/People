namespace People;

public partial class App : Application
{
    public static PersonRepository PersonRepo { get; private set; }

    public App(PersonRepository repo)
    {
        InitializeComponent();

        PersonRepo = repo;

        // Asume que tienes una MainPage creada para mostrar
        MainPage = new MainPage();
    }
}
