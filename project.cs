using System;
using System.Collections.Generic;

namespace umlproject
{
    abstract class User
    {
        public string User_ID { get; set; }
        public string Name { get; set; }
        public User(string user_ID, string name)
        {
            this.User_ID = user_ID;
            this.Name = name;
        }
    }
    class Student : User
    {

        List<string> Registered_Courses;
        public Student(string user_ID, string name, List<string> regestird_courses) : base(user_ID, name)
        {
            this.Registered_Courses = regestird_courses;
        }
        public List<string> GetRegestirdCourses()
        {
            return Registered_Courses;
        }
        public void AddCourse(string course)
        {
            Registered_Courses.Add(course);
        }
        public void Remove_Course(string course)
        {
            Registered_Courses.Remove(course);
        }
        public void Display_Courses()
        {
            Console.WriteLine("Regestird Courses:");
            foreach (var course in Registered_Courses)
            {
                Console.WriteLine(course);
            }
        }
        public override string ToString()
        {
            return $"{User_ID},{Name},{string.Join(";", Registered_Courses)}"; ;
        }
    }
    class Faculty_member : User
    {
        List<string> Taught_Courses;
        public Faculty_member(string user_ID, string name, List<string> taught_courses) : base(user_ID, name)
        {
            Taught_Courses = taught_courses;
        }
        public List<string> Get_Taught_Courses()
        {
            return Taught_Courses;
        }
        public void Add_Taught_Course(string course)
        {
            Taught_Courses.Add(course);
        }
        public void Remove_Taught_Course(string course)
        {
            Taught_Courses.Remove(course);
        }
        public void Display_Taught_Courses()
        {
            Console.WriteLine("Taught Courses:");
            foreach (var course in Taught_Courses)
            {
                Console.WriteLine(course);
            }
        }
        public override string ToString()
        {
            return $"{User_ID},{Name},{string.Join(";", Taught_Courses)}";
        }
    }
    class Card
    {
        public int Card_Number { get; set; }
        public double Balance { get; set; }
        public string Status { get; set; }
        public string User_ID { get; set; }
        public string Type { get; set; }
        public Card(int card_number, double balance, string status, string user_id, string type)
        {
            Card_Number = card_number;
            Balance = balance;
            Status = status;
            User_ID = user_id;
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
            Console.WriteLine("=== Card Information ===");
            Console.WriteLine($"Card Number: {Card_Number}");
            Console.WriteLine($"Balance: {Balance} JD");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"User ID: {User_ID}");
            Console.WriteLine("========================");
        }
        public override string ToString()
        {
            return $"{Card_Number},{Balance},{Status},{User_ID},{Type}";
        }
        class Transaction
        {
            public string Transaction_ID { get; set; }
            public int Card_Number { get; set; }
            public string Type { get; set; }
            public double Amount { get; set; }
            public Transaction(string transaction_ID, int card_number, string type, double amount)
            {
                Transaction_ID = transaction_ID;
                Card_Number = card_number;
                Type = type;
                Amount = amount;
            }
            public void Display_Transaction()
            {
                string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
                Console.WriteLine($"ID: {Transaction_ID} | Card: {Card_Number} | Type: {Type} | Amount: {amountStr}");
            }
            public override string ToString()
            {
                string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
                return $"{Transaction_ID},{Card_Number},{Type},{amountStr}";
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
                    { "Steak" , 8},
                    { "Soup" , 2 },
                    { "Sandwich", 3 },
                    { "Salad" , 4 },
                    { "Tea" , 2 },
                    { "Juice" , 3 },
                    { "Cake" , 5 },
                    { "Water" , 1 }
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
            class Bus_Service
            {
                string route;
                double cost;
            }
            class car_parking
            {
                int parking_spot;
                double cost;
            }
            class System_manger
            {

            }
            class File_manager
            {

            }
            internal class Program
            {
                static void Main(string[] args)
                {
    
                }
            }
        }
    }
}
