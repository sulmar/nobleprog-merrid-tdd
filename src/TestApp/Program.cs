using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Samples;

namespace TestApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PumpRepository repository = new PumpRepository();

            // Act
            List<Pump> pumps = repository.GetPumpsByAreaByLinq("PLOAD");


            foreach (Pump pump in pumps)
            {
                Console.WriteLine($"Name: {pump.Name} Area: {pump.Area} TypeId: {pump.TypeId}");
            }
        }
    }
}
