using System;

namespace ShopOnline.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDated { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
        string MetaKeyword { get; set; }
        bool Status { get; set; }
    }
}