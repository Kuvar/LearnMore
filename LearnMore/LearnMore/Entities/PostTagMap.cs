//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostTagMap
    {
        public int Id { get; set; }
        public int Post_id { get; set; }
        public int Tag_id { get; set; }
    
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}