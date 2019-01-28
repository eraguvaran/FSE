using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone_MVC_WebAPI.Models
{
  public class Follower
  {
     
    public int FR_ID { get; set; }
    public int user_id { get; set; }

    public int follower_Id { get; set; }

    public string userName { get; set; }

    public string followerUserName { get; set; }
  }
}