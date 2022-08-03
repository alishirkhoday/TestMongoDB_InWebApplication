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
            _mobileNumbers = new List<MobileNumber>
            {
                new MobileNumber { Value = "09308336840" }
            ,
                new MobileNumber { Value = "09123456789" }
            };
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCustomerModel addCustomerModel)
        {
            Customer customer = new Customer();
            MobileNumber mobile = new MobileNumber();
            customer.Name = addCustomerModel.Name;
            customer.Family = addCustomerModel.Family;
            customer.BirthDate = addCustomerModel.BirthDate;
            customer.Age = addCustomerModel.Age;
            customer.MobileNumbers = _mobileNumbers;
            customer.Email = addCustomerModel.Email;
            customer.Address = addCustomerModel.Address;
            CustomerValidator validator = new();
            ValidationResult results = validator.Validate(customer);
            if (results.IsValid)
            {
                var customerCollection = MongodbContext.Context().GetCollection<Customer>("Customers");
                //var mobileNumberCollection = MongodbContext.Context().GetCollection<Customer>("MobileNumber");
                //var checkCustomerMobileNumber = customerCollection.AsQueryable().Any(c => c.MobileNumbers == addCustomerModel.MobileNumber);
                //var checkCustomerEmail = customerCollection.AsQueryable().Any(c => c.Email == addCustomerModel.Email);
                //if (
                //    !checkCustomerMobileNumber
                //    &&
                //    !checkCustomerEmail
                //    )
                //{
                    customerCollection.InsertOne(customer);
                    //return RedirectToAction("Add");
                //}
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    return Content("Property " + item.PropertyName + " failed validation. Error was: " + item.ErrorMessage);
                }
                //return View("MyErrorValidation");
                return View();
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
