namespace App.Models
{
    class Grade
    {
        private static int quantity = 1;
        private int _id;
        private double _score;

        private static List<Grade> _grades = new List<Grade>();

        private Student _student;

        private Activity _activity;

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

        public Activity Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }

        public List<Grade> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }



        public Grade(double score, Student student, Activity activity)
        {
            this.Score = score;
            this.Student = student;
            this.Activity = activity;
            this.Id = quantity;
            quantity++;
        }

        ~Grade()
        {
            this.Student = null;
            this.Activity = null;
        }
    }
}