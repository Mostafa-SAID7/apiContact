using apiContact.Data;
using apiContact.Models.Dtos;
using apiContact.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace apiContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            // Seed initial data if empty (optional, for demo)
            if (!_dbContext.Contacts.Any())
            {
                _dbContext.Contacts.AddRange(
                    new Contact { Name = "Alice Johnson", Email = "alice@example.com", Phone = "123-456-7890" },
                    new Contact { Name = "Bob Smith", Email = "bob@example.com", Phone = "987-654-3210" }
                );
                _dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetContact(Guid id)
        {
            var contact = _dbContext.Contacts.Find(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(AddRequestDto request)
        {
           var dominModel = new Contact { 
               Id = Guid.NewGuid(),
               Name = request.Name, 
                Email = request.Email, 
                Phone = request.Phone, 
                IsActive = request.IsActive 
            };
              _dbContext.Contacts.Add(dominModel);
                _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetContact), new { id = dominModel.Id }, dominModel);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = _dbContext.Contacts.Find(id);
            if (contact == null) return NotFound();

            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
