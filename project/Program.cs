using System;
using App.Models;
using App.Controllers;

namespace App {
    class Program {
        static void Main(string[] args) {
            int option = 0;

            Console.WriteLine("---- Bem vindo ao TextClassroom ----");
            do {
                Console.WriteLine("---- Escolha uma opção ----");
                Console.WriteLine("1 - Entrar como professor");
                Console.WriteLine("2 - Entrar como aluno");
                Console.WriteLine("3 - Sair");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 3) break;

                Console.WriteLine("---- Digite seu email ----");
                string email = Console.ReadLine();
                Console.WriteLine("---- Digite sua senha ----");
                string password = Console.ReadLine();

                switch (option){
                    case 1:
                        try{
                            Teacher teacher = TeacherController.Login(email, password);
                        } catch (Exception e){
                            Console.WriteLine("Credenciais incorretas");
                        }
                        break;
                    case 2:
                        try{
                            Student student = StudentController.Login(email, password);
                        } catch (Exception e){
                            Console.WriteLine("Credenciais incorretas");
                        }
                        break;
                }
                
            } while (true);
        }

        public void TeacherMenu(Teacher teacher)
        {
            do{

            } while (true);
        }
    }
}