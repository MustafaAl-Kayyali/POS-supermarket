using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

public class OracleDB
{
    private static readonly string connectionString =
     "User Id=scott;Password=tiger;" +
     "Data Source=(DESCRIPTION=" +
     "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
     "(CONNECT_DATA=(SERVICE_NAME=orcl)));";

    // Method to execute SELECT queries and return a DataTable
    public DataTable ExecuteQuery(string query, OracleParameter[] parameters = null)
    {
        DataTable dataTable = new DataTable();
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error executing query: {ex.Message}");
        }
        return dataTable;
    }

    // Method to execute INSERT, UPDATE, DELETE queries and return the number of affected rows
    public int ExecuteNonQuery(string query, OracleParameter[] parameters = null, OracleTransaction transaction = null)
    {
        int rowsAffected = 0;
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    // Assign transaction if provided
                    if (transaction != null)
                    {
                        command.Transaction = transaction;
                    }

                    // Add parameters if provided
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    // Execute the non-query
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error executing non-query: {ex.Message}");
        }
        return rowsAffected;
    }

    // Method to execute a scalar query and return a single value
    public object ExecuteScalar(string query, OracleParameter[] parameters = null)
    {
        using (OracleConnection conn = new OracleConnection(connectionString))
        using (OracleCommand cmd = new OracleCommand(query, conn))
        {
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            conn.Open();
            return cmd.ExecuteScalar();
        }
    }

    // Method to get a database connection
    public OracleConnection GetConnection()
    {
        return new OracleConnection(connectionString);
    }

}