using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к каталогу : ");
            string pathName = Console.ReadLine();
            long dirSize = CountFiles(pathName);

            Console.WriteLine("Directory: {0}, Size: {1} bytes", Path.GetDirectoryName(pathName), dirSize);

            DeletFiles(pathName);
            InfoDelet(pathName);

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

        static void DeletFiles(string path)
        {
            if (Directory.Exists(path))
            {
                long dirSize = 0;

                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    DirectoryInfo[] dirInfoArray = dirInfo.GetDirectories();
                    FileInfo[] fileInfoArray = dirInfo.GetFiles();
                    int count = fileInfoArray.Length;
                    Console.WriteLine("Удалено файлов: {0} ", count);

                    foreach (FileInfo fileInfo in fileInfoArray)
                    {
                        dirSize += fileInfo.Length;
                    }

                    foreach (DirectoryInfo dirInf in dirInfoArray)
                    {
                        dirSize += CountFiles(dirInfo.FullName);
                    }

                    Console.WriteLine("Освобождено: {0} bytes", dirSize);

                    if ((DateTime.Now - dirInfo.CreationTime) > TimeSpan.FromMinutes(30))
                    {
                        dirInfo.Delete(true);
                        Console.WriteLine("Каталог и файлы удалены");
                    }
                    else
                    {
                        Console.WriteLine("Каталогу меньше 30 минут");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            else
            {
                Console.WriteLine("Такого каталога не существует");
            }
        }

        static void InfoDelet(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Текущий размер папки: 0 ");
            }
        }

    }
}
