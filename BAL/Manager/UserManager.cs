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
    public class UserManager:UserIManager
    {
        public bool addUser(User user)
        {
            int numRowsAffected = 0;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@name",user.name),
                new SqlParameter("@email", user.email),
                new SqlParameter("@password",user.password)
            };
            numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[addUser]", CommandType.StoredProcedure, parameters);
            if (numRowsAffected > 0)
                return true;
            return false;
        }

        public List<User> getUsers()
        {
            DataSet dt = new DataSet();
            try
            {
                var Users = new List<User>();

                using (dt = ADOManager.Instance.DataSet("[getAllUsers]", CommandType.StoredProcedure))
                {

                    Users = dt.Tables[0].AsEnumerable().Select(cmp => new User
                    {
                        id = cmp.Field<int>("userId"),
                        name = cmp.Field<string>("name"),
                        email = cmp.Field<string>("email"),
                        password = cmp.Field<string>("password"),
                      


                    }).ToList();

                }
                return Users;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool updateUser(User user)
        {
            int numRowsAffected = 0;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",user.id),
                new SqlParameter("@password",user.password)
            };
            numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[updateUser]", CommandType.StoredProcedure, parameters);
            if (numRowsAffected > 0)
                return true;
            else
                return false;
        }
        public bool getUser(string email)
        {
            int numRowsAffected = 0;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@email",email),
            };
            numRowsAffected = ADOManager.Instance.ExecuteNonQuery("[getUser]", CommandType.StoredProcedure, parameters);
            if (numRowsAffected > 0)
                return true;
            else
                return false;
        }
    }

}
