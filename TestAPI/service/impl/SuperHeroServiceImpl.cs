using System;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.model;

namespace TestAPI.service.impl
{
	public class SuperHeroServiceImpl : SuperHeroService
	{
      
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero { Id = 1, Name = "Spider Man" , FirstName = "Peter" , LastName = "Parker" , Place = "New York"},
                new SuperHero { Id = 2, Name = "Iron Man", FirstName = "Tony", LastName = "Stark", Place = "Malibu" },
                new SuperHero { Id = 3, Name = "Wonder Woman", FirstName = "Diana", LastName = "Prince", Place = "Themyscira" },
                new SuperHero { Id = 4, Name = "Black Panther", FirstName = "T'Challa", LastName = "", Place = "Wakanda" }
            };
        private readonly AppDbContext appDbContext;

        public SuperHeroServiceImpl(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
		}

        public async Task<List<SuperHero>> AddHero(SuperHero superHero)
        {
            appDbContext.SuperHeroes.Add(superHero);
            await appDbContext.SaveChangesAsync();
            return await appDbContext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> DeleteHero(int Id)
        {
            var hero = await appDbContext.SuperHeroes.FindAsync(Id);
            if (hero is null)
                return null;
            appDbContext.SuperHeroes.Remove(hero);

            await appDbContext.SaveChangesAsync();

            return  hero;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await appDbContext.SuperHeroes.ToListAsync();

            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int Id)
        {
            var hero = await appDbContext.SuperHeroes.FindAsync(Id);
            if (hero is null)
                return null;

            return hero;
        }

        public async Task<SuperHero?> UpdateHero(int Id, SuperHero superHero)
        {
            var hero = await appDbContext.SuperHeroes.FindAsync(Id);
            if (hero is null)
                return null;

            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;

            await appDbContext.SaveChangesAsync();

            return  hero;
        }
    }
}

