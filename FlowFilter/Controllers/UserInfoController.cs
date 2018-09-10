using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FlowFilter.Data;
using FlowFilter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FlowFilter.Controllers
{
    [Authorize(Roles = "UserInfo")]
    public class UserInfoController : Controller
    {
        private readonly FlowFilterContext db;
        public UserInfoController(FlowFilterContext context)
        {
            db = context;
        }
        public IActionResult UserList()
        {
            return View();
        }
        public IActionResult AccessList()
        {
            return View();
        }

        public async Task<IActionResult> GetUserList(int page = 1, int limit = 10)
        {
            var users = db.UserInfos.AsNoTracking().Select(s => new
            {
                s.Id,
                s.Name,
                s.Tag,
                CreateTime = s.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                LastLoginTime = s.LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss"),
            });
            var retList = new
            {
                code = 0,
                msg = "",
                count = users?.Count(),
                data = users?.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        public async Task<IActionResult> GetAccessList(int page = 1, int limit = 10)
        {
            var users = db.UserInfos.AsNoTracking().Select(s => new
            {
                s.Id,
                s.Name,
                s.UserAccess
            });
            JArray jArray = new JArray();
            await users.ForEachAsync(u =>
            {
                JObject jObject = new JObject();
                jObject.Add("Id", u.Id);
                jObject.Add("Name", u.Name);
                Enum.GetValues(typeof(Access)).Cast<Access>().ToList().ForEach(s =>
                {
                    jObject.Add(s.ToString(), (u.UserAccess & s) == s);
                });
                jArray.Add(jObject);
            });

            var retList = new
            {
                code = 0,
                msg = "",
                count = jArray?.Count(),
                data = jArray?.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        [HttpPost]
        public async Task<IActionResult> SetAccess(int userId, Access access, bool on)
        {
            var user = await db.UserInfos.FindAsync(userId);
            if (user == null)
            {
                return Content("target error");
            }
            if (on)
            {
                user.UserAccess = user.UserAccess | access;
            }
            else
            {
                user.UserAccess = user.UserAccess & ~access;
            }
            
            await db.SaveChangesAsync();
            return Content("Ok");
        }

        [HttpPost]
        public async Task<IActionResult> AddAllAccessToSelectedUser(List<UserInfo> userIdList)
        {
            foreach (var each in userIdList)
            {
                var user = await db.UserInfos.FindAsync(each.Id);
                if (user == null)
                {
                    return BadRequest("user does not exsit");
                }
                user.UserAccess = (Enum.GetValues(typeof(Access)).Cast<Access>().Aggregate(((i, i1) => i | i1)));
            }
            await db.SaveChangesAsync();
            return Content("Ok");
        }


        [HttpPost]
        public async Task<IActionResult> ChangeOwnPassword(string oldPassword, string newPassword)
        {
            var userIdStr = User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr))
            {
                return BadRequest();
            }
            if (int.TryParse(userIdStr, out int userId) == false)
            {
                return BadRequest();
            }
            var passwordSha1Base64 =
                Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(oldPassword)));
            var user = await db.UserInfos.FirstOrDefaultAsync(s=>s.Id == userId && s.Password == passwordSha1Base64);
            if (user == null)
            {
                return Content("error");
            }
            var newPasswordSha1Base64 =
                Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword)));
            user.Password = newPasswordSha1Base64;
            await db.SaveChangesAsync();
            return Content("Ok");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(int userId, string newPassword)
        {
            var newPasswordSha1Base64 =
                Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword)));
            var user = await db.UserInfos.FindAsync(userId);
            if (user == null)
            {
                return Content("target error");
            }
            user.Password = newPasswordSha1Base64;
            await db.SaveChangesAsync();
            return Content("Ok");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserInfo(int userId, string username, string tag)
        {
            var user = await db.UserInfos.FindAsync(userId);
            if (user == null)
            {
                return Content("target error");
            }
            user.Name = username;
            user.Tag = tag;
            await db.SaveChangesAsync();
            return Content("Ok");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await db.UserInfos.FindAsync(userId);
            if (user == null)
            {
                return Content("target error");
            }
            db.Remove(user);
            await db.SaveChangesAsync();
            return Content("Ok");
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string username, string tag, string password, bool allAccess)
        {
            var user = new UserInfo()
            {
                Name = username,
                CreateTime = DateTime.Now,
                Password = Convert.ToBase64String(SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))),
                Tag = tag,
                UserAccess = allAccess ? (Enum.GetValues(typeof(Access)).Cast<Access>().Aggregate(((i, i1) => i | i1))) : 0
            };
            db.UserInfos.Add(user);
            await db.SaveChangesAsync();
            return Content("Ok");
        }
    }
}