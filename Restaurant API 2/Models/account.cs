//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant_API_2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string full_name { get; set; }
        public Nullable<int> role { get; set; }
    }
}
