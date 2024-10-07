using System.Data.SqlClient;

public static class ScriptExecuter
{
    public static void ExecuteFile(string connectionString, string fileName)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string data = File.ReadAllText(fileName);

            conn.Open();

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = data;
                cmd.ExecuteNonQuery();
            }
        }
    }
}