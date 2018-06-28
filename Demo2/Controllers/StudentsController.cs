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
    public class StudentsController : ControllerBase
    {
        private readonly Datacontext _datacontext;
        public StudentsController(Datacontext datacontext)
        {
            _datacontext = datacontext;
            if (_datacontext.Students.Count() == 0)
            {
                _datacontext.Students.Add(new Student { Name = "Huy", ClassId = 1, Address = "Ha Dong", Email = "huytq@gmail.com" });
                _datacontext.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            return _datacontext.Students.ToList();
        }

        [HttpGet("{id}",Name = "GetStudent")]
        public ActionResult<Student> GetById(int id)
        {
            var item = _datacontext.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Student st)
        {
            _datacontext.Students.Add(st);
            _datacontext.SaveChanges();
            return CreatedAtRoute("GetStudent", new { id = st.StudentId }, st);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student st)
        {
            var item = _datacontext.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = st.Name;
            item.Address = st.Address;
            item.ClassId = st.ClassId;
            item.Email = st.Email;
            _datacontext.Students.Update(item);
            _datacontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item=_datacontext.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _datacontext.Students.Remove(item);
            _datacontext.SaveChanges();
            return NoContent();
        }
    }
}