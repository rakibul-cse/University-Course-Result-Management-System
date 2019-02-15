using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS.DAL
{
    public class RegisterStudentGetway
    {
        internal string SaveStudent(Models.RegisterStudents registerStudent,string AutoID)
        {
            string Query = @"INSERT INTO [Student_Registation]
           ([RegNo]
           ,[St_Name]
           ,[Email]
           ,[ContractNo]
           ,[Date]
           ,[Address]
           ,[DeptID]
           ,[Adby]
           ,[Addate])
     VALUES
           ('" + AutoID + "','" + registerStudent.Name + "','" + registerStudent.Email + "','" + registerStudent.ContractNo + "',GETDATE(),'" + registerStudent.Address + "','" + registerStudent.DeptID + "','Sojol',GETDATE())";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }

        internal int GetValidation(string ID)
        {
            int dt = DataTransfection.GetShowSingleValueInt("COUNT(*)", "St_Name", "Student_Registation", ID);
            return dt;
        }
    }
}