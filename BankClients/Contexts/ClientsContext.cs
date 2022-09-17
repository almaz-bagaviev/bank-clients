namespace BankClients.Contexts;

public class ClientsContext: DbContext
{
    public DbSet<Client> ClientTable { get; set; }

    public ClientsContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB;
                                    DataBase = BankCliensDataBase;
                                    Trusted_Connection = True;");
    }
}
