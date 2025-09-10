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
        private const string CONNECTION_STRING = @"Server=localhost;Port=5432;User Id=postgres;Password=Mak.2017;DataBase=game;";
        private const string TABLE_NAME = "games";
        static async Task Main(string[] args)
        {
            await TestConnection();
            // BoardGame boardGame = new() {Name = "'checkers'", MinPlayers = 2, MaxPlayers = 4, AverageDuration = 2 };
            CreateTable();
            // await InsertRecord(boardGame);
            // await InsertRecord(new BoardGame() {Name = "'Azul'", MinPlayers = 2, MaxPlayers = 4, AverageDuration = 4 });
            // await Add(new BoardGame() { Name = "Chess", MinPlayers = 2, MaxPlayers = 6, AverageDuration = 1 });
            await ReadData();
            // await UpdateRecords();
            await DeleteRecord("'BG103'");
            await ReadData();
        }

        //Create a new table
        public static async Task CreateTable()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"CREATE TABLE IF NOT EXISTS games( id VARCHAR primary key, Name VARCHAR NOT NULL, MinPlayers SMALLINT NOT NULL, MaxPlayers SMALLINT, AverageDuration SMALLINT );";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
             Console.WriteLine("Table created");
        }

        //Insert new records to a table
        private static async Task InsertRecord(BoardGame game)
        {
            await using (NpgsqlConnection con = GetConnection())
            {
                string query = $"INSERT INTO games(id, name, minplayers, maxplayers, averageDuration) VALUES ('{game.Id}', {game.Name}, {game.MinPlayers}, {game.MaxPlayers}, {game.AverageDuration})";
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

        //Read data
        private static async Task ReadData()
        {
            string query = "SELECT * FROM games";

            await using (NpgsqlConnection con = GetConnection())
            {
                var cmd = new NpgsqlCommand(query, con);
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine($"{new String('*', 65)}\n{"id",-5} | {"name",-10} | {"minplayers",-11} | {"maxplayers",-11} | {"averageDuration",-15}\n{new String('*', 65)}");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["id"],-5} | {reader["name"],-10} | {reader["minplayers"],-11} | {reader["maxplayers"],-11} | {reader["averageDuration"],-15}");
                }
                Console.WriteLine(new String('*',65));
            }
        }
        //UPDATING RECORDS
        private static async Task UpdateRecords()
        {
            string query = $"UPDATE games SET averageduration = CASE name WHEN 'checkers' THEN 5 WHEN 'Azul' THEN 3 WHEN 'Chess' THEN 4 END";
            await using (NpgsqlConnection con = GetConnection())
            {
                var cmd = new NpgsqlCommand(query, con);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            Console.WriteLine("Updated successfully");
        }

        //DELETE RECORDS
        private static async Task DeleteRecord(string gameId)
        {
            string query = $"DELETE FROM games WHERE id = {gameId}";
            await using (NpgsqlConnection con = GetConnection())
            {
                var cmd = new NpgsqlCommand(query, con);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            Console.WriteLine("Record deleted successfully!");
        }

        //Test connection
        private static async Task TestConnection()
        {
            await using (NpgsqlConnection con = GetConnection())
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