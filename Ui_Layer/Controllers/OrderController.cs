using AutoMapper;
using Business.BusinessInterface;
using Doman.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Ui_Layer.Models;

namespace Ui_Layer.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _Order;
        private readonly IItem _Items;
        private readonly ICustomer _Cust;
        private readonly IMapper _Mapper;

        public OrderController( IOrder order,IItem items,ICustomer customer,IMapper mapper)
        {
            _Order = order;
            _Items = items;
            _Cust = customer;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            ViewBag.OrderH =_Order.GetAllOrder();
            return View();
        }
        public IActionResult Create()
        { 
            ViewBag.Items=_Items.GetItems();
            ViewBag.Customer=_Cust.GetCustomers();
            return View();
        }
        public IActionResult Create_Order(OrderHView orderHView )
        {
            var Order = _Mapper.Map<OrderH>(orderHView);
            var result= _Order.CreateOrder(Order);
            if (result == false)
            {
                ViewBag.Massage = "Order Fild";
                return RedirectToAction("Create");
            }
           return RedirectToAction("Index");
        }
        public IActionResult Edit(string Id)
        {
            var orderHView= _Mapper.Map<OrderHView>(_Order.GetOrder(Id));
            ViewBag.Items = _Items.GetItems();
            ViewBag.Customer = _Cust.GetCustomers();
            return View(orderHView);
        }
        public IActionResult Edit_Order(OrderHView orderHView)
        {
            var Order = _Mapper.Map<OrderH>(orderHView);
            var result = _Order.DeleteOrder(orderHView.Id);

            if (result == false)
            {
                ViewBag.Massage = "Order Updated1 Fild";
                return RedirectToAction("Edit",orderHView.Id);
            }
            result = _Order.CreateOrder(Order);

            if (result == false)
            {
                ViewBag.Massage = "Order Updated2 Fild";
                return RedirectToAction("Edit", orderHView.Id);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string ID)
        {
            if (ModelState.IsValid)
            {
              var result=  _Order.DeleteOrder(ID);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetCustInformation(string Id)
        {
            var Cust=_Cust.GetCustomer(Id);
            return Json(Cust);
        }
        public IActionResult GetItemsInformation()
        {
            var Itms = _Items.GetItems();
            return Json(Itms);
        }
        public IActionResult GetItemInformation(string Id)
        {
            var items = _Items.GetItem(Id);
            return Json(items);
        }
    }

}
