using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу : ");
            string pathName = Console.ReadLine();
            ReadFile(pathName);
            Console.ReadKey();
        }

        static void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                var studentsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Students");
                if (!Directory.Exists(studentsFolder))
                    Directory.CreateDirectory(studentsFolder);

                Student[] students = null;

                using (var stream = File.Open(path, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();

                    students = (Student[])formatter.Deserialize(stream);
                }

                if (students == null)
                    return;

                foreach (var student in students)
                {
                    var groupFilePath = Path.Combine(studentsFolder, student.Group + ".txt");

                    using (var streamWriter = new StreamWriter(groupFilePath, true))
                    {
                        streamWriter.WriteLine(student.Name + ", " + student.DateOfBirth.ToString("dd.MM.yyyy"));
                    }
                }
            }
        }
    }
}
