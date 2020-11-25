using Wsei.ExchangeThings.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.ExchangeThings.Web.Entities;
using Wsei.ExchangeThings.Web.Database;

namespace Wsei.ExchangeThings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddingController : ControllerBase
    {
        private ExchangesDbContext _dbContext;

        public AddingController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AddNewItemResponse Post(ItemModel item)
        {

            var entity = new ItemEntities
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            var response = new AddNewItemResponse()
            {
                success = true,
                message = "nice! it works!",
                addedItem = item
            };


            return response;
        }

    }
}
