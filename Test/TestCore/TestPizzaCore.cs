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
        this._handler = new PizzaCore(this.Context);
        this._pizza = PizzaTestData.PizzaModel;
        this._pizza = await this._handler.SaveAsync(this._pizza);
    }

    [Test]
    public async Task GetAsync()
    {
        var response = await this._handler.GetAsync(this._pizza.Id);
        Assert.IsTrue(response != null);
    }

    [Test]
    public async Task GetAllAsync()
    {
        var response = await this._handler.GetAllAsync();
        Assert.IsTrue(response.Count() == 1);
    }

    [Test]
    public async Task UpdateAsync()
    {
        var originalPizza = this._pizza;
        this._pizza.Name = new Faker().Commerce.Product();
        var response = await this._handler.UpdateAsync(this._pizza);
        var outcome = response.Name.Equals(originalPizza.Name);
        Assert.IsTrue(outcome);
    }

    [Test]
    public async Task SaveAsync()
    {
        var outcome = this._pizza.Id == 1;
        Assert.IsTrue(outcome);
    }

    [Test]
    public async Task DeleteAsync()
    {
        var response = await this._handler.DeleteAsync(this._pizza.Id);
        Assert.IsTrue(response);
    }
}