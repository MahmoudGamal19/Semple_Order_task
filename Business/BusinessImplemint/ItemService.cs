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
    public class ItemService : IItem
    {
        private readonly IRepository<Items> _Item_Repo;
        private readonly ApplicationDbContext _db;

        public ItemService(IRepository<Items> repository,ApplicationDbContext db)
        {
            _Item_Repo = repository;
            _db = db;
        }

        public bool CheckRelations(string id)
        {
            var item = _db.OrderD.FirstOrDefault(O => O.Item_Id == id);
            if(item == null)
                return false;
            return true;
        }

        public void DeleteItem(string Id)
        {
            var item = _Item_Repo.Get(Id);
            if(item == null)
            {
                throw new ArgumentNullException("this id " + Id + "not found");
            }
            _Item_Repo.Delete(item);
        }

        public Items GetItem(string Id)
        {
            return _Item_Repo.Get(Id);
        }

        public IEnumerable<Items> GetItems()
        {
            return _Item_Repo.GetAll();
        }

        public void InsertItem(Items items)
        {
           _Item_Repo.Insert(items);
        }

        public void SaveChange()
        {
            _Item_Repo.SaveChange();

        }

        public void UpdatItem(Items items)
        {
           _Item_Repo.Update(items);
        }
    }
}
