using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
  public class ChallengeDB : DBFunctions
  {

    DBFunctions dbf = new DBFunctions();

    public ChallengeDB() : base() { }

    private Challenge CreateModel(Challenge challenge)
    {
      challenge.id = (int)reader["id"];
      challenge.title = reader["title"].ToString();
      challenge.description = reader["description"].ToString();
      challenge.points = (int)reader["points"];
      challenge.createdAt = Convert.ToDateTime(reader["createdAt"]).ToString("dd/MM/yyyy");
      return challenge;
    }

    public ChallengeList SelectAll()
    {
      ChallengeList list = new ChallengeList();
      try
      {
        string sqlStr = "SELECT * FROM challenge";
        cmd = GenerateOleDBCommand(sqlStr, "EcoChallenges.accdb");
        conObj.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          Challenge challenge = new Challenge();
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

    public Challenge SelectChallengeById(int id)
    {
      ChallengeList list = SelectAll();
      Challenge challenge = list.Find(item => item.id == id);
      return challenge;
    }

    public int AddChallenge(Challenge challenge)
    {
      string insertSql = string.Format("INSERT INTO challenge (title, description, points) values ('{0}', '{1}', '{2}')", challenge.title, challenge.description, challenge.points);
      return dbf.ChangeTable(insertSql, "EcoChallenges.accdb");
    }

    public int UpdateChallenge(Challenge challenge)
    {
      string updateSql = string.Format("UPDATE challenge SET title='{0}', description='{1}', points={2} WHERE id={3}", challenge.title, challenge.description, challenge.points, challenge.id);
      return dbf.ChangeTable(updateSql, "EcoChallenges.accdb");
    }

    public int DeleteChallenge(int id)
    {
      string delSql = "DELETE FROM challenge WHERE id=" + id;
      return dbf.ChangeTable(delSql, "EcoChallenges.accdb");
    }
  }
}
