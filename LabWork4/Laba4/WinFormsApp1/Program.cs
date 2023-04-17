// TODO: Длинные строки
// TODO: Комментарии
// TODO:+ Избавиться от связки с Mainform
namespace WinFormsApp1
{
    internal static class Program
    {
        // TODO:+ Нужно убрать ссылку на MainForm
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}