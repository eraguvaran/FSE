//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterClone_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tweet
    {
        public int tweet_id { get; set; }
        public int user_id { get; set; }
        public string message { get; set; }
        public System.DateTime created { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
