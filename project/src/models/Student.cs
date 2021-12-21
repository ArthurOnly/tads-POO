namespace App.Models
{
    class Student : User
    {
        public Student(string name, string email, string password) : base(name, email, password)
        {}
                
    }
}