namespace Test.Setup.TestData.Pizza;

public static class PizzaTestData
{
	public static Faker Faker = new Faker();

	public static PizzaModel Pizza = new()
	{
		Id = 1,
		Name = Faker.PickRandom(pizzas),
		Description = string.Empty,
		Price = Faker.Finance.Amount(),
		DateCreated = DateTime.Now,
	};

	public static PizzaModel? PizzaModel = new()
	{
		Id = 1,
		Name = Faker.PickRandom(pizzas),
		Description = string.Empty,
		Price = Faker.Finance.Amount(),
		DateCreated = DateTime.Now
	};

	private static readonly List<string> pizzas = new()
	{
		"Veggie Pizza",
		"Pepperoni Pizza",
		"Meat Pizza",
		"Margherita Pizza",
		"BBQ Chicken Pizza",
		"Hawaiian Pizza"
	};
}

