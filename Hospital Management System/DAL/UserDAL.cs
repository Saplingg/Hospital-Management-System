using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital_Management_System.DAL
{
    public class UserDAL
    {
        private readonly HospitalManagementDbContext _context;
        public UserDAL()
        {
            _context = new HospitalManagementDbContext();
        }
        public User? GetUser(string username, string password, string role)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.Role == role && u.Active == true );
        }
       
    }
}
