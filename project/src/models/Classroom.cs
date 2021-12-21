namespace App.Models
{
    class Classroom
    {
        private static int quantity = 1;
        private int _id;
        private string _subject;

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

        public Classroom(string subject)
        {
            this.Subject = subject;
            this.Id = quantity;
            quantity++;
        }
    }
}