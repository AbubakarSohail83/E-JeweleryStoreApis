using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.IManager;
using DAL;
using MODEL.Models;

namespace BAL.Manager
{
    public class CategoryManager: CategoryIManager
    {
        public List<Category> GetCategories()
        {
            DataSet dt = new DataSet();
            try
            {
                var ProductCategories = new List<Category>();

                using (dt = ADOManager.Instance.DataSet("[getAllCategories]", CommandType.StoredProcedure))
                {
                    ProductCategories = dt.Tables[0].AsEnumerable().Select(cmp => new Category
                    {
                        id = cmp.Field<int>("CategoryId"),
                        categoryName = cmp.Field<string>("Name"),
                        createdOn = cmp.Field<DateTime?>("createdOn"),
                        modifiedOn = cmp.Field<DateTime?>("modifiedOn"),
                    }).ToList();

                }
                return ProductCategories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addCategory(Category cat)
        {
            int numRowsAffected = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Name",cat.categoryName)
                };
                numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[addCategory]", CommandType.StoredProcedure, parameters);
                if(numRowsAffected>0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateCategory(Category cat)
        {
            int numRowsAffected = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Name",cat.categoryName),
                    new SqlParameter("@id",cat.id)
                };
                numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[updateCategory]", CommandType.StoredProcedure, parameters);
                if (numRowsAffected > 0)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool deleteCategory(int categoryId)
        {
            int numRowsAffected = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id",categoryId)
                };
                numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[deleteCategory]", CommandType.StoredProcedure, parameters);
                if (numRowsAffected > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
