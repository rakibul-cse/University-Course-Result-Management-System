using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UCRMS.DAL
{
    public class EnrollCourseGetway
    {
        SqlConnection con=new SqlConnection(DBConnector.ConnString());
        internal string SaveCourseEnroll(Models.EnrollCourses enrollCourses)
        {
            string Query = @"INSERT INTO [EnrollCourse]
           ([RegID]
           ,[CourseID]
           ,[Date]          
           ,[Adby]
           ,[Addate])
     VALUES
           ('" + enrollCourses.RegNo + "','" + enrollCourses.Course + "','" +enrollCourses.Date + "','Sojol',GETDATE())";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }
    }
}