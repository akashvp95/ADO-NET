using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;

namespace FootBallProject.Models
{
    public class FootBallContext : DbContext
    {
        public FootBallContext()
            :base("name = FTDB")
        {

        }
        public DbSet<Football> FootballTable { get; set; } 
    }
}