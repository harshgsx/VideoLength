using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaInfoDotNet;

namespace GetMediaDurationsNet
{
    class Program
    {
        public static int GetAllFiles(string inputDirectory, string fileFormat)
        {
            int overAllDuration = 0;          
            var files = Directory.GetFiles(inputDirectory, fileFormat, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                
                MediaInfoDotNet.MediaFile medaFileMetada = new MediaFile(file);
                overAllDuration += medaFileMetada.General.Duration;

            }

            return overAllDuration;
        }
        static void Main(string[] args)
        {
            string readingLine = Console.ReadLine();
            while (readingLine != "q")
            {
                Console.WriteLine("Enter Folder Name: ");
                string directoryName = Console.ReadLine();
                Console.WriteLine("Media Extension: ");
                string extension = Console.ReadLine();
                if (extension == string.Empty)
                {
                    extension = ".mp4";
                    Console.WriteLine("Default Extension : " + extension);
                }

                var overAllDuration = GetAllFiles(directoryName, "*" + extension);


                var Days = TimeSpan.FromMilliseconds(overAllDuration).Days;
                var Hours = TimeSpan.FromMilliseconds(overAllDuration).Hours;
                var Miniuts = TimeSpan.FromMilliseconds(overAllDuration).Minutes;
                var Seconds = TimeSpan.FromMilliseconds(overAllDuration).Seconds;


                Console.WriteLine("Overall Timings: " + Days.ToString() + ":" + Hours.ToString() + ":" + Miniuts.ToString() + ":" + Seconds.ToString());
                Console.ReadLine();

            }

        }
    }
}
