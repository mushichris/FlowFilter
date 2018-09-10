using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FlowFilter.Models;

namespace FlowFilter.Data
{
    public class DbInitializer
    {
        public static void Initialize(FlowFilterContext context)
        {
            try
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Whatthfuck!");
            }
            try
            {
                if (!context.UserInfos.Any())
                {
                    var userinfos = new UserInfo()
                    {
                        Id = 1,
                        Name = "admin",
                        Password = Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes("123456"))),
                        UserAccess = (Enum.GetValues(typeof(Access)).Cast<Access>().Aggregate(((i, i1) => i | i1))),
                    };
                    context.UserInfos.Add(userinfos);
                    var abc = new UserInfo()
                    {
                        Id = 2,
                        Name = "user",
                        Password = Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes("123456"))),
                        UserAccess = Access.AppRule,
                    };
                    context.UserInfos.Add(abc);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Whatthfuck!");
            }

        }
    }
}
