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
    
    public partial class RequestAsset
    {
        public int RequestAssetId { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> RequestTypeId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<int> RequestBy { get; set; }
        public Nullable<int> StatusRequestId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual RequestType RequestType { get; set; }
        public virtual StatusRequest StatusRequest { get; set; }
    }
}