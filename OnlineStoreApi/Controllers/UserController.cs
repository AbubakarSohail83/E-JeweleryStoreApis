using BAL.IManager;
using BAL.Manager;
using MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineStoreApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class UserController : ApiController
    {
        private readonly UserIManager _usermanager;

        public UserController()
        {
            _usermanager = new UserManager();
        }

        [HttpPost]
        [Route("api/AddUser")]
        public IHttpActionResult AddUser(User user)
        {
            bool result = false;
            result = _usermanager.addUser(user);
            if(result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            List<User> result = _usermanager.getUsers();
            if (result !=null)
                return Ok(result);
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/GetUser")]
        public IHttpActionResult GetUser(string userEmail)
        {
           bool result= _usermanager.getUser(userEmail);
            if (result != null)
                return Ok(result);
            else
            {
                return NotFound();
            }
        }



        [HttpPut]
        [Route("api/PutUser/{userId}")]
        public IHttpActionResult updateItem(int userId, User user)
        {
            bool result = _usermanager.updateUser(user);
            if (result)
                return Ok(result);
            return NotFound();
        }

    }
}
