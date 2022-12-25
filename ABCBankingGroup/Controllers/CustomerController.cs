using ABCBankingGroup.Models;
using ABCBankingGroup.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ABCBankingGroup.Controllers
{
    public class CustomerController : Controller
    {

        private readonly DatabaseContext _db;

        public CustomerController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> objCustomerList = _db.Customers.ToList();
            return View(objCustomerList);
        }

        // Create Account
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer obj)
        {
            if(ModelState.IsValid)
            {
                _db.Customers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Account created successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Edit Account
        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var accountFromDb = _db.Customers.Find(id);

            if (accountFromDb == null)
            {
                return NotFound();
            }

            return View(accountFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Account updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }


        // Delete An Account
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var accountFromDb = _db.Customers.Find(id);

            if (accountFromDb == null)
            {
                return NotFound();
            }

            return View(accountFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.Customers.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            _db.Customers.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Account deteled successfully!";
            return RedirectToAction("Index");
        }
    }
}
