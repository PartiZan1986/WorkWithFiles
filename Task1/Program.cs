using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeletFiles();
            Console.ReadKey();
        }

        static void DeletFiles()
        {
            Console.WriteLine("Введите путь к каталогу: ");

            string pathName = Console.ReadLine();

            if (Directory.Exists(pathName))
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(pathName);

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
    }
}
