using System;
using TestAPI.model;

namespace TestAPI.service
{
	public interface SuperHeroService
	{
		Task<List<SuperHero>> GetAllHeroes();
		Task<SuperHero?> GetSingleHero(int Id);
		Task<List<SuperHero>> AddHero(SuperHero superHero);
		Task<SuperHero?> UpdateHero(int Id, SuperHero superHero);
		Task<SuperHero?> DeleteHero(int Id);
    }
}

