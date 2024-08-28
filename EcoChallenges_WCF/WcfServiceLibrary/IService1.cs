using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace WcfServiceLibrary
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IService1
  {
    // User
    [OperationContract]
    UserList GetAllUsers();

    [OperationContract]
    string GetUserName(string email);

    [OperationContract]
    string GetUserPassword(string email);

    [OperationContract]
    int SetUserPassword(string email, string password);

    [OperationContract]
    bool UserExists(string email);

    [OperationContract]
    int AddUser(User user);

    [OperationContract]
    int UpdateUser(User user);

    [OperationContract]
    int DeleteUser(string email, string password);

    [OperationContract]
    int AddUserPoints(string email, int points);

    [OperationContract]
    bool AdminExists(string email, string password);

    // City
    [OperationContract]
    CityList GetAllCities();

    [OperationContract]
    City GetCityByName(string name);

    [OperationContract]
    City GetCityById(int id);

    [OperationContract]
    List<City> OrderByCityName();

    // Challenge
    [OperationContract]
    ChallengeList GetAllChallenges();

    [OperationContract]
    Challenge GetChallenge(int id);

    [OperationContract]
    int AddChallenge(Challenge challenge);

    [OperationContract]
    int UpdateChallenge(Challenge challenge);

    [OperationContract]
    int DeleteChallenge(int id);

    // UserChallenge
    [OperationContract]
    List<UserChallenge> GetAllChallengesByUser(string email);

    [OperationContract]
    List<UserChallenge> GetAllCompletedChallenges(int id);

    [OperationContract]
    UserChallenge GetUserChallenge(int id, string email);

    [OperationContract]
    int AddUserChallenge(UserChallenge challenge);

    [OperationContract]
    int CompleteUserChallenge(int id, string email, string comment);

    [OperationContract]
    int DeleteUserChallenge(int id, string email);

    // Message
    [OperationContract]
    MessageList GetAllMessages();

    [OperationContract]
    int CreateMessage(Message message);

    [OperationContract]
    int DeleteMessage(int id);

    [OperationContract]
    int MarkMessageAsRead(int id, bool isRead);
  }
}
