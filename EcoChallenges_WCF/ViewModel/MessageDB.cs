using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;

namespace ViewModel
{
  public class MessageDB : DBFunctions
  {
    DBFunctions dbf = new DBFunctions();

    public MessageDB() : base() { }

    private Message CreateModel(Message message) {
      message.id = (int)reader["id"];
      message.email = reader["email"].ToString();
      message.subject = reader["subject"].ToString();
      message.content = reader["content"].ToString();
      message.sentAt = Convert.ToDateTime(reader["sentAt"]).ToString("dd/MM/yyyy HH:mm");
      message.isRead = (bool)reader["isRead"];
      return message;
    }

    public MessageList SelectAll()
    {
      MessageList list = new MessageList();
      try
      {
        string sqlStr = "SELECT * FROM message";
        cmd = GenerateOleDBCommand(sqlStr, "EcoChallenges.accdb");
        conObj.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          Message message = new Message();
          list.Add(CreateModel(message));
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

    public int CreateMessage(Message message)
    {
      string insertSql = string.Format("INSERT INTO [message] (email, subject, content, isRead) values ('{0}', '{1}', '{2}', 0)", message.email, message.subject, message.content);
      return dbf.ChangeTable(insertSql, "EcoChallenges.accdb");
    }

    public int DeleteMessage(int id)
    {
      string delSql = string.Format("DELETE FROM [message] WHERE id={0}", id);
      return dbf.ChangeTable(delSql, "EcoChallenges.accdb");
    }

    public int MarkMessageAsRead(int id, bool isRead)
    {
      string updateSql = string.Format("UPDATE [message] SET isRead={0} WHERE id={1}", isRead ? 1 : 0, id);
      return dbf.ChangeTable(updateSql, "EcoChallenges.accdb");
    }
  }
}
