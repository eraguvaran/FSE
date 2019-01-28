using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone_MVC_WebAPI;
using TwitterClone_MVC_WebAPI.Models;
using TwitterClone_MVC_WebAPI.Repository;

namespace TwitterClone_MVC_WebAPI.Controllers
{
  public class UserController : Controller
  {
    TwitterRepository _Repository = new TwitterRepository();
    // GET: Twitter
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Home()
    {
      return View();
    }

    [HttpGet]
    public ActionResult SignUp()
    {
      return View();
    }


    [HttpPost]
    public ActionResult SignUp(Person model)
    {
      string _ValidationMessage = string.Empty;

      _Repository.AddUser(model, out _ValidationMessage);
      TempData["Message"] = _ValidationMessage;

      if (_ValidationMessage.Contains("Success"))
        return RedirectToAction("Login");
      else
        return View();
    }

    //public ActionResult Validate(string uname, string pwd)
    //{
    //  User obj = db.Validate(uname, pwd);
    //  if (obj != null)
    //  {
    //    return RedirectToAction("Details", obj);
    //  }
    //  else if (uname == "Admin" && pwd == "Admin")
    //  {
    //    return RedirectToAction("GetAll");
    //  }
    //  else
    //  {
    //    TempData["err"] = "Invalid Login Details";
    //    return RedirectToAction("Login");
    //  }

    //}

    public ActionResult Logout()
    {
      Session.Clear();
      return RedirectToAction("Login", "User");
    }

    [HttpGet]
    public ActionResult Login()
    {
      Session.Clear();
      return View();
    }


    [HttpPost]
    public ActionResult Login(Person model)
    {

      Person _Resultmodel = new Person();
      //if (ModelState.IsValid)
      {
        string _ValidationMessage = string.Empty;
        try
        {
          _Repository.Validate(model.username, model.password, out _ValidationMessage, out _Resultmodel);
          TempData["Message"] = _ValidationMessage;
          Session["UserInfo"] = _Resultmodel;
        }
        catch (Exception ex)
        {
          AddErrors(ex, "User", "Login");
        }
      }
      if (_Resultmodel.user_id != 0)
        return RedirectToAction("Home", "Twitter");
      else
        return View();
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