using System.Xml.Serialization;

namespace App.Models
{
    [XmlInclude(typeof(Teacher))]
    [XmlInclude(typeof(Student))]
    public abstract class User 
    {
        protected static List<User> _users = new List<User>();
        public static int quantity = 1;
        private int _id;
        private string _name;
        private string _email;
        private string _password;

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

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User()
        {
            
        }

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Id = quantity;
            _users.Add(this);
            quantity++;

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream("store/users.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _users);
            }
        }

        public static void readFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            if (File.Exists("store/users.xml"))
            {
                using (StreamReader reader = new StreamReader("store/users.xml"))
                {
                    _users = (List<User>)serializer.Deserialize(reader);
                }
            }
        }

        ~User()
        {
            _users.Remove(this);

            //escrever dados no ficheiro XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream("store/users.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(fs, _users);
            }
            serializer = null;
        }

        public static User Login(string email, string password)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Email == email && _users[i].Password == password)
                {
                    return _users[i];
                }
            }
            return null;
        }

    }
}