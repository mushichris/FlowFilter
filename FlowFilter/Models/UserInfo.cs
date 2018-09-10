using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public class UserInfo
    {
        public const string Salt = "GongXing";
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "用户Id")]
        public int Id { get; set; }
        [Required, MaxLength(128), Display(Name = "用户名")]
        public string Name { get; set; }
        [MaxLength(128), Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [Display(Name = "最后登录时间")]
        public DateTime LastLoginTime { get; set; }
        [MaxLength(128), Display(Name = "备注")]
        public string Tag { get; set; }
        [Required, Display(Name = "用户权限")]
        public Access UserAccess { get; set; }

    }

    [Flags]
    public enum Access
    {
        Home = 0x01,
        AppRule = 0x02,
        Log = 0x04,
        UserInfo = 0x08
    }
}
