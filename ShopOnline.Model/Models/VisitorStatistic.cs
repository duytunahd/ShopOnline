using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model.Models
{
    [Table("VisitorStatistics")]
    class VisitorStatistic
    {
        [Key]

        public Guid ID { get; set; }

        [Required]
        public DateTime VisitedDate { get; set; }
        [MaxLength(50)]
        [Required]
        public string IPAddress { get; set; }
    }
}
