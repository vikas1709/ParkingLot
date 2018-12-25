using System;
using System.Collections.Generic;
using System.Linq;

namespace  ParkingLot
{
    public enum VehicleType
    {
        Car,
        Bike,
        Truck
    }
    public class ParkingGarage
    {
        List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
        public ParkingGarage()
        {
            parkingSpots = new List<ParkingSpot>();
        }
        public void AddParkingSpot(ParkingSpot ps)
        {

            parkingSpots.Add(ps);
        }
        public string Park(Vehicle v)
        {
            ParkingSpot ps = parkingSpots.Where(p => p.GetVehicleType() == v.GetVehicleType() && p.GetSpotTaken() == false).FirstOrDefault();
            if (ps != default(ParkingSpot))
            {
                ps.SetSpotTaken();
            }
            else
            {
                return "No Spots available";
            }
            return "Vehicle Parked";
        }

    }
   public class ParkingLot
    {
        
        public static void Main()
        {
            ParkingGarage pl = new ParkingGarage();
            ParkingSpot ps1 = new ParkingSpot(1,1,1,VehicleType.Car);
            ParkingSpot ps2 = new ParkingSpot(1,1,2, VehicleType.Truck);
            pl.AddParkingSpot(ps1);
            pl.AddParkingSpot(ps2);
            Vehicle v1 = new Vehicle(VehicleType.Truck);
            Console.WriteLine(pl.Park(v1));
            Vehicle v2 = new Vehicle(VehicleType.Car);
            Console.WriteLine(pl.Park(v2));
            Vehicle v3 = new Vehicle(VehicleType.Bike);
            Console.WriteLine(pl.Park(v3));
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    public class Vehicle
    {
        private VehicleType type;
        public Vehicle(VehicleType type)
        {
            this.type = type;
        }
        public VehicleType GetVehicleType()
        {
            return this.type;
        }

    }
    public class ParkingSpot
    {
        private int level;
        private int row;
        private int SpotNumber;
        private Boolean taken;
        private VehicleType type;

        public ParkingSpot(int level, int row, int SpotNumber, VehicleType type)
        {
            this.level = level;
            this.row = row;
            this.SpotNumber = SpotNumber;
            this.type = type;
        }

        public int GetLevel()
        {
            return this.level;

        }
        public int GetRow()
        {
            return this.row;

        }
        public int GetSpotNumber()
        {
            return this.SpotNumber;

        }
        public VehicleType GetVehicleType()
        {
            return this.type;

        }
        public Boolean GetSpotTaken()
        {
            return this.taken;

        }
        public void SetSpotTaken()
        {
            this.taken = true;

        }
    }


}
