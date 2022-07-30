using System.ComponentModel.DataAnnotations;
using TestMongoDB_InWebApplication.DomainModel.Entity;

namespace TestMongoDB_InWebApplication.Web.Models.Customer
{
    public class AddCustomerModel
    {
        //[Required(ErrorMessage = "لطفا نام مشتری را وارد کنید")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "لطفا نام نام خانوادگی مشتری را وارد کنید")]
        public string Family { get; set; }

        //[Required(ErrorMessage = "لطفا موبایل مشتری را وارد کنید")]
        public string MobileNumber { get; set; }

        //[Required(ErrorMessage = "لطفا ایمیل مشتری را وارد کنید")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "لطفا آدرس مشتری را وارد کنید")]
        public string Address { get; set; }
    }
}
