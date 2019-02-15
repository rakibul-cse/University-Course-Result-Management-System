using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBConnector
/// </summary>
public class DBConnector
{
     
	public DBConnector()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string ConnString()
    {
       
        // return String.Format("Server=.;Database=Library_DB;User ID=sa;Password=123;Trusted_Connection=False;");
        return String.Format("Server=.;Database=UCRMS_DB; User ID=sa; Password=123; Trusted_Connection=False;");
    }
}