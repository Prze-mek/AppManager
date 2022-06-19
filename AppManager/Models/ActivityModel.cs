using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppManager.Models
{
    public class ActivityModel
    {
        [Key]
        public int ActivityID { get; set; }
        [Required]
        public string ActivityName { get; set; }
        [Required]
        public DateTime ActivityExecuteDate { get; set; }
        public bool Status { get; set; } = false;
    }
}
