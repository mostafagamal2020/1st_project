using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assd.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentcontroller : ControllerBase
    {
        private readonly school context;
        private readonly IMapper mapper;
        public studentcontroller(school School, IMapper Mapper)
        {
            context = School;
            mapper = Mapper;
        }
        [HttpGet("GetALL")]
        public ActionResult getAll()
        {
            var lst = context.Students.
                Include(c => c.RegForm).
                ThenInclude(c => c.Items).ThenInclude(c => c.Subject)
                .ToList();
            return Ok(lst);
        }        
        [HttpPost("AddStudent")]
        public ActionResult add(StudentRegister s)
        {
            var end = mapper.Map<student>(s);
            context.Students.Add(end);
            context.SaveChanges();
            return Ok(end);
        }
        [HttpPost("login")]
        public ActionResult login(StudentLogin s)
        {
            var list = context.Students.Where(w => w.Email == s.Email).FirstOrDefault();
            if (list == null)
            {
                return Unauthorized("not found this email");
            }
            else
            {
                return Ok(list);
            }
        }
        [HttpDelete("remove")]
        public ActionResult delete(int id)
        {
            var list = context.Students.Where(s => s.Id == id).FirstOrDefault();
            if (list == null)
            {
                return Unauthorized("dont found this id ");
            }
            else
            {
                context.Students.Remove(list);
                context.SaveChanges();
                return Ok("done");
            }
        }
        [HttpPost("update")]
        public ActionResult Updatee(int id, StudentRegister stu)
        {
            var list = context.Students.AsNoTracking().Where(w => w.Id == id).FirstOrDefault();
            if (list == null)
            {
                return BadRequest("not found this student");
            }
            else
            {
                student s = new student()
                {
                    Id = id,
                    Name = stu.Name ?? list.Name,
                    Email = stu.Email ?? list.Email,
                    Password = stu.Password ?? list.Password
                };
                context.Students.Update(s);      
                context.SaveChanges();
                return Ok("done");
            }
            //    //student st = _mapper.Map<student>(p);
            //    //var list = _context.Students.Any(s=>s.Id==p.Id);
            //    //if(list==true)
            //    //{
            //    //    _context.Students.Update(st);
            //    //    _context.SaveChanges();
            //    //}
            //    //else
            //    //{
            //    //    return BadRequest("not found this student");
            //    //}
        }
    }
}

