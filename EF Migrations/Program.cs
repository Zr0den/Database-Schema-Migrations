using EF_Migrations;

namespace DatabaseSchemaMigrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var db = new Model();
            Console.WriteLine("test");
        }
    }
}