using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TestMongoDB_InWebApplication.DomainModel.Entity;
using TestMongoDB_InWebApplication.Web.Models.Customer;

namespace TestMongoDB_InWebApplication.Web.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCustomerModel addCustomerModel)
        {
            if (ModelState.IsValid)
            {
                var checkCustomer=
                var customer = new Customer
                {
                    Name = addCustomerModel.Name,
                    Family = addCustomerModel.Family,
                    MobileNumber = addCustomerModel.MobileNumber,
                    Email = addCustomerModel.Email,
                    Address = addCustomerModel.Address,
                };
                .InsertOne(customer);
            }
            return View(addCustomerModel);
        }

        [HttpGet]
        public IActionResult GetListProducts()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("TestStore1");
            var customerCollection = db.GetCollection<Customer>("Customers");
            //var filter = new BsonDocument();
            //var document = customerCollection.Find(filter).ToList();
            var document = customerCollection.AsQueryable().ToList();
            return View(document);
        }
    }
}
