namespace BankClients.Entities;

public class Client
{
    public int Id { get; set; }
    public int No { get; set; }
    public DateTime Date { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Passport { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    /// <param name="no">Уникальный идентификатор</param>
    /// <param name="fullName">Ф.И.О</param>
    /// <param name="age">Возраст</param>
    /// <param name="passport">Паспортные данные</param>
    /// <param name="dateOfBirth">Дата рождения</param>
    /// <param name="placeOfBirth">Место рождения</param>
    public Client(int no, string fullName, int age, string passport, DateTime dateOfBirth, string placeOfBirth)
    {
        this.No = no;
        this.Date = DateTime.Now;
        this.FullName = fullName;
        this.Age = age;
        this.Passport = passport;
        this.DateOfBirth = dateOfBirth;
        this.PlaceOfBirth = placeOfBirth;
    }

    public Client()
    {

    }

    public override string ToString()
    {
        return $"{No,3} {Date,20} {FullName,40} {Age,3} {Passport,12} {DateOfBirth.ToShortDateString(),10} {PlaceOfBirth,22}";
    }
}