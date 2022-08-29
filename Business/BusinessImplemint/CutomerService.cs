
using Business.BusinessInterface;
using Doman.Model;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessImplemint
{
    public class CutomerService:ICustomer
    {
        private readonly IRepository<Customer> _Cust_Repo;
        private readonly ApplicationDbContext _db;

        public CutomerService(IRepository<Customer> Cust_Repo,ApplicationDbContext db)
        {
            _Cust_Repo = Cust_Repo;
            _db = db;
        }

        public bool CheckRelations(string id)
        {
            var Cust = _db.OrderH.FirstOrDefault(O => O.Cust_Id == id);
            if(Cust == null)
                return false;
            return true;   
        }

        public void DeleteCustomer(string Id)
        {
            var  customer =_Cust_Repo.Get(Id);   
            _Cust_Repo.Delete(customer);
        }

        public Customer GetCustomer(string Id)
        {
            var customer =_Cust_Repo.Get(Id);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _Cust_Repo.GetAll();
        }

        public void InsertCustomer(Customer customer)
        {
            _Cust_Repo.Insert(customer);
        }

        public void SaveChange()
        {
            _Cust_Repo.SaveChange();
        }

        public void UpdateCustomer(Customer customer)
        {
            _Cust_Repo.Update(customer);
        }
    }
}
