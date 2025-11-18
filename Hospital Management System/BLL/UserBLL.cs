using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;
        public UserBLL()
        {
            _userDAL = new UserDAL();
        }
        public User? Login(string username, string password, string role)
        {   // Validation cơ bản
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))

                return null;

            return _userDAL.GetUser(username, password, role);
        }
        public List<User> GetAllUsers()
        {
            return _userDAL.GetAllUsers();
        }
        public void AddUser(User user)
        {
            // Bạn có thể thêm validation ở đây trước khi gọi DAL



            _userDAL.AddUser(user);
        }
        public void DeleteUser(User user)
        {
            _userDAL.DeleteUser(user);
        }
        public void UpdateUser(User user)
        {
            _userDAL.UpdateUser(user);
        }
    }
}
