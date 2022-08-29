using Business.BusinessInterface;
using Doman.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessImplemint
{
    public class OrderService : IOrder
    {
        private readonly IRepository<OrderH> _OederH;
        private readonly ApplicationDbContext _db;
        private readonly IRepository<Customer> _Cust;
        private readonly IRepository<Items> _Item;

        public OrderService(ApplicationDbContext db, IRepository<OrderH> OederH
            , IRepository<Items> items,
            IRepository<Customer>Cust)
        { 
            _OederH = OederH;
            _db = db;
            _Cust = Cust;
            _Item = items;
        }

        public bool CreateOrder(OrderH orderH)
        {
            if (orderH != null)
            {
                foreach (var x in orderH.OrderD)
                {
                    x.Item = _Item.Get(x.Item_Id);
                    x.OrderH = orderH;
                    x.Orderh_Id = orderH.Id;
                }
                _db.OrderD.AddRange(orderH.OrderD);
                _db.OrderH.Add(orderH);
                _OederH.SaveChange();
                return true;
            }
            return false;
        }
        public bool DeleteOrder(string Id)
        {
            try
            {
                var order = _db.OrderH.SingleOrDefault(x => x.Id == Id);
                order.OrderD = _db.OrderD.Where(x => x.Orderh_Id == Id).ToList();
                _db.OrderD.RemoveRange(order.OrderD);
                _db.OrderH.Remove(order);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<OrderH> GetAllOrder()
        { 
            return _db.OrderH.Include(b=>b.Customer).ToList();
        }
        public OrderH GetOrder(string Id)
        {
            var order = _db.OrderH.SingleOrDefault(x => x.Id == Id);
            order.OrderD = _db.OrderD.Where(x => x.Orderh_Id == Id).ToList();
            order.Customer = _Cust.Get(order.Cust_Id);
            return order;
        }
    }
}
