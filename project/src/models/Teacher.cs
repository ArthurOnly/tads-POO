using App.Helpers;
using System;
using System.Collections.Generic;

namespace App.Models
{
    class Teacher : User, IComparable<Teacher>
    {
        private static List<Teacher> _teachers = new List<Teacher>();


        public static List<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        public Teacher(string name, string email, string password) : base(name, email, password)
        {
            _teachers.Add(this);
            save();
        }

        ~Teacher()
        {
            
        }

        public int CompareTo(Teacher other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public void save(){
            JsonHelper.SaveInJson("teachers", _teachers);
        }

    }
}