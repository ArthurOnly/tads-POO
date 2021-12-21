namespace App.Models
{
    class Task 
    {
        private static int quantity = 1;
        private int _id;
        private string _name;
        private string _description;
        private string _link;

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

        public Task(string name, string description, string link)
        {
            this.Name = name;
            this.Description = description;
            this.Link = link;
            this.Id = quantity;
            quantity++;
        }

    }
}