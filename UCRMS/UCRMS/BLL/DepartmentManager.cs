using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models;

/// <summary>
/// Summary description for DepartmentManager
/// </summary>
public class DepartmentManager
{
    private DepartmentGetway _DepartmentGetway = new DepartmentGetway(); 
	public DepartmentManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string SaveDepartment(Department aDepartment)
    {
        if (aDepartment.Name == "")
        {
            throw new Exception("Enter name ....!!!!!");
        }
        if (aDepartment.Code == "")
        {
            throw new Exception("Enter Code ....!!!!!");
        }
        int code = GetValidationCode(aDepartment.Code);
        if(code>0)
        {
             throw new Exception("this Code Alrady Exsist.....!!");
        }

        return _DepartmentGetway.SaveDepartment(aDepartment);
    }        

    public int GetValidationCode(string Code)
    {
        return _DepartmentGetway.GetValidationCode(Code);
    }

    public DataTable GetShowItemsDetails()
    {
        return _DepartmentGetway.GetShowItemsDetails();
    }

    public DataTable GetShowSemester()
    {
        return _DepartmentGetway.GetShowSemester();
    }

    internal List<Department> GetShowDepartmentDetails()
    {
        return _DepartmentGetway.GetShowDepartmentDetails();
    }

    internal List<Semester> GetShowSemesterDetails()
    {
        return _DepartmentGetway.GetShowSemesterDetails();
    }
}