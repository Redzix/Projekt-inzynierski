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

        //Information about pressed pause button
        private bool pausePressed = false;

        //Information about enabled buttons. If algorithm works they are disabled.
        private bool buttonEnabled = true;

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
        /// Disable or enable using some controls.
        /// </summary>
        protected virtual void ChangeControlsState()
        {
            buttonEnabled = !buttonEnabled;

            this.view.openFileButton.Enabled = buttonEnabled;
            this.view.saveResultsButton.Enabled = buttonEnabled;
            this.view.nextAlgorithmButton.Enabled = buttonEnabled;
            this.view.previousAlgorithmButton.Enabled = buttonEnabled;
            this.view.autoSearchButton.Enabled = buttonEnabled;
            this.view.stepSearchButton.Enabled = buttonEnabled;
            this.view.clearButton.Enabled = buttonEnabled;
        }

        /// <summary>
        /// Causes a delay between highlighting each algorithm steps.
        /// </summary>
        /// <param name="time">It's the delay time in miliseconds.</param>
        protected virtual void Delay(int time)
        {
            System.Diagnostics.Stopwatch stp = new System.Diagnostics.Stopwatch();
            this.delayTime = time;

            stp.Start();

            while (stp.ElapsedMilliseconds <= this.delayTime)
            {
                System.Windows.Forms.Application.DoEvents();

                if(this.view.delayTimeComboBox.Text != "")
                {
                    this.delayTime = Int32.Parse(this.view.delayTimeComboBox.Text);
                }else { }

                while (pausePressed)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            stp.Stop();
        }

        /// <summary>
        /// Changes state of pausePressed when the pauseButton is pressed.
        /// </summary>
        public virtual void Pause()
        {
            this.pausePressed = !pausePressed;
        }

        
    }
}
