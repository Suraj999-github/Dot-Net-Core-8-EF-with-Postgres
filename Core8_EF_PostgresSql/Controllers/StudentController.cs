using Core8_EF_PostgresSql.DbContexts;
using Core8_EF_PostgresSql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core8_EF_PostgresSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }       
        [HttpPost]
        [Route("/add")]
        public async Task<Object> add(AddStudent req)
        {
            try
            {
                Student entity = new Student();
                entity.PhoneNumber = req.PhoneNumber;
                entity.FirstName = req.FirstName;
                entity.LastName = req.LastName;
                entity.MiddleName = req.MiddleName;
                entity.Salutation = req.Salutation;
                await _context.student.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                var msg= ex.Message;
                return "Failed";
            }
        }
        [HttpPut]
        [Route("/update")]
        public async Task<Object> update(UpdateStudent req)
        {
            try
            {
                Student entity = new Student();
                entity= await _context.student.FindAsync(req.Id);
                if(entity!=null)
                {
                    entity.PhoneNumber = req.PhoneNumber;
                    entity.FirstName = req.FirstName;
                    entity.LastName = req.LastName;
                    entity.MiddleName = req.MiddleName;
                    entity.Salutation = req.Salutation;
                    _context.student.Update(entity);
                    await _context.SaveChangesAsync();
                }              
                return entity;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return "Failed";
            }
        }
        [HttpGet]
        [Route("/get/{id}")]
        public async Task<Object> getById(long id)
        {
            try
            {
                return await _context.student.FindAsync(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
        [Route("/list")]
        public async Task<Object> list()
        {
            try
            {
                return await _context.student.ToListAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
