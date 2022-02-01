using System;
using System.IO;
using System.Collections.Generic;

namespace Part7
{
    class Program
    {
        static string _path = "UserData.txt";
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            Console.WriteLine("Загрузка данных...");

            if (!File.Exists(_path))
            {
                FileInfo fi1 = new FileInfo(_path);
                using (StreamWriter sw = fi1.CreateText())
                {
                    sw.WriteLine($"0#{DateTime.Now}#AA#0#0#{DateTime.Now}#0#AA");
                }
            }
            else
            {
                ReadData();
            }//Проверка на существовние файла и его создание при его отсутствии

            Console.WriteLine("Загрузка завершена");

            while (true)
            {
                bool _exit = false;
                Console.WriteLine("1 - показать всех сотрудников, 2 - добавить сотрудника, 3 - изменить данные сотрудника\n" +
                    "4 - показать всех сотрудников в диапазоне дат, 5 - сортировка по убыванию, 6 - сортирока по возрастанию, 0 - выход:");

                switch (Console.ReadLine())
                {
                    case "0":
                        Exit();
                        _exit = true;
                        break;
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        WriteData();
                        break;
                    case "3":
                        Edit();
                        break;
                    case "4":
                        ShowByDate();
                        break;
                    case "5":
                        SortDateDown();
                        break;
                    case "6":
                        SortDateUp();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Повторите ввод");

                        break;
                }

                if (_exit) break;
            }
        }

        static private void ReadData()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    employees.Add(new Employee(sr.ReadLine()));
                }

            }
        }//Чтение из файла.

        static private void WriteData()
        {
            string line = $"{employees.Count}#{DateTime.Now}#";
            Console.Write("Введите ФИО сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите возраст сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            line += Console.ReadLine();
            employees.Add(new Employee(line));

            Console.WriteLine("Выполнено, нажмите любую кнопку для подолжения");
            Console.ReadKey();
            Console.Clear();
        }//Дополнение денных.

        static private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach(Employee employee in employees)
                {
                    sw.WriteLine($"{employee.ID}#" +
                                 $"{employee.CreateTime}#" +
                                 $"{employee.FullName}#" +
                                 $"{employee.Age}#" +
                                 $"{employee.Height}#" +
                                 $"{employee.BirthDate}#" +
                                 $"{employee.Birthplace}");
                }
            }
        }//Сохранение в файл.

        static private void Edit()
        {
            Console.Write("Введите ID сотрудника для редактирования записи: ");
            int ID;
            try
            {
                int _id = int.Parse(Console.ReadLine());
                Console.Write($"Редактируемая запись: {employees[_id].ID} ");
                ID = _id;
            }
            catch(Exception e)
            {
                Console.Write($"Неверный ввод! Возврат к главному экрану");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            string line = $"{employees[ID].ID}#{DateTime.Now}#";
            Console.Write("Введите ФИО сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите возраст сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            line += Console.ReadLine();
            employees[ID] = new Employee(line);

            Console.WriteLine("Выполнено, нажмите любую кнопку для подолжения");
            Console.ReadKey();
            Console.Clear();
        }//Редактирование записи.

        static private void ShowByDate()
        {
            DateTime min, max;
            Console.Write("Введите начальную дату: ");
            min = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите конечную дату: ");
            max = DateTime.Parse(Console.ReadLine());

            foreach(Employee employee in employees)
            {
                if(employee.CreateTime >= min && employee.CreateTime <= max)
                {
                    Console.WriteLine($"{employee.ID}   " +
                                 $"{employee.CreateTime}    " +
                                 $"{employee.FullName}  " +
                                 $"{employee.Age}   " +
                                 $"{employee.Height}    " +
                                 $"{employee.BirthDate} " +
                                 $"{employee.Birthplace}");
                }
            }

            Console.WriteLine("Выполнено, нажмите любую кнопку для подолжения");
            Console.ReadKey();
            Console.Clear();
        }//Просмотр записей в определенном промежутке дат

        static private void ShowAll()
        {
            if (employees != null)
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"{employee.ID}   " +
                                     $"{employee.CreateTime}    " +
                                     $"{employee.FullName}  " +
                                     $"{employee.Age}   " +
                                     $"{employee.Height}    " +
                                     $"{employee.BirthDate} " +
                                     $"{employee.Birthplace}");
                }
            }

            Console.WriteLine("Выполнено, нажмите любую кнопку для подолжения");
            Console.ReadKey();
            Console.Clear();
        }//Просмотр всех записей.

        static private void SortDateUp()
        {
            DateTime[] counter = new DateTime[employees.Count];
            string[] list = new string[employees.Count];

            for(int i = 0; i < list.Length; i++)
            {
                counter[i] = employees[i].CreateTime;
                list[i] =
                    employees[i].ID + "~" +
                    employees[i].FullName + " " +
                    employees[i].Age + " " +
                    employees[i].Height + " " +
                    employees[i].BirthDate + " " +
                    employees[i].Birthplace + " ";
            }

            Array.Sort(counter, list);

            for(int i = 0; i < counter.Length; i++)
            {
                int found = list[i].IndexOf("~");
                Console.WriteLine(list[i].Substring(0, found) + "   " + counter[i] + "  " + list[i].Substring(found + 1));
            }

            Console.WriteLine("Выполнено, нажмите любую кнопку для подолжения");
            Console.ReadKey();
            Console.Clear();
        }//Сортировка по дате в возрастающем порядке

        static private void SortDateDown()
        {
            DateTime[] counter = new DateTime[employees.Count];
            string[] list = new string[employees.Count];

            for (int i = 0; i < list.Length; i++)
            {
                counter[i] = employees[i].CreateTime;
                list[i] =
                    employees[i].ID + "~" +
                    employees[i].FullName + " " +
                    employees[i].Age + " " +
                    employees[i].Height + " " +
                    employees[i].BirthDate + " " +
                    employees[i].Birthplace + " ";
            }

            Array.Sort(counter, list);

            for (int i = counter.Length - 1; i >= 0; i--)
            {
                int found = list[i].IndexOf("~");
                Console.WriteLine(list[i].Substring(0, found) + "   " + counter[i] + "  " + list[i].Substring(found + 1));
            }

            Console.WriteLine("Выполнено, нажмите любую кнопку для подолжения");
            Console.ReadKey();
            Console.Clear();
        }//Сортировка по дате в убывающем порядке

        static private void Exit()
        {
            Console.WriteLine("Для сохранения и выхода нажмите ENTER, для выхода без созранения введите NO и нажмите ENTER:");
            if(Console.ReadLine() == "NO")
            {
                Console.WriteLine("Выход без сохранений");
            }
            else
            {
                Console.WriteLine("Сохраняем...");
                SaveToFile();
                Console.WriteLine("Сохранено");
            }
        }//Выход с возможностью сохранения
    }
}
