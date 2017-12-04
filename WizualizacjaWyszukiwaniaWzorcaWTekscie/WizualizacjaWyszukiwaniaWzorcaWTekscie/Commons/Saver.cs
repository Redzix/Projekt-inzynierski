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
using EngineeringProject.Model;

namespace EngineeringProject.Commons
{
    class Saver
    {
        //Event logger
        private Logger logger = LogManager.GetCurrentClassLogger();

        //Information about first saved file
        private static bool firstSave = true;

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
            if (!Directory.Exists("Results"))
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
            File.CreateText(path).Close();

        }

        /// <summary>
        /// Save searched results in text file.
        /// </summary>
        /// <param name="result">Currently saved row.</param>
        /// <returns></returns>
        public bool DefaultSaveResults(string result)
        {
            int fileLength = 0;

            try
            {             

                if (File.Exists("Results\\results.txt"))
                {
                    fileLength = File.ReadLines("Results\\results.txt").Count();

                    using (StreamWriter write = new StreamWriter("Results\\results.txt", true))
                    {
                        if (fileLength == 0)
                        {
                            write.WriteLine("Method,Range length,Pattern length,Sequences number,Search time");
                            write.WriteLine(result);
                        }
                        else
                        {
                            write.WriteLine(result);
                        }
                    }
                    logger.Info("File saved");
                    return true;
                }
                else
                {
                    logger.Info("File \"results.txt\" doesn't exist");
                    CreateFile("Results\\results.txt");

                    using (StreamWriter write = new StreamWriter("Results\\results.txt", true))
                    {
                        if (fileLength == 0)
                        {
                            write.WriteLine("Method,Range length,Pattern length,Sequences number,Search time");
                            write.WriteLine(result);
                        }
                        else
                        {
                            write.WriteLine(result);
                        }
                    }
                    logger.Info("File saved");
                    return true;
                }
            }
            catch (Exception exc)
            {
                logger.Error(exc.ToString());
                return false;
            }
        }

        /// <summary>
        /// Save searched results in text file.
        /// </summary>
        /// <param name="result">Currently saved row.</param>
        /// <param name="header">Column header of the file.</param>
        /// <param name="path">New file path.</param>
        /// <returns></returns>
        public bool CustomSaveResults(string result, string header, string path)
        {
            int fileLength = 0;

            try
            {
                if (firstSave)
                {
                    File.WriteAllText(path, String.Empty);
                }

                if (File.Exists(path))
                {
                    fileLength = File.ReadLines(path).Count();

                    using (StreamWriter write = new StreamWriter(path, true))
                    {
                        if (fileLength == 0)
                        {
                            write.WriteLine(header);
                            write.WriteLine(result);
                        }
                        else
                        {
                            write.WriteLine(result);
                        }
                    }
                    logger.Info("File " + path + " saved");
                    return true;
                }
                else
                {
                    logger.Info("File " +  path + " doesn't exist");
                    CreateFile(path);

                    using (StreamWriter write = new StreamWriter(path, true))
                    {
                        if (fileLength == 0)
                        {
                            write.WriteLine(header);
                            write.WriteLine(result);
                        }
                        else
                        {
                            write.WriteLine(result);
                        }
                    }
                    logger.Info("File " + path + " saved");
                    return true;
                }
            }
            catch (Exception exc)
            {
                logger.Error(exc.ToString());
                return false;
            }
        }

        public void SetFirstSave(bool state)
        {
            firstSave = state;
        }

    }
}
