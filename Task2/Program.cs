using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к каталогу : ");
            string pathName = Console.ReadLine();
            long dirSize = CountFiles(pathName);

            Console.WriteLine("Directory: {0}, Size: {1} bytes", Path.GetDirectoryName(pathName), dirSize);

            Console.ReadKey();
        }

        static long CountFiles(string path)
        {
            long dirSize = 0;

            if (Directory.Exists(path))
            {
                try
                {
                    DirectoryInfo currentDirInfo = new DirectoryInfo(path);
                    DirectoryInfo[] dirInfoArray = currentDirInfo.GetDirectories();
                    FileInfo[] fileInfoArray = currentDirInfo.GetFiles();                    

                    foreach (FileInfo fileInfo in fileInfoArray)
                    {
                        dirSize += fileInfo.Length;
                    }

                    foreach (DirectoryInfo dirInfo in dirInfoArray)
                    {
                        dirSize += CountFiles(dirInfo.FullName);
                    }

                    return dirSize;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return dirSize;
                }
            }
            else
            {
                Console.WriteLine("Такого каталога не существует");
            }

            return dirSize;
        }
    }
}
