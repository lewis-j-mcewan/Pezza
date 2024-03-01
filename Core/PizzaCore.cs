namespace Core;

public class PizzaCore(DatabaseContext databaseContext) : IPizzaCore
{
	public async Task<PizzaModel?> GetAsync(int id)
	{
		var entity = await databaseContext.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
		if (entity == null)
		{
			return null;
		}
		return entity.Map();
	}

	public async Task<IEnumerable<PizzaModel>?> GetAllAsync()
	{
		var entities = await databaseContext.Pizzas.Select(x => x).AsNoTracking().ToListAsync();
		if (entities.Count == 0)
		{
			return null;
		}
		return entities.Map();
	}

	public async Task<PizzaModel?> UpdateAsync(PizzaModel? pizza)
	{
		var entity = await databaseContext.Pizzas.FirstOrDefaultAsync(x => x.Id == pizza.Id);
		if (entity == null)
		{
			return null;
		}

		entity.Name = !string.IsNullOrEmpty(pizza.Name) ? pizza.Name : entity.Name;
		entity.Description = !string.IsNullOrEmpty(pizza.Description) ? pizza.Description : entity.Description;
		entity.Price = pizza.Price ?? entity.Price;
		databaseContext.Pizzas.Update(entity);
		await databaseContext.SaveChangesAsync();

		return entity.Map();
	}

	public async Task<PizzaModel?> SaveAsync(PizzaModel? pizza)
	{
		if (pizza == null)
		{
			return null;
		}

		var entity = pizza.Map();
		entity.DateCreated = DateTime.UtcNow;
		databaseContext.Pizzas.Add(entity);
		await databaseContext.SaveChangesAsync();
		pizza.Id = entity.Id;

		return entity.Map();
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var result = await databaseContext.Pizzas.Where(x => x.Id == id).FirstOrDefaultAsync();
		if (result == null)
		{
			return false;
		}

		databaseContext.Remove(result);
		await databaseContext.SaveChangesAsync();
		
		return true;
	}
}

