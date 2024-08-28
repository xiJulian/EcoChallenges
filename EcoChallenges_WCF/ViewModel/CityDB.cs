using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace ViewModel
{
  public class CityDB : DBFunctions
  {
    private CityList list = new CityList();

    private City CreateModel(City city)
    {
      city.id = (int)reader["id"];
      city.name = reader["name"].ToString();
      return city;
    }

    public City SelectCityByName(string name)
    {
      list = SelectAll();
      City city = list.Find(item => item.name == name);
      return city;
    }

    public City SelectCityById(int id)
    {
      list = SelectAll();
      City city = list.Find(item => item.id == id);
      return city;
    }

    public List<City> OrderByCityName()
    {
      list = SelectAll();
      return list.OrderBy(item => item.name).ToList();
    }

    public CityList SelectAll()
    {
      try
      {
        string sqlStr = "SELECT * FROM city";
        cmd = GenerateOleDBCommand(sqlStr, "EcoChallenges.accdb");
        conObj.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          City city = new City();
          list.Add(CreateModel(city));
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
        if (this.conObj.State == System.Data.ConnectionState.Open)
          this.conObj.Close();
      }
      return list;
    }
  }
}
