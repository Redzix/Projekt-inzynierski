//Saver.cs
//
//Responsible for saving searching results.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using EngineeringProject.Enum;
using NLog;

namespace EngineeringProject.Commons
{
    class Saver
    {
        //Event logger
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Main constructor.
        /// </summary>
        public Saver()
        {
            CheckDirectory();
        }

        /// <summary>
        /// Checks if directory exist.
        /// </summary>
        private void CheckDirectory()
        {
            if (!Directory.Exists(Path.GetDirectoryName("Results")))
                CreateDirectory("Results");
            else
                logger.Info("Directory \"Results\" already exist");
        }

        /// <summary>
        /// Creates new directory.
        /// </summary>
        /// <param name="path">New directory path.</param>
        private void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
            logger.Info("Directory \"Results\" created");
        }

        /// <summary>
        /// Create new file.
        /// </summary>
        /// <param name="path">New file path.</param>
        private void CreateFile(string path)
        {
            File.CreateText(path);
           
        }

        /// <summary>
        /// Save seached results in text file.
        /// </summary>
        /// <param name="rangeLength">Length of current range.</param>
        /// <param name="patternLegth">Length of currentpattern.</param>
        /// <param name="count">Count of found sequences.</param>
        /// <param name="time">Searching time.</param>
        /// <param name="method">Current searching method.</param>
        /// <returns></returns>
        public bool SaveResults(int rangeLength, int patternLegth, int count, long time, ESearchMethods method)
        {
            try
            {
                if (File.Exists("Results\\results.txt"))
                {
                    using (StreamWriter write = new StreamWriter("Results\\results.txt", true))
                    {
                        write.WriteLine(method.ToString() + "," + rangeLength + "," + patternLegth + "," + count + "," + time);
                    }
                    logger.Info("File saved");
                    return true;
                }
                else
                {
                    logger.Info("File \"results.txt\" doesn't exist");
                    CreateFile("Results\\results.txt");
                    return false;
                }
            }catch(Exception exc)
            {
                logger.Error(exc.ToString());
                return false;
            }
        }
    }
}
