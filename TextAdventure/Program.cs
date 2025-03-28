using System.Timers;

class Program
{
    string ?command;
    Character player;
    struct Character
    {
        public string ?Name;
        public int Level;
        public int Health;
        public int Mana;

        public Character(string name, int level, int health, int mana)
        {
            Name = name;
            Level = level;
            Health = health;
            Mana = mana;
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();
        program.GameLoop();
    }

    public void GameLoop()
    {
        while (true)
        {
            Console.WriteLine("Please enter a command (start, stop, exit):");
            command = Console.ReadLine();
            Commands(command);
        }
    }

    public void Commands(string ?command)
    {
        switch (command)
        {
            case "start":
                StartCharacterCreation();
                break;
            case "stop":
                Console.WriteLine("Game stopped");
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }

    public void StartCharacterCreation()
    {
        string creationMessage = "Booting up character creation...";
        for (int i = 0; i < creationMessage.Length; i++)
        {
            Console.Write(creationMessage[i]);
            Thread.Sleep(100); // Simulate a typing effect
        }
        Console.WriteLine(); // Move to the next line after the message
        creationMessage = "Please enter your character's name:";
        for (int i = 0; i < creationMessage.Length; i++)
        {
            Console.Write(creationMessage[i]);
            Thread.Sleep(100); // Simulate a typing effect
        }
        Console.WriteLine(); // Move to the next line after the message
        
        while (true)
        {
            player.Name = Console.ReadLine();
            while (player.Name == null)
            {
                Console.WriteLine("Name cannot be empty. Please enter your character's name:");
                player.Name = Console.ReadLine();
            }
            Console.WriteLine($"Hello, {player.Name}! Now, let's set up your character.");
            break;
        }
        Console.WriteLine("Please enter your character's level (1-100):");
    }
}