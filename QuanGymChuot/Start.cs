using System;
using System.Windows.Forms;

namespace QuanGymChuot
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error has occured and the program will close.\nPlease send report to developer to improve app.\nThanks for your help!\n\nError message:\n" + ex.Message,
                                "Quán Gym Chuột", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
