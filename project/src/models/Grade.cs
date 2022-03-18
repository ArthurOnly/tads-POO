using System.Xml.Serialization;

namespace App.Models
{
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(Activity))]
    public class Grade
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

        public static List<Grade> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }

        public Grade()
        {

        }

        public Grade(double score, Student student, Activity activity)
        {
            this.Score = score;
            this.Student = student;
            this.Activity = activity;
            this.Id = quantity;
            quantity++;

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Grade>));
            using (FileStream fs = new FileStream("store/grades.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _grades);
            }
        }

        public static void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Grade>));
            if (File.Exists("store/grades.xml"))
            {
                using (StreamReader reader = new StreamReader("store/grades.xml"))
                {
                    Grades = (List<Grade>)serializer.Deserialize(reader);
                }
            }
        }

        ~Grade()
        {
            this.Student = null;
            this.Activity = null;
            _grades.Remove(this);

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Grade>));
            using (FileStream fs = new FileStream("store/grades.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _grades);
            }
        }
    }
}