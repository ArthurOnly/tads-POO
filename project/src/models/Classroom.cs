using System.Collections;

namespace App.Models
{
    class Classroom : IComparable<Classroom>
    {
        private static int quantity = 1;
        private int _id;
        private string _subject;

        private static List<Classroom> _classrooms = new List<Classroom>();
        private Teacher _teacher;

        private List<Student> _students;

        private List<Activity> _activities;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public Teacher Teacher
        {
            get { return _teacher; }
            set { _teacher = value; }
        }

        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public List<Activity> Activities
        {
            get { return _activities; }
            set { _activities = value; }
        }

        public static List<Classroom> Classrooms
        {
            get { return _classrooms; }
            set { _classrooms = value; }
        }

        public Classroom(string subject, Teacher teacher)
        {
            _id = quantity++;
            _subject = subject;
            _students = new List<Student>();
            _activities = new List<Activity>();
            _teacher = teacher;
            quantity++;
            _classrooms.Add(this);
        }

        ~Classroom()
        {
            _students.Clear();
            _activities.Clear();
        }

        public int CompareTo(Classroom other)
        {
            return this.Subject.CompareTo(other.Subject);
        }
    }
}