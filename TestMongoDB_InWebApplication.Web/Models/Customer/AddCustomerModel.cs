using System.ComponentModel.DataAnnotations;
using TestMongoDB_InWebApplication.DomainModel.Entity;

namespace TestMongoDB_InWebApplication.Web.Models.Customer
{
    public class AddCustomerModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateOnly BirthDate { get; set; }
        public int Age { get; set; }
        public MobileNumber MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
