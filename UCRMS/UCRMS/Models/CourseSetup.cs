using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseSetup
/// </summary>
public class CourseSetup
{
	public CourseSetup()
	{
		//
		// TODO: Add constructor logic here
		//
	}   
    
    public string Code { get; set; }

    public string Semester { get; set; }

    public string DeptID { get; set; }

    public string Description { get; set; }

    public string Credit { get; set; }

    public string Name { get; set; }

    public object ID { get; set; }
}