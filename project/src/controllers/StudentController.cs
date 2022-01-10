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
            do{
                Console.WriteLine("---- Menu do aluno ----");
                Console.WriteLine("1 - Listar turmas");
                Console.WriteLine("2 - Acessar turma");
                Console.WriteLine("3 - Sair");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 3) break;

                switch (option)
                {
                    case 1:
                        IndexClassroom(student);
                        break;

                    case 2:
                        ShowClassroom(student);
                        break;
                    
                    case 3:
                        break;

                    default:
                        break;
                }
            } while (true);
        }

        public static void IndexClassroom(Student student)
        {
            Console.WriteLine("---- Lista de turmas ----");
            foreach (Classroom classroom in student.Classrooms)
            {
                Console.WriteLine(classroom.Id + " - " + classroom.Subject);
            }
        }

        public static void ShowClassroom(Student student)
        {
            Console.WriteLine("---- Acessar turma ----");
            Console.WriteLine("Digite o id da turma");
            int id = Convert.ToInt32(Console.ReadLine());
            Classroom classroom = student.Classrooms.Find(x => x.Id == id);
            if (classroom == null)
            {
                Console.WriteLine("Turma não encontrada");
                return;
            }
            else {
                ClassroomController.MenuStudent(student, classroom);
            }
        }

        public static void Register()
        {
            try{
                Console.WriteLine("---- Cadastro de aluno ----");
                Console.WriteLine("Digite seu nome");
                string name = Console.ReadLine();
                Console.WriteLine("Digite seu email");
                string email = Console.ReadLine();
                Console.WriteLine("Digite sua senha");
                string password = Console.ReadLine();

                Student student = new Student(name, email, password);
                Menu(student);
            } catch (Exception e){
                Console.WriteLine("Erro no registro");
            }
        }
  
    }
}