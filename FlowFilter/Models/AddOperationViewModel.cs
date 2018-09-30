using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public class AddOperationViewModel
    {
        [Required]
        public PROTOCOL_FIELD Field { get; set; }
        [Required]
        public AppOperationType Type { get; set; }
        [Required]
        public UInt64 Para { get; set; }
        [Required]
        public int AppRuleId { get; set; }
    }
}
