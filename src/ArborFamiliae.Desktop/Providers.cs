using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae
{
    public record Provider(string Name, string Assembly)
    {
        public static Provider MySql = new(nameof(MySql), typeof(Data.Mysql.MySqlMarker).Assembly.GetName().Name!);
        //public static Provider Postgres = new(nameof(Postgres), typeof(Postgres.Marker).Assembly.GetName().Name!);
    }
}
