internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введіть пароль:");
        string pass = null;
        try
        {
            pass = GetPassword();
        }
        catch (InvalidPasswordException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Процес завершено");
        }
    }

    private static string GetPassword()
    {
        string userInput = Console.ReadLine();
        if (userInput.Length < 8)
        {
            throw new InvalidPasswordException("Пароль має містити не менше 8 знаків");
        }
        else if (!HasDigit(userInput))
        {
            throw new InvalidPasswordException("Пароль повинен містити числа");
        }
        else if (!HasLetter(userInput))
        {
            throw new InvalidPasswordException("Пароль має містити літери");
        }

        Console.WriteLine("Пароль успішно ствонено");
        
        return userInput;
    }

    private static bool HasLetter(string value)
    {
        foreach (char c in value)
        {
            if (char.IsLetter(c))
            {
                return true;
            }
        }
        return false;
    }

    private static bool HasDigit(string value)
    {
        foreach (char c in value)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}