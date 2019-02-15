using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS.Models;

namespace UCRMS.DAL
{
    public class TeacherGetway
    {
        SqlConnection con = new SqlConnection(DBConnector.ConnString());
        internal int GetValidation(string TeacherName)
        {
            int dt = DataTransfection.GetShowSingleValueInt("COUNT(*)", "Name", "Teacher", TeacherName);
            return dt;
        }

        internal string SaveTeacher(Teacher aTeacher)
        {
            string Query = @"INSERT INTO [Teacher]
           ([Name]
           ,[Address]
           ,[Email]
           ,[ContractNo]
           ,[DesignatioID]
           ,[DepartmentID]
           ,[CreditTaken]
           ,[Addby]
           ,[Addate])
     VALUES
           ('" + aTeacher.Name+ "','" + aTeacher.Address+ "','" +aTeacher.Email+ "','" + aTeacher.ContractNo+ "','" + aTeacher.Designation + "','" + aTeacher.Department + "','"+aTeacher.CreditTaken+"','Sojol',GETDATE())";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }

        internal List<Teacher> GetAllTeacherDetails()
        {
            string query = @"SELECT [Name] ,[Address],[Email],[ContractNo],[DesignatioID],[DepartmentID] ,[CreditTaken] FROM [Teacher]";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            Teacher aTeacher = null;
            var ThList = new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    aTeacher = new Teacher();
                    aTeacher.Name = reader["Name"].ToString();
                    aTeacher.Address = reader["Address"].ToString();
                    aTeacher.Email = reader["Email"].ToString();
                    aTeacher.ContractNo = reader["ContractNo"].ToString();
                    aTeacher.Designation = reader["DesignatioID"].ToString();
                    aTeacher.Department = reader["DepartmentID"].ToString();
                    aTeacher.CreditTaken = reader["CreditTaken"].ToString();
                    ThList.Add(aTeacher);
                }
            }
            con.Close();
            return ThList;
        }

        internal List<Teacher> GetShowTeacherDetails()
        {
            string query = @"SELECT ID,[Name] FROM [Teacher]";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            Teacher aTeacher = null;
            var ThList = new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    aTeacher = new Teacher();
                    aTeacher.ID=(int)reader["ID"];
                    aTeacher.Name = reader["Name"].ToString();
                   
                    ThList.Add(aTeacher);
                }
            }
            con.Close();
            return ThList;
        }
    }
}