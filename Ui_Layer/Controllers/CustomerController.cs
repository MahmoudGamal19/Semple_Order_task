using AutoMapper;
using Business.BusinessInterface;
using Doman.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Ui_Layer.Models;

namespace Ui_Layer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _Cust;
        private readonly IMapper _Mapper;

        public CustomerController(ICustomer customer,IMapper mapper)
        {
            _Cust = customer;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            var Cust =_Mapper.Map<IEnumerable<CustomerView>>(_Cust.GetCustomers());
            ViewBag.Customer = Cust;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create_customer(CustomerView customerview)
        {
            if (ModelState.IsValid) { 
                if(customerview != null) {

                    var customer = _Mapper.Map<Customer>(customerview);
                    _Cust.InsertCustomer(customer);
                    _Cust.SaveChange();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edite(string Id)
        {
            var cust=_Mapper.Map<CustomerView>(_Cust.GetCustomer(Id));
            return View(cust);
        }
        public IActionResult Edite_customer(CustomerView customerview)
        {
            if (ModelState.IsValid) {
                if (customerview != null)
                {
                    var customer = _Mapper.Map<Customer>(customerview);
                    _Cust.UpdateCustomer(customer);
                    _Cust.SaveChange();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edite","Customer",customerview.Id);
        }
        public IActionResult Delete(string Id)
        {
            if (ModelState.IsValid) {
                var chick = _Cust.CheckRelations(Id);
                if (chick == false)
                {
                    _Cust.DeleteCustomer(Id);
                    ViewBag.Massage = null;
                }
                else
                {
                    ViewBag.Massage = "Customer : "+Id+"Has Orders";
                }
            }
            return RedirectToAction("Index");
        }

    }
}
