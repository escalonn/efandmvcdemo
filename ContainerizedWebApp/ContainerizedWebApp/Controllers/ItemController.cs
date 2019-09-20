using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ContainerizedDataAccess.Entities;
using ContainerizedWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContainerizedWebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly mvcappdbContext _context;
        private readonly ILogger<ItemController> _logger;

        public ItemController(mvcappdbContext context, ILogger<ItemController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Item
        public ActionResult Index()
        {
            if (TempData.ContainsKey("username"))
            {
                TempData["username"] = TempData["username"] + "!";
                TempData.Keep("username");
            }

            Account myAccount;
            try
            {
                myAccount = _context.Account
                    .Include(a => a.Item) // 
                    .First(a => a.Name == "Nick");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Exception while retrieving account {accountName} from DB", "Nick");
                return View("DatabaseError");
            }

            IEnumerable<ItemViewModel> model = myAccount.Item.Select(i => new ItemViewModel
            {
                Id = i.Id,
                Name = i.Name
            });

            return View(model);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // the validation spans will be filled in with any modelstate errors
                    return View(model);
                }

                var item = new Item
                {
                    Name = model.Name
                };

                Account myAccount = _context.Account
                    //.Include(a => a.Item) // 
                    .First(a => a.Name == "Nick");

                //myAccount.Item.Add(item); // adds the new entity (including the foreign key relationship)
                //                          // as far as EF is concerned.

                item.Account = myAccount;
                _context.Item.Add(item); // does the same thing, don't need to do both

                _context.SaveChanges(); // applies all changes so far as a transaction to the DB.
                // (also wires up any )

                _logger.LogInformation("Item {itemName} with ID {itemId} created for account {accountId}",
                    item.Name, item.Id, myAccount.Id);

                TempData["username"] = item.Name;

                //// manual server side validation
                //ModelState.AddModelError("Name", "Name already in use");
                //return View(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
