using SuperHeroAPI.Repositories.SuperHeroRepository;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly ISuperHeroRepository _repository;

        public SuperHeroService(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuperHero?>?> AddHero(SuperHero hero)
        {
            return await _repository.AddHero(hero);
        }

        public async Task<List<SuperHero?>?> DeleteHero(int id)
        {

            return await _repository.DeleteHero(id);
        }

        public async Task<List<SuperHero?>> GetAllHeroes()
        {
            return await _repository.GetAllHeroes();
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            return await _repository.GetSingleHero(id);
        }

        public async Task<List<SuperHero?>?> UpdateHero(int id, SuperHero request)
        {
            return await _repository.UpdateHero(id, request);
        }
    }
}
