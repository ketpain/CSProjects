using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security;
using System.Timers;
public struct Character
{
    public string ?name;
    public int level;
    public int currentHealth;
    public int maxHealth;
    public int currentMana;
    public int maxMana;
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;
    public int armor;
    public int damage;
    public int speed;
    public int experience;
    public int experienceToLevelUp;
    public int gold;
}

class Program
{
    string ?command;
    Character player;
    bool isPlayerCreated = false;
    static void Main(string[] args)
    {
        Program program = new Program();
        program.GameLoop();
    }
    public void GameLoop()
    {
        // Initialize the player character
        InitializePlayer(ref player);
        // Begins the character creation process
        StartCharacterCreation();

        // Introduce the scene to the player
        // BeginIntroScene();

        while (true)
        {
            SimulateTyping("Please enter a command. Type help for more commands:");
            command = Console.ReadLine();
            PlayerCommands(command);
        }
    }
    public void InitializePlayer(ref Character newCharacter)
    {
        newCharacter.name = "";
        newCharacter.level = 1;
        newCharacter.currentHealth = 100;
        newCharacter.maxHealth = 100;
        newCharacter.currentMana = 100;
        newCharacter.maxMana = 100;
        newCharacter.strength = 5;
        newCharacter.dexterity = 5;
        newCharacter.constitution = 5;
        newCharacter.intelligence = 5;
        newCharacter.wisdom = 5;
        newCharacter.charisma = 5;
        newCharacter.armor = 5;
        newCharacter.damage = 5;
        newCharacter.speed = 10;
        newCharacter.experience = 0;
        newCharacter.experienceToLevelUp = 100;
        newCharacter.gold = 0;
    }
    public void PlayerCommands(string ?command)
    {
        switch (command)
        {
            case "help":
                GetHelp();
                break;
            case "stats":
                DisplayPlayerStats();
                break;
            case "inv":
                Console.WriteLine("To be implemented.");
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
        Console.WriteLine("help – gives a list of commands");
        Console.WriteLine("attack – attack an enemy");
        Console.WriteLine("defend – defend against an enemy attack");
        Console.WriteLine("inv – view your inventory");
        Console.WriteLine("run – run away from an enemy");
        Console.WriteLine("stats – view your character's stats");
        Console.WriteLine();
    }
    public void SimulateTyping(string creationMessage)
    {
        for (int i = 0; i < creationMessage.Length; i++)
        {
            Console.Write(creationMessage[i]);
            //Thread.Sleep(50); // Simulate a typing effect
        }
        Console.WriteLine();
    }
    public void StartCharacterCreation()
    {
        if (isPlayerCreated == true)
        {
            SimulateTyping("You have already created a character. Please type 'stats' to view your character's stats.");
            return;
        }
        isPlayerCreated = true;
        bool nameReady = false;
        string ?input;

        SimulateTyping("Booting up character creation...");
        
        // Character Name Creation
        while (nameReady == false || player.name == null)
        {
            SimulateTyping("Please enter your character's name:");
            
            player.name = Console.ReadLine();
            
            SimulateTyping( $"Your name is {player.name}. Is this correct?");

            Console.WriteLine($"Type y/n");
            input = Console.ReadLine();
            if (input == "y") { break; }
            
        }

        bool firstTime = true;
        int pointsToAllot = 10;
        while (true)
        {

            if (firstTime == false) // So we don't waste time printing this message again
            {
                SimulateTyping($"Points Remaining: {pointsToAllot}");
                Console.WriteLine("Please enter the stat you would like to allot points to:");
                Console.WriteLine("1. Strength\n2. Dexterity\n3. Constitution\n4. Intelligence\n5. Wisdom\n6. Charisma\n7. None");
            }    

            if (firstTime == true)
            {
                SimulateTyping($"Hello, {player.name}! Now, let's set up your character.");
                SimulateTyping($"You have {pointsToAllot} points to allot to your stats. You can allot them to strength, dexterity, constitution, intelligence, wisdom, or charisma. You can also choose to not allot any points.");
                SimulateTyping($"Points Remaining: {pointsToAllot}\nPlease enter the stat you would like to allot points to:");
                SimulateTyping("1. Strength\n2. Dexterity\n3. Constitution\n4. Intelligence\n5. Wisdom\n6. Charisma\n7. None");
                firstTime = false; // Set to false after the first iteration
            }

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SimulateTyping("You have chosen to allot points to strength.");
                    player.strength += 1;
                    break;
                case "2":
                    SimulateTyping("You have chosen to allot points to dexterity.");
                    player.dexterity += 1;
                    break;
                case "3":
                    SimulateTyping("You have chosen to allot points to constitution.");
                    player.constitution += 1;
                    break;
                case "4":
                    SimulateTyping("You have chosen to allot points to intelligence.");
                    player.intelligence += 1;
                    break;
                case "5":
                    SimulateTyping("You have chosen to allot points to wisdom.");
                    player.wisdom += 1;
                    break;
                case "6":
                    SimulateTyping("You have chosen to allot points to charisma.");
                    player.charisma += 1;
                    break;
                case "7":
                    SimulateTyping("You have chosen to not allot any points.");
                    break;
                default:
                    SimulateTyping("Invalid input. Please try again.");
                    continue; // Skip the rest of the loop and ask for input again
            }

            // Check if pointsToAllot is 0
            pointsToAllot -= 1;
            if (pointsToAllot == 0)
            {
                SimulateTyping("You have allotted all of your points. Your character is now ready!");
                break; // Exit the loop
            }
        }

        // Now that the character is created, display the stats
        DisplayPlayerStats();

        SimulateTyping("\nCharacter creation complete! You can now start your adventure.");
        SimulateTyping("Press any key to continue...");
        Console.ReadKey(true); // Wait for the user to press a key
    }
    public void DisplayPlayerStats()
    {
        SimulateTyping($"Your character's stats are as follows:\nName: {player.name}\nLevel: {player.level}\nCurrent Health: {player.currentHealth}\nMax Health: {player.maxHealth}\nCurrent Mana: {player.currentMana}\nMax Mana: {player.maxMana}\nStrength: {player.strength}\nDexterity: {player.dexterity}\nConstitution: {player.constitution}\nIntelligence: {player.intelligence}\nWisdom: {player.wisdom}\nCharisma: {player.charisma}\nArmor: {player.armor}\nDamage: {player.damage}\nSpeed: {player.speed}\nExperience: {player.experience}\nExperience to Level Up: {player.experienceToLevelUp}\nGold: {player.gold}");
    }
}