
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
    public class ItemController : ApiController
    {
        private readonly ItemIManager _itemmanager;
        public ItemController()
        {
            _itemmanager = new ItemManager();
        }

        #region GetInsuranceCompanies
        //[Authorize]
        [HttpGet]
        [Route("api/GetItems")]
        public IHttpActionResult GetItems()
        {

            List<item> result = null;
            result = _itemmanager.GetItems();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/AddItem")]
        public IHttpActionResult AddItem(item item)
        {
            bool result = false;
            result = _itemmanager.addItem(item);
            if (result)
                return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Route("api/UpdateItem/{itemId}")]
        public IHttpActionResult updateItem(int itemId, item item)
        {
            bool result = _itemmanager.updateItem(item);
            if (result)
                return Ok(result);
            return NotFound();
        }

        [HttpDelete]
        [Route("api/DeleteItem/{itemId}")]
        public IHttpActionResult deleteItem(int itemId)
        {
            bool result = _itemmanager.deleteItem(itemId);
            if (result)
                return Ok(result);
            return NotFound();
        }
        #endregion
    }
}
