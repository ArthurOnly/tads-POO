using App.Models;

namespace App.Controllers
{
    static class StudentController{
        private static List<Student> _students;

        public static List<Student> Index(){
            return _students;
        }

        public static Student Show(int id){
            for (int i = 0; i < _students.Count ; i++){
                if (_students[i].Id == id){
                    return _students[i];
                }
            }
            return null;
        }

        public static void Delete(int id){
            for (int i = 0; i < _students.Count ; i++){
                if (_students[i].Id == id){
                    _students.RemoveAt(i);
                }
            }
        }
        public static void Create(Student student){
            _students.Add(student);
        }
  
    }
}