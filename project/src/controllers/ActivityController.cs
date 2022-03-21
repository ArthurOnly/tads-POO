using App.Models;
using System;
using System.Linq;

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
                Console.WriteLine("3 - 3 Maiores notas");
                Console.WriteLine("4 - Sumário de notas");
                Console.WriteLine("5 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 5) break;

                switch(option)
                {
                    case 1:
                        Console.WriteLine(activity.Name + " - " + activity.Description + " - " + activity.Link + " - " + activity.FinalDate.ToString("dd/MM/yyyy"));
                        break;
                    case 2:
                        foreach (Student studentL in Classroom.Classrooms.Where(c => c.Activities.Contains(activity)).SelectMany(c => c.Students))
                        {
                            Console.WriteLine(studentL.Id + " - " + studentL.Name);
                        }
                        Console.WriteLine("Digite o id do aluno");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Student student = Classroom.Classrooms.Where(c => c.Activities.Contains(activity)).First().Students.Find(x => x.Id == id);
                        if (student != null) {
                            Console.WriteLine("Aluno encontrado");
                            Console.WriteLine("Digite a nota do aluno");
                            int grade = Convert.ToInt32(Console.ReadLine());
                            Grade gradeF = new Grade(grade, student);
                            activity.Grades.Add(gradeF);
                            activity.save();
                            Classroom.Classrooms.Where(c => c.Activities.Contains(activity)).First().save();
                        }
                        else Console.WriteLine("Aluno não encontrado");
                        break;

                    case 3:
                        var act = activity.Grades.OrderByDescending(x => x.Score).Take(3);
                        if (act.Count() == 0) Console.WriteLine("Nenhuma nota registrada");
                        else
                        {
                            foreach (Grade grade in act)
                            {
                                Console.WriteLine(grade.Student.Id + " - " + grade.Student.Name + " - " + grade.Score);
                            }
                        }
                        break;

                    case 4:
                        var studentsPerGrade = activity.Grades.GroupBy(x => Math.Floor(x.Score), (key, group) => new { Key = key, Count = group.Count() });
                        if (studentsPerGrade.Count() == 0) Console.WriteLine("Nenhuma nota registrada");
                        else
                        {
                            foreach (var grade in studentsPerGrade)
                            {
                                Console.WriteLine(grade.Key + " - " + grade.Count);
                            }
                        }
                        break;
                    case 5:
                        break;
                }
            } while (true);
        }

        public static void MenuStudent(Student student, Activity activity)
        {
            do{
                Console.WriteLine("---- Menu da atividade ----");
                Console.WriteLine("1 - Mostrar descrição");
                Console.WriteLine("2 - Mostrar nota do aluno");
                Console.WriteLine("3 - Voltar");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 3) break;

                switch(option)
                {
                    case 1:
                        Console.WriteLine(activity.Name + " - " + activity.Description + " - " + activity.Link + " - " + activity.FinalDate.ToString("dd/MM/yyyy"));
                        break;
                    case 2:
                        Grade grade = activity.Grades.Find(x => x.Student.Id == student.Id);
                        if (grade != null) {
                            Console.WriteLine("Nota: " + grade.Score);
                        }
                        else Console.WriteLine("Nota não lançada");
                        break;
                    case 3:
                        break;
                }
            } while (true);
        }
    }
}