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
    
    public partial class Right
    {
        public Right()
        {
            this.RoleRights = new HashSet<RoleRight>();
        }
    
        public int RightId { get; set; }
        public string RightName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual ICollection<RoleRight> RoleRights { get; set; }
    }
}
