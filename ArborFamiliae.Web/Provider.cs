﻿namespace ArborFamiliae.Web
{
    public record Provider(string Name, string Assembly)
    {
        public static Provider MySql = new(nameof(MySql), typeof(Data.Mysql.Marker).Assembly.GetName().Name!);
        //public static Provider Postgres = new(nameof(Postgres), typeof(Postgres.Marker).Assembly.GetName().Name!);
    }
}
