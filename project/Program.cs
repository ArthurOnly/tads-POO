using System;
using App.Models;
using App.Controllers;

namespace App {
    class Program {
        static void Main(string[] args) {
            int option = 0;

            Teacher initial = new Teacher("teste", "t@t", "123");

            Console.WriteLine("---- Bem vindo ao TextClassroom ----");
            do {
                Console.WriteLine("---- Escolha uma opção ----");
                Console.WriteLine("1 - Entrar como professor");
                Console.WriteLine("2 - Entrar como aluno");
                Console.WriteLine("3 - Sair");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 3) break;

                switch (option){
                    case 1:
                        TeacherController.Login();
                        break;
                    case 2:
                        StudentController.Login();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                
            } while (true);
        }
    }
}