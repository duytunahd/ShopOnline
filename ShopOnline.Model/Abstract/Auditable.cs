using System;
using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDated { get; set; }
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [MaxLength(256)]
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}