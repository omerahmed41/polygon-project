using System;
using System.IO;
namespace gtkline
{
    public class phraseFile
    {
        public phraseFile()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Sample.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WåriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + "Cant open the file");
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string Messege()
        {
            return "text file";
        }
    }
}
