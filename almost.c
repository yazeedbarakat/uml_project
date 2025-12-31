using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace UniversityCardManagementSystem
{
    abstract class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }

        public User(string user_ID, string name)
        {
            this.UserID = user_ID;
            this.Name = name;
        }
        public User() 
        {
            UserID = "";
            Name = "";
        }
    }

    class Student : User
    {
        public List<string> RegisteredCourses;

        public Student(string user_ID, string name, List<string> regestird_courses)
            : base(user_ID, name)
        {
            this.RegisteredCourses = regestird_courses;
        }
        public Student() : base("", "")
        {
            RegisteredCourses = new List<string>();
        }
        public List<string> GetRegestirdCourses()
        {
            return RegisteredCourses;
        }

        public void AddCourse(string course)
        {
            RegisteredCourses.Add(course);
        }

        public void Remove_Course(string course)
        {
            RegisteredCourses.Remove(course);
        }

        public void Display_Courses()
        {
            Console.WriteLine("Regestird Courses:");
            foreach (var course in RegisteredCourses)
            {
                Console.WriteLine(course);
            }
        }

        public override string ToString()
        {
            return UserID + "," + Name + "," + string.Join(";", RegisteredCourses);
        }
    }

    class FacultyMember : User
    {
        public List<string> TaughtCourses;

        public FacultyMember(string user_ID, string name, List<string> taught_courses)
            : base(user_ID, name)
        {
            TaughtCourses = taught_courses;
        }
        public FacultyMember() : base("", "")
        {
            TaughtCourses = new List<string>();
        }

        public List<string> Get_Taught_Courses()
        {
            return TaughtCourses;
        }

        public void Add_Taught_Course(string course)
        {
            TaughtCourses.Add(course);
        }

        public void Remove_Taught_Course(string course)
        {
            TaughtCourses.Remove(course);
        }

        public void Display_Taught_Courses()
        {
            Console.WriteLine("Taught Courses:");
            foreach (var course in TaughtCourses)
            {
                Console.WriteLine(course);
            }
        }

        public override string ToString()
        {
            return UserID + "," + Name + "," + string.Join(";", TaughtCourses);
        }
    }

    class Card
    {
        public int CardNumber { get; set; }
        public double Balance { get; set; }
        public string Status { get; set; }
        public string UserID { get; set; }
        public string Type { get; set; }

        public Card(int card_number, double balance, string type, string status, string userid)
        {
            CardNumber = card_number;
            Balance = balance;
            Status = status;
            UserID = userid;
            Type = type;
        }

        public Card() 
        {
            CardNumber = 0;
            Balance = 0;
            Status = "";
            UserID = "";
            Type = "";
        }
        public bool Is_Blocked()
        {
            return Status.ToLower() == "blocked";
        }

        public void recharge(double amount)
        {
            Balance += amount;
        }

        public bool deduct(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Display_Card_Info()
        {
            Console.WriteLine("Card Number: " + CardNumber);
            Console.WriteLine("Balance: " + Balance + "JD");
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("User ID: " + UserID);
        }

        public override string ToString()
        {
            return CardNumber + "," + Balance + "," + Type + "," + Status + "," + UserID;
        }
    }
    class Transaction
    {
        public string TransactionID { get; set; }
        public int CardNumber { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }

        public Transaction(string transaction_ID, int card_number, string type, double amount, string date)
        {
            TransactionID = transaction_ID;
            CardNumber = card_number;
            Type = type;
            Amount = amount;
            Date = date;
        }
        public Transaction()
        {
            TransactionID = "";
            CardNumber = 0;
            Type = "";
            Amount = 0;
            Date = "";
        }

        public void Display_Transaction()
        {
            Console.WriteLine("Transaction ID: " + TransactionID + " Card Number: " + CardNumber + " Type: " + Type + " Amount: " + Amount + " Date: " + Date);
        }

        public override string ToString()
        {
            string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
            return $"{TransactionID},{CardNumber},{Type},{amountStr}";
        }
    }

    class Attendance
    {
        public string Course_ID { get; set; }
        public string Date { get; set; }
        public List<string> Attendees;

        public Attendance(string course_ID, string date)
        {
            Course_ID = course_ID;
            Date = date;
            Attendees = new List<string>();
        }
        public Attendance()
        {
            Course_ID = "";
            Date = "";
            Attendees = new List<string>();
        }

        public void Add_Attendee(string user_id)
        {
            Attendees.Add(user_id);
        }

        public void Remove_Attendee(string user_id)
        {
            Attendees.Remove(user_id);
        }

        public void Display_Attendees()
        {
            Console.WriteLine($"Course: {Course_ID} | Date: {Date}");
            Console.WriteLine($"Attendees: {string.Join(", ", Attendees)}");
            Console.WriteLine($"Total: {Attendees.Count} students");
        }

        public override string ToString()
        {
            return $"{Course_ID},{Date},{string.Join(";", Attendees)}";
        }
    }
    class Cafeteria_Service
    {
        Dictionary<string, double> Menu;

        public Cafeteria_Service()
        {
            Menu = new Dictionary<string, double>
            {
                { "Steak", 8 },
                { "Soup", 2 },
                { "Sandwich", 3 },
                { "Salad", 4 },
                { "Tea", 2 },
                { "Juice", 3 },
                { "Cake", 5 },
                { "Water", 1 }
            };
        }

        public void Display_Menu()
        {
            Console.WriteLine("\n=== Cafeteria Menu ===");
            int count = 1;
            foreach (var item in Menu)
            {
                Console.WriteLine($"{count}. {item.Key}: {item.Value} JD");
                count++;
            }
            Console.WriteLine("======================");
        }

        public double Calculate_Total(List<string> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                if (Menu.ContainsKey(item))
                {
                    total += Menu[item];
                }
            }
            return total;
        }

        public List<string> Get_Menu_Items()
        {
            return new List<string>(Menu.Keys);
        }
    }

    class Bus_Service
    {
        public string Track_1_Origin { get; set; }
        public string Track_1_Destination { get; set; }
        public double Track_1_Cost { get; set; }

        public string Track_2_Origin { get; set; }
        public string Track_2_Destination { get; set; }
        public double Track_2_Cost { get; set; }

        public string Track_3_Origin { get; set; }
        public string Track_3_Destination { get; set; }
        public double Track_3_Cost { get; set; }

        public Bus_Service()
        {
            Track_1_Origin = "main gate";
            Track_1_Destination = "Northern buildings";
            Track_1_Cost = 3;

            Track_2_Origin = "main gate";
            Track_2_Destination = "Southern buildings";
            Track_2_Cost = 4;

            Track_3_Origin = "main gate";
            Track_3_Destination = "Library";
            Track_3_Cost = 5;
        }

        public void DisplayTracks()
        {
            Console.WriteLine("\n=== BUS TRACKS ===");
            Console.WriteLine("1) " + Track_1_Origin + "  " + Track_1_Destination + " | Cost: " + Track_1_Cost + " JD");
            Console.WriteLine("2) " + Track_2_Origin + "  " + Track_2_Destination + " | Cost: " + Track_2_Cost + " JD");
            Console.WriteLine("3) " + Track_3_Origin + "  " + Track_3_Destination + " | Cost: " + Track_3_Cost + " JD");
            Console.WriteLine("==================");
        }

        public double Get_Track_Cost(int choice)
        {
            switch (choice)
            {
                case 1: return Track_1_Cost;
                case 2: return Track_2_Cost;
                case 3: return Track_3_Cost;
                default: return 0;
            }
        }

        public string GetT_rack_Info(int choice)
        {
            switch (choice)
            {
                case 1: return Track_1_Origin + "  " + Track_1_Destination;
                case 2: return Track_2_Origin + "  " + Track_2_Destination;
                case 3: return Track_3_Origin + "  " + Track_3_Destination;
                default: return "Invalid Track";
            }
        }
    }
    class Car_Parking
    {
        public void Display_Rates()
        {
            Console.WriteLine("\n=== Car Parking Rates ===");
            Console.WriteLine("[1] first hour: 5 JD\n[2] second hour: 4 JD\n[3] third hour: 3 JD\n[4] fourth hour: 2 JD\n[5] fivth hour: 1 JD\n[6] above 5 hours for free");
            Console.WriteLine("=========================");
        }

        public double Calculate_Cost(int Hours)
        {
            double Cost = 0;
            while (Hours > 0)
            {
                switch (Hours)
                {
                    case 1: Cost += 5; break;
                    case 2: Cost += 4; break;
                    case 3: Cost += 3; break;
                    case 4: Cost += 2; break;
                    case 5: Cost += 1; break;
                }
                Hours--;
            }
            return Cost;
        }
    }

    class SystemManager
    {
        List<Student> Students;
        List<FacultyMember> FacultyMembers;
        List<Card> Cards;
        List<Transaction> Transactions;
        List<Attendance> Attendances;
        public SystemManager()
        {
            if (!File.Exists("students.json"))
            {
                LoadInitialData();
            }
            else
            {
                LoadFromFiles();
            }
        }
        private void LoadInitialData()
        {
            Students = new List<Student>
        {
            new Student("S01", "Ali", new List<string> { "CPE100", "SE400" }),
            new Student("S02", "Omar", new List<string> { "CPE100", "NES200" }),
            new Student("S03", "Reem", new List<string> { "NES200", "CIS300", "SE400" }),
            new Student("S04", "Maher", new List<string> { "CPE100", "SE400" })
        };
            FacultyMembers = new List<FacultyMember>
        {
            new FacultyMember("F01", "Sami", new List<string> { "CPE100", "CIS300" }),
            new FacultyMember("F02", "Eman", new List<string> { "NES200", "SE400" })
        };
            Cards = new List<Card>()
        {
            new Card(10, 80, "faculty member", "unblocked", "F02"),
            new Card(20, 110, "student", "unblocked", "S02"),
            new Card(30, 95, "student", "blocked", "S03"),
            new Card(40, 160, "student", "unblocked", "S04")
        };
            Transactions = new List<Transaction>();
            Attendances = new List<Attendance>();
            SaveALLFiles();
        }
        private void LoadFromFiles()
        {
            if (File.Exists("students.json"))
            {
                string json = File.ReadAllText("students.json");
                Students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
            else
                Students = new List<Student>();

            if (File.Exists("faculty.json"))
            {
                string json = File.ReadAllText("faculty.json");
                FacultyMembers = JsonSerializer.Deserialize<List<FacultyMember>>(json) ?? new List<FacultyMember>();
            }
            else
                FacultyMembers = new List<FacultyMember>();

            if (File.Exists("cards.json"))
            {
                string json = File.ReadAllText("cards.json");
                Cards = JsonSerializer.Deserialize<List<Card>>(json) ?? new List<Card>();
            }
            else
                Cards = new List<Card>();

            if (File.Exists("transactions.json"))
            {
                string json = File.ReadAllText("transactions.json");
                Transactions = JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
            else
                Transactions = new List<Transaction>();

            if (File.Exists("attendance.json"))
            {
                string json = File.ReadAllText("attendance.json");
                Attendances = JsonSerializer.Deserialize<List<Attendance>>(json) ?? new List<Attendance>();
            }
            else
                Attendances = new List<Attendance>();
        }
        private void SaveALLFiles()
        {
            File.WriteAllText("students.json",
                JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true }));

            File.WriteAllText("faculty.json",
                JsonSerializer.Serialize(FacultyMembers, new JsonSerializerOptions { WriteIndented = true }));

            File.WriteAllText("cards.json",
                JsonSerializer.Serialize(Cards, new JsonSerializerOptions { WriteIndented = true }));

            File.WriteAllText("transactions.json",
                JsonSerializer.Serialize(Transactions, new JsonSerializerOptions { WriteIndented = true }));

            File.WriteAllText("attendance.json",
                JsonSerializer.Serialize(Attendances, new JsonSerializerOptions { WriteIndented = true }));
        
        }
        public Card GetCard(int cardNumber)
        {
            foreach (var card in Cards)
            {
                if (card.CardNumber == cardNumber)
                {
                    return card;
                }
            }
            return null;
        }
        private Student GetStudent(string userId)
        {
            foreach (var student in Students)
            {
                if (student.UserID == userId)
                    return student;
            }
            return null;
        }
        private FacultyMember GetFaculty(string userID)
        {
            foreach (var faculty in FacultyMembers)
            {
                if (faculty.UserID == userID)
                    return faculty;
            }
            return null;
        }

        public void IssueCard()
        {
            Console.Write("\nEnter card number: ");
            int CardNumber = int.Parse(Console.ReadLine());
            if (GetCard(CardNumber) != null)
            {
                Console.WriteLine("card number already exists!");
                return;
            }
            Console.Write("Enter card type (student/faculty member): ");
            string type = Console.ReadLine();

            Console.Write("Enter user ID: ");
            string UserId = Console.ReadLine();

            if (type == "student")
            {
                Student student = GetStudent(UserId);
                if (student == null)
                {
                    Console.WriteLine("Student ID not found!");
                    return;
                }
            }
            else if (type == "faculty member")
            {
                FacultyMember faculty = GetFaculty(UserId);
                if (faculty == null)
                {
                    Console.WriteLine("Faculty ID not found");
                    return;
                }
            }
            else
            {
                return;
            }
        }
        public void BlockCard()
        {
            Console.Write("\nUnblocked cards:\n");
            var UnblockedCards = new List<Card>();
            foreach (var card in Cards)
            {
                if (!card.Is_Blocked())
                {
                    UnblockedCards.Add(card);
                }
            }
            if (UnblockedCards.Count == 0)
            {
                Console.WriteLine("No unblocked cards found!\n");
                return;
            }
            foreach (var card in UnblockedCards)
            {
                Console.WriteLine("Card Number: " + card.CardNumber + " | User ID: " + card.UserID);
            }
            Console.Write("\nEnter card number to block: ");
            int cardNumber = int.Parse(Console.ReadLine());
            Card cardToBlock = GetCard(cardNumber);
            if (cardToBlock == null || cardToBlock.Is_Blocked())
            {
                Console.WriteLine("Invalid card number!\n");
                return;
            }
            cardToBlock.Status = "blocked";
            SaveALLFiles();
            Console.WriteLine("Card blocked successfully!\n");
        }
        public void UnblockCard()
        {
            Console.Write("\nBlocked cards:\n");
            var BlockedCards = new List<Card>();
            foreach (var card in Cards)
            {
                if (card.Is_Blocked())
                {
                    BlockedCards.Add(card);
                }
            }
            if (BlockedCards.Count == 0)
            {
                Console.WriteLine("No blocked cards found!\n");
                return;
            }
            foreach (var card in BlockedCards)
            {
                Console.WriteLine("Card Number: " + card.CardNumber + " | User ID: " + card.UserID);
            }
            Console.Write("\nEnter card number to unblock: ");
            int cardNumber = int.Parse(Console.ReadLine());
            Card cardToUnblock = GetCard(cardNumber);
            if (cardToUnblock == null || !cardToUnblock.Is_Blocked())
            {
                Console.WriteLine("Invalid card number!\n");
                return;
            }
            cardToUnblock.Status = "unblocked";
            SaveALLFiles();
            Console.WriteLine("Card unblocked successfully!\n");
        }
        public void ViewALLCards()
        {
            foreach (var card in Cards)
            {
                card.Display_Card_Info();
                Console.WriteLine();
            }
        }
        public void ViewALLTransactions()
        {
            foreach (var transaction in Transactions)
            {
                transaction.Display_Transaction();
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static SystemManager systemManager = new SystemManager();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("[1] Login As Admin");
                Console.WriteLine("[2] Login As Card Holder");
                Console.WriteLine("[3] Exit\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminLogin();
                        break;
                    case "2":
                        CardHolderLogin();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                }
            }
        }
            static void AdminLogin()
            {
                while (true)
                {
                    Console.WriteLine("[1] Issue Card");
                    Console.WriteLine("[2] Block Card");
                    Console.WriteLine("[3] Unblock Card");
                    Console.WriteLine("[4] View All Cards");
                    Console.WriteLine("[5] View All Transactions");
                    Console.WriteLine("[6] Back To Main Login Screen\n");
                    Console.Write("Enter your choice: ");
                    string adminChoice = Console.ReadLine();
                    switch (adminChoice)
                    {
                        case "1":
                            systemManager.IssueCard();
                            break;
                        case "2":
                            systemManager.BlockCard();
                        break;
                        case "3":
                            systemManager.UnblockCard();
                        break;
                        case "4":
                            systemManager.ViewALLCards();
                            break;
                        case "5":
                            systemManager.ViewALLTransactions();
                        break;
                        case "6":
                            return;
                    }
                }
            }

            static void CardHolderLogin()
            {
                while (true)
                {
                    Console.WriteLine("[1] Student");
                    Console.WriteLine("[2] Faculty Member");
                    Console.WriteLine("[3] Back To Main Login Screen\n");
                    Console.Write("Enter your choice: ");

                    string cardHolderChoice = Console.ReadLine();
                    switch (cardHolderChoice)
                    {
                        case "1":
                            //StudentMenu();
                            break;
                        case "2":
                            //FacultyMenu();
                            break;
                        case "3":
                            return;
                    }
                }
            }
    }
}
