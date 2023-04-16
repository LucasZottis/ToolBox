using MyGears.Components;
using MyGears.Enums;
using MyGears.WinForms.Tests;

namespace MyGears.WinForms.Tests;

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
        ToolBoxEnvironment.AppName = "MyGears Tests";
        ToolBoxEnvironment.GeneralFont = new Font( new FontFamily( "Roboto" ), 12F );
        //ToolBoxEnvironment.Theme = Theme.White

        Application.Run( new FormularioBase() );
    }
}