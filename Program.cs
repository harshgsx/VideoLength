using MediaInfoDotNet;
using System;
using System.IO;

namespace GetMediaDurationsNet
{
    class Program
    {
        public static int GetAllFiles(string inputDirectory, string fileFormat)
        {
            int overAllDuration = 0;
            if (Directory.Exists(inputDirectory))
            {
                var files = Directory.GetFiles(inputDirectory, fileFormat,SearchOption.AllDirectories);
                foreach (string file in files)
                {

                    MediaInfoDotNet.MediaFile medaFileMetada = new MediaFile(file);
                    overAllDuration += medaFileMetada.General.Duration;

                }
            }
            else
            {
                Console.WriteLine("Directroy does not exist");
            }
            return overAllDuration;
        }
        public static void showHelp()
        {
            Console.WriteLine("Any Key to contineue and use q to quit");
        }
        static void Main(string[] args)
        {
            showHelp();
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

                var overAllDuration = GetAllFiles(directoryName + "\\", "*" + extension);


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
