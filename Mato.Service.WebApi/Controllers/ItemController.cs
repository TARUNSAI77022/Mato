using AutoMapper;
using Mato.Service.WebApi.DTO;
using Mato.Service.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mato.Service.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly sampleContext _dbContext;
        private readonly IMapper _mapper;
        ResponseClass result = new ResponseClass();

        public ItemController(IMapper mapper1)
        {
            _dbContext = new sampleContext();
            _mapper = mapper1;

        }
        [HttpGet("Getitems")]
        public ResponseClass Getitems()
        {
            var result = new ResponseClass();

            try
            {
                var detailssss = _dbContext.Itemdetails.ToList();

                if (detailssss.Count > 0)
                {
                    result.responsecode = 200;
                    result.responsemessage = "Items retrieved successfully";
                    result.Res = detailssss;
                }
                else
                {
                    result.responsecode = 404;
                    result.responsemessage = "No items found";
                }
            }
            catch (Exception ex)
            {
                result.responsecode = 500;
                result.responsemessage = $"An error occurred: {ex.Message}";
            }

            return result;
        }
        [HttpGet("Byname")]
        public IActionResult Getitemname(string itemname)
        {

            var code = _dbContext.Itemdetails.FirstOrDefault(s => s.Itemname == itemname);
            return Ok(code);

        }
        [HttpDelete("deleteitem")]
        public JsonResult Deleteitem(string itemname)
        {
            var code = _dbContext.Itemdetails.FirstOrDefault(s => s.Itemname == itemname);

            if (code != null)
            {
                _dbContext.Itemdetails.Remove(code);
                _dbContext.SaveChanges();
                return Json(new { message = "Item deleted successfully", item = code });
            }

            return Json(new { message = "Item not found" });
        }


        [HttpPost("AddItem")]
        public ResponseClass Additems(iteminfo info)
        {
            Itemdetail itemDetail = new Itemdetail
            {
                Itemname = info.name,
            };
            _dbContext.Itemdetails.Add(itemDetail);
            _dbContext.SaveChanges();
            result.responsemessage = "Item added successfully";
            result.responsecode = 200;
            result.Issuccess = true;

            return result;
        }

    }
}

public class iteminfo
{
    public string name { get; set; }
}