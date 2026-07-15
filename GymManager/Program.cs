namespace GymManager;

public class Program
{
    static void Main(string[] args)
    {
        Gym gym = new Gym();
        Menu(gym);
    }

    private static void Menu(Gym gym)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Athletic Gym Manager");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View all members\n2. Register new member\n3. Exit");

            int choice = ReadInt("Choice: ");

            switch (choice)
            {
                case 1:
                    ShowMemberList(gym.GetMembers());
                    break;
                case 2:
                    Member member = CreateMember();
                    gym.RegisterMember(member);
                    break;
                case 3:
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    #region 
    // Helpers to validate console information
    private static void ShowMemberList(IReadOnlyList<Member> member)
    {
        Console.WriteLine("--- Registered members ---");
        if (member.Count <= 0)
        {
            Console.WriteLine("There are no registered users");
            return;
        }

        foreach (var members in member)
        {
            string status = members.IsActive? "Active" : "Inactive";
            Console.WriteLine($"- {members.Name} ({members.Age} years old) | Joined: {members.InscriptionDate:yyyy-MM-dd} | Status: {status}");
        }
    }
    private static Member CreateMember()
    {
        string name = ReadName("Please write name member: ");
        int age = ReadAge("Please write age member: ");
        DateTime inscriptionDate = ReadDate("Please write inscription date: ");
        bool isActive = ReadBool("Please write if the member is active (true, false): ");

        return new Member(name, age, inscriptionDate, isActive);
    }
    
    private static int ReadInt(string prompt)
    {
        int value;
        Console.WriteLine(prompt);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Please enter a valid whole number");
            Console.WriteLine(prompt);
        }
        return value;
    }

    private static DateTime ReadDate(string prompt)
    {
        DateTime value;
        Console.WriteLine(prompt);
        while (!DateTime.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Please enter a valid date (e.g. 2026-07-13)");
            Console.WriteLine(prompt);
        }
        return value;
    }

    private static bool ReadBool(string prompt)
    {
        bool value;
        Console.WriteLine(prompt);
        while (!bool.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Please enter true or false");
            Console.WriteLine(prompt);
        }
        return value;
    }

    private static string ReadName(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()?.Trim();

            try
            {
                if (input != null)
                {
                    Member.ValidateName(input);
                    return input;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static int ReadAge(string prompt)
    {
        while (true)
        {
            int candidate = ReadInt(prompt);
            try
            {
                Member.ValidateAge(candidate);
                return candidate;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    #endregion
}