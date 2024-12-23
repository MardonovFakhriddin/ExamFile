using Npgsql;

namespace Infrastructure.Data;

public interface IContext
{
    NpgsqlConnection Connection();
}

public class DapperContext : IContext
{
    private readonly string connectionString =
        "Server = localhost;port = 5432; Database = FileExam; Username = localhost;Password = LMard1909";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}