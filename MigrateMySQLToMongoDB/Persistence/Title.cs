using System;
using MongoDB.Bson;
namespace Persistence
{
  public class Title
  {
    public Title(DateTime fromDate, string empTitle, DateTime toDate)
    {
      FromDate = fromDate;
      EmpTitle = empTitle;
      ToDate = toDate;
    }

    public int EmpNo { set; get; }
    public DateTime FromDate { get; set; }
    public string EmpTitle { get; set; }
    public DateTime ToDate { get; set; }
  }
}
