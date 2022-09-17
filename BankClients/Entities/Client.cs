namespace BankClients.Entities;

public struct Client
{

    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Дата и время добавления записи
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Ф.И.О сотрудника
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Рост
    /// </summary>
    public int Growth { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public string PlaceOfBirth { get; set; }

    /// <summary>
    /// Конструктор Client
    /// </summary>
    public Client(int ID, DateTime Date, string FullName, int Age, int Growth, DateTime DateOfBirth, string PlaceOfBirth)
    {
        this.ID = ID;
        this.Date = Date;
        this.FullName = FullName;
        this.Age = Age;
        this.Growth = Growth;
        this.DateOfBirth = DateOfBirth;
        this.PlaceOfBirth = PlaceOfBirth;
    }

    public override string ToString()
    {
        return $"{ID,3} {Date,20} {FullName,40} {Age,3} {Growth,4} {DateOfBirth.ToShortDateString(),10} {PlaceOfBirth,22}";
    }
}