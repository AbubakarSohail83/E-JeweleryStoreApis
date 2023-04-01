using MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IManager
{
   public interface ItemIManager
    {

        List<item>  GetItems();
        bool addItem(item item);
        bool updateItem(item item);
        bool deleteItem(int itemId);
    }
}
