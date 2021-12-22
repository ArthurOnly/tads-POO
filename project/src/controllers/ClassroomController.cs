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
                Console.WriteLine("4 - Cadastrar aluno");
                Console.WriteLine("5 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 6) break;

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
                        Console.WriteLine("Digite o nome do aluno");
                        string name2 = Console.ReadLine();
                        Console.WriteLine("Digite o email do aluno");
                        string email = Console.ReadLine();
                        Console.WriteLine("Digite a senha do aluno");
                        string password = Console.ReadLine();
                        Student student = new Student(name2, email, password);
                        classroom.Students.Add(student);
                        break;
                    case 6:
                        break;

                }
            } while (true);
        }
    }
}