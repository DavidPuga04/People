using Microsoft.Extensions.Logging;

namespace People;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Ruta a la base de datos
        string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");

        // Registrar PersonRepository como singleton
        builder.Services.AddSingleton<PersonRepository>(s => new PersonRepository(dbPath));

        // Registrar App pasando el repositorio
        builder.Services.AddSingleton<App>(s =>
        {
            var repo = s.GetRequiredService<PersonRepository>();
            return new App(repo);
        });

        builder
            .UseMauiApp<App>() // Esto ahora sí sabe usar App(repo)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
