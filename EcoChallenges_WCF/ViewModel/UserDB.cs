using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Model;

namespace ViewModel
{
  public class UserDB : DBFunctions
  {
    DBFunctions dbf = new DBFunctions();
    CityDB cityDB = new CityDB();
    UserList list = new UserList();

    public UserDB() : base() { }

    private User CreateModel(User user)
    {
      user.id = (int)reader["id"];
      user.email = reader["email"].ToString();
      user.firstName = reader["firstName"].ToString();
      user.lastName = reader["lastName"].ToString();
      user.password = reader["password"].ToString();
      user.points = (int)reader["points"];
      int cityId = (int)reader["city"];
      user.city = cityDB.SelectCityById(cityId);
      return user;
    }

    public UserList SelectAll()
    {
      try
      {
        string sqlStr = "SELECT * FROM [user]";
        cmd = GenerateOleDBCommand(sqlStr, "EcoChallenges.accdb");
        conObj.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          User user = new User();
          list.Add(CreateModel(user));
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        if (reader != null)
          reader.Close();
        if (this.conObj.State == ConnectionState.Open)
          this.conObj.Close();
      }
      return list;
    }

    public string SelectUserNameByEmail(string email)
    {
      string sqlStr = string.Format("SELECT firstName FROM [user] WHERE email='{0}'", email);
      DataTable dt = dbf.Select(sqlStr, "EcoChallenges.accdb");
      return dt.Rows[0][0].ToString();
    }

    public string SelectUserPasswordByEmail(string email)
    {
      string sqlStr = string.Format("SELECT password FROM [user] WHERE email='{0}'", email);
      DataTable dt = dbf.Select(sqlStr, "EcoChallenges.accdb");
      return dt.Rows[0][0].ToString();
    }

    public int UpdateUserPasswword(string email, string password)
    {
      string updateSql = string.Format("UPDATE [user] SET [password]='{0}' WHERE email='{1}'", password, email);
      return dbf.ChangeTable(updateSql, "EcoChallenges.accdb");
    }

    public bool UserExists(string email)
    {
      string sqlStr = string.Format("SELECT * FROM [user] WHERE email='{0}'", email);
      DataTable dt = dbf.Select(sqlStr, "EcoChallenges.accdb");
      if (dt == null) return false;
      return dt.Rows.Count > 0;
    }

    public int AddUser(User user)
    {
      string insertSql = string.Format("INSERT INTO [user] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", user.email, user.firstName, user.lastName, user.password, user.city.id, user.points);
      return dbf.ChangeTable(insertSql, "EcoChallenges.accdb");
    }

    public int UpdateUser(User user)
    {
      string updateSql = string.Format("UPDATE [user] SET [firstName]='{0}', [lastName]='{1}', [password]='{2}', [points]={3}, [city]={4} WHERE email='{5}'", user.firstName, user.lastName, user.password, user.points, user.city.id, user.email);
      return dbf.ChangeTable(updateSql, "EcoChallenges.accdb");
    }
    public int DeleteUser(string email, string password)
    {
      string delSql = string.Format("DELETE FROM [user] WHERE email='{0}' AND password='{1}'", email, password);
      return dbf.ChangeTable(delSql, "EcoChallenges.accdb");
    }

    public int AddUserPoints(string email, int points)
    {
      string updateSql = string.Format("UPDATE [user] SET points = points + {0} WHERE email='{1}'", points, email);
      return dbf.ChangeTable(updateSql, "EcoChallenges.accdb");
    }

    public bool AdminExists(string email, string password)
    {
      return dbf.CheckAdmin(email, password);
    }
  }
}
