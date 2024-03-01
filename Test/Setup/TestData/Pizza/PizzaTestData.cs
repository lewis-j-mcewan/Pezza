namespace Test.Setup.TestData.Pizza;

public static class PizzaTestData
{
	private static Faker _faker = new Faker();
	
	private static readonly List<string> Pizzas =
	[
		"Veggie Pizza",
		"Pepperoni Pizza",
		"Meat Pizza",
		"Margherita Pizza",
		"BBQ Chicken Pizza",
		"Hawaiian Pizza"
	];

	public static PizzaModel Pizza = new()
	{
		Id = 1,
		Name = _faker.PickRandom(Pizzas),
		Description = string.Empty,
		Price = _faker.Finance.Amount(),
		DateCreated = DateTime.Now,
	};

	public static readonly PizzaModel? PizzaModel = new()
	{
		Id = 1,
		Name = _faker.PickRandom(Pizzas),
		Description = string.Empty,
		Price = _faker.Finance.Amount(),
		DateCreated = DateTime.Now
	};
}

