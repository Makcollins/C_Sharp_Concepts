using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Npgsql;

namespace PGDemo
{
    class Program
    {
        //NpgsqlConnection object
        private NpgsqlConnection connection;

        //CONNECTION_STRING
        private const string CONNECTION_STRING = @"Server=localhost;Port=5432;User Id=postgres;Password=Mak.2017;DataBase=school;";

        static void Main(string[] args)
        {
            DisplayRecords();
            Console.ReadKey();
        }
        private static void InsertRecord()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"insert into students(Name,Fees) values ('Stephen',700)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Record inserted");
                }
            }
        }

        private static void DisplayRecords()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "SELECT * FROM students";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Success");
            }
        }

        private static void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connected");
                }
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(CONNECTION_STRING);
        }
    }
}