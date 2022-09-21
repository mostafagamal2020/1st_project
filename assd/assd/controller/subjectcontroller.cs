using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assd.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class subjectcontroller:ControllerBase
    {
        school context;
        IMapper mapper;

        public subjectcontroller(school school, IMapper mapper)
        {
            context = school;
           mapper = mapper;
        }

        [HttpPost("AddSubject")]
        public ActionResult Add(string SubjectName)
        {

            subject s = new subject
            {
                Name = SubjectName
            };

            context.Subjects.Add(s);
            context.SaveChanges();

            return Ok(s);
        }
        [HttpGet("get all subject")]
        public ActionResult get_subjects()
        {
            var list = context.Subjects.ToList();
            return Ok(list);
        }
        [HttpDelete("delete subject")]
        public ActionResult rem_subjects(int id)
        {
            var list = context.Subjects.Where(w => w.Id == id).FirstOrDefault();
            if (list == null)
            {
                return BadRequest("not found this id");
            }
            else
            {
                context.Remove(list);
                context.SaveChanges();
                return Ok(list);
            }
        }
    }
}
