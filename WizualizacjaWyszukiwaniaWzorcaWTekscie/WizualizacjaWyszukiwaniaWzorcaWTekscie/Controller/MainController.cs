using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineeringProject.View;

namespace EngineeringProject.Controller
{
    abstract class MainController
    {
        //Object of MainWindow class.
        protected MainWindow view;

        //Time of delay between next algorithm steps.
        protected int delayTime = 100;

        /// <summary>
        /// Method which implements searching algorithm which works without any delaying.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        public abstract List<int> SearchPattern(string pattern, string range);

        /// <summary>
        /// Method which implements searching algorithm which works with delay between next steps. Allows higlighitng of next steps.
        /// </summary>
        /// <param name="pattern">It's a search pattern given by user.</param>
        /// <param name="range">It's a text in which the pattern will be searched.</param>
        /// <returns>Return list of indexes of positions matched sequences or null if the range is empty.</returns>
        public abstract List<int> SearchPattern(string pattern, string range, int time);

        /// <summary>
        /// Causes a delay between highlighting each algorithm steps.
        /// </summary>
        /// <param name="time">It's the delay time in miliseconds.</param>
        protected virtual void Delay(int time)
        {
            System.Diagnostics.Stopwatch stp = new System.Diagnostics.Stopwatch();
            stp.Start();
            while (stp.ElapsedMilliseconds <= time)
            {
                System.Windows.Forms.Application.DoEvents();

                //TODO: maxint exception
                this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);

            }
            stp.Stop();
        }
    }
}
