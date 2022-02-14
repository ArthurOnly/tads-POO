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
                Console.WriteLine("3 - Registrar-se como aluno");
                Console.WriteLine("4 - Sair do programa");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 4) break;

                switch (option){
                    case 1:
                        TeacherController.Login();
                        break;
                    case 2:
                        StudentController.Login();
                        break;
                    case 3:
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
            new Teacher("teste", "t@t", "123");

            new Student("a1", "a@a", "123");
            new Student("e1", "e@e", "123");
            new Student("c1", "c@c", "123");
            new Student("d1", "d@d", "123");
            new Student("b1", "b@b", "123");
            new Student("f1", "f@f", "123");
        }
    }
}