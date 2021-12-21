namespace App.Models
{
    abstract class User 
    {
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

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Id = quantity;
            quantity++;
        }

    }
}