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
    public class CategoryController : ApiController
    {
        private readonly CategoryIManager _categoryManager;

        public CategoryController()
        {
            _categoryManager = new CategoryManager();
        }

        [HttpGet]
        [Route("api/GetCategories")]
        public IHttpActionResult GetCategories()
        {
            List<Category> result = null;
            result = _categoryManager.GetCategories();
            if(result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("api/addCategory")]
        public IHttpActionResult addCategory(Category cat)
        {
            bool result = false;
            result = _categoryManager.addCategory(cat);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/updateCategory/{catId}")]
        public IHttpActionResult updateCategory(int catId, Category cat)
        {

            bool result = false;
            result = _categoryManager.updateCategory(cat);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("api/deleteCategory/{catId}")]
        public IHttpActionResult deleteCategory( int catId)
        {
            bool result = false;
            result = _categoryManager.deleteCategory(catId);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
