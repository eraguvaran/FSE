using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone_MVC_WebAPI.Models;

namespace TwitterClone_MVC_WebAPI.Models
{
  public class TwitterModal
  {
    public TwitterModal()
    {
      this._tweets = new List<Tweet>();
      this._follower = new List<Follower>();
      this._following = new List<Following>();
      this._person = new Person();
      this._myTweet = new Tweet();
    }
    public List<Tweet> _tweets { get; set; }
    public List<Follower> _follower { get; set; }
    public List<Following> _following { get; set; }
    public Person _person { get; set; }

    public Tweet _myTweet { get; set; }

  }
}