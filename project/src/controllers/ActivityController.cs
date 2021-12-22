using App.Models;
using App.Controllers;

namespace App.Controllers
{
    static class ActivityController
    {

        public static void MenuTeacher(Activity activity)
        {
            do{
                Console.WriteLine("---- Menu da atividade ----");
                Console.WriteLine("1 - Mostrar descrição");
                Console.WriteLine("2 - Atribuir nota");
                Console.WriteLine("3 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 3) break;

                switch(option)
                {
                    case 1:
                        Console.WriteLine(activity.Name + " - " + activity.Description + " - " + activity.Link);
                        break;
                    case 2:
                        Console.WriteLine("Digite o id do aluno");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Student student = activity.Classroom.Students.Find(x => x.Id == id);
                        if (student != null) {
                            Console.WriteLine("Aluno encontrado");
                            Console.WriteLine("Digite a nota do aluno");
                            int grade = Convert.ToInt32(Console.ReadLine());
                            activity.Grades.Add(new Grade(grade, student, activity));
                        }
                        else Console.WriteLine("Aluno não encontrado");
                        break;
                    case 3:
                        break;
                }
            } while (true);
        }
    }
}