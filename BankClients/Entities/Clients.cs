namespace BankClients.Entities;

public struct Client
{
    // <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

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
    /// Конструктор Worker
    /// </summary>
    public Client(int id, DateTime date, string fullName, int age, int growth, DateTime dateOfBirth, string placeOfBirth)
    {
        this.Id = id;
        this.Date = date;
        this.FullName = fullName;
        this.Age = age;
        this.Growth = growth;
        this.DateOfBirth = dateOfBirth;
        this.PlaceOfBirth = placeOfBirth;
    }

    public override string ToString()
    {
        return $"{Id,3} {Date,20} {FullName,40} {Age,3} {Growth,4} {DateOfBirth.ToShortDateString(),10} {PlaceOfBirth,22}";
    }
}
