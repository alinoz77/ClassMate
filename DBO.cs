using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;
using ClassMate.Output;

namespace ClassMate.DBO
{
    public class DBOHandler {
        string remoteConnectionString = "Server=tcp:classmate.database.windows.net,1433;Database=ClassMate;User ID=sefu@classmate;Password=qwerty21!;TrustServerCertificate=False;Connection Timeout=30;";
        string cloudConnectionString = "Server=tcp:classmate.database.windows.net,1433;Database=ClassMate;User ID=sefu@classmate;Password=qwerty21!;TrustServerCertificate=False;Connection Timeout=30;Encrypt=True;";
        string connectionString = cloudConnectionString;
        public DBOHandler() {
        } 
       
       public List<OutputData> Query()
       {
           List<OutputData> _templist=new List<OutputData>();
           using(var   conn = new SqlConnection(connectionString)) 
           {
               var cmd = conn.CreateCommand();

               cmd.CommandText = @"select Student.Name, Student.DOB, Headset.Attention, convert(varchar, Headset.ReadDate, 120)
                    from Student,Headset 
                    where Student.HeadsetID = Headset.HeadsetID";
               conn.Open();
               
               using(var reader = cmd.ExecuteReader())
               {
                   while(reader.Read()) {
                       string Name = reader.GetString(0);
                       string DOB = reader.GetString(1);
                       double Value = reader.GetDouble(2);
                       string ReadDate = reader.GetString(3);
                       Console.WriteLine(Name + " - " + DOB + " - " + Value + " - " + ReadDate);
                     OutputData  _tempread = new OutputData(Name, DOB, Value, ReadDate);
                     _templist.Add(_tempread);
                   }
               }
           }  
           return _templist;
       }
    
        public void updatetHeadsetData(int headsetId, int attention) {
            using(var conn = new SqlConnection(connectionString)) 
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE dbo.Headset SET ReadDate=CURRENT_TIMESTAMP, Attention= " + attention + " WHERE HeadsetID=" + headsetId;
                conn.Open();
                cmd.ExecuteScalar();
            }
        }
    }
}
