namespace App.Models
{
    class Activity
    {
        private static List<Activity> _activities = new List<Activity>();

        private List<Grade> _grades = new List<Grade>();
        private static int quantity = 1;
        private int _id;
        private string _name;
        private string _description;
        private string _link;

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

        public Activity(string name, string description, string link, Classroom classroom)
        {
            this.Name = name;
            this.Description = description;
            this.Link = link;
            this.Id = quantity;
            this.Classroom = classroom;
            quantity++;
            _activities.Add(this);
        }

        ~Activity()
        {
            _activities.Remove(this);
        }

    }
}