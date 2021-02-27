using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace TestConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService _userManager = new UserManager(new EfUserDal());

            //var result= _userManager.Add(new User
            // {
            //     FirstName = "Emin",
            //     LastName = "Binici",
            //     Email = "emin.binici34@gmail.com",
            //     Password = "1234",
            //     Telephone = "12345",
            //     CreateDate = DateTime.Now,
            //     UpdateDate= DateTime.Now,
            //     IsActive=true
            // }) ;


            // Console.WriteLine(result.Message);
            var result = _userManager.GetBasketDetail(11);
            Console.WriteLine(result.Message);
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductId + "\n" + product.ProductModel + "\n" + product.ImageUrl + "\n" + product.ProductPrice + "\n" + product.Quantity);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
