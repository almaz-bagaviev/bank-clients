namespace BankClients.Models;

public class AppModel
{
    static Repository repository;

    static AppModel()
    {
        repository = new(Repository.GetRepository());
    }

    public static void Start()
    {
        Menu();
    }

    /// <summary>
    /// Метод ручного добавления сотрудника пользователем
    /// </summary>
    /// <returns></returns>
    static Client NewWorker()
    {
        Client client = new();

        //ID
        bool IDFlag = false;
        while (!IDFlag)
        {
            Write("ID: ");
            if (IDFlag = int.TryParse(ReadLine(), out int UserID))
            {
                client.Id = UserID;
            }
        }

        //Дата и время добавления записи:
        client.Date = DateTime.Now;
        WriteLine($"Дата и время добавления записи: {client.Date} ");

        //Ф.И.О:
        Write("Ф.И.О: ");
        client.FullName = ReadLine();

        //Возраст:
        bool AgeFlag = false;
        while (!AgeFlag)
        {
            Write("Возраст: ");
            if (AgeFlag = int.TryParse(ReadLine(), out int UserAge)) //Возраст AgeFlag должен быть цифрой
            {
                client.Age = UserAge;
            }
        }

        //Рост:
        bool GrowthFlag = false;
        while (!GrowthFlag)
        {
            Write("Рост: ");
            if (GrowthFlag = int.TryParse(ReadLine(), out int UserGrowth))
            {
                client.Growth = UserGrowth;
            }
        }

        //Дата рождения
        bool dateFlag = false;
        while (!dateFlag)
        {
            Write("Дата рождения: ");
            if (dateFlag = DateTime.TryParse(ReadLine(), out DateTime UserAddDate))
            {
                client.DateOfBirth = UserAddDate;
            }
        }

        //Место рождения
        Write("Место рождения: ");
        client.PlaceOfBirth = ReadLine();

        return client;
    }

    /// <summary>
    /// Метод вычисления индекса удаляемого сотрудника
    /// </summary>
    /// <returns></returns>
    static int IndexForRemoveWorker()
    {
        int WorkerRemoveIndex;
        bool indexFlag = false;
        do
        {
            Write("Индекс, по которому удаляется Сотрудник:");
            indexFlag = int.TryParse(ReadLine(), out WorkerRemoveIndex);
        } while (!indexFlag);

        return WorkerRemoveIndex;
    }

    /// <summary>
    /// Меню при запуске приложения
    /// </summary>
    static void Menu()
    {
        string userChoice = string.Empty;
        while (userChoice != "7")
        {
            StartText();

            userChoice = ReadLine();

            switch (userChoice)
            {
                case "1": repository.Add(NewWorker()); break;
                case "2": WriteLine(repository.Print()); break;
                case "3": repository.Remove(IndexForRemoveWorker()); break;
                case "4": repository.SortByDateOfBirth_Ascending(); break;
                case "5": repository.SortByDateOfBirth_Descending(); break;
                case "6": repository.Save(UserPath()); break;
                case "7": break;

                default: WriteLine($"Выберите правильный пукт Меню\n"); break;
            }
        }
    }

    /// <summary>
    /// Метод ввода пользователем имени для сохраняемого файла
    /// </summary>
    /// <returns></returns>
    static string UserPath()
    {
        Write("Введите имя файла для сохранения на компьютере: ");
        string documentNamePath = ReadLine();
        string FullNamePath = $"{documentNamePath}.txt";

        return FullNamePath;
    }

    /// <summary>
    /// Текст для выбора действий пользователем при Старте
    /// </summary>
    static void StartText()
    {
        string text = $"\nСписок сотрудников" +
                $"\nДобавить запись - 1" +
                $"\nПоказать запись - 2" +
                $"\nУдалить запись - 3" +
                $"\nСортировка по возрастанию даты - 4" +
                $"\nСортировка по убыванию даты - 5" +
                $"\nСохранить в файл - 6" +
                $"\nВыход - 7";

        WriteLine(text);
    }
}
