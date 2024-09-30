using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Samples
{
    // Definicja klasy
    public class Pump
    {
        public string Name { get; set; }
        public string Area { get; set; } // Wlasciwosc
        public int TypeId { get; set; }
    }

    public class PumpRepository
    {
        private List<Pump> pumps;

        public PumpRepository()
        {
            pumps = new List<Pump>
             {
                new Pump { Name = "P1", Area = "PLOAD", TypeId = 2 },
                new Pump { Name = "P2", Area = "PLOAD", TypeId = 3 },
                new Pump { Name = "P3", Area = "PUNLOAD", TypeId = 3 },
                new Pump { Name = "P4", Area = "PLOAD", TypeId = 2 },
                new Pump { Name = "P5", Area = "PUNLOAD", TypeId = 1 },
            };
        }

        public List<Pump> GetPumpsByArea(string area)
        {
            List<Pump> results = new List<Pump>();

            foreach (var pump in pumps)
            {
                if (pump.Area == area)
                {
                    results.Add(pump);
                }
            }

            return results;
        }

        public List<Pump> GetPumpsByAreaByLinq(string area)
        {
            int? selectedTypeId = null;

            var query = pumps
                .Where(p => p.Area == area);

            if (selectedTypeId.HasValue)
            {
                query = query.Where(p => p.TypeId == selectedTypeId);
            }

            var results = query.ToList();

            return results;
        }

        public void AggrateTest()
        {
            var query = pumps.GroupBy(p => p.Area)
                .Select(g => new { Area = g.Key, Quantity = g.Count() })
                .ToList();
        }

        public void GroupBy(Pump p)
        {

        }
    }
}
