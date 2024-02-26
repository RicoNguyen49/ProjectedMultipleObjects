using System;

namespace PrivateMultipleObjects
{
    // Base Class
    class Club
    {
        protected int _id;
        protected string name;
        protected string location;
        protected int members;

        // Default constructor
        public Club()
        {
            _id = 0;
            name = "";
            location = "";
            members = 0;
        }

        // Parameterized constructor
        public Club(int _id, string name, string location, int members)
        {
            this._id = _id;
            this.name = name;
            this.location = location;
            this.members = members;

        }

        // Get and Set Methods
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        public string GetLocation() { return location; }
        public void SetLocation(string location) { this.location = location; }

        public int GetMembers() { return members; }
        public void SetMembers(int members) { this.members = members; }

        public int Get_iD() { return _id; }
        public void Set_iD(int _id) { this._id = _id; }

        // Virtual methods for add/change and display
        public virtual void AddChange()
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Location: ");
            location = Console.ReadLine();
            Console.Write("Members: ");
            members = int.Parse(Console.ReadLine());
            Console.Write("ID: ");
            _id = int.Parse(Console.ReadLine());

        }

        public virtual void Display()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Location: {location}");
            Console.WriteLine($"Members: {members}");
            Console.WriteLine($"ID: {_id}");
        }
    }

    // Derived Class
    class GamingClub : Club
    {
        protected string gameType;
        protected int onlinePlayers;

        // Default constructor
        public GamingClub() : base()
        {
            gameType = "";
            onlinePlayers = 0;
        }

        // Parameterized constructor ensuring base fields are initialized
        public GamingClub(int _id, string name, string location, int members, string gameType, int onlinePlayers)
            : base(_id, name, location, members)
        {
            this.gameType = gameType;
            this.onlinePlayers = onlinePlayers;
        }

        // Get and Set Methods
        public string GetGameType() { return gameType; }
        public void SetGameType(string gameType) { this.gameType = gameType; }

        public int GetOnlinePlayers() { return onlinePlayers; }
        public void SetOnlinePlayers(int onlinePlayers) { this.onlinePlayers = onlinePlayers; }

        // Override add/change and display methods
        public override void AddChange()
        {
            base.AddChange();
            Console.Write("Game Type: ");
            gameType = Console.ReadLine();
            Console.Write("Online Players: ");
            onlinePlayers = int.Parse(Console.ReadLine());
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Game Type: {gameType}");
            Console.WriteLine($"Online Players: {onlinePlayers}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many clubs do you want to enter?");
            int maxClubs;
            while (!int.TryParse(Console.ReadLine(), out maxClubs))
                Console.WriteLine("Please enter a whole number");
            Club[] emps = new Club[maxClubs];
            Console.WriteLine("How many gaming clubs do you want to enter?");
            int maxGaming;
            while (!int.TryParse(Console.ReadLine(), out maxGaming))
                Console.WriteLine("Please enter a whole number");

            // Array of Club objects
            GamingClub[] GamingClubs = new GamingClub[maxGaming];

            int choice, rec, type;
            int GamingCounter = 0;
            int ClubCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for gaming club or 2 for clubs");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Gaming clubs or 2 for clubs");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //gaming clubs
                            {
                                if (GamingCounter <= maxClubs)
                                {
                                    Console.WriteLine("Creating a new Gaming Club...");
                                    GamingClubs[GamingCounter] = new GamingClub(); // places an object in the array instead of null
                                    GamingClubs[GamingCounter].AddChange();
                                    GamingCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of clubs has been added");
                            }

                            else //club
                            {
                                if (ClubCounter <= maxClubs)
                                {
                                    emps[ClubCounter] = new Club(); // places an object in the array instead of null
                                    emps[ClubCounter].AddChange();
                                    ClubCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of managers has been added");
                            }
                            break;

                        case 2: // Change
                            Console.Write("Enter the club number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the club number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1)
                            {
                                while (rec > GamingCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the club number you want to change: ");
                                    rec--;
                                }
                                GamingClubs[rec].AddChange();
                            }

                            else
                            {
                                while (rec > ClubCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                emps[rec].AddChange();
                            }
                            break;

                        case 3: // Print All
                            if (type == 1) //Manager
                            {
                                Console.WriteLine("Printing all clubs...");
                                for (int i = 0; i < GamingCounter; i++)
                                    GamingClubs[i].Display();
                            }
                            else
                            {
                                for (int i = 0; i < ClubCounter; i++)
                                    emps[i].Display();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;

                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();
            }
        }

        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
