using Hospital_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    class ServiceBLL
    {
        ServiceDAL serviceDAL;
        public List<Models.Service> GetAllServices()
        {
            serviceDAL = new ServiceDAL();
            return serviceDAL.GetAllServices();
        }
    }
}
