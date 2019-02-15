using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS.Models;

/// <summary>
/// Summary description for DepartmentGetway
/// </summary>
public class DepartmentGetway
{
    SqlConnection con = new SqlConnection(DBConnector.ConnString());
    internal string SaveDepartment(Department aDepartment)
    {
        string Query = @"INSERT INTO [Department] 
         ([Code] 
        ,[Name] 
        ,[AddBy] 
        ,[AddDate])
     VALUES
           ('" +aDepartment.Code + "','" + aDepartment.Name+ "','Sojol',GETDATE())";
        int rowEffect = DataTransfection.ExecuteNonQuery(Query);
        if (rowEffect > 0)
        {
            return "Record is/are Saved Sucessfully....!!";
        }
        else
            throw new Exception("Record Save Failed....!!! ");
    }
        
    internal int GetValidationCode(string Code)
    {
        //string Query = @"SELECT * from [Department] where Code='"+Code+"'";
        int dt = DataTransfection.GetShowSingleValueInt("COUNT(*)", "Code", "Department", Code);
        return dt;
        
        
    }

    internal DataTable GetShowItemsDetails()
    {
        string Query = @"SELECT [ID],row_number() over (order by ID) as Serial ,[Name] FROM [Department]";
        DataTable dt = DataTransfection.GetShowDataTable(Query, "Department");
        return dt;
    }

    internal DataTable GetShowSemester()
    {
        string Query = @"SELECT [ID],row_number() over (order by ID) as Serial ,[Name] FROM [Semester]";
        DataTable dt = DataTransfection.GetShowDataTable(Query, "Semester");
        return dt;
    }

    internal List<Department> GetShowDepartmentDetails()
    {

        string query = @"SELECT [ID],[Code],[Name] FROM [Department]";
        SqlCommand command = new SqlCommand(query, con);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        Department adpt = null;
        var dptList = new List<Department>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                adpt = new Department();
                adpt.ID =(int)reader["ID"];
                adpt.Code = reader["Code"].ToString();
                adpt.Name = reader["Name"].ToString();
                dptList.Add(adpt);
            }
        }
        con.Close();
        return dptList;
    }

    internal List<Semester> GetShowSemesterDetails()
    {
        string query = @"SELECT [ID],[Name] FROM [Semester]";
        SqlCommand command = new SqlCommand(query, con);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        Semester aSmpt = null;
        var SmtList = new List<Semester>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                aSmpt = new Semester();
                aSmpt.Id = (int)reader["ID"];
                aSmpt.Name = reader["Name"].ToString();
                SmtList.Add(aSmpt);
            }
        }
        con.Close();
        return SmtList;
    }
}