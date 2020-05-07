using Microsoft.AspNet.Identity;
using System;
namespace PasswordHasherTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            Console.WriteLine(passwordHasher.HashPassword("strong password"));
            Console.ReadLine();
        }
    }
}