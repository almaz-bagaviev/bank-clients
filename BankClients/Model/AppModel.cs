namespace BankClients.Model;

public class AppModel
{
    static Repository repository;
    static Client client;

    public AppModel()
    {
        repository = new(Repository.GetRepository());
    }

    public void Start() => Menu();

    private static Client GetClient()
    {
        client = new();

        bool IdFlag = false;
        while (!IdFlag)
        {
            Write("Id: ");
            if (IdFlag = int.TryParse(ReadLine(), out int UserNo))
            {
                client.No = UserNo;
            }
        }

        client.Date = DateTime.Now;
        WriteLine($"Дата и время добавления записи: {client.Date} ");

        Write("Ф.И.О: ");
        client.FullName = ReadLine();

        bool AgeFlag = false;
        while (!AgeFlag)
        {
            Write("Возраст: ");
            if (AgeFlag = int.TryParse(ReadLine(), out int UserAge))
            {
                client.Age = UserAge;
            }
        }

        Write("Паспортные данные: ");
        client.Passport = ReadLine();

        bool dateFlag = false;
        while (!dateFlag)
        {
            Write("Дата рождения: ");
            if (dateFlag = DateTime.TryParse(ReadLine(), out DateTime UserAddDate))
            {
                client.DateOfBirth = UserAddDate;
            }
        }

        Write("Место рождения: ");
        client.PlaceOfBirth = ReadLine();

        return client;
    }

    private static int IndexForRemoveWorker()
    {
        int WorkerRemoveIndex;
        bool indexFlag = false;
        do
        {
            Write("Индекс, по которому удаляется Сотрудник: ");
            indexFlag = int.TryParse(ReadLine(), out WorkerRemoveIndex);
        } while (!indexFlag);

        return WorkerRemoveIndex;
    }

    private static void Menu()
    {
        string userChoice = string.Empty;
        while (userChoice != "8")
        {
            StartText();

            userChoice = ReadLine();

            switch (userChoice)
            {
                case "1": repository.Add(GetClient()); break;
                case "2": WriteLine(repository.Print()); break;
                case "3": repository.Remove(IndexForRemoveWorker()); break;
                case "4": repository.SortByDateOfBirth_Ascending(); break;
                case "5": repository.SortByDateOfBirth_Descending(); break;
                case "6": repository.Save(UserPath()); break;
                case "7": repository.Save2DB(); break;
                case "8": break;

                default: WriteLine($"Выберите правильный пукт Меню\n"); break;
            }
        }
    }
    private static string UserPath()
    {
        Write("Введите имя файла для сохранения на компьютере: ");
        string documentNamePath = ReadLine();
        string FullNamePath = $"{documentNamePath}.txt";

        return FullNamePath;
    }

    private static void StartText()
    {
        string text = $"\nСписок сотрудников" +
                $"\nДобавить запись - 1" +
                $"\nПоказать запись - 2" +
                $"\nУдалить запись - 3" +
                $"\nСортировка по возрастанию даты - 4" +
                $"\nСортировка по убыванию даты - 5" +
                $"\nСохранить в файл - 6" +
                $"\nСохранить в Базу данных - 7" +
                $"\nВыход - 8";

        WriteLine(text);
    }
}
