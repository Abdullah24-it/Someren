namespace Someren.Repositories
{
    public class DbSomerenRepository : IHomeRepository
    {
        private readonly string? _connectionString;
        public DbSomerenRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Someren");
        }
    }
}
