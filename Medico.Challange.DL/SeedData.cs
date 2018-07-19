using Medico.Challange.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medico.Challange.DL
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationMainDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationMainDbContext>>()))
            {
                // Look for any movies.
                if (context.Patient.Any())
                {
                    return;   // DB has been seeded
                }
                
                context.Patient.AddRange(
                    new Patient
                    {
                        FirstName = "Kayla",
                        LastName = "Chavez",
                        Gender = "Wanita",
                        PlaceOfBirth = "Cilegon",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Kenneth",
                        LastName = "Anderson",
                        Gender = "Pria",
                        PlaceOfBirth = "Mojokerto",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Minnie",
                        LastName = "Pierce",
                        Gender = "Wanita",
                        PlaceOfBirth = "Semarang",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Jimmy",
                        LastName = "Hammond",
                        Gender = "Pria",
                        PlaceOfBirth = "Kupang",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Leon",
                        LastName = "Pope",
                        Gender = "Pria",
                        PlaceOfBirth = "Sabang",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Nellie",
                        LastName = "Morton",
                        Gender = "Wanita",
                        PlaceOfBirth = "Ambon",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Misty",
                        LastName = "Bowman",
                        Gender = "Wanita",
                        PlaceOfBirth = "Salatiga",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Caroline",
                        LastName = "Norris",
                        Gender = "Wanita",
                        PlaceOfBirth = "Samarinda",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Lynn",
                        LastName = "Frazier",
                        Gender = "Wanita",
                        PlaceOfBirth = "Pare-Pare",
                        DateOfBirth = GenerateDateTime(),
                    },

                    new Patient
                    {
                        FirstName = "Fernando",
                        LastName = "Marsh",
                        Gender = "Pria",
                        PlaceOfBirth = "Jambi",
                        DateOfBirth = GenerateDateTime(),
                    }
                );
                context.SaveChanges();
            }
        }

        private static DateTime GenerateDateTime()
        {
            var startDate = new DateTime(1980, 01, 01);
            var endDate = new DateTime(2009, 12, 31);
            TimeSpan timeSpan = endDate - startDate;
            var randomTest = new Random();
            TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = startDate + newSpan;

            return newDate;
        }
    }
}
