using System;
using App.Models;
using App.Controllers;

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

        public static void Seed()
        {
            Student.readFromFile();
            Teacher.readFromFile();
            Grade.readFromFile();
            Classroom.readFromFile();
            Activity.readFromFile();
        }
    }
}