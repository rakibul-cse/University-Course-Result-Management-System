using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS.Models;

namespace UCRMS.DAL
{
    public class StudentResultGetway
    {
        SqlConnection con=new SqlConnection(DBConnector.ConnString());
        internal List<Models.StudentResults> GetAllResultGradet(string Grade)
        {
            try
            {
                string Parameter = "";
                if (Grade != "")
                {
                    Parameter = " where Grade='" + Grade + "' ";
                }
                string query = @"SELECT [ID],[Grade] ,[Flag] FROM [Grades] " + Parameter;
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                StudentResults Aresult = null;
                var CrstList = new List<StudentResults>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Aresult = new StudentResults();
                        Aresult.ID = Convert.ToInt32(reader["ID"]);
                        Aresult.Grade = reader["Grade"].ToString();
                        CrstList.Add(Aresult);
                    }
                }
                con.Close();
                return CrstList;
            }
            catch (Exception ex)
            {
                
               throw new Exception(ex.Message);
            }
            
        }

        internal string SaveStudentResult(StudentResults studentResults)
        {
            try
            {
                string Query = @"INSERT INTO [StudentResult]
           ([RegID]
           ,[CourseID]
           ,[GradeID]
           ,[Addby]
           ,[Addate])
     VALUES
           ('" + studentResults.RegNo + "','" + studentResults.Course+ "','" + studentResults.Grade+ "','Sojol',GETDATE())";
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