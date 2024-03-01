namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController(IPizzaCore pizzaCore) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Get(int id)
    {
        var response = await pizzaCore.GetAsync(id);
        if (response == null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult> Get()
    {
        var response = await pizzaCore.GetAllAsync(); 
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Update([FromBody] PizzaModel pizza)
    {
        var response = await pizzaCore.UpdateAsync(pizza);
        if (response == null)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Create([FromBody] PizzaModel pizza)
    {
        var response = await pizzaCore.SaveAsync(pizza);
        if (response == null)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(int id)
    {
        var response = await pizzaCore.DeleteAsync(id);
        if (!response)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}