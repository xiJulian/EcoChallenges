using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;
using Model;

namespace WcfServiceLibrary
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  public class Service1 : IService1
  {
    UserDB userDB = new UserDB();
    CityDB cityDB = new CityDB();
    ChallengeDB challengeDB = new ChallengeDB();
    UserChallengeDB userChallengeDB = new UserChallengeDB();
    MessageDB messageDB = new MessageDB();

    // User
    public UserList GetAllUsers()
    {
      return userDB.SelectAll();
    }

    public string GetUserName(string email)
    {
      return userDB.SelectUserNameByEmail(email);
    }

    public string GetUserPassword(string email)
    {
      return userDB.SelectUserPasswordByEmail(email);
    }

    public int SetUserPassword(string email, string password)
    {
      return userDB.UpdateUserPasswword(email, password);
    }

    public bool UserExists(string email)
    {
      return userDB.UserExists(email);
    }

    public int AddUser(User user)
    {
      return userDB.AddUser(user);
    }

    public int UpdateUser(User user)
    {
      return userDB.UpdateUser(user);
    }

    public int DeleteUser(string email, string password) {
      return userDB.DeleteUser(email, password);
    }

    public int AddUserPoints(string email, int points)
    {
      return userDB.AddUserPoints(email, points);
    }

    public bool AdminExists(string email, string password)
    {
      return userDB.AdminExists(email, password);
    }

    // City
    public CityList GetAllCities()
    {
      return cityDB.SelectAll();
    }

    public City GetCityByName(string name) {
      return cityDB.SelectCityByName(name);
    }

    public City GetCityById(int id)
    {
      return cityDB.SelectCityById(id);
    }

    public List<City> OrderByCityName()
    {
      return cityDB.OrderByCityName();
    }

    // Challenge
    public ChallengeList GetAllChallenges()
    {
      return challengeDB.SelectAll();
    }

    public Challenge GetChallenge(int id)
    {
      return challengeDB.SelectChallengeById(id);
    }

    public int AddChallenge(Challenge challenge)
    {
      return challengeDB.AddChallenge(challenge);
    }

    public int UpdateChallenge(Challenge challenge)
    {
      return challengeDB.UpdateChallenge(challenge);
    }

    public int DeleteChallenge(int id)
    {
      return challengeDB.DeleteChallenge(id);
    }

    // UserChallenge
    public List<UserChallenge> GetAllChallengesByUser(string email)
    {
      return userChallengeDB.SelectAllByUser(email);
    }

    public List<UserChallenge> GetAllCompletedChallenges(int id)
    {
      return userChallengeDB.SelectCompletedAllById(id);
    }

    public UserChallenge GetUserChallenge(int id, string email)
    {
      return userChallengeDB.SelectChallengeByIdAndEmail(id, email);
    }

    public int AddUserChallenge(UserChallenge challenge)
    {
      return userChallengeDB.AddChallenge(challenge);
    }

    public int CompleteUserChallenge(int id, string email, string comment)
    {
      return userChallengeDB.CompleteChallenge(id, email, comment);
    }

    public int DeleteUserChallenge(int id, string email)
    {
      return userChallengeDB.DeleteChallenge(id, email);
    }


    // Message
    public MessageList GetAllMessages()
    {
      return messageDB.SelectAll();
    }

    public int CreateMessage(Message message)
    {
      return messageDB.CreateMessage(message);
    }

    public int DeleteMessage(int id)
    {
      return messageDB.DeleteMessage(id);
    }

    public int MarkMessageAsRead(int id, bool isRead)
    {
      return messageDB.MarkMessageAsRead(id, isRead);
    }
  }
}
