using MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IManager
{
    public interface CategoryIManager
    {

        List<Category> GetCategories();
        bool addCategory(Category cat);

        bool updateCategory(Category cat);
        bool deleteCategory(int categoryId);

    }
}
