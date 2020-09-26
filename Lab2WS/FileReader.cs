using System;
using System.IO;

namespace Lab2WS
{
    class FileReader
    {
        public string[] Read(string filename)
        {


            // Implement this using info from the slides.
            string[] readLines = File.ReadAllLines(filename);
            

            //for testing
            /*
            foreach(string line in readLines){

                Console.WriteLine(readLines);
            }
            */
            return readLines;
        }
    }
}
