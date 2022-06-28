namespace BankClients.Entities;

public struct Client
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Growth { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; }

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
