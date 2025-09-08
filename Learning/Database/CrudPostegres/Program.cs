using System;
using System.Data;
using System.Threading.Tasks;
using CrudPostegres;
using Npgsql;

namespace CrudPostgres
{
    class Program
    {
        // private NpgsqlConnection connection;

        //CONNECTION_STRING
        private const string CONNECTION_STRING = @"Server=localhost;Port=5432;User Id=postgres;Password=Mak.2017;DataBase=school;";
        private const string TABLE_NAME = "games";
        static async Task Main(string[] args)
        {
            TestConnection();
            BoardGame boardGame = new() { Id = 101, Name = "'checkers'", MinPlayers = 2, MaxPlayers = 4, AverageDuration = 2 };
            // CreateTable();
            // await InsertRecord(boardGame);
            await InsertRecord(new BoardGame() { Id = 103, Name = "'Azul'", MinPlayers = 2, MaxPlayers = 4, AverageDuration = 4 });
            // await Add(new BoardGame() { Id = 102, Name = "'Chess'", MinPlayers = 2, MaxPlayers = 6, AverageDuration = 1 });
        }

        //Create a new table
        public static void CreateTable()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"CREATE TABLE games( id INTEGER primary key, Name VARCHAR NOT NULL, MinPlayers SMALLINT NOT NULL, MaxPlayers SMALLINT, AverageDuration SMALLINT );";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Table created");
                }

            }
        }

        //Insert new records to a table
        private static async Task InsertRecord(BoardGame game)
        {
            await using (NpgsqlConnection con = GetConnection())
            {
                string query = $"INSERT INTO games(id, name, minplayers, maxplayers, averageDuration) VALUES ({game.Id}, {game.Name}, {game.MinPlayers}, {game.MaxPlayers}, {game.AverageDuration})";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        //Insert records to a table
        private static async Task Add(BoardGame game)
        {
            string query = $"INSERT INTO games (id, name, minplayers, maxplayers, averageDuration) VALUES (@id, @name, @minPl, @maxPl, @avgDur)";

            await using (NpgsqlConnection connection = GetConnection())
            {
                var cmd = new NpgsqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("id", game.Id);
                cmd.Parameters.AddWithValue("name", game.Name);
                cmd.Parameters.AddWithValue("minPl", game.MinPlayers);
                cmd.Parameters.AddWithValue("maxPl", game.MaxPlayers);
                cmd.Parameters.AddWithValue("avgDur", game.AverageDuration);

                await cmd.ExecuteNonQueryAsync();
            }
            Console.WriteLine("Inserted succefully");
        }
        //Test connection
        private static void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connected Successfully!");
                }
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(CONNECTION_STRING);
        }
    }
}


//https://www.code4it.dev/blog/postgres-crud-operations-npgsql/
//https://learning.syncfusion.com/?sfwd-courses=database-design&sfwd-lessons=database-design-all-in-one-tutorial-series-8-hours