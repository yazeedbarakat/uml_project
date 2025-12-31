using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    }

    class Student : User
    {
        List<string> RegisteredCourses;

        public Student(string user_ID, string name, List<string> regestird_courses)
            : base(user_ID, name)
        {
            this.RegisteredCourses = regestird_courses;
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
        List<string> TaughtCourses;

        public FacultyMember(string user_ID, string name, List<string> taught_courses)
            : base(user_ID, name)
        {
            TaughtCourses = taught_courses;
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

        public void Display_Transaction()
        {
            string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
            Console.WriteLine($"ID: {TransactionID} | Card: {CardNumber} | Type: {Type} | Amount: {amountStr}");
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
        List<string> Attendees;

        public Attendance(string course_ID, string date)
        {
            Course_ID = course_ID;
            Date = date;
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
            Students = new List<Student>();
            FacultyMembers = new List<FacultyMember>();
            Cards = new List<Card>();
            Transactions = new List<Transaction>();
            Attendances = new List<Attendance>();
        }
        private void SaveALLFiles()
        {
            // For now, just use simple text format
            // We'll improve this later

            // Save students
            using (StreamWriter sw = new StreamWriter("students.txt"))
            {
                foreach (var student in Students)
                {
                    sw.WriteLine(student.ToString());
                }
            }

            // Save faculty
            using (StreamWriter sw = new StreamWriter("faculty.txt"))
            {
                foreach (var faculty in FacultyMembers)
                {
                    sw.WriteLine(faculty.ToString());
                }
            }

            // Save cards
            using (StreamWriter sw = new StreamWriter("cards.txt"))
            {
                foreach (var card in Cards)
                {
                    sw.WriteLine(card.ToString());
                }
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
        public void ViewALLCards()
        {
            foreach (var card in Cards)
            {
                card.Display_Card_Info();
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
                            Console.WriteLine("Issuing Card...\n");
                            break;
                        case "2":
                            Console.WriteLine("Blocking Card...\n");
                            break;
                        case "3":
                            Console.WriteLine("Unblocking Card...\n");
                            break;
                        case "4":
                            systemManager.ViewALLCards();
                            break;
                        case "5":
                            Console.WriteLine("Viewing All Transactions...\n");
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
