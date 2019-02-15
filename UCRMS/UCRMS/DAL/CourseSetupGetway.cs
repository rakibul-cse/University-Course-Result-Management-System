using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCRMS.Models;

/// <summary>
/// Summary description for CourseSetupGetway
/// </summary>
public class CourseSetupGetway
{
    SqlConnection con = new SqlConnection(DBConnector.ConnString());
	public CourseSetupGetway()
	{
       
        //
		// TODO: Add constructor logic here
		//
	}

    internal string SaveDepartment(CourseSetup acourse)
    {
        string Query = @"INSERT INTO [Course]
           ([Code]
           ,[CourseName]
           ,[Credit]
           ,[Description]
           ,[DepartmentID]
           ,[SemesterID]
           ,[Addby]
           ,[Adddate]) 
     VALUES
           ('" + acourse.Code + "','" + acourse.Name + "','" + acourse.Credit + "','" + acourse.Description + "','" + acourse.DeptID+ "','" + acourse.Semester+ "','Sojol',GETDATE())";
        int rowEffect = DataTransfection.ExecuteNonQuery(Query);
        if (rowEffect > 0)
        {
            return "Record is/are Saved Sucessfully....!!";
        }
        else
            throw new Exception("Record Save Failed....!!! ");
    }

    internal string UpdateDepartment(CourseSetup acourse)
    {
        string Query = @"UPDATE [Course]
   SET [Code] ='" + acourse.Code + "' ,[CourseName] ='" + acourse.Name + "',[Credit] ='" + acourse.Credit + "' ,[Description] ='" + acourse.Description + "',[DepartmentID] ='" + acourse.DeptID + "' ,[SemesterID] ='" + acourse.Semester + "' ,[Updateby] ='Sojol',[Update] = GETDATE()  WHERE ID='" + acourse.ID + "'";
        int rowEffect = DataTransfection.ExecuteNonQuery(Query);
        if (rowEffect > 0)
        {
            return "Record is/are Update Sucessfully....!!";
        }
        else
            throw new Exception("Record Update Failed....!!! ");
    }   
   
    internal int GetValidation(string ID)
    {
        int dt = DataTransfection.GetShowSingleValueInt("COUNT(*)", "Code", "Course", ID);
        return dt;
    }

//    internal CourseSetup GetTestSetup(int ID)
//    {
//        string Query = @"SELECT [ID]
//      ,[Code]
//      ,[CourseName]
//      ,[Credit]
//      ,[Description]
//      ,[DepartmentID]
//      ,[SemesterID]      
//  FROM [Course] where ID='" + ID + "'";
//        DataTable dt = DataTransfection.GetShowDataTable(Query, "Course");
//        if (dt.Rows.Count == 0)
//        {
//            return null;
//        }
//        return new CourseSetup(dt.Rows[0]);
//    }

    internal List<Department> GetDepartmentList()
    {
        string query = "SELECT * FROM Department";
        SqlCommand command = new SqlCommand(query, con);

        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        Department dept = null;

        var typesList = new List<Department>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                dept = new Department();
                dept.ID = (int)reader["ID"];
                dept.Name = reader["Name"].ToString();
                typesList.Add(dept);
            }
        }
        con.Close();
        return typesList;
    }

    internal List<CourseSetup> GetAllCourseList(string Code)
    {
        string Parameter = "";
        if (Code != "")
        {
            Parameter = " where Code='" + Code + "' ";
        }
        string query = @"SELECT ID,[Code],[CourseName],[Credit] FROM [Course] "+Parameter;
        SqlCommand command = new SqlCommand(query, con);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        CourseSetup acourse = null;
        var CrstList = new List<CourseSetup>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                acourse = new CourseSetup();
                acourse.ID= reader["ID"].ToString();
                acourse.Code = reader["Code"].ToString();
                acourse.Name = reader["CourseName"].ToString();
                acourse.Credit = reader["Credit"].ToString();
                CrstList.Add(acourse);
            }
        }
        con.Close();
        return CrstList;
    }
    // Teacher Name
    //internal List<CourseSetup> GetShowTeacherDetails()
    //{
    //    //string query = @"SELECT ID,[Code] from [Course]";
    //    //SqlCommand command = new SqlCommand(query, con);
    //    //con.Open();
    //    //SqlDataReader reader = command.ExecuteReader();
    //    //CourseSetup acourse = null;
    //    //var CrstList = new List<CourseSetup>();
    //    //if (reader.HasRows)
    //    //{
    //    //    while (reader.Read())
    //    //    {
    //    //        acourse = new CourseSetup();
    //    //        acourse.ID = (int)reader["ID"];
    //    //        acourse.Code = reader["Code"].ToString();                
    //    //        CrstList.Add(acourse);
    //    //    }
    //    //}
    //    //con.Close();
    //    //return CrstList;
    //}

    internal List<RegisterStudents> GetAllRegList(string RegNo)
    {
        string Parameter = "";
        if (RegNo != "")
        {
            Parameter = " where RegNo='" + RegNo + "' ";
        }
        string query = @"SELECT t1.[ID],[RegNo],[St_Name] ,[Email] ,[ContractNo] ,[Address] ,t2.[Name] as DeptId FROM [Student_Registation] t1 inner join [Department] t2 on t2.ID=t1.DeptID  " + Parameter;
        SqlCommand command = new SqlCommand(query, con);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        RegisterStudents acourse = null;
        var CrstList = new List<RegisterStudents>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                acourse = new RegisterStudents();
                acourse.ID = Convert.ToInt32(reader["ID"].ToString());
                acourse.RegNo = reader["RegNo"].ToString();
                acourse.Name = reader["St_Name"].ToString();
                acourse.Email = reader["Email"].ToString();
                acourse.ContractNo = reader["ContractNo"].ToString();
                acourse.Address = reader["Address"].ToString();
                acourse.DeptID = reader["DeptId"].ToString();
                CrstList.Add(acourse);
            }
        }
        con.Close();
        return CrstList;
    }
}