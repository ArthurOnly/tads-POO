using App.Models;

namespace App.Controllers
{
    static class TeacherController
    {
        private static List<Teacher> _teachers;

        public static List<Teacher> Index(){
            return _teachers;
        }

        public static Teacher Show(int id){
            for (int i = 0; i < _teachers.Count ; i++){
                if (_teachers[i].Id == id){
                    return _teachers[i];
                }
            }
            return null;
        }

        public static void Delete(int id){
            for (int i = 0; i < _teachers.Count ; i++){
                if (_teachers[i].Id == id){
                    _teachers.RemoveAt(i);
                }
            }
        }

        public static void Create(Teacher teacher){
            _teachers.Add(teacher);
        }

        public static Teacher Login(string email, string password){
            for (int i = 0; i < _teachers.Count ; i++){
                if (_teachers[i].Email == email && _teachers[i].Password == password){
                    return _teachers[i];
                }
            }
            return null;
        }
    }
}