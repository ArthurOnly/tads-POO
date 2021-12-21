namespace App.Models
{
    class Teacher : User
    {
        public Teacher(string name, string email, string password) : base(name, email, password)
        {}
    }
}