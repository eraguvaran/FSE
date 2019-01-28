using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TwitterClone_MVC_WebAPI.Models
{
  public class Person
  {
   
    [Required(ErrorMessage = "required")]
    [DisplayName("UserName")]
    public string username { get; set; }
    public int user_id { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "required")]
    [DisplayName("Password")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    public string password { get; set; }

    [Compare("Password", ErrorMessage = "Confirm password dose not match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string confirmpassword { get; set; }

    [Required(ErrorMessage = "required")]
    [DisplayName("FullName")]
    public string fullname { get; set; }

    [Required(ErrorMessage = "required")]
    [EmailAddress(ErrorMessage = "InValid Email")]
    public string email { get; set; }

    public DateTime joined { get; set; }

    public bool active { get; set; }


  }
}