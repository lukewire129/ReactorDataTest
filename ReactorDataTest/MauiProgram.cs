using ReactorData;
using ReactorData.Maui;
using ReactorData.Sqlite;
using ReactorDataTest.Components;
using ReactorDataTest.Resources.Styles;

namespace ReactorDataTest
{
    public static class MauiProgram
    {
        static readonly string _dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "todo_app.db");
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiReactorApp<HomePage>(app =>
                {
                    app.UseTheme<ApplicationTheme>();
                },
                unhandledExceptionAction: e =>
                {
                    System.Diagnostics.Debug.WriteLine(e.ExceptionObject);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //ReactorData
            builder.UseReactorData (services =>
            {
                services.AddReactorData (                    
                    connectionStringOrDatabaseName: $"Data Source={_dbPath}",
                    configure: _ => _.Model<Todo> (),
                    modelContextConfigure: options =>
                    {
                        options.ConfigureContext = context => context.Load<Todo> ();
                    });
            });

            return builder.Build();
        }
    }
}
