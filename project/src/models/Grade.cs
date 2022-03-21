using App.Helpers;
using System;
using System.Collections.Generic;

namespace App.Models
{
    class Grade
    {
        private static int quantity = 1;
        private int _id;
        private double _score;

        private static List<Grade> _grades = new List<Grade>();

        private Student _student;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Student Student
        {
            get { return _student; }
            set { _student = value; }
        }

        public static List<Grade> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }

        public Grade(){}

        public Grade(double score, Student student)
        {
            this.Score = score;
            this.Student = student;
            this.Id = quantity;
            _grades.Add(this);
            quantity++;
            save();
        }

        ~Grade()
        {
            this.Student = null;
        }

        public void save(){
            JsonHelper.SaveInJson("grades", _grades);
        }
    }
}