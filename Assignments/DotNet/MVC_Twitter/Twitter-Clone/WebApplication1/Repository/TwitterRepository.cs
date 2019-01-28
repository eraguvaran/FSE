using CommonCommunicationHelper.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone_BAL;
using TwitterClone_DAL;
using DTO = CommonCommunicationHelper.DTO;
using Model = TwitterClone_MVC_WebAPI.Models;

namespace TwitterClone_MVC_WebAPI.Repository
{
  public class TwitterRepository
  {
    TwitterService _twitterService = new TwitterService();
    public ValidationResult AddUser(Model.Person model, out string _ValidationMessage)
    {
      ValidationResult _validationResult = new ValidationResult();
      _ValidationMessage = string.Empty;
      try
      {
        Person _dtoPerson = new Person { active = true, email = model.email, fullname = model.fullname, password = model.password, username = model.username, joined = DateTime.Now };
        _validationResult = _twitterService.AddUser(_dtoPerson, out _ValidationMessage);
        return ValidationResult.Sucess;
      }
      catch (Exception)
      {

        return ValidationResult.failure;
      }

      finally
      {

      }

    }


    public ValidationResult Validate(string uname, string pwd, out string _ValidationMessage, out Model.Person model)
    {
      ValidationResult _validationResult = new ValidationResult();
      model = new Model.Person();
      _ValidationMessage = string.Empty;
      try
      {
        Person _dtoPerson;

        _validationResult = _twitterService.ValidateUser(uname, pwd, out _ValidationMessage, out _dtoPerson);
        model = new Model.Person { active = _dtoPerson.active, email = _dtoPerson.email, fullname = _dtoPerson.fullname, password = _dtoPerson.password, user_id = _dtoPerson.user_id, username = _dtoPerson.username, joined = _dtoPerson.joined };
        return _validationResult;
      }
      catch (Exception)
      {

        return ValidationResult.failure;
      }

      finally
      {

      }

    }

    public List<Model.Tweet> getAllTweets(int userId)
    {
      List<Model.Tweet> _Tweets = new List<Model.Tweet>();
      //List<Tweet> _tweets = new List<Tweet>();
      List<DTO.Tweet> _tweets = new List<DTO.Tweet>();

      _twitterService.GetTweets(userId, out _tweets);
      foreach (var s in _tweets)
      {
        _Tweets.Add(new Model.Tweet
        {
          message = s.message,
          created = s.created,
          user_id = s.user_id,
          fullname = s.fullname,
          tweet_id = s.tweet_id,
          DateTwitted = s.created.ToLongDateString(),
        });
      }
      return _Tweets;
    }
    public List<Model.Tweet> getAllUserTweets(int userId)
    {
      List<Model.Tweet> _Tweets = new List<Model.Tweet>();
      //List<Tweet> _tweets = new List<Tweet>();
      List<DTO.Tweet> _tweets = new List<DTO.Tweet>();

      _twitterService.GetTweetsForUser(userId, out _tweets);
      foreach (var s in _tweets)
      {
        _Tweets.Add(new Model.Tweet
        {
          message = s.message,
          created = s.created,
          user_id = s.user_id,
          fullname = s.fullname,
          tweet_id = s.tweet_id,
          DateTwitted = s.created.ToLongDateString(),
        });
      }
      return _Tweets;
    }
    public ValidationResult SaveTweet(Model.Tweet _tweetModel, int userId, out string _ValidationMessage)
    {
      ValidationResult _validationResult = new ValidationResult();
      _ValidationMessage = string.Empty;

      TwitterClone_DAL.Tweet _tweet;
      try
      {
        _tweet = new TwitterClone_DAL.Tweet { user_id = _tweetModel.user_id, created = _tweetModel.created, message = _tweetModel.message };
        _validationResult = _twitterService.SaveTweet(_tweet, userId, out _ValidationMessage);


        return _validationResult;

      }
      catch (Exception)
      {

        return ValidationResult.failure;
      }

      finally
      {

      }
    }

    public List<Model.Person> getUser(string userName)
    {
      List<Model.Person> _follower = new List<Model.Person>();
      var result = _twitterService.GetUsers(userName);

      foreach (var item in result)
      {
        _follower.Add(new Model.Person
        {
          username = item.username,
          user_id = item.user_id,
          fullname = item.fullname
        });
      }

      return _follower;
    }

    public List<Model.Person> AddFollowerByUser(int userID, string userName, out string message)
    {
      List<Model.Person> _follower = new List<Model.Person>();
      var result = _twitterService.AddFollowerByUser(userID, userName, out message);

    
        _follower.Add(new Model.Person
        {
          username = result.username,
          user_id = result.user_id,
          fullname = result.fullname
        });
      

      return _follower;
    }

    public List<Model.Follower> getFollowers(int userId)
    {
      List<Model.Follower> _follower = new List<Model.Follower>();
      var result = _twitterService.GetFollowers(userId);

      foreach (var item in result)
      {
        _follower.Add(new Model.Follower
        {
          follower_Id = item.follower_id,
          user_id = item.user_id,
          followerUserName = item.Person.username,
          userName = item.Person1.username
        });
      }

      return _follower;
    }

    public List<Model.Following> getFollowings(int userId)
    {
      List<Model.Following> _followings = new List<Model.Following>();
      var result = _twitterService.GetFollowings(userId);

      foreach (var item in result)
      {
        _followings.Add(new Model.Following
        {
          following_Id = item.following_id,
          user_id = item.user_id,
          followingUserName = item.Person1.username,
          userName = item.Person.username
        });
      }

      return _followings;
    }
  }
}