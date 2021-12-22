using App.Models;
using App.Controllers;

namespace App.Controllers
{
    static class TeacherController
    {
        public static void Login()
        {
            Console.WriteLine("---- Digite seu email ----");
            string email = Console.ReadLine();
            Console.WriteLine("---- Digite sua senha ----");
            string password = Console.ReadLine();

            try{
                User user = User.Login(email, password);
                Teacher teacher = (Teacher)user;
                Menu(teacher);
            } catch (Exception e){
                Console.WriteLine("Credenciais incorretas");
            }
        }

        public static void Menu(Teacher teacher)
        {
            do{
                Console.WriteLine("---- Menu do professor ----");
                Console.WriteLine("1 - Criar turma");
                Console.WriteLine("2 - Listar turmas");
                Console.WriteLine("3 - Acessar turma");
                Console.WriteLine("4 - Deletar turma");
                Console.WriteLine("5 - Sair");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 5) break;

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite a matéria da turma");
                        string subject = Console.ReadLine();
                        Classroom classroom = new Classroom(subject, teacher);
                        teacher.Classrooms.Add(classroom);
                        break;

                    case 2:
                        Console.WriteLine("---- Turmas ----");
                        foreach (Classroom tclassroom in teacher.Classrooms)
                        {
                            Console.WriteLine(tclassroom.Id + " - " + tclassroom.Subject);
                        }
                        break;
                    
                    case 3:
                        Console.WriteLine("Digite o id da turma");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Classroom classroom2 = teacher.Classrooms.Find(x => x.Id == id);
                        if (classroom2 != null) {
                            Console.WriteLine("Turma encontrada");
                            ClassroomController.MenuTeacher(classroom2);
                        }
                        else Console.WriteLine("Turma não encontrada");
                        break;

                    case 4:
                        Console.WriteLine("Digite o id da turma");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        Classroom classroom3 = teacher.Classrooms.Find(x => x.Id == id2);
                        if (classroom3 != null) {
                            Console.WriteLine("Turma encontrada");
                            teacher.Classrooms.Remove(classroom3);
                        }
                        else Console.WriteLine("Turma não encontrada");
                        break;

                    case 5:
                        break;

                    default:
                        break;
                }
            } while (true);
        }
    }
}