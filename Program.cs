using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace exceptions_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Instrucrion: put files to /bin/Debug/netcoreapp3.1/test then run program and watch result");
            string path_to_files = "test";
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            foreach (string fileName in Directory.GetFiles(path_to_files))
            {
                if (regexExtForImage.IsMatch(Path.GetExtension(fileName)))
                {
                    try
                    {
                        Bitmap new_bitmap = new Bitmap(fileName);
                        new_bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        new_bitmap.Save(path_to_files + "\\" + Path.GetFileNameWithoutExtension(fileName) + "-mirrored.gif", System.Drawing.Imaging.ImageFormat.Gif);
                        Console.WriteLine("The image " + Path.GetFileName(fileName) + " was mirrored");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("The file " + Path.GetFileName(fileName) + " is not an image");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
