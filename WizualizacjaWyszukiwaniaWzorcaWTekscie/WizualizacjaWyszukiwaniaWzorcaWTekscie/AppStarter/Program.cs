using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NLog;
namespace EngineeringProject.View
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.Info("Application Searching Pattern Visualisation succesfully started.");
            MainWindow main = null;
            //bool waitForStop = false;
           // Thread thread = new Thread(delegate ()
           // {
                
                main = new MainWindow();
               // main.closeThis += (() => { waitForStop = true; });
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(main);
            //});


            //thread.SetApartmentState(ApartmentState.STA);
           // thread.Start();
            

          /*  while (true)
            {
                if(waitForStop)
                {
                    thread.Abort();
                    
                    Thread.Sleep(10);
                    thread.Start();
                }
            }*/
 
        }
    }
}
