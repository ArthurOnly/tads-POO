namespace App.Models
{
    class Teacher : User
    {
        private List<Classroom> _classrooms;

        public List<Classroom> Classrooms
        {
            get { return _classrooms; }
            set { _classrooms = value; }
        }
        public Teacher(string name, string email, string password) : base(name, email, password)
        {
            _classrooms = new List<Classroom>();
        }

    }
}