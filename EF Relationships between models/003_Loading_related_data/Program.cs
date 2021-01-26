using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _003_Loading_related_data
{
    class Program
    {
        static void Main(string[] args)
        {
            //GeneratedData();
            //Eager loading (жадная загрузка)
            using (Context db = new Context())
            {
                Team team = db.Teams
                    .Include(t => t.Players)
                    .Include(x => x.Stadium)
                    .FirstOrDefault();

                Console.WriteLine($"Team: {team.Name}");
                foreach (var item in team.Players)
                {
                    Console.WriteLine($"Player: {item.Name}     Country: {item.Country?.Name}");
                }
            }
            Console.WriteLine(new string ('-',20));

            using (Context db = new Context())
            {
                Team team = db.Teams
                    .Include(t => t.Players)
                        .ThenInclude(x => x.Country)
                    .FirstOrDefault();

                Console.WriteLine($"Team: {team.Name}");
                foreach (var item in team.Players)
                {
                    Console.WriteLine($"Player: {item.Name}     Country: {item.Country?.Name}");
                }
            }
            Console.WriteLine(new string('-', 20));


            using (Context db = new Context())
            {
                Team team = db.Teams
                    .Include(t => t.Players)
                        .ThenInclude(x => x.Country)
                        .ThenInclude(c => c.Capital)
                        .Include(t => t.Stadium)
                    .FirstOrDefault();

                Console.WriteLine($"Team: {team.Name}, Stadium: {team.Stadium.Name}");
                foreach (var item in team.Players)
                {
                    Console.WriteLine($"Player: {item.Name}     Country: {item.Country?.Name}   City: {item.Country?.Capital.Name}");
                }
            }
            Console.WriteLine(new string('-', 20));

            //Explicit loading (явная загрузка)

            using (Context db = new Context())
            {
                var team = db.Teams.FirstOrDefault();
                db.Players.Where(p => p.TeamId == team.Id).Load();

                Console.WriteLine($"Team: {team?.Name}");
                foreach (var item in team.Players)
                {
                    Console.WriteLine($"Player: {item.Name}");
                }
            }

            using (Context db = new Context())
            {
                var team = db.Teams.FirstOrDefault();
                db.Entry(team).Collection(p => p.Players).Load();

                Console.WriteLine($"Team: {team.Name}");
                foreach (var item in team.Players)
                {
                    Console.WriteLine($"Player: {item.Name}");
                }
            }

            using (Context db = new Context())
            {
                Player player = db.Players.FirstOrDefault();
                db.Entry(player).Reference(x => x.Team).Load();

                Console.WriteLine($" {player.Name} - {player.Team.Name}");
            }
        }

        public static void GeneratedData()
        {
            using (Context db = new Context())
            {
                var listTeams = new List<Team>
                {
                    new Team()
                    {
                        Name="RealMadrid",
                        Stadium=new Stadium() { Name ="Philips Arena"}
                    },
                    new Team()
                    {
                        Name ="Barcelona",
                        Stadium = new Stadium(){Name="Barcelona Stadium"}
                    }
                };
                db.Teams.AddRange(listTeams);
                db.SaveChanges();

                var listCountry = new List<Country>()
                {
                    new Country() { Name = "Spain", Capital = new City() { Name = "Madrid" } },
                    new Country() { Name = "Germany", Capital = new City() { Name = "Berlin" } },
                    new Country() { Name = "France", Capital = new City() { Name = "Paris" } },
                };
                db.Countries.AddRange(listCountry);
                db.SaveChanges();

                var listPlayers = new List<Player>
                {
                    new Player(){Name = "Messi",TeamId =1,CountryId=1},
                    new Player(){Name = "Ronaldo",TeamId =1,CountryId=1},
                    new Player(){Name = "Ivanov",TeamId =1,CountryId=1},
                    new Player(){Name = "Alyona",TeamId =1,CountryId=2},
                    new Player(){Name = "Vorobiova",TeamId =1,CountryId=2},
                    new Player(){Name = "Ed Sheeran",TeamId =1,CountryId=3},
                };
                db.Players.AddRange(listPlayers);
                db.SaveChanges();
            }
        }
    }
}
