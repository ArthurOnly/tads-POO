using System.Xml.Serialization;

namespace App.Models
{
    [XmlInclude(typeof(Classroom))]
    [XmlInclude(typeof(Grade))]
    public class Activity : IComparable<Activity>
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
        [XmlArray]
        public List<Grade> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }
        [XmlArray]
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

        public Activity()
        {

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

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Activity>));
            using (FileStream fs = new FileStream("store/activities.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _activities);
            }
        }

        ~Activity()
        {
            _activities.Remove(this);

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Activity>));
            using (FileStream fs = new FileStream("store/activities.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _activities);
            }
        }

        public int CompareTo(Activity other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public static void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Activity>));
            if (File.Exists("store/activities.xml"))
            {
                using (StreamReader reader = new StreamReader("store/activities.xml"))
                {
                    Activities = (List<Activity>)serializer.Deserialize(reader);
                }
            }
        }

    }
}