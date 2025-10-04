using apiContact.Data;
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
        public IActionResult AddContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
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
