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

        private Classroom _classroom;

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

        public Classroom Classroom
        {
            get { return _classroom; }
            set { _classroom = value; }
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

        public Activity(string name, string description, string link, Classroom classroom, DateTime finalDate)
        {
            _id = quantity++;
            _name = name;
            _description = description;
            _link = link;
            _classroom = classroom;
            _finalDate = finalDate;
            quantity++;
            _activities.Add(this);
        }

        ~Activity()
        {
            _activities.Remove(this);
        }

        public int CompareTo(Activity other)
        {
            return this.Name.CompareTo(other.Name);
        }

    }
}