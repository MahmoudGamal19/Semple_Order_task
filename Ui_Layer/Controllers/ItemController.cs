using AutoMapper;
using Business.BusinessInterface;
using Doman.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ui_Layer.Models;

namespace Ui_Layer.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItem _Item;
        private readonly IMapper _Mapper;

        public ItemController(IItem Item,IMapper mapper)
        {
            _Item = Item;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            var Item =_Mapper.Map<IEnumerable<ItemView>>(_Item.GetItems());
            ViewBag.Items = Item;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create_Item(ItemView itemview)
        {
            if (ModelState.IsValid)
            {
                if(itemview != null)
                { var item = _Mapper.Map<Items>(itemview);
                    _Item.InsertItem(item);
                    return RedirectToAction("Index");
                }
                
            }
            return RedirectToAction("Create");
        }
        public IActionResult Edit(string Id)
        {
            var item =_Mapper.Map<ItemView>(_Item.GetItem(Id));

            return View(item);
        }
        public IActionResult Edit_Item(ItemView itemview)
        {
            var items = _Mapper.Map<Items>(itemview);
             _Item.UpdatItem(items);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(string Id)
        {
            if (ModelState.IsValid)
            {
                var check=_Item.CheckRelations(Id);
                if (check == false)
                {
                    _Item.DeleteItem(Id);
                    ViewBag.Massage = null;
                }
                else
                {
                    ViewBag.Massage = "Item : " + Id + "Incloude in Orders";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
