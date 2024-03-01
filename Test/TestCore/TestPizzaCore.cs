using Test.Setup.TestData.Pizza;

namespace Test.TestCore;

[TestFixture]
public class TestPizzaCore : QueryTestBase
{
    private PizzaCore? _handler;
    private PizzaModel? _pizza;

    /* Runs before every test to set up a new Pizza Core.
        We then mock the new pizza with PizzaTestData
    **/
    [SetUp]
    public async Task Init()
    {
        Dispose();
        _handler = new PizzaCore(Context);
        _pizza = PizzaTestData.PizzaModel;
        _pizza = await _handler.SaveAsync(_pizza);
    }

    [Test]
    public async Task GetAsync()
    {
        var response = await _handler.GetAsync(_pizza.Id);
        Assert.IsTrue(response != null);
    }

    [Test]
    public async Task GetAllAsync()
    {
        var response = await _handler.GetAllAsync();
        Assert.IsTrue(response.Count() == 1);
    }

    [Test]
    public async Task UpdateAsync()
    {
        var originalPizza = _pizza;
        _pizza.Name = new Faker().Commerce.Product();
        var response = await _handler.UpdateAsync(_pizza);
        var outcome = response.Name.Equals(originalPizza.Name);
        Assert.IsTrue(outcome);
    }

    [Test]
    public async Task SaveAsync()
    {
        var outcome = _pizza.Id == 1;
        Assert.IsTrue(outcome);
    }

    [Test]
    public async Task DeleteAsync()
    {
        var response = await _handler.DeleteAsync(_pizza.Id);
        Assert.IsTrue(response);
    }
}