namespace BankClients.Repositories;

public class Repository
{
    static Random random;
    List<Client> clients;
    ClientsContext context;

    static Repository()
    {
        random = new();
    }

    public Repository(List<Client> clients)
    {
        this.clients = clients;
        context = new();
    }

    public static List<Client> GetRepository()
    {
        List<Client> newClient = new();
        for (int i = 0; i < 5; i++)
        {
            newClient.Add(new Client(
                i+1,
                $"Сотрудник {i + 1}",
                random.Next(18, 60),
                "****  ******",
                new DateTime(random.Next(1970, 2004), random.Next(1, 13), random.Next(1, 29)),
                $"Город {i + 1}"
                ));
        }
        return newClient;
    }

    public void Add(Client addClient) => clients.Add(addClient);

    public void Remove(int index)
    {
        int findIndex = -1;
        for (int i = 0; i < clients.Count; i++)
        {
            if (clients[i].No == index) findIndex = i;
        }

        if (findIndex == -1) return;

        for (int i = findIndex; i < clients.Count - 1; i++)
        {
            clients[findIndex] = clients[findIndex + 1];
        }

        clients.Remove(clients[findIndex]);
    }

    public void Save(string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(path))
        {

            foreach (var e in clients)
            {
                string note = string.Empty;
                note += $"{e.No}\t";
                note += $"{e.Date,20}\t";
                note += $"{e.FullName,40}\t";
                note += $"{e.Age,3}\t";
                note += $"{e.Passport,12}\t";
                note += $"{e.DateOfBirth.ToShortDateString(),10}\t";
                note += $"{e.PlaceOfBirth,22}\t";

                streamWriter.WriteLine(note);
            }
        };

        using (StreamReader streamReader = new StreamReader(path, Encoding.Unicode))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                WriteLine(streamReader.ReadLine());
            }
        };
    }

    public void Save2DB()
    {
        foreach (var addClients in clients)
        {
            context.ClientTable.Add(addClients);
        }
        context.SaveChanges();
    }

    public void SortByDateOfBirth_Ascending()
    {
        //public void Sort(int index, int count, IComparer<T> comparer);
        clients.Sort(SortAscending);
    }
    private int SortAscending(Client x, Client y)
    {
        //-1, 1, 0
        return x.DateOfBirth < y.DateOfBirth ? -1 : x.DateOfBirth > y.DateOfBirth ? 1 : 0;
    }

    public void SortByDateOfBirth_Descending()
    {
        clients.Sort(SortDescending);
    }
    private int SortDescending(Client x, Client y)
    {
        return x.DateOfBirth < y.DateOfBirth ? 1 : x.DateOfBirth > y.DateOfBirth ? -1 : 0;
    }

    public string Print()
    {
        StringBuilder stringBuilder = new();
        for (int i = 0; i < clients.Count; i++)
        {
            stringBuilder.Append($"{clients[i]}\n");
        }
        return stringBuilder.ToString();
    }
}
