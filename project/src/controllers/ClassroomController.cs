using App.Models;
using App.Controllers;
using System.Globalization;

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
                Console.WriteLine("4 - Atualizar atividade");
                Console.WriteLine("5 - Deletar atividade");
                Console.WriteLine("6 - Adicionar aluno");
                Console.WriteLine("7 - Remover aluno");
                Console.WriteLine("8 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 8) break;

                switch(option)
                {
                    case 1:
                        CreateActivity(classroom);
                        break;

                    case 2:
                        IndexActivities(classroom);
                        break;

                    case 3:
                        ShowActivity(classroom);
                        break;

                    case 4:
                        UpdateActivity(classroom);
                        break;

                    case 5:
                        DeleteActivity(classroom);
                        break;

                    case 6:
                        AddStudent(classroom);
                        break;
                        
                    case 7:
                        RemoveStudent(classroom);
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            } while (true);
        }

        private static void CreateActivity(Classroom classroom)
        {
            Console.WriteLine("Digite o nome da atividade");
            string name = Console.ReadLine();
            Console.WriteLine("Digite a descrição da atividade");
            string description = Console.ReadLine();
            Console.WriteLine("Digite o link da atividade");
            string link = Console.ReadLine();
            Console.WriteLine("Digite a data de entrega da atividade (m/d/Y)");
            string finalDate = Console.ReadLine();
            DateTime date = DateTime.Parse(finalDate, CultureInfo.CreateSpecificCulture("pt-BR"));
            Activity activity = new Activity(name, description, link, classroom, date);
            classroom.Activities.Add(activity);
        }

        private static void UpdateActivity(Classroom classroom)
        {
            Console.WriteLine("Digite o id da atividade");
            int id = Convert.ToInt32(Console.ReadLine());
            Activity activity = classroom.Activities.Find(x => x.Id == id);
            if (activity != null) {
                Console.WriteLine("Digite o nome da atividade");
                string name = Console.ReadLine();
                Console.WriteLine("Digite a descrição da atividade");
                string description = Console.ReadLine();
                Console.WriteLine("Digite o link da atividade");
                string link = Console.ReadLine();
                activity.Name = name;
                activity.Description = description;
                activity.Link = link;
            }
            else {
                Console.WriteLine("Atividade não encontrada");
            }
        }

        private static void IndexActivities(Classroom classroom)
        {
            Console.WriteLine("---- Atividades ----");
            classroom.Activities.Sort();
            foreach (Activity activity5 in classroom.Activities)
            {
                Console.WriteLine(activity5.Id + " - " + activity5.Name);
            }
        }

        private static void ShowActivity(Classroom classroom)
        {
            Console.WriteLine("Digite o id da atividade");
            int id = Convert.ToInt32(Console.ReadLine());
            Activity activity3 = classroom.Activities.Find(x => x.Id == id);
            if (activity3 != null) {
                Console.WriteLine("Atividade encontrada");
                ActivityController.MenuTeacher(activity3);
            }
            else Console.WriteLine("Atividade não encontrada");
        }

        private static void DeleteActivity(Classroom classroom)
        {
            Console.WriteLine("Digite o id da atividade");
            int id = Convert.ToInt32(Console.ReadLine());
            Activity activity = classroom.Activities.Find(x => x.Id == id);
            if (activity != null) {
                Console.WriteLine("Atividade encontrada");
                classroom.Activities.Remove(activity);
            }
            else Console.WriteLine("Atividade não encontrada");
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

        public static async void MenuStudent(Student student, Classroom classroom)
        {
            do{
                Console.WriteLine("---- Menu da turma ----");
                Console.WriteLine("1 - Listar atividades");
                Console.WriteLine("2 - Acessar atividade");
                Console.WriteLine("3 - Acessar atividade mais recente");
                Console.WriteLine("3 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 4) break;

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
                        Activity act = Activity.Activities.Where(a => a.Classroom == classroom).OrderByDescending(a => a.FinalDate).First();
                        if (act != null) {
                            Console.WriteLine("Atividade encontrada");
                            ActivityController.MenuStudent(student, act);
                        }
                        else Console.WriteLine("Não há atividades");
                        break;
                    case 4:
                        break;
                }
            } while (true);
        }
    }
}