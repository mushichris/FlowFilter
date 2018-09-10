using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowFilter.Models
{
    public class AddActionViewModel
    {
        [Required]
        public PROTOCOL_FIELD Field { get; set; }
        [Required]
        public AppActionType Type { get; set; }
        public UInt32 Para { get; set; }
        [Required]
        public int AppRuleId { get; set; }
    }
}
