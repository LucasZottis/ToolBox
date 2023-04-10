namespace ToolBox.WinForms.Tests;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        ToolBoxEnvironment.AppName = "ToolBox Tests";
        ToolBoxEnvironment.GeneralFont = new Font( new FontFamily( "Roboto" ), 12F );

        Application.Run( new FormularioBase() );
    }
}