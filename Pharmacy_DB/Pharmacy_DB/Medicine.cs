using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_DB
{
   public class Medicine
    {
        private static int _id=0;
        public int ID { get; set; }
        public string Name { get; set; }

        private List<Pill> pills;


        public Medicine(string name)
        {
            _id++;
            ID = _id;
            Name = name;

            pills = new List<Pill>()
            {
                new Pill{Name="Merphi",Type="Anesthetize",Price=3.50f},
                new Pill{Name="Pentalgin",Type="NoGrip",Price=1.55f},
                new Pill{Name="Paracetamol",Type="NoGrip",Price=2.70f},
                new Pill{Name="Analgin",Type="NoGrip",Price=1.70f},
                new Pill{Name="Depazol",Type="Pressure",Price=6.70f},

            };
            
        }
            public List<Pill> GetPills()
            {
            return pills;
            }
    

        public void AddMedicine(Pill m)
        {
            pills.Add(m);
        }

        public void Delete_Medicine(int id)
        {
           for (int i=0; i < pills.Count; i++)
            {
                if (id == pills[i].ID)
                {
                    pills.RemoveAt(i);
                    break;
                }
            }
        }

        public void UpdatePills(int id ,string name, string type, float price )
        {
            Pill piill = Getpill( id);
            piill.Name = name;
            piill.Type = type;
            piill.Price = price;
        }

        public Pill Getpill(int id)
        {
            Pill result = null;

            for (int i = 0; i < pills.Count; i++)
            {
                if (id == pills[i].ID)
                {
                    result = pills[i];
                }
            }
            return result;

        }


    }
}
