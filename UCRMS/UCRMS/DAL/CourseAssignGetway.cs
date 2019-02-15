using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS.Models;

namespace UCRMS.DAL
{
    public class CourseAssignGetway
    {
        SqlConnection con=new SqlConnection(DBConnector.ConnString());
        internal string SaveCourseAssain(Models.CourseAssign courseAssign)
        {
            string Query = @"INSERT INTO [CourseAssaign]
           ([DeptID]
           ,[TechID]
           ,[CourseID]
           ,[Credit]
           ,[Addby]
           ,[Addate])
     VALUES
           ('" + courseAssign.Department+ "','" + courseAssign.Teacher+ "','" + courseAssign.CourseID+ "','" + courseAssign.Credit+ "','Sojol',GETDATE())";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }

        internal int GetValidation(string CourseName)
        {
            int dt = DataTransfection.GetShowSingleValueInt("COUNT(*)", "CourseName", "Course", CourseName);
            return dt;
        }

        internal List<Models.CourseAssign> GetAllCourseAssainDetails(string CourseName)
        {
            string Parameter = "";
            if (CourseName != "")
            {
                Parameter = " where Code='" + CourseName + "' ";
            }
            string query = @"SELECT t1.[ID],t2.Name as [Department],t3.Name as [Teacher Name],t4.CourseName as[Course Name],t1.[Credit] FROM [CourseAssaign] t1 inner join [Department] t2 on t2.ID=t1.DeptID  inner join [Teacher] t3 on t3.ID=t1.TechID inner join [Course] t4 on t4.ID=t1.ID " + Parameter;
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            CourseAssign acourse = null;
            var CrstList = new List<CourseAssign>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    acourse = new CourseAssign();
                    acourse.ID = (int)reader["ID"];
                    acourse.Department =reader["Department"].ToString();
                    acourse.Teacher = reader["Teacher Name"].ToString();
                    acourse.CourseID = reader["Course Name"].ToString();
                    acourse.Credit = Convert.ToDecimal(reader["Credit"]);

                    CrstList.Add(acourse);
                }
            }
            con.Close();
            return CrstList;
        }
    }
}