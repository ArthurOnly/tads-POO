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
                Console.WriteLine("4 - Atualizar turma");
                Console.WriteLine("5 - Deletar turma");
                Console.WriteLine("6 - Listar alunos");
                Console.WriteLine("7 - Sair");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 7) break;

                switch (option)
                {
                    case 1:
                        CreateClassroom(teacher);
                        break;

                    case 2:
                        IndexClassroom(teacher);
                        break;
                    
                    case 3:
                        ShowClassroom(teacher);
                        break;

                    case 4:
                        UpdateClassroom(teacher);
                        break;

                    case 5:
                        DeleteClassroom(teacher);
                        break;

                    case 6:
                        IndexStudent(teacher);
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (true);
        }

        private static void CreateClassroom(Teacher teacher)
        {
            Console.WriteLine("Digite a matéria da turma");
            string subject = Console.ReadLine();
            Classroom classroom = new Classroom(subject, teacher);
            teacher.Classrooms.Add(classroom);
        }

        private static void IndexClassroom(Teacher teacher)
        {
            var classrooms = Classroom.Classrooms.Where(c => c.Teacher.Id == teacher.Id);
            Console.WriteLine("---- Turmas ----");
            foreach (Classroom classroom in classrooms)
            {
                Console.WriteLine(classroom.Id + " - " + classroom.Subject);
            }
        }

        private static void ShowClassroom(Teacher teacher)
        {
            Console.WriteLine("Digite o id da turma");
            int id = Convert.ToInt32(Console.ReadLine());
            Classroom classroom = Classroom.Classrooms.Find(x => x.Id == id);
            if (classroom != null) {
                Console.WriteLine("Turma encontrada");
                ClassroomController.MenuTeacher(classroom);
            }
            else Console.WriteLine("Turma não encontrada");
        }

        private static void UpdateClassroom(Teacher teacher)
        {
            Console.WriteLine("Digite o id da turma");
            int id = Convert.ToInt32(Console.ReadLine());
            Classroom classroom = teacher.Classrooms.Find(x => x.Id == id);
            if (classroom != null) {
                Console.WriteLine("Turma encontrada");
                Console.WriteLine("Digite o novo nome da turma");
                string subject = Console.ReadLine();
                classroom.Subject = subject;
            }
            else Console.WriteLine("Turma não encontrada");
        }

        public static void DeleteClassroom(Teacher teacher)
        {
            Console.WriteLine("Digite o id da turma");
            int id = Convert.ToInt32(Console.ReadLine());
            Classroom classroom = teacher.Classrooms.Find(x => x.Id == id);
            if (classroom != null) {
                Console.WriteLine("Turma encontrada");
                teacher.Classrooms.Remove(classroom);
            }
            else Console.WriteLine("Turma não encontrada");
        }

        private static void CreateStudent(Teacher teacher)
        {
            Console.WriteLine("Digite o nome do aluno");
            string name = Console.ReadLine();
            Console.WriteLine("Digite o email do aluno");
            string email = Console.ReadLine();
            Console.WriteLine("Digite a senha do aluno");
            string password = Console.ReadLine();
            Student student = new Student(name, email, password);
        }

        private static void IndexStudent(Teacher teacher)
        {
            var students = Student.Students.Select(s => s.Id + " - " + s.Name);
            Console.WriteLine("---- Alunos ----");
            foreach (string student in students)
            {
                Console.WriteLine(student);
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

                Teacher tc = new Teacher(name, email, password);
                Console.WriteLine("---- Cadastro realizado com sucesso ----");
            } catch (Exception e){
                Console.WriteLine(e);
            }
        }
    }
}