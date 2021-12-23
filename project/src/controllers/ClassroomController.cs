using App.Models;
using App.Controllers;

namespace App.Controllers
{
    static class ClassroomController
    {

        public static void MenuTeacher(Classroom classroom)
        {
            do{
                Console.WriteLine("---- Menu da turma ----");
                Console.WriteLine("1 - Criar atividade");
                Console.WriteLine("2 - Listar atividades");
                Console.WriteLine("3 - Acessar atividade");
                Console.WriteLine("4 - Deletar atividade");
                Console.WriteLine("5 - Adicionar aluno");
                Console.WriteLine("6 - Remover aluno");
                Console.WriteLine("7 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 7) break;

                switch(option)
                {
                    case 1:
                        Console.WriteLine("Digite o nome da atividade");
                        string name = Console.ReadLine();
                        Console.WriteLine("Digite a descrição da atividade");
                        string description = Console.ReadLine();
                        Console.WriteLine("Digite o link da atividade");
                        string link = Console.ReadLine();
                        Activity activity = new Activity(name, description, link, classroom);
                        classroom.Activities.Add(activity);
                        break;
                    case 2:
                        Console.WriteLine("---- Atividades ----");
                        foreach (Activity activity5 in classroom.Activities)
                        {
                            Console.WriteLine(activity5.Id + " - " + activity5.Name);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o id da atividade");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Activity activity3 = classroom.Activities.Find(x => x.Id == id);
                        if (activity3 != null) {
                            Console.WriteLine("Atividade encontrada");
                            ActivityController.MenuTeacher(activity3);
                        }
                        else Console.WriteLine("Atividade não encontrada");
                        break;
                    case 4:
                        Console.WriteLine("Digite o id da atividade");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        Activity activity2 = classroom.Activities.Find(x => x.Id == id2);
                        if (activity2 != null) {
                            Console.WriteLine("Atividade encontrada");
                            classroom.Activities.Remove(activity2);
                        }
                        else Console.WriteLine("Atividade não encontrada");
                        break;
                    case 5:
                        AddStudent(classroom);
                        break;
                        
                    case 6:
                        RemoveStudent(classroom);
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            } while (true);
        }

        private static void AddStudent(Classroom classroom)
        {
            Console.WriteLine("Digite o id do aluno");
            int id = Convert.ToInt32(Console.ReadLine());
            Student student = Student.Students.Find(x => x.Id == id);
            if (student == null) {
                Console.WriteLine("Aluno inexistente");
                return;
            }
            Student studentInClass = classroom.Students.Find(x => x.Id == id);
            if (studentInClass == null) {
                classroom.Students.Add(student);
                student.Classrooms.Add(classroom);
            }
            else Console.WriteLine("Aluno já adicionado");
        }

        private static void RemoveStudent(Classroom classroom)
        {
            Console.WriteLine("Digite o id do aluno");
            int id = Convert.ToInt32(Console.ReadLine());
            Student student = classroom.Students.Find(x => x.Id == id);
            if (student != null) {
                classroom.Students.Remove(student);
                student.Classrooms.Remove(classroom);
            }
            else Console.WriteLine("Aluno não encontrado");
        }

        public static void MenuStudent(Student student, Classroom classroom)
        {
            do{
                Console.WriteLine("---- Menu da turma ----");
                Console.WriteLine("1 - Listar atividades");
                Console.WriteLine("2 - Acessar atividade");
                Console.WriteLine("3 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 3) break;

                switch(option)
                {
                    case 1:
                        Console.WriteLine("---- Atividades ----");
                        foreach (Activity activity in classroom.Activities)
                        {
                            Console.WriteLine(activity.Id + " - " + activity.Name);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o id da atividade");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Activity activity3 = classroom.Activities.Find(x => x.Id == id);
                        if (activity3 != null) {
                            Console.WriteLine("Atividade encontrada");
                            ActivityController.MenuStudent(student, activity3);
                        }
                        else Console.WriteLine("Atividade não encontrada");
                        break;
                    case 3:
                        break;
                }
            } while (true);
        }
    }
}