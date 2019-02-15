using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UCRMS.Models;

/// <summary>
/// Summary description for CourseSetupManager
/// </summary>
public class CourseSetupManager
{
    CourseSetupGetway aCourseGetway = new CourseSetupGetway();
	public CourseSetupManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string SaveCourse(CourseSetup acourse)
    {
        if (acourse.Name == "")
        {
            throw new Exception("Enter name ....!!!!!");
        }         
        if (acourse.Code == "")
        {
            throw new Exception("Enter Code ....!!!!!");
        }
        int aTest = aCourseGetway.GetValidation(acourse.Code);
        if (aTest >0)
        {
            throw new Exception("this Code already Existed....!!!!!");
        }
        return aCourseGetway.SaveDepartment(acourse);
    }

    public int GetValidation(string ID)
    {
        return aCourseGetway.GetValidation(ID);
    }

    internal List<Department> GetDepartmentList()
    {
        return aCourseGetway.GetDepartmentList();
    }

    internal List<CourseSetup> GetAllCourseList(string Code)
    {
        return aCourseGetway.GetAllCourseList(Code);
    }

    //internal List<CourseSetup> GetShowTeacherDetails()
    //{
    //    return aCourseGetway.GetShowTeacherDetails();
    //}

    internal List<RegisterStudents> GetAllRegList(string RegNo)
    {
        return aCourseGetway.GetAllRegList(RegNo);
    }
}