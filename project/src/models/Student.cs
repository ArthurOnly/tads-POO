using System.Xml.Serialization;

namespace App.Models
{
    [XmlInclude(typeof(Classroom))]
    public class Student : User, IComparable<Student>
    {
        private List<Classroom> _classrooms;
        private static List<Student> _students = new List<Student>();

        [XmlArray]
        public List<Classroom> Classrooms
        {
            get { return _classrooms; }
            set { _classrooms = value; }
        }
        [XmlArray]
        public static List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public Student() : base()
        {
            _classrooms = new List<Classroom>();
        }

        public Student(string name, string email, string password) : base(name, email, password)
        {
            //logica construtor
            _classrooms = new List<Classroom>();
            _students.Add(this);

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream("store/students.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _students);
            }
        }

        public static void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            if (File.Exists("store/students.xml"))
            {
                using (StreamReader reader = new StreamReader("store/students.xml"))
                {
                    Students = (List<Student>)serializer.Deserialize(reader);
                }
            }
        }

        ~Student()
        {
            _classrooms = null;
            _students.Remove(this);

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream("store/students.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _students);
            }
        }
                
    }
}