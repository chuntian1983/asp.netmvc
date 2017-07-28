using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Data_Access_Laye;

namespace WebApplication3.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL dal = new SalesERPDAL();
            return dal.embloyees.ToList();
        }
    }
}