using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.DB;
//using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return Ok(ClassRoom.Current.Dict);
        }
        //[HttpGet("{id}")]
        //public ActionResult GetClassById(int id)
        //{
        //    if (ClassRoom.Current.Dict.TryGetValue(id, out var className))
        //    {
        //        return Ok(new { Id = id, Name = className });
        //    }
        //    return NotFound();
        //}
        [HttpGet("{id}")]
        public ActionResult CheckKey(int id)
        {
            bool exists = ClassRoom.Current.Dict.ContainsKey(id);
            if (exists)
            {
                return Ok(new { Exists = true, Id = id, Name = ClassRoom.Current.Dict[id] });
            }
            else
            {
                return BadRequest();

            }
        }
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id) { 
            
        //    return Ok(ClassRoom.Current.Dict.Remove(id));
        //    }
        //[HttpPost]
        //public ActionResult Add(int key, string value) {
        //    if (ClassRoom.Current.Dict.ContainsKey(key))
        //    {
        //        return BadRequest();
        //    }
        //    ClassRoom.Current.Dict.Add(key, value);
        //    return Ok(ClassRoom.Current.Dict);

        //}  
    }
}
