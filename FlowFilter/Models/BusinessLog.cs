using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public class BusinessLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int RuleId { get; set; }
        public DateTime LogTime { get; set; }
        public string SrcMAC { get; set; }
        public string DstMAC { get; set; }
    }
}
