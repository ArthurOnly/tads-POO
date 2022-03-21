using App.Helpers;
using System;
using System.Collections.Generic;
namespace App.Models
{
    class Student : User, IComparable<Student>
    {
        private static List<Student> _students = new List<Student>();

        public static List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public Student(){}

        public Student(string name, string email, string password) : base(name, email, password)
        {
            _students.Add(this);
            save();
        }

        //on poperty change

        ~Student()
        {
            _students.Remove(this);
        }

        public void save()
        {
            JsonHelper.SaveInJson("students", _students);
        }
    }
}