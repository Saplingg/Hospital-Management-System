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

    }
}
