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
    public class regformcontroller : ControllerBase
    {
        school _context;
        IMapper _mapper;

        public regformcontroller(school school, IMapper mapper)
        {
            _context = school;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public ActionResult add(RegFormDTO r)
        {
            var obj = _mapper.Map<regform>(r);
            _context.RegForms.Add(obj);
            _context.SaveChanges();
            obj.Items = new List<regformitem>();
            for (int i = 0; i < r.SubjectsIds.Count; i++)
            {
                regformitem f = new regformitem();
                f.SubjectId = r.SubjectsIds[i];
                f.RegFormId = obj.Id;
                _context.RegFormItems.Add(f);
            }
            _context.SaveChanges();
            return Ok("done");
        }
        [HttpGet("get all regform")]
        public ActionResult get_all()
        {
            var list = _context.RegForms.ToList();
            return Ok(list);
        }
        [HttpDelete("delete regform")]
        public ActionResult remove(int id)
        {
            var list = _context.RegForms.Where(w => w.Id == id).FirstOrDefault();
            if (list == null)
            {
                return BadRequest("not found this id");
            }
            else
            {
                _context.Remove(list);
                _context.SaveChanges();
                return Ok("done");
            }
        }
        [HttpGet("get all regformitem")]
        public ActionResult get_all_regformitem()
        {
            var list = _context.RegFormItems.ToList();
            return Ok(list);
        }
        [HttpDelete("delete regformitem")]
        public ActionResult remove_item(int id)
        {
            var list = _context.RegFormItems.Where(w => w.Id == id).FirstOrDefault();
            if (list == null)
            {
                return BadRequest("not found this regformitem");
            }
            else
            {
                _context.Remove(list);
                _context.SaveChanges();
                return Ok("done");
            }
        }
    }
}
