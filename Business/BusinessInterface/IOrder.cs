using Doman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessInterface
{
    public interface IOrder
    {
        IEnumerable<OrderH> GetAllOrder();
        bool CreateOrder(OrderH orderH);
        bool DeleteOrder(string Id);
        OrderH GetOrder(string Id);
    }
}
