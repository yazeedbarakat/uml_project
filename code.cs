// yazeed barakat - ID 165936
// qusai awawdeh - Id 172298
// moath abu khait - Id 164369


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
        public List<string> RegisteredCourses { get; set; }

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
        public List<string> TaughtCourses { get; set; }

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

        public Transaction(string transaction_ID, int card_number, string type, double amount)
        {
            TransactionID = transaction_ID;
            CardNumber = card_number;
            Type = type;
            Amount = amount;
        }
        public Transaction()
        {
            TransactionID = "";
            CardNumber = 0;
            Type = "";
            Amount = 0;
        }

        public void Display_Transaction()
        {
            string amountStr = Amount != 0 ? Amount.ToString() + " JD" : "N/A";
            Console.WriteLine("Transaction ID: " + TransactionID + " Card Number: " + CardNumber + " Type: " + Type + " Amount: " + amountStr);
        }

        public override string ToString()
        {
            string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
            return TransactionID + "," + CardNumber + "," + Type + "," + amountStr;
        }
    }

    class Attendance
    {
        public string Course_ID { get; set; }
        public string Date { get; set; }
        public List<string> Attendees { get; set; }

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

        public string GetItemName(int choice)
        {
            if (choice < 1 || choice > Menu.Count)
            {
                return null;
            }
            var items = Menu.ToList();
            return items[choice - 1].Key;
        }
        public double GetItemPrice(int choice)
        {
            if (choice < 1 || choice > Menu.Count)
            {
                return 0;
            }
            var items = Menu.ToList();
            return items[choice - 1].Value;
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
        Cafeteria_Service Cafeteria = new Cafeteria_Service();
        Bus_Service Bus = new Bus_Service();
        Car_Parking Parking = new Car_Parking();
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
                using (FileStream fs = new FileStream("students.json", FileMode.Open, FileAccess.Read))
                {
                    Students = JsonSerializer.Deserialize<List<Student>>(fs) ?? new List<Student>();
                }
            }
            else
                Students = new List<Student>();

            if (File.Exists("faculty.json"))
            {
                using (FileStream fs = new FileStream("faculty.json", FileMode.Open, FileAccess.Read))
                {
                    FacultyMembers = JsonSerializer.Deserialize<List<FacultyMember>>(fs) ?? new List<FacultyMember>();
                }
            }
            else
                FacultyMembers = new List<FacultyMember>();

            if (File.Exists("cards.json"))
            {
                using (FileStream fs = new FileStream("cards.json", FileMode.Open, FileAccess.Read))
                {
                    Cards = JsonSerializer.Deserialize<List<Card>>(fs) ?? new List<Card>();
                }
            }
            else
                Cards = new List<Card>();

            if (File.Exists("transactions.json"))
            {
                using (FileStream fs = new FileStream("transactions.json", FileMode.Open, FileAccess.Read))
                {
                    Transactions = JsonSerializer.Deserialize<List<Transaction>>(fs) ?? new List<Transaction>();
                }
            }
            else
                Transactions = new List<Transaction>();

            if (File.Exists("attendance.json"))
            {
                using (FileStream fs = new FileStream("attendance.json", FileMode.Open, FileAccess.Read))
                {
                    Attendances = JsonSerializer.Deserialize<List<Attendance>>(fs) ?? new List<Attendance>();
                }
            }
            else
                Attendances = new List<Attendance>();
        }
        private void SaveALLFiles()
        {
            using (FileStream fs = new FileStream("students.json", FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, Students);
            }

            using (FileStream fs = new FileStream("faculty.json", FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, FacultyMembers);
            }

            using (FileStream fs = new FileStream("cards.json", FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, Cards);
            }

            using (FileStream fs = new FileStream("transactions.json", FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, Transactions);
            }

            using (FileStream fs = new FileStream("attendance.json", FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, Attendances);
            }
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
            Card newCard = new Card(CardNumber, 50, type, "unblocked", UserId);
            Cards.Add(newCard);
            SaveALLFiles();
            Console.WriteLine("Card issued successfully!\n");
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
            if (Transactions.Count == 0)
            {
                Console.WriteLine("No transactions found!\n");
                return;
            }
            foreach (var transaction in Transactions)
            {
                transaction.Display_Transaction();
                Console.WriteLine();
            }
        }
        public void RechargeCard(int cardNumber)
        {
            Card card = GetCard(cardNumber);
            if (card == null)
            {
                Console.WriteLine("Card not found!");
                return;
            }
            card.Display_Card_Info();
            Console.Write("Enter amount to recharge: ");
            double amount = double.Parse(Console.ReadLine());
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }
            double OldBalance = card.Balance;
            card.recharge(amount);
            Console.WriteLine("\nRechared successfully");
            Console.WriteLine("Old balance: " + OldBalance + " JD");
            Console.WriteLine("New balance: " + card.Balance + " JD");
            Console.WriteLine("\nEnter transaction ID: ");
            string transactionID = Console.ReadLine();
            Transaction transaction = new Transaction(transactionID, cardNumber, "recharge", amount);
            Transactions.Add(transaction);
            SaveALLFiles();
        }
        public void RecordLectureAttendance(int cardNumber)
        {
            Card card = GetCard(cardNumber);
            Student student = GetStudent(card.UserID);
            if (card == null || student == null)
            {
                Console.WriteLine("Card or student not found!");
                return;
            }
            Console.WriteLine("\nRegistered courses for student " + student.Name + ":\n");
            int index = 1;
            foreach (var course in student.RegisteredCourses)
            {
                Console.WriteLine("[" + index++ + "]   " + course);
            }
            Console.Write("\nEnter course ID: ");
            string courseID = Console.ReadLine();
            if (!student.RegisteredCourses.Contains(courseID))
            {
                Console.WriteLine("Student is not registered for this course!");
                return;
            }
            Console.Write("Enter date (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            Attendance attendance = null;
            foreach (var att in Attendances)
            {
                if (att.Course_ID == courseID && att.Date == date)
                {
                    attendance = att;
                    break;
                }
            }
            if (attendance == null)
            {
                attendance = new Attendance(courseID, date);
                Attendances.Add(attendance);
            }

            foreach (var attendee in attendance.Attendees)
            {
                if (attendee == student.UserID)
                {
                    Console.WriteLine("Attendance already recorded for this course!");
                    return;
                }
            }
            attendance.Add_Attendee(student.UserID);
            Console.WriteLine("Attendance recorded successfully!\n");
            Console.Write("\nEnter transaction ID: ");
            string transactionID = Console.ReadLine();
            Transaction transaction = new Transaction(transactionID, cardNumber, "attendance", 0);
            Transactions.Add(transaction);
            SaveALLFiles();
        }
        public void PayForCafeteria(int cardNumber)
        {
            Card card = GetCard(cardNumber);
            if (card == null)
            {
                Console.WriteLine("Card not found!");
                return;
            }
            Cafeteria.Display_Menu();
            List<string> selectedItems = new List<string>();
            double totalcost = 0;
            while (true)
            {
                Console.Write("Enter item number to add to order or 0 to finish: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    break;
                }
                string itemName = Cafeteria.GetItemName(choice);
                double itemPrice = Cafeteria.GetItemPrice(choice);
                if (itemName == null)
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }
                selectedItems.Add(itemName);
                totalcost += itemPrice;
                Console.WriteLine(itemName + " added to order. Current total: " + totalcost + " JD");
            }
            if (totalcost == 0)
            {
                Console.WriteLine("No items selected!");
                return;
            }
            if (!card.deduct(totalcost))
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }
            else
            {
                Console.WriteLine("Payment successful! New balance: " + card.Balance + " JD");
                Console.Write("\nEnter transaction ID: ");
                string transactionID = Console.ReadLine();
                Transaction transaction = new Transaction(transactionID, cardNumber, "payment", totalcost);
                Transactions.Add(transaction);
                SaveALLFiles();
            }
        }
        public void PayForBusRide(int cardNumber)
        {
            Card card = GetCard(cardNumber);
            if (card == null)
            {
                Console.WriteLine("Card not found!");
                return;
            }
            Bus.DisplayTracks();
            Console.Write("\nEnter track number: ");
            int choice = int.Parse(Console.ReadLine());
            double trackCost = Bus.Get_Track_Cost(choice);
            if (trackCost == 0)
            {
                Console.WriteLine("Invalid track choice!");
                return;
            }
            if (!card.deduct(trackCost))
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }
            else
            {
                Console.WriteLine("Payment successful! New balance: " + card.Balance + " JD");
                Console.Write("\nEnter transaction ID: ");
                string transactionID = Console.ReadLine();
                Transaction transaction = new Transaction(transactionID, cardNumber, "payment", trackCost);
                Transactions.Add(transaction);
                SaveALLFiles();
            }
        }
        public void ViewTransactionHistory(int cardNumber)
        {
            var cardTransactions = new List<Transaction>();
            foreach (var transaction in Transactions)
            {
                if (transaction.CardNumber == cardNumber)
                {
                    cardTransactions.Add(transaction);
                }
            }
            if (cardTransactions.Count == 0)
            {
                Console.WriteLine("No transactions found for this card!\n");
                return;
            }
            foreach (var transaction in cardTransactions)
            {
                transaction.Display_Transaction();
                Console.WriteLine();
            }
        }
        public void AccessCarParking(int cardNumber)
        {
            Card card = GetCard(cardNumber);
            if (card == null)
            {
                Console.WriteLine("Card not found!");
                return;
            }
            Parking.Display_Rates();
            Console.Write("\nEnter number of hours: ");
            int hours = int.Parse(Console.ReadLine());
            double cost = Parking.Calculate_Cost(hours);
            Console.WriteLine("Total parking cost: " + cost + " JD");
            if (!card.deduct(cost))
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }
            else
            {
                Console.WriteLine("Payment successful! New balance: " + card.Balance + " JD");
                Console.Write("\nEnter transaction ID: ");
                string transactionID = Console.ReadLine();
                Transaction transaction = new Transaction(transactionID, cardNumber, "payment", cost);
                Transactions.Add(transaction);
                SaveALLFiles();
            }
        }
        public void GenerateAttendanceReport(int cardNumber)
        {
            Card card = GetCard(cardNumber);
            FacultyMember faculty = GetFaculty(card.UserID);
            if (card == null || faculty == null)
            {
                Console.WriteLine("Card or faculty member not found!");
                return;
            }
            Console.WriteLine("\nTaught courses for faculty member " + faculty.Name + ":\n");
            int index = 1;
            foreach (var course in faculty.TaughtCourses)
            {
                Console.WriteLine("[" + index++ + "]   " + course);
            }
            Console.Write("\nEnter course ID: ");
            string courseID = Console.ReadLine();
            if (!faculty.TaughtCourses.Contains(courseID))
            {
                Console.WriteLine("Faculty member does not teach this course!");
                return;
            }
            Console.Write("Enter date (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            Attendance attendance = null;
            foreach (var att in Attendances)
            {
                if (att.Course_ID == courseID && att.Date == date)
                {
                    attendance = att;
                    break;
                }
            }
            if (attendance == null)
            {
                Console.WriteLine("No attendance records found for this course on this date!");
                return;
            }
            attendance.Display_Attendees();
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
                Console.WriteLine("\n[1] Issue Card");
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
                Console.WriteLine("\n[1] Login AS Student");
                Console.WriteLine("[2] Login as Faculty Member");
                Console.WriteLine("[3] Back To Main Login Screen\n");
                Console.Write("Enter your choice: ");

                string cardHolderChoice = Console.ReadLine();
                switch (cardHolderChoice)
                {
                    case "1":
                        Console.WriteLine("Hmm, you're trying to login as student");
                        break;
                    case "2":
                        Console.WriteLine("Hmm, you're trying to login as faculty member");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        continue;
                }

                Console.Write("\nEnter valid card number: ");
                int cardNumber;
                if (!int.TryParse(Console.ReadLine(), out cardNumber))
                {
                    Console.WriteLine("Invalid card number!");
                    continue;
                }
                Card card = systemManager.GetCard(cardNumber);
                if (card == null)
                {
                    Console.WriteLine("Card not found!");
                    continue;
                }
                if (card.Is_Blocked())
                {
                    Console.WriteLine("Card is blocked!");
                    continue;
                }
                if (cardHolderChoice == "1" && card.Type != "student")
                {
                    Console.WriteLine("This card is not for a student!");
                    continue;
                }
                else if (cardHolderChoice == "2" && card.Type != "faculty member")
                {
                    Console.WriteLine("This card is not for a faculty member!");
                    continue;
                }
                if (cardHolderChoice == "1")
                {
                    StudentMenu(cardNumber);
                }
                else if (cardHolderChoice == "2")
                {
                    FacultyMenu(cardNumber);
                }
            }
        }
        static void StudentMenu(int cardnumber)
        {
            while (true)
            {
                Console.WriteLine("\n[1] Recharge card");
                Console.WriteLine("[2] Record lecture attendance");
                Console.WriteLine("[3] Pay for cafeteria");
                Console.WriteLine("[4] Pay for bus ride");
                Console.WriteLine("[5] View transaction history");
                Console.WriteLine("[6] Logout\n");
                Console.Write("Enter your choice: ");
                string studentChoice = Console.ReadLine();
                switch (studentChoice)
                {
                    case "1":
                        systemManager.RechargeCard(cardnumber);
                        break;
                    case "2":
                        systemManager.RecordLectureAttendance(cardnumber);
                        break;
                    case "3":
                        systemManager.PayForCafeteria(cardnumber);
                        break;
                    case "4":
                        systemManager.PayForBusRide(cardnumber);
                        break;
                    case "5":
                        systemManager.ViewTransactionHistory(cardnumber);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;

                }
            }
        }
        static void FacultyMenu(int cardnumber)
        {
            while (true)
            {
                Console.WriteLine("\n[1] Recharge card");
                Console.WriteLine("[2] Access card parking");
                Console.WriteLine("[3] Generate attendance report");
                Console.WriteLine("[4] Logout\n");
                Console.Write("Enter your choice: ");
                string facultyChoice = Console.ReadLine();
                switch (facultyChoice)
                {
                    case "1":
                        systemManager.RechargeCard(cardnumber);
                        break;
                    case "2":
                        systemManager.AccessCarParking(cardnumber);
                        break;
                    case "3":
                        systemManager.GenerateAttendanceReport(cardnumber);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
