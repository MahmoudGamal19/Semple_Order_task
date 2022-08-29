using Doman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessInterface
{
    public interface IItem
    {
        IEnumerable<Items> GetItems();
        Items GetItem(string Id);
        void InsertItem(Items items);
        void UpdatItem(Items items);
        void DeleteItem(String Id);
        void SaveChange();
        bool CheckRelations(string id);

    }
}
