using System.Xml.Serialization;

namespace App.Models
{
    [XmlInclude(typeof(Classroom))]
    public class Teacher : User, IComparable<Teacher>
    {
        private static List<Teacher> _teachers = new List<Teacher>();
        private List<Classroom> _classrooms;

        [XmlArray]
        public List<Classroom> Classrooms
        {
            get { return _classrooms; }
            set { _classrooms = value; }
        }

        public static List<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        public Teacher() : base()
        {
            _classrooms = new List<Classroom>();
        }
        public Teacher(string name, string email, string password) : base(name, email, password)
        {
            _classrooms = new List<Classroom>();
            _teachers.Add(this);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
            using (FileStream fs = new FileStream("store/teachers.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, _teachers);
            }
        }

        ~Teacher()
        {
            _classrooms = null;
            _teachers.Remove(this);

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
            using (FileStream fs = new FileStream("store/teachers.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, _teachers);
            }
        }

        public static void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
            if (File.Exists("store/teachers.xml"))
            {
                using (StreamReader reader = new StreamReader("store/teachers.xml"))
                {
                    Teachers = (List<Teacher>)serializer.Deserialize(reader);
                }
            }
        }

        public int CompareTo(Teacher other)
        {
            return this.Name.CompareTo(other.Name);
        }

    }
}