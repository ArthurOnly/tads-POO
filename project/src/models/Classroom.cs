using System.Xml.Serialization;

namespace App.Models
{
    [XmlInclude(typeof(Teacher))]
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(Activity))]
    public class Classroom : IComparable<Classroom>
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
        [XmlArray]
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
        [XmlArray]
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

        public Classroom()
        {
            _students = new List<Student>();
            _activities = new List<Activity>();
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

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Classroom>));
            using (FileStream fs = new FileStream("store/classrooms.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _classrooms);
            }
        }

        ~Classroom()
        {
            _students.Clear();
            _activities.Clear();
            _classrooms.Remove(this);
        }

        public static void saveToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Classroom>));
            using (FileStream fs = new FileStream("store/classrooms.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _classrooms);
            }
        }

        public static void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Classroom>));
            if (File.Exists("store/classrooms.xml"))
            {
                using (StreamReader reader = new StreamReader("store/classrooms.xml"))
                {
                    Classrooms = (List<Classroom>)serializer.Deserialize(reader);
                }
            }
        }

        public int CompareTo(Classroom other)
        {
            return this.Subject.CompareTo(other.Subject);
        }
    }
}