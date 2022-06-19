using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppManager.Models
{
    public class ItemModel
    {

        [Key]
        public int ItemID { get; set; }

        [Required]
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }


        [ForeignKey("ActivityModel")]
        public List<ActivityModel> ActivityID { get; set; }

        public string OwnerID { get; set; }
        public virtual ICollection<ActivityModel> Activities { get; set; }

    }
}
