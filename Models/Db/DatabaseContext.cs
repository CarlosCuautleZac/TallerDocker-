﻿using Microsoft.EntityFrameworkCore;
using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Db
{
    public class DatabaseContext:DbContext
    {

        public DbSet<User> Users { get; set; }
    }
}
