using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly Datacontext _datacontext;
        public ClassesController(Datacontext datacontext)
        {
            _datacontext = datacontext;
            if (_datacontext.Classes.Count() == 0)
            {
                _datacontext.Classes.Add(new Class { Name = "AT12" });
                _datacontext.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Class>> GetAll()
        {
            return _datacontext.Classes.ToList();
        }

        [HttpGet("{id}",Name ="GetClass")]
        public ActionResult<Class> GetById(int id)
        {
            var item = _datacontext.Classes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Class cl)
        {
            _datacontext.Classes.Add(cl);
            _datacontext.SaveChanges();
            return CreatedAtRoute("GetClass", new { id = cl.ClassId }, cl);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Class cl)
        {
            var item = _datacontext.Classes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = cl.Name;

            _datacontext.Classes.Update(item);
            _datacontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _datacontext.Classes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _datacontext.Classes.Remove(item);
            _datacontext.SaveChanges();
            return NoContent();
        }
    }
}