using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UCRMS.DAL
{
    public class RoomAllocateGetway
    {
        SqlConnection con=new SqlConnection(DBConnector.ConnString());
        internal string SaveRoomAllocate(Models.RoomAllocate roomAllocate)
        {
            try
            {
                string Query = @"INSERT INTO [ClassRoomAllocate]
           ([DeptID]
           ,[CourseID]
           ,[RoomNo]
           ,[Day]
           ,[Fromday]
           ,[Today]
           ,[Adby]
           ,[Addate])
     VALUES
           ('" +roomAllocate.Department + "','" + roomAllocate.CourseID+ "','" +roomAllocate.RoomNo+ "','" + roomAllocate.Day + "','" + roomAllocate.From + "','" + roomAllocate.To+ "','Sojol',GETDATE())";
                int rowEffect = DataTransfection.ExecuteNonQuery(Query);
                if (rowEffect > 0)
                {
                    return "Record is/are Saved Sucessfully....!!";
                }
                else
                    throw new Exception("Record Save Failed....!!! ");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}