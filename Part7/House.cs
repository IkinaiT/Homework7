using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part7
{
    struct Employee
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string Birthplace { get; set; }

        public Employee(string input)
        {
            string[] arr = input.Split('#');

            ID = int.Parse(arr[0]);
            CreateTime = DateTime.Parse(arr[1]);
            FullName = arr[2];
            Age = int.Parse(arr[3]);
            Height = int.Parse(arr[4]);
            BirthDate = DateTime.Parse(arr[5]);
            Birthplace = arr[6];
        }


    }
}
