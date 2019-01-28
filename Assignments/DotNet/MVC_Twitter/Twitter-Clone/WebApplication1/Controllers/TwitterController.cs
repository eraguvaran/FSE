using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone_MVC_WebAPI.Models;
using TwitterClone_MVC_WebAPI.Repository;

namespace TwitterClone_MVC_WebAPI.Controllers
{
  public class TwitterController : Controller
  {
    TwitterRepository _Repository = new TwitterRepository();

    [HttpGet]
    public ActionResult Home()
    {
      TwitterModal _twitterModal = new TwitterModal();
      Person userModel;
      if (Session["UserInfo"] != null)
      {
        userModel = (Person)Session["UserInfo"];
        _twitterModal._person.fullname = userModel.fullname;
        _twitterModal._person.email = userModel.email;
        _twitterModal._person.user_id = userModel.user_id;
        _twitterModal._tweets = _Repository.getAllUserTweets(userModel.user_id);
        _twitterModal._following = _Repository.getFollowings(userModel.user_id);
        _twitterModal._follower = _Repository.getFollowers(userModel.user_id);
      }
      return View(_twitterModal);
    }

    [ChildActionOnly]
    public PartialViewResult GetTweetMessages(int userId)
    {
      if (Session["UserInfo"] != null && userId == 0)
      {
        Person userModel = (Person)Session["UserInfo"];
        userId = userModel.user_id;
      }
      List<Tweet> _Tweets = new List<Tweet>();
      try
      {
        _Tweets = _Repository.getAllTweets(userId);
      }
      catch (Exception ex)
      {
        AddErrors(ex, "Twitter", "GetTweetMessages");
      }
      return PartialView("Tweets", _Tweets);
    }

    public ActionResult SearchUsersByName(string name)
    {
      List<Person> lstFollower = new List<Person>();
      string isValidUser = string.Empty;
      lstFollower = _Repository.getUser(name);

      return Json(new { lstFollower = lstFollower, isValid = lstFollower.Any()?"User Found":"No user Found" }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult AddFollower(string name)
    {
      List<Person> lstFollower = new List<Person>();
      string message = string.Empty;
      int userId = 0;
      if (Session["UserInfo"] != null && userId == 0)
      {
        Person userModel = (Person)Session["UserInfo"];
        userId = userModel.user_id;
      }
      string isValidUser = string.Empty;
      lstFollower = _Repository.AddFollowerByUser(userId, name, out message);

      return Json(new { lstFollower = lstFollower, isValid = message }, JsonRequestBehavior.AllowGet);
    }
    

    [HttpPost]
    [AllowAnonymous]
    public ActionResult AddTweet(TwitterModal _twitterModal)
    {
      string _ValidationMessage = string.Empty;
      try
      {
        if (Session["UserInfo"] != null)
        {
          Person userModel = (Person)Session["UserInfo"];
          Tweet tweet = new Tweet
          {
            user_id = userModel.user_id,
            fullname = userModel.fullname,
            message = _twitterModal._myTweet.message,
            created = DateTime.Now,

          };

          _Repository.SaveTweet(tweet, userModel.user_id, out _ValidationMessage);

        }
        else
        {
          return RedirectToAction("Login", "User");
        }

      }
      catch (Exception ex)
      {
        AddErrors(ex, "Twitter", "AddTweet");
      }
      return RedirectToAction("Home", "Twitter");
    }

    public ActionResult GetUsers(string type)
    {
      TwitterModal lst = new TwitterModal();
      try
      {
        if (Session["UserInfo"] != null)
        {
          Person userModel = (Person)Session["UserInfo"];
          if (type == "follow")
          {
            var userList = _Repository.getFollowers(userModel.user_id);
            userList.ToList().ForEach(x =>
            lst._follower.Add(new Follower()
            {
              user_id = x.user_id,
              follower_Id = x.follower_Id,
              followerUserName = x.followerUserName,
              userName = x.userName

            }));
          }
          else
          {
            var userList = _Repository.getFollowings(userModel.user_id);
            userList.ToList().ForEach(x =>
            lst._following.Add(new Following()
            {
              user_id = x.user_id,
              following_Id = x.following_Id,
              followingUserName = x.followingUserName,
              userName = x.userName

            }));
          }

        }

      }
      catch (Exception ex)
      {
        AddErrors(ex, "Twitter", "getusers");
      }
      if (type == "follow")
        return Json(new { lst._follower }, JsonRequestBehavior.AllowGet);
      else
        return Json(new { lst._following }, JsonRequestBehavior.AllowGet);
    }

    private void AddErrors(Exception error, string controller, string action)
    {
      ErrLog.WriteLog(error, controller, action);
      ModelState.AddModelError("", error);
    }

    protected override void OnException(ExceptionContext filterContext)
    {
      filterContext.ExceptionHandled = true;
      Exception ex = filterContext.Exception;
      string controller = filterContext.RouteData.Values["controller"].ToString();
      string action = filterContext.RouteData.Values["action"].ToString();
      ErrLog.WriteLog(ex, controller, action);
      filterContext.Result = View("Error");
    }
  }
}