using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace WingtipToys.Models
{
    public class UsersDatabaseInitializer
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Seed()
        {
            //GetCategories().ForEach(c => context.Categories.Add(c));
            GetSeedUsers().ForEach(p => addUser(p, "Pa$$word1"));
        }

        private void addUser(User user, string password)
        {
            var userMgr = new UserManager<User>(new UserStore<User>(context));
            var result = userMgr.Create(user, password);

            if (user.Manager.HasValue && user.Manager.GetValueOrDefault(false))
            {
                userMgr.AddToRole(userMgr.FindByEmail(user.Email).Id, "manager");
            }
        }

        protected void initializer(ApplicationDbContext context)
        {
            //GetCategories().ForEach(c => context.Categories.Add(c));
            GetSeedUsers().ForEach(p => context.Users.Add(p));
        }

        private static List<User> GetSeedUsers()
        {
            var products = new List<User> {
                new User
                {
                    UserName = "Alexandra@wingtiptoys.com",
                    Email = "Alexandra@wingtiptoys.com",
                    FirstName = "Alexandra",
                    LastName = "Abigail",
                    ImagePath = "planepaper.png",
                    Manager = true
                },
                new User
                {
                    UserName = "Gabrielle@wingtiptoys.com",
                    Email = "Gabrielle@wingtiptoys.com",
                    FirstName = "Gabrielle",
                    LastName = "Hannah",
                    ImagePath = "planepaper.png",
                    Manager = true
                },
                new User
                {
                    UserName = "Hannah@wingtiptoys.com",
                    Email = "Hannah@wingtiptoys.com",
                    FirstName = "Hannah",
                    LastName = "waters",
                    ImagePath = "planepaper.png",
                    Manager = true
                },
                new User
                {
                    UserName = "Irene@wingtiptoys.com",
                    Email = "Irene@wingtiptoys.com",
                    FirstName = "Irene",
                    LastName = "Abigail",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Jennifer@wingtiptoys.com",
                    Email = "Jennifer@wingtiptoys.com",
                    FirstName = "Alexandra",
                    LastName = "Jennifer",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Maria@wingtiptoys.com",
                    Email = "Maria@wingtiptoys.com",
                    FirstName = "Lily",
                    LastName = "Maria",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Carolyn@wingtiptoys.com",
                    Email = "Carolyn@wingtiptoys.com",
                    FirstName = "Carolyn",
                    LastName = "Bernadette",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Kimberly@wingtiptoys.com",
                    Email = "Kimberly@wingtiptoys.com",
                    FirstName = "Kimberly",
                    LastName = "Abigail",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Diane@wingtiptoys.com",
                    Email = "Diane@wingtiptoys.com",
                    FirstName = "Carolyn",
                    LastName = "Diane",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Katherine@wingtiptoys.com",
                    Email = "Katherine@wingtiptoys.com",
                    FirstName = "Grace",
                    LastName = "Katherine",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Jessica@wingtiptoys.com",
                    Email = "Jessica@wingtiptoys.com",
                    FirstName = "Jessica",
                    LastName = "Adams",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Rebecca@wingtiptoys.com",
                    Email = "Rebecca@wingtiptoys.com",
                    FirstName = "Natalie",
                    LastName = "Rebecca",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Abigail@wingtiptoys.com",
                    Email = "Abigail@wingtiptoys.com",
                    FirstName = "Ruth",
                    LastName = "Abigail",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Stephanie@wingtiptoys.com",
                    Email = "Stephanie@wingtiptoys.com",
                    FirstName = "Tracey",
                    LastName = "Stephanie",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Pippa@wingtiptoys.com",
                    Email = "Pippa@wingtiptoys.com",
                    FirstName = "Molly",
                    LastName = "Pippa",
                    ImagePath = "planepaper.png",
                    Manager = false
                },
                new User
                {
                    UserName = "Leah@wingtiptoys.com",
                    Email = "Leah@wingtiptoys.com",
                    FirstName = "Penelope",
                    LastName = "Leah",
                    ImagePath = "planepaper.png",
                    Manager = false
                }
            };

            return products;
        }
    }
}