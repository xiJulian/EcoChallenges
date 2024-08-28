using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using Model;

namespace ViewModel
{
  public class UserChallengeDB : DBFunctions
  {

    DBFunctions dbf = new DBFunctions();

    public UserChallengeDB() : base() { }

    private UserChallenge CreateModel(UserChallenge challenge)
    {
      challenge.challengeId = (int)reader["challengeId"];
      challenge.userEmail = reader["userEmail"].ToString();
      challenge.startedAt = Convert.ToDateTime(reader["startedAt"]).ToString("dd/MM/yyyy HH:mm");
      challenge.completedAt = reader["completedAt"] != DBNull.Value ? Convert.ToDateTime(reader["completedAt"]).ToString("dd/MM/yyyy HH:mm") : null;
      challenge.isCompleted = (bool)reader["isCompleted"];
      challenge.comment = reader["comment"] != DBNull.Value ? reader["comment"].ToString() : null;
      return challenge;
    }

    public UserChallengeList SelectAll()
    {
      UserChallengeList list = new UserChallengeList();
      try
      {
        string sqlStr = "SELECT * FROM userChallenge";
        cmd = GenerateOleDBCommand(sqlStr, "EcoChallenges.accdb");
        conObj.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          UserChallenge challenge = new UserChallenge();
          list.Add(CreateModel(challenge));
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

    public List<UserChallenge> SelectAllByUser(string email)
    {
      UserChallengeList list = SelectAll();
      return list.FindAll(item => item.userEmail == email);
    }

    public UserChallenge SelectChallengeByIdAndEmail(int id, string email)
    {
      UserChallengeList list = SelectAll();
      UserChallenge challenge = list.Find(item => item.challengeId == id && item.userEmail == email);
      return challenge;
    }

    public List<UserChallenge> SelectCompletedAllById(int id)
    {
      UserChallengeList list = SelectAll();
      return list.FindAll(item => item.isCompleted && item.challengeId == id);
    }

    public int AddChallenge(UserChallenge challenge)
    {
      string insertSql = string.Format("INSERT INTO userChallenge (challengeId, userEmail, isCompleted) values ({0}, '{1}', 0)", challenge.challengeId, challenge.userEmail);
      return dbf.ChangeTable(insertSql, "EcoChallenges.accdb");
    }

    public int CompleteChallenge(int id, string email, string comment)
    {
      string updateSql = string.Format("UPDATE userChallenge SET completedAt=Now(), isCompleted=1, comment='{0}' WHERE challengeId={1} AND userEmail='{2}'", comment, id, email);
      return dbf.ChangeTable(updateSql, "EcoChallenges.accdb");
    }

    public int DeleteChallenge(int id, string email)
    {
      string delSql = string.Format("DELETE FROM userChallenge WHERE challengeId={0} AND userEmail='{1}'", id, email);
      return dbf.ChangeTable(delSql, "EcoChallenges.accdb");
    }
  }
}
