using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3.Data_Access_Laye
{
    public class SalesERPDAL:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> embloyees { get; set; }
    }
}