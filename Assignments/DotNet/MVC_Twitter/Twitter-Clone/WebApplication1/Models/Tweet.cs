using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TwitterClone_MVC_WebAPI.Models
{
  public class Tweet
  { 
    //[DisplayName("Tweet#")] 
    public int tweet_id { get; set; }
    public int user_id { get; set; }

    [DisplayName("Name")]
    public string fullname { get; set; }

    [DisplayName("Tweet")]
    public string message { get; set; }

    [DisplayName("When")]
    public DateTime created { get; set; }

    public string DateTwitted { get; set; }
  }
}