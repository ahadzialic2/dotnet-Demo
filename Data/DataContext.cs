﻿using dotnet_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_Demo.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }

    }
}