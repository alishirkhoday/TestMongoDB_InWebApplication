using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TestMongoDB_InWebApplication.DataAccess.UseMongoDB;
using TestMongoDB_InWebApplication.DomainModel.Entity;
using TestMongoDB_InWebApplication.DomainModel.Validator;
using TestMongoDB_InWebApplication.Web.Models.Customer;

namespace TestMongoDB_InWebApplication.Web.Controllers
{
    public class TestController : Controller
    {
        private List<MobileNumber> _mobileNumbers;
        public TestController()
        {
            _mobileNumbers = new List<MobileNumber>();   
        }

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
                Customer customer = new Customer();
                //MobileNumber mobileNumber = new MobileNumber();
                customer.Name = addCustomerModel.Name;
                customer.Family = addCustomerModel.Family;
                customer.MobileNumber = addCustomerModel.MobileNumber;
                customer.Email = addCustomerModel.Email;
                customer.Address = addCustomerModel.Address;
                CustomerValidator validator = new CustomerValidator();
                ValidationResult results = validator.Validate(customer);
                if (results.IsValid)
                {
                    var customerCollection = MongodbContext.Context().GetCollection<Customer>("Customers");
                    //var mobileNumberCollection = MongodbContext.Context().GetCollection<Customer>("MobileNumber");
                    var checkCustomer = customerCollection.AsQueryable().Any(c => c.MobileNumber == addCustomerModel.MobileNumber);
                    var checkCustomer1 = customerCollection.AsQueryable().Any(c => c.Email == addCustomerModel.Email);
                    if (!checkCustomer&&!checkCustomer1)
                    {
                        customerCollection.InsertOne(customer);
                        return RedirectToAction("Add");
                    }
                }
                else
                {
                    foreach (var failure in results.Errors)
                    {
                        return Content("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
            }
            return View(addCustomerModel);
        }

        [HttpGet]
        public IActionResult GetListCustomrs()
        {
            var customerCollection = MongodbContext.Context().GetCollection<Customer>("Customers");
            //var filter = new BsonDocument();
            //var document = customerCollection.Find(filter).ToList();
            var document = customerCollection.AsQueryable().ToList();
            return View(document);
        }
    }
}
