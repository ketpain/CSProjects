using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security;
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
    }
    static void Main(string[] args)
    {
        Program program = new Program();
        program.GameLoop();
    }
    public void GameLoop()
    {
        player.Name = "";
        player.Level = 1;
        player.Health = 100;
        player.Mana = 100;
        
        while (true)
        {
            Console.WriteLine("Please enter a command (start, help, or exit):");
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
            case "help":
                GetHelp();
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }
    public void GetHelp()
    {
        Console.WriteLine("\nAvailable Commands: ");
        Console.WriteLine("help");
        Console.WriteLine("attack");
        Console.WriteLine("defend");
        Console.WriteLine("use");
        Console.WriteLine("run");
        Console.WriteLine();
    }
    public void SimulateTyping(string creationMessage)
    {
        for (int i = 0; i < creationMessage.Length; i++)
        {
            Console.Write(creationMessage[i]);
            Thread.Sleep(100); // Simulate a typing effect
        }
        Console.WriteLine();
    }
    public void StartCharacterCreation()
    {
        bool nameReady = false;   
        string ?input;

        string creationMessage = "Booting up character creation...";
        SimulateTyping(creationMessage);
            
        while (nameReady == false || player.Name == null)
        {
            creationMessage = "Please enter your character's name:";
            SimulateTyping(creationMessage);

            player.Name = Console.ReadLine();

            creationMessage = $"Your name is {player.Name}. Is this correct?";
            SimulateTyping(creationMessage);

            Console.WriteLine($"Type y/n");
            input = Console.ReadLine();
            if (input == "y") { break; }
            
        }
        creationMessage = $"Hello, {player.Name}! Now, let's set up your character.";
        SimulateTyping(creationMessage);
    }
}