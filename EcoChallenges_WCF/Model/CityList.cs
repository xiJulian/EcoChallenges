using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
  public class CityList : List<City>
  {
    public CityList() { }
    public CityList(IEnumerable<City> list) : base(list) { }
    public List<City> OrderByCityName() {
      if (Count > 0) return this.OrderBy(item => item.name).ToList();
      return null;
    }
  }
}
