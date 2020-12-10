using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wsei.ExchangeThings.Web.Database;

namespace Wsei.ExchangeThings.Web.ViewComponents
{
    public class ItemsView : ViewComponent
    {
        private readonly ExchangesDbContext _dbContext;

        public ItemsView(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()
        {
            var latestItem = _dbContext.Items.OrderByDescending(x => x.Id).First();
            return View("Index", latestItem);
        }
    }
}
