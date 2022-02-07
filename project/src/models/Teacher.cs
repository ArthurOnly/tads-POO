namespace App.Models
{
    class Teacher : User, IComparable<Teacher>
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

        ~Teacher()
        {
            _classrooms = null;
        }

        public int CompareTo(Teacher other)
        {
            return this.Name.CompareTo(other.Name);
        }

    }
}