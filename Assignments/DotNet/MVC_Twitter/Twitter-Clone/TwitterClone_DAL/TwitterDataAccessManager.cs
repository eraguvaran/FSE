using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using DTO = CommonCommunicationHelper.DTO;

namespace TwitterClone_DAL
{
  public class TwitterDataAccessManager
  {
    DOTNETEntities _TwitterEntity;
    //DbSet<DOTNETEntities> _TwitterEntity;
    public TwitterDataAccessManager()
    {
      _TwitterEntity = new DOTNETEntities();
      //string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    }

    public void getAllFollowingsByUserId(int userid)
    {

      var res = (from d in _TwitterEntity.Followings
                 join b in _TwitterEntity.People on d.user_id equals b.user_id
                 where userid == d.user_id
                 select d).ToList();

    }

    public void getAllTweetsByUserID(int userid)
    {

      List<Tweet> _Tweets = (from p in _TwitterEntity.Tweets
                             join s in _TwitterEntity.People on p.user_id equals s.user_id
                             where p.user_id == userid
                             select p
                            ).ToList();
    }


    public void AddUser(Person model, out string _ValidationMessage)
    {
      _ValidationMessage = string.Empty;
      try
      {

        using (DOTNETEntities _TwitterEntity = new DOTNETEntities())
        {
          Person isExist = (from p in _TwitterEntity.People
                            where p.username == model.username
                            select p).FirstOrDefault();
          if (isExist == null)
          {
            _TwitterEntity.People.Add(model);
            _TwitterEntity.SaveChanges();
            _ValidationMessage = "User " + model.username + " Successfully Created!.";
          }
          else
            _ValidationMessage = "This user " + model.username + " Already Exists!.";
        }

      }
      catch (Exception ex)
      {
        string error = ex.Message;
        throw;
      }


    }


    public void ValidateUser(string uname, string pwd, out string _ValidationMessage, out Person model)
    {
      model = null;
      _ValidationMessage = string.Empty;
      try
      {

        using (DOTNETEntities _TwitterEntity = new DOTNETEntities())
        {
          model = (from p in _TwitterEntity.People
                   where p.username == uname && p.password == pwd && p.active == true
                   select p).FirstOrDefault();
          if (model == null)
          {
            _ValidationMessage = " Invalid UserID/Password !.";
          }
          else
          {
            _ValidationMessage = string.Empty;
          }
        }

      }
      catch (Exception ex)
      {
        string error = ex.Message;
        throw;
      }


    }

    public void SaveTweet(Tweet _tweet, int user_id, out string _ValidationMessage)
    {
      _ValidationMessage = string.Empty;


      using (DOTNETEntities _TwitterEntity = new DOTNETEntities())
      {

        _TwitterEntity.Tweets.Add(_tweet);
        _TwitterEntity.SaveChanges();
        _ValidationMessage = "Tweet Successfully Posted!.";

      }

    }

    public List<DTO.Tweet>  GetTweets(int userId, bool includeFollowersTweet)
    {
      List<Tweet> tweets = new List<Tweet>();
      List<Tweet> _followerTweets = new List<Tweet>();
      List<DTO.Tweet> _Tweets = new List<DTO.Tweet>();

      using (var db = new DOTNETEntities())
      {
        db.Tweets.Where(x => x.user_id == userId).OrderByDescending(z=> z.created).ToList()
            .ForEach(y =>
            tweets.Add(new Tweet()
            {
              tweet_id = y.tweet_id,
              user_id = y.user_id,
              message = y.message,
              created = y.created,
              Person = y.Person

            }));
        if (includeFollowersTweet)
        {
          List<Tweet> _followertweets = (from t in db.Tweets
                                         join fr in db.Followers on t.user_id equals fr.follower_id
                                         join p in db.People on fr.follower_id equals p.user_id
                                         where fr.user_id == userId
                                         select t
                                        ).Distinct().ToList();

          tweets.AddRange(_followertweets);
        }
        tweets = tweets.OrderByDescending(x => x.created).ToList();
        foreach (var s in tweets)
        {
          _Tweets.Add(new DTO.Tweet
          {
            message = s.message,
            created = s.created,// ?? DateTime.Now,
            user_id = s.user_id,
            fullname = s.Person == null ? "" : s.Person.fullname,
            tweet_id = s.tweet_id
          });
        }

      }
      _Tweets.OrderByDescending(s => s.created);
      return _Tweets;
    }

    public List<Follower> GetFollowers(int userId)
    {
      List<Follower> _followers = new List<Follower>();
      using (var db = new DOTNETEntities())
      {

        //_followers = (from t in db.Tweets
        //              join fr in db.Followers on t.user_id equals fr.follower_Id
        //              where fr.user_id == userId
        //              select fr
        //             ).Distinct().ToList();

        db.Followers.Where(x => x.user_id == userId)
          .ToList()
          .ForEach(y =>
          _followers.Add(new Follower()
          {
            user_id = y.user_id,
            follower_id = y.follower_id,
            Person = y.Person,
            Person1 = y.Person1
          }));

      }

      return _followers;
    }


    


    public List<Following> GetFollowings(int userId)
    {
      Collection<Following> follwings = new Collection<Following>();
      using (var db = new DOTNETEntities())
      {
        db.Followers.Where(x => x.follower_id == userId)
            .ToList()
            .ForEach(y =>
            follwings.Add(new Following()
            {
              user_id = y.user_id,
              following_id = y.user_id,
              Person = y.Person,
              Person1 = y.Person1
            }));
      }

      return follwings.ToList();
    }

    public List<Person> GetUser(string userName)
    {
      List<Person> _Person = new List<Person>();
      using (var db = new DOTNETEntities())
      {
        _Person = (from p in db.People
                   where p.username == userName
                   select p).ToList();
          
      }

      return _Person;
    }

    public Person AddFollowerByUser(int userID, string userName, out string message)
    {
      Person _Person = new Person();
      message = string.Empty;
      using (var db = new DOTNETEntities())
      {
        _Person = (from p in db.People
                   where p.username == userName
                   select p).FirstOrDefault();
        
        if (_Person != null && _Person.user_id !=0)
        {
          Follower _addUser = new Follower() { user_id = userID, follower_id = _Person.user_id };
          if (!db.Followers.Where(s => s.user_id == _addUser.user_id && s.follower_id == _addUser.follower_id).Any())
          {
            db.Followers.Add(_addUser);
            db.SaveChanges();
            message = "Follower is added";
          }
          else
          {
            message = "Follower is already in your list!.";
          }
        }
      }
      
      return _Person;
    }
  }
}

