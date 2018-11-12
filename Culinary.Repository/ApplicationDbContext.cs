﻿using Culinary.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Culinary.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        //ADD IDENTITY AND USER TABLE

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>()
                .HasMany(x => x.Components);

            builder.Entity<Recipe>()
                .HasOne(x => x.RecipeRatings);
                

           
        }

    }
}
