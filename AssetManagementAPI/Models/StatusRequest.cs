//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssetManagementAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StatusRequest
    {
        public StatusRequest()
        {
            this.RequestAssets = new HashSet<RequestAsset>();
        }
    
        public int StatusRequestId { get; set; }
        public string StatusRequestName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual ICollection<RequestAsset> RequestAssets { get; set; }
    }
}
