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
          
            _userManager.Add(new User
            {
                FirstName = "Emin",
                LastName = "Binici",
                Email = "emin.binici34@gmail.com",
                Password = "1234",
                Telephone = "12345",
                CreateDate = DateTime.Now.ToUniversalTime(),
                UpdateDate= DateTime.Now.ToUniversalTime(),
                IsActive=true
            }) ;

     

            Console.WriteLine("Hello World!");
        }
    }
}
