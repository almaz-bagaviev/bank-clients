namespace BankClients.Repositories;

public class Repository
{
    static Random random;
    List<Client> client;

    static Repository()
    {
        random = new Random();
    }

    public Repository(List<Client> clients)
    {
        this.client = clients;
    }

    /// <summary>
    /// Метод добавления рандомных сотрудников
    /// </summary>
    /// <returns></returns>
    public static List<Client> GetRepository()
    {
        List<Client> newClient = new();

        for (int i = 0; i < 5; i++)
        {
            newClient.Add(new Client(
                i + 1,
                DateTime.Now,
                $"Сотрудник {i + 1}",
                random.Next(18, 60),
                random.Next(155, 201),
                new DateTime(random.Next(1970, 2004), random.Next(1, 13), random.Next(1, 29)),
                $"Город {i + 1}"
                ));
        }
        return newClient;
    }

    /// <summary>
    /// Добавление записи
    /// </summary>
    /// <param name="addClient"></param>
    public void Add(Client addClient)
    {
        client.Add(addClient);
    }

    /// <summary>
    /// Удаление записи
    /// </summary>
    /// <param name="index">Индекс удаляемого сотрудника</param>
    public void Remove(int index)
    {
        int findIndex = -1;
        for (int i = 0; i < client.Count; i++)
        {
            if (client[i].Id == index) findIndex = i;
        }

        if (findIndex == -1) return;

        for (int i = findIndex; i < client.Count - 1; i++)
        {
            client[findIndex] = client[findIndex + 1];
        }

        client.Remove(client[findIndex]);
    }

    /// <summary>
    /// Метод сохранения информации о сотруднике с использованием StreamWriter и StreamReader
    /// </summary>
    /// <param name="path"></param>
    public void Save(string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(path))
        {

            foreach (var e in client)
            {
                string note = string.Empty;
                note += $"{e.Id,3}\t";
                note += $"{e.Date,20}\t";
                note += $"{e.FullName,40}\t";
                note += $"{e.Age,3}\t";
                note += $"{e.Growth,4}\t";
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
                Console.WriteLine(streamReader.ReadLine());
            }
        };
    }


    /// <summary>
    /// Сортировка по дате Дней рождения сотрудников по Возрастанию
    /// </summary>
    public void SortByDateOfBirth_Ascending()
    {
        //public void Sort(int index, int count, IComparer<T> comparer);
        client.Sort(SortAscending);
    }
    private int SortAscending(Client x, Client y)
    {
        //-1, 1, 0
        return x.DateOfBirth < y.DateOfBirth ? -1 : x.DateOfBirth > y.DateOfBirth ? 1 : 0;
    }


    /// <summary>
    /// Сортировка по дате Дней рождения сотрудников по Убыванию
    /// </summary>
    public void SortByDateOfBirth_Descending()
    {
        client.Sort(SortDescending);
    }
    private int SortDescending(Client x, Client y)
    {
        //-1, 1, 0
        return x.DateOfBirth < y.DateOfBirth ? 1 : x.DateOfBirth > y.DateOfBirth ? -1 : 0;
    }


    /// <summary>
    /// Печать информации о сотрудниках
    /// </summary>
    public string Print()
    {
        StringBuilder stringBuilder = new();
        for (int i = 0; i < client.Count; i++)
        {
            stringBuilder.Append($"{client[i]}\n");
        }
        return stringBuilder.ToString();
    }
}
