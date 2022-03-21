using System;
using App.Models;
using App.Controllers;
using System.Text.Json;

namespace App {
    class Program {
        static void Main(string[] args) {
            int option = 0;

            Seed();

            Console.WriteLine("---- Bem vindo ao TextClassroom ----");
            do {
                Console.WriteLine("---- Escolha uma opção ----");
                Console.WriteLine("1 - Entrar como professor");
                Console.WriteLine("2 - Entrar como aluno");
                Console.WriteLine("3 - Registrar-se como professor");
                Console.WriteLine("4 - Registrar-se como aluno");
                Console.WriteLine("5 - Sair do programa");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 5) break;

                switch (option){
                    case 1:
                        TeacherController.Login();
                        break;
                    case 2:
                        StudentController.Login();
                        break;
                    case 3:
                        TeacherController.Register();
                        break;
                    case 4:
                        StudentController.Register();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                
            } while (true);
        }

        public static async void Seed()
        {
            string json = "";

            try{            
                json = System.IO.File.ReadAllText("src/store/students.json");
                Student.Students = JsonSerializer.Deserialize<List<Student>>(json);
            } catch (Exception e){
                Console.WriteLine("Nao foi possivel ler estudantes");
            }

            try{            
                json = System.IO.File.ReadAllText("src/store/teachers.json");
                Teacher.Teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            } catch (Exception e){
                Console.WriteLine("Nao foi possivel ler professores");
            }

            try{            
                json = System.IO.File.ReadAllText("src/store/users.json");
                User.Users = JsonSerializer.Deserialize<List<User>>(json);
            } catch (Exception e){
                Console.WriteLine(e);
            }

            try{            
                json = System.IO.File.ReadAllText("src/store/classrooms.json");
                Classroom.Classrooms = JsonSerializer.Deserialize<List<Classroom>>(json);
            } catch (Exception e){
                Console.WriteLine(e);
            }

            try{            
                json = System.IO.File.ReadAllText("src/store/grades.json");
                Grade.Grades = JsonSerializer.Deserialize<List<Grade>>(json);
            } catch (Exception e){
                Console.WriteLine(e);
            }

            try{            
                json = System.IO.File.ReadAllText("src/store/activities.json");
                Activity.Activities = JsonSerializer.Deserialize<List<Activity>>(json);
            } catch (Exception e){
                Console.WriteLine(e);
            }

            foreach (Activity a in Activity.Activities){
                Console.WriteLine(a.Name);
                Console.WriteLine(a.Grades.First().Student.Id);  
            }
        }
    }
}