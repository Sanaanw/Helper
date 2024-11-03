using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Student
    {
        int field1 = 3;
        public Student(){}
        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine($"ID: {ID},Name: {Name}");
        }
    }
}
