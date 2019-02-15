using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataTransfection
/// </summary>
public class DataTransfection
{
    DBConnector aDBConnector = new DBConnector();
	public DataTransfection()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    internal static void GetExecuteNonQuery(string Query)
    {
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        try
        {
            
            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }  

    public static int GetShowSingleValueInt(string ShowField, string SearchField, string TableName, string Parameter)
    {
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        try
        {
            connection.Open();
            string Query = "select " + ShowField + " from " + TableName + " where " + SearchField + "='" + Parameter + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    public static int GetShowSingleValueInt(string ShowField,  string TableName)
    {
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        try
        {
            connection.Open();
            string Query = "select " + ShowField + " from " + TableName + " ";
            SqlCommand command = new SqlCommand(Query, connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    public static string GetShowSingleValueString(string ShowField, string SearchField, string TableName, string Parameter)
    {
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        try
        {
            connection.Open();
            string Query = "select " + ShowField + " from " + TableName + " where " + SearchField + "='" + Parameter + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            return command.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
  

    internal static DataTable GetShowDataTable(string Query,string TableName)
    {
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        try
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(Query,connection);
            DataSet ds = new DataSet();
            da.Fill(ds, TableName);
            DataTable table = ds.Tables[TableName];
            return table;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    internal static int ExecuteNonQuery(string Query)
    {
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        try
        {

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
           int rowEffect= command.ExecuteNonQuery();
           return rowEffect;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    
    }
