using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_GYB
{
    public class Posta
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Produckt { get; set; }

        public string Packid { get; set; }
        public static Posta CreateFromLine(string line, char separator = ',')
        {
            string[] values = line.Split(separator);

            return new Posta()
            {
                Id = int.Parse(values[0]),
                FirstName = values[1],
                LastName = values[2],
                Address = values[3],
                Produckt = values[4],
                Packid = values[5]
            };
        }
        public override string ToString()
        {
            return $"Person<{FirstName} {LastName}: {Packid}>";
        }

        public string ToCSVLine()
        {
            return $"{Id},{FirstName},{LastName}" +
                $",{Address},{Produckt},{Packid}";
        }
    }
}