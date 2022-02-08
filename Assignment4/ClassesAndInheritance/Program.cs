// See https://aka.ms/new-console-template for more information

using System;

namespace App
{
    class EmployeeTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n-------------- CLASSES AND INHERITANCE ---------------\n");

            Console.WriteLine("\n------------------- EMPLOYEE --------------------\n");
            Employee E1 = new Employee("Bhavin", "Sheth", 55000);
            Employee E2 = new Employee("Mihir", "Agarwal", 62000);

            Console.WriteLine("\nBEFORE RAISE");
            Console.WriteLine(E1);
            Console.WriteLine(E2);
            E1.giveRaise(10);
            E2.giveRaise(10);
            Console.WriteLine("\nAFTER RAISE");
            Console.WriteLine(E1);
            Console.WriteLine(E2);

            Console.WriteLine("\n-------------- PERMANENT EMPLOYEE ---------------\n");
            PermanentEmployee PE1 = new PermanentEmployee("Raj", "Jadhav", 40000, 15000, 1000, 2000, new DateTime(2022, 02, 01), new DateTime(2052, 02, 01));
            PermanentEmployee PE2 = new PermanentEmployee("Chaitanya", "Nagdev", 50000, 13000, 1500, 1000, new DateTime(2022, 03, 01), new DateTime(2052, 03, 01));

            Console.WriteLine("\nBEFORE RAISE");
            Console.WriteLine(PE1);
            Console.WriteLine(PE2);
            PE1.giveRaise(10);
            PE2.giveRaise(10);
            Console.WriteLine("\nAFTER RAISE");
            Console.WriteLine(PE1);
            Console.WriteLine(PE2);

            Console.WriteLine("\n");
        }
    }

    public class Employee
    {
        protected string _firstName;
        protected string _lastName;
        protected double _monthlySalary;

        public Employee(string firstName, string lastName, double monthlySalary)
        {
            _firstName = firstName;
            _lastName = lastName;
            _monthlySalary = monthlySalary;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public double MonthlySalary
        {
            get => _monthlySalary;
            set => _monthlySalary = value < 0 ? 0.0 : value;
        }

        public override string ToString()
        {
            string s = "\nEmployee - ";
            s += "\nFirst Name: " + _firstName + ", Last Name: " + _lastName;
            s += "\nMonthly Salary: " + _monthlySalary;
            return s;
        }

        public virtual void giveRaise(double percentage)
        {
            _monthlySalary += (percentage / 100) * _monthlySalary;
        }
    }

    public class PermanentEmployee : Employee
    {
        private double _dearnessAllowance;
        private double _housingRentAllowance;
        private double _providentFund;
        private DateTime _joiningDate;
        private DateTime _expectedRetirementDate;

        public PermanentEmployee(string firstName, string lastName, double monthlySalary, double housingRentAllowance, double dearnessAllowance, double providentFund, DateTime joiningDate, DateTime expectedRetirementDate) : base(firstName, lastName, monthlySalary)
        {
            _housingRentAllowance = housingRentAllowance;
            _dearnessAllowance = dearnessAllowance;
            _providentFund = providentFund;
            _joiningDate = joiningDate;
            _expectedRetirementDate = expectedRetirementDate;
        }

        public double HousingRentAllowance
        {
            get => _housingRentAllowance;
        }

        public double DearnessAllowance
        {
            get => _dearnessAllowance;
        }

        public double ProvidentFund
        {
            get => _providentFund;
        }

        public DateTime JoiningDate
        {
            get => _joiningDate;
        }

        public DateTime ExpectedRetirementDate
        {
            get => _expectedRetirementDate;
        }

        public override string ToString()
        {
            string s = "\nPermanent Employee - ";
            s += "\nFirst Name: " + _firstName + ", Last Name: " + _lastName;
            s += "\nHousing Rent Allowance: " + _housingRentAllowance;
            s += "\nDearness Allowance: " + _dearnessAllowance;
            s += "\nProvident Fund: " + _providentFund;
            s += "\nMonthly Salary: " + _monthlySalary;
            s += "\nJoining Date: " + _joiningDate.ToString("dddd, dd MMMM yyyy");
            s += "\nExpected Retirement Date: " + _expectedRetirementDate.ToString("dddd, dd MMMM yyyy");
            return s;
        }

        public override void giveRaise(double percentage)
        {
            base.giveRaise(percentage);
            _monthlySalary += _housingRentAllowance + _dearnessAllowance;
        }

    }
}