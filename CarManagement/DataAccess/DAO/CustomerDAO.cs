using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CustomerDAO
    {
        // Singelaton Customer 
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }

        // Get All Customer 
        public List<Customer> GetAllCustomer()
        {
            try
            {
                var dbContex = new FUCarRentingManagementContext();
                return dbContex.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Login 
        public Customer checkLogin(string email, String password)
        {
            try
            {
                var dbContex = new FUCarRentingManagementContext();
                return dbContex.Customers.SingleOrDefault(m => m.Email.Equals(email) && m.Password.Equals(password));
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
        }
    }
}
