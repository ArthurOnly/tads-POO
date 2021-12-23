namespace App.Models
{
    class Student : User
    {
        private List<Classroom> _classrooms;
        private static List<Student> _students = new List<Student>();

        public List<Classroom> Classrooms
        {
            get { return _classrooms; }
            set { _classrooms = value; }
        }

        public static List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public Student(string name, string email, string password) : base(name, email, password)
        {
            _classrooms = new List<Classroom>();
            _students.Add(this);
        }

        ~Student()
        {
            _classrooms = null;
            _students.Remove(this);
        }
                
    }
}