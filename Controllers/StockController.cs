using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        //using primary constructor for the bellow code instead
//  public StockController(ApplicationDbContext context)
//       {
//         _context=context;
//       } 
        [HttpGet]
      public IActionResult GetAll(){
        //deffered execution
        var stocks=_context.Stocks.ToList()
        .Select(s=>s.ToStockDto());
        return Ok(stocks);
      } 
      [HttpGet("{id}")]
      public IActionResult GetById([FromRoute] int id)
      {
       var stock=_context.Stocks.Find(id);
       if(stock==null){
        return NotFound();
       }
       return Ok(stock.ToStockDto());
      }
      [HttpPost]
      public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
      {
        var stockModel=stockDto.ToStockFromCreateDTO();
        _context.Stocks.Add(stockModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById),new {id=stockModel.Id},stockModel.ToStockDto());
      }
    }
}