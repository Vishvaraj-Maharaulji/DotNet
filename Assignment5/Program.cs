
// See https://aka.ms/new-console-template for more information

using System;

namespace App
{
    interface IVehicle
    {
        internal enum RentType
        {
            kms, days
        }
        internal double calculateRent(int units);
        internal void getInfo();
        internal DateOnly getLastMaintenanceDate();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.Write($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.Write("\n--------------------- GENERICS ----------------------\n");
            Indica indica1 = new Indica("Petrol", 5, "GJ-06-KN-0024", IVehicle.RentType.days, 5, 1000, new DateOnly(2020, 12, 16));
            MBenzEclass mBenz1 = new MBenzEclass(7, "GJ-01-AB-7875", IVehicle.RentType.kms, 3, 17, new DateOnly(2021, 07, 18));
            Qualis qualis1 = new Qualis("Diesel", 7, "Gj-04-GS-5700", IVehicle.RentType.kms, 7, 13, new DateOnly(2022, 11, 21));
            Davidharley dHarley1 = new Davidharley("GJ-01-HI-0210", IVehicle.RentType.kms, 5, 14, new DateOnly(2022, 02, 28));
            MBenzEclass mBenz2 = new MBenzEclass(7, "GJ-01-AB-7875", IVehicle.RentType.kms, 3, 17, new DateOnly(2020, 10, 26));

            RentedVehicle<IVehicle> rv = new RentedVehicle<IVehicle>();

            rv.addVehicle(indica1);
            rv.addVehicle(mBenz1);
            rv.addVehicle(qualis1);
            rv.addVehicle(dHarley1);
            rv.addVehicle(mBenz2);

            rv.giveForRent(indica1, new DateOnly(2021, 12, 20), new DateOnly(2021, 12, 29), 0);
            rv.giveForRent(qualis1, new DateOnly(2022, 07, 10), new DateOnly(2022, 07, 15), 500);
            rv.giveForRent(mBenz1, new DateOnly(2022, 09, 05), new DateOnly(2022, 09, 19), 1500);

            Console.Write($"\nTotal Rent Per {5} {indica1.rentType} for this vehicle : {rv.calculateRent(indica1, 5)}");
            Console.Write($"\nTotal Rent Per {50} {qualis1.rentType} for this vehicle : {rv.calculateRent(qualis1, 50)}");
            Console.Write($"\nTotal Rent Per {100} {mBenz1.rentType} for this vehicle : {rv.calculateRent(mBenz1, 100)}");

            Console.Write($"\n\nTotal Rent Per Today : {rv.calculateTotalRentToday()}");

            Console.Write($"\n\nBelow Vehicles are Rented - ");
            rv.getCheckListRentedVehicle();

            Console.Write("\n\nBelow Vehicles are available before 29-March-2022 - ");
            rv.showAvailableByDate(new DateOnly(2022, 03, 29));

            Console.Write($"\n\nBelow Vehicles are in Maintenance - ");
            rv.checkVehiclesInMaintenance();

            Console.Write("\n\n");
        }
    }

    class RentedVehicle<T>
    {
        List<Vehicle<T>> vehicleList;

        public RentedVehicle()
        {

            vehicleList = new List<Vehicle<T>>();
        }

        public void addVehicle(T vehicle)
        {

            Vehicle<T> v = new Vehicle<T>(vehicle);
        }

        public void giveForRent(T vehicle, DateOnly startDate, DateOnly endDate, double advancedPayment)
        {

            Vehicle<T> v = new Vehicle<T>(vehicle, startDate, endDate, advancedPayment);
            vehicleList.Add(v);
        }

        public double calculateRent(T vehicle, int units)
        {
            double rent = 0.0;
            foreach (Vehicle<T> v in vehicleList)
            {

                if ((v.vehicle!).Equals(vehicle))
                {
                    v.noOfUnitsTravelled = units;
                    rent = ((IVehicle)vehicle!).calculateRent(units) - v.advancedPayment;
                }
            }
            return rent;
        }

        public double calculateTotalRentToday()
        {
            double totalRent = 0;
            foreach (Vehicle<T> v in vehicleList)
            {
                totalRent += ((IVehicle)v.vehicle!).calculateRent(v.noOfUnitsTravelled) - v.advancedPayment;
            }
            return totalRent;
        }

        public void getCheckListRentedVehicle()
        {
            foreach (Vehicle<T> v in vehicleList)
            {
                ((IVehicle)v.vehicle!).getInfo();
                Console.Write($"\nRented from {v.startDateOfRent} to {v.endDateOfRent}");
            }
        }

        public void checkVehiclesInMaintenance()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            foreach (Vehicle<T> v in vehicleList)
            {
                IVehicle iVehicle = ((IVehicle)v.vehicle!);
                if (iVehicle.getLastMaintenanceDate().CompareTo(today) > 0)
                {
                    iVehicle.getInfo();
                    Console.Write($"\nIn Maintenance - Yes");
                }
            }
        }

        public void showAvailableByDate(DateOnly date)
        {
            Console.Write($"\n\nAvailable Vehicles on {date}");
            foreach (Vehicle<T> v in vehicleList)
            {
                if (v.startDateOfRent.CompareTo(date) > 0)
                {
                    ((IVehicle)v.vehicle!).getInfo();
                }
            }
        }
    }

    class Vehicle<T>
    {
        public T vehicle;
        public DateOnly startDateOfRent, endDateOfRent;
        public int noOfUnitsTravelled;
        public double advancedPayment;

        public Vehicle(T vehicle, DateOnly startDate, DateOnly endDate, double advancedPayment)
        {
            this.vehicle = vehicle;
            startDateOfRent = startDate;
            endDateOfRent = endDate;
            this.advancedPayment = advancedPayment;
        }

        public Vehicle(T vehicle)
        {
            this.vehicle = vehicle;
        }

        public int calculateDays()
        {
            int year = endDateOfRent.Year - startDateOfRent.Year;
            int month = endDateOfRent.Month - startDateOfRent.Month;
            int day = endDateOfRent.Day - startDateOfRent.Day;

            return year + month + day;
        }
    }

    class Indica : IVehicle
    {
        string? type, number;
        public IVehicle.RentType rentType;
        int age, rentPerUnit, seater;
        DateOnly lastMaintenanceDate;

        public Indica(string type, int seater, string number, IVehicle.RentType rentType, int age, int rentPerUnit, DateOnly lastMaintenanceDate)
        {
            this.type = type;
            this.seater = seater;
            this.number = number;
            this.rentType = rentType;
            this.age = age;
            this.rentPerUnit = rentPerUnit;
            this.lastMaintenanceDate = lastMaintenanceDate;
        }

        public double calculateRent(int units)
        {
            return (double)(rentPerUnit * units);
        }

        public void getInfo()
        {
            Console.Write("\n\nBrand Name : Indica");
            Console.Write($"\nCar Number : {number}");
            Console.Write($"\nTotal Seats : {seater}");
            Console.Write($"\nType : {type}");
            Console.Write($"\nCar Age : {age}");
            Console.Write($"\nRent Per Unit : {rentPerUnit}");
        }

        public DateOnly getLastMaintenanceDate()
        {
            return lastMaintenanceDate;
        }
    }

    class Qualis : IVehicle
    {
        string? type, number;
        public IVehicle.RentType rentType;
        int age, rentPerUnit, seater;
        DateOnly lastMaintenanceDate;

        public Qualis(string type, int seater, string number, IVehicle.RentType rentType, int age, int rentPerUnit, DateOnly lastMaintenanceDate)
        {
            this.type = type;
            this.seater = seater;
            this.number = number;
            this.rentType = rentType;
            this.age = age;
            this.rentPerUnit = rentPerUnit;
            this.lastMaintenanceDate = lastMaintenanceDate;
        }

        public double calculateRent(int units)
        {
            return (double)(rentPerUnit * units);
        }

        public void getInfo()
        {
            Console.Write("\n\nBrand Name : Qualis");
            Console.Write($"\nCar Number : {number}");
            Console.Write($"\nTotal Seats : {seater}");
            Console.Write($"\nType : {type}");
            Console.Write($"\nCar Age : {age}");
            Console.Write($"\nRent Per Unit : {rentPerUnit}");
        }

        public DateOnly getLastMaintenanceDate()
        {
            return lastMaintenanceDate;
        }
    }

    class Davidharley : IVehicle
    {
        string? number;
        public IVehicle.RentType rentType;
        int age, rentPerUnit;
        DateOnly lastMaintenanceDate;

        public Davidharley(string number, IVehicle.RentType rentType, int age, int rentPerUnit, DateOnly lastMaintenanceDate)
        {
            this.number = number;
            this.rentType = rentType;
            this.age = age;
            this.rentPerUnit = rentPerUnit;
            this.lastMaintenanceDate = lastMaintenanceDate;
        }

        public double calculateRent(int units)
        {
            return (double)(rentPerUnit * units);
        }

        public void getInfo()
        {
            Console.Write("\n\nBrand Name : David Harley");
            Console.Write($"\nBike Number : {number}");
            Console.Write("\nTotal Seats : 2");
            Console.Write("\nType : Petrol");
            Console.Write($"\nBike Age : {age}");
            Console.Write($"\nRent Per Unit : {rentPerUnit}");
        }

        public DateOnly getLastMaintenanceDate()
        {
            return lastMaintenanceDate;
        }
    }

    class MBenzEclass : IVehicle
    {
        string? number;
        public IVehicle.RentType rentType;
        int age, rentPerUnit, seater;
        DateOnly lastMaintenanceDate;

        public MBenzEclass(int seater, string number, IVehicle.RentType rentType, int age, int rentPerUnit, DateOnly lastMaintenanceDate)
        {
            this.seater = seater;
            this.number = number;
            this.rentType = rentType;
            this.age = age;
            this.rentPerUnit = rentPerUnit;
            this.lastMaintenanceDate = lastMaintenanceDate;
        }

        public double calculateRent(int units)
        {
            return (double)(rentPerUnit * units);
        }

        public void getInfo()
        {
            Console.Write("\n\nBrand Name : Mercedez Benz E-Class");
            Console.Write($"\nCar Number : {number}");
            Console.Write($"\nTotal Seats : {seater}");
            Console.Write("\nType : Petrol");
            Console.Write($"\nCar Age : {age}");
            Console.Write($"\nRent Per Unit : {rentPerUnit}");
        }

        public DateOnly getLastMaintenanceDate()
        {
            return lastMaintenanceDate;
        }
    }
}