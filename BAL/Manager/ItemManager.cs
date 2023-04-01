using BAL.IManager;
using DAL;
using MODEL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Manager
{
    public class ItemManager : ItemIManager
    {
        #region GetInsuranceCompanies

        void AddCategory(Category cat)
        {

        }
        public List<item> GetItems()
        {
            DataSet dt = new DataSet();
            try
            {
                var ProductItems = new List<item>();

                using (dt = ADOManager.Instance.DataSet("[getAllItems]", CommandType.StoredProcedure))
                {
                    ProductItems = dt.Tables[0].AsEnumerable().Select(cmp => new item
                    {
                        id = cmp.Field<int>("ItemId"), 
                        name = cmp.Field<string>("Name"), 
                        categoryId= cmp.Field<int?>("categoryId"), 
                        createdOn= cmp.Field<DateTime?>("createdOn"), 
                        modifiedOn = cmp.Field<DateTime?>("modifiedOn"), 
                        category= cmp.Field<string>("category"),
                        price=cmp.Field<double?>("price")


                    }).ToList();

                }
                return ProductItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addItem(item item)
        {
            int numRowsAffected = 0;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@itemName",item.name),
                new SqlParameter("@category", item.category),
                new SqlParameter("@price",item.price)
            };
            numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[addItem]", CommandType.StoredProcedure, parameters);
            if (numRowsAffected > 0)
                return true;
            return false;
        }
        public bool updateItem(item item)
        {
            int numRowsAffected = 0;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@itemName",item.name),
                new SqlParameter("@category", item.category),
                new SqlParameter("@price",item.price),
                new SqlParameter("@id",item.id)
            };
            numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[updateItem]", CommandType.StoredProcedure, parameters);
            if (numRowsAffected > 0)
                return true;
            return false;
        }
        public bool deleteItem(int itemId)
        {
            int numRowsAffected = 0;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",itemId)
            };
            numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[deleteItem]", CommandType.StoredProcedure, parameters);
            if (numRowsAffected > 0)
                return true;
            return false;
        }
        #endregion


    }
}
