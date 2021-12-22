using App.Models;

namespace App.Controllers
{
    static class StudentController{
        public static void Login()
        {
            Console.WriteLine("---- Digite seu email ----");
            string email = Console.ReadLine();
            Console.WriteLine("---- Digite sua senha ----");
            string password = Console.ReadLine();

            try{
                User user = User.Login(email, password);
                Student student = (Student)user;
                Menu(student);
            } catch (Exception e){
                Console.WriteLine("Credenciais incorretas");
            }
        }

        public static void Menu(Student student)
        {

        }
  
    }
}