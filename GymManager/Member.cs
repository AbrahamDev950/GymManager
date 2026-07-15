namespace GymManager;

public class Member
{
    private string? name;
    private int age;
    private bool isActive;
    private DateTime inscriptionDate;

    public string? Name
    {
        get => name;
        set
        {
            if (value != null)
            {
                ValidateName(value);
                name = value;
            }
        }
    }

    public int Age
    {
        get => age;
        set
        {
            ValidateAge(value);
            age = value;
        }
    }

    public DateTime InscriptionDate { get; set; }
    public bool IsActive { get; set; }

    public Member(string name, int age, DateTime inscriptionDate, bool isActive)
    {
        ValidateName(name);
        ValidateAge(age);
        this.Name = name;
        this.Age = age;
        this.InscriptionDate = inscriptionDate;
        this.IsActive = isActive;
    }

    public override string ToString()
    {
        return $"Member {Name}, Age {Age}, Inscription Date {InscriptionDate}, Is active? {IsActive}";
    }

    public static void ValidateName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        if (name.Length < 3)
        {
            throw new ArgumentException("Name must be at least 3 characters long");
        }
        char[] chars = name.ToCharArray();
        foreach (var c in chars)
        {
            if (!char.IsLetter(c))
            {
                throw new ArgumentException("Name must contain only letters");
            }
        }
    }

    public static void ValidateAge(int age)
    {
        if (age < 0 || age > 100)
        {
            throw new ArgumentException("Age must be between 0 and 100");
        }
    }
}