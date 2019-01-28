using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone_MVC_WebAPI.Models
{
  public class Following
  {
     
    public int FG_ID { get; set; }
    public int user_id { get; set; }
    public int following_Id { get; set; }

    public string userName { get; set; }

    public string followingUserName { get; set; }
  }
}