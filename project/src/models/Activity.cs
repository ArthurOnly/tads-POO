using App.Helpers;
using System;
using System.Collections.Generic;

namespace App.Models
{
    class Activity : IComparable<Activity>
    {
        private static List<Activity> _activities = new List<Activity>();
        private List<Grade> _grades = new List<Grade>();
        private static int quantity = 1;
        private int _id;
        private string _name;
        private string _description;
        private string _link;

        private DateTime _finalDate;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }


        public List<Grade> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }

        public static List<Activity> Activities
        {
            get { return _activities; }
            set { _activities = value; }
        }

        public DateTime FinalDate
        {
            get { return _finalDate; }
            set { _finalDate = value; }
        }

        public Activity(){}

        public Activity(string name, string description, string link, DateTime finalDate, List<Grade> grades)
        {
            this.Name = name;
            this.Description = description;
            this.Link = link;
            this.FinalDate = finalDate;
            this.Grades = grades;
            this.Id = quantity;
            _activities.Add(this);
            quantity++;
            save();
        }
        public Activity(string name, string description, string link, DateTime finalDate)
        {
            _id = quantity++;
            _name = name;
            _description = description;
            _link = link;
            _finalDate = finalDate;
            quantity++;
            _activities.Add(this);
            save();
        }

        ~Activity()
        {
            _activities.Remove(this);
        }

        public int CompareTo(Activity other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public void save(){
            JsonHelper.SaveInJson("activities", _activities);
        }
    }
}