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
                new Contact { Name = "Alice Johnson",     Email = "alice.johnson@example.com",       Phone = "+12025550101", IsActive = true },
    new Contact { Name = "Bob Smith",         Email = "bob.smith@example.com",           Phone = "+12025550102", IsActive = false },
    new Contact { Name = "Carla Mendes",      Email = "carla.mendes@sample.org",         Phone = "+5511998001010", IsActive = true },
    new Contact { Name = "Diego Rivera",      Email = "diego.rivera@mail.com",           Phone = "+521155501234", IsActive = true },
    new Contact { Name = "Elena Petrova",     Email = "elena.petrova@example.ru",        Phone = "+74951234567", IsActive = false },
    new Contact { Name = "Farah Hassan",      Email = "farah.hassan@example.eg",         Phone = "+201001234567", IsActive = true },
    new Contact { Name = "George Miller",     Email = "gmiller@company.co",              Phone = "+441632960001", IsActive = true },
    new Contact { Name = "Hiro Tanaka",       Email = "hiro.tanaka@example.jp",          Phone = "+81312345678", IsActive = false },
    new Contact { Name = "Ibrahim Khalil",    Email = "ibrahim.khalil@example.com",      Phone = "+201234567890", IsActive = true },
    new Contact { Name = "Julia Roberts",     Email = "julia.roberts@movies.com",        Phone = "+13105550123", IsActive = true },

    new Contact { Name = "Kofi Mensah",       Email = "kofi.mensah@sample.gh",           Phone = "+233201234567", IsActive = false },
    new Contact { Name = "Lina Gomez",        Email = "lina.gomez@example.co",           Phone = "+34600111222", IsActive = true },
    new Contact { Name = "Marcus Aurelius",   Email = "marcus.a@example.net",            Phone = "+390612345678", IsActive = false },
    new Contact { Name = "Nadia Petro",       Email = "nadia.petro@example.org",         Phone = "+447700900123", IsActive = true },
    new Contact { Name = "Omar Rahman",       Email = "omar.rahman@mail.org",            Phone = "+971501234567", IsActive = true },
    new Contact { Name = "Priya Singh",       Email = "priya.singh@example.in",          Phone = "+919876543210", IsActive = true },
    new Contact { Name = "Quincy Adams",      Email = "quincy.adams@sample.com",         Phone = "+13035550111", IsActive = false },
    new Contact { Name = "Rosa Diaz",         Email = "rosa.diaz@example.mx",            Phone = "+525512345678", IsActive = true },
    new Contact { Name = "Sandro Ricci",      Email = "sandro.ricci@italia.it",          Phone = "+390612345679", IsActive = false },
    new Contact { Name = "Tariq Al-Mansour",  Email = "tariq.mansour@example.sa",        Phone = "+966501234567", IsActive = true },

    new Contact { Name = "Uma Patel",         Email = "uma.patel@sample.in",             Phone = "+918023334455", IsActive = true },
    new Contact { Name = "Vera Novak",        Email = "vera.novak@example.cz",           Phone = "+420602123456", IsActive = false },
    new Contact { Name = "Will Turner",       Email = "will.turner@sea.net",             Phone = "+442071234567", IsActive = true },
    new Contact { Name = "Xiao Li",          Email = "xiao.li@example.cn",              Phone = "+8613012345678", IsActive = true },
    new Contact { Name = "Yara Haddad",       Email = "yara.haddad@example.lb",          Phone = "+96170123456", IsActive = false },
    new Contact { Name = "Zane Cooper",       Email = "zane.cooper@startup.io",          Phone = "+16465550101", IsActive = true },
    new Contact { Name = "Abby Turner",       Email = "abby.turner@example.com",         Phone = "+12025550103", IsActive = true },
    new Contact { Name = "Bruno Silva",       Email = "bruno.silva@brazil.com",          Phone = "+551198001122", IsActive = false },
    new Contact { Name = "Carmen Ortega",     Email = "carmen.ortega@es.example",        Phone = "+34600111223", IsActive = true },
    new Contact { Name = "Dmitri Ivanov",     Email = "dmitri.ivanov@mail.ru",           Phone = "+79261234567", IsActive = true },

    new Contact { Name = "Eva Long",          Email = "eva.long@example.uk",             Phone = "+447700900124", IsActive = false },
    new Contact { Name = "Felipe Costa",      Email = "felipe.costa@br.org",             Phone = "+5511998002020", IsActive = true },
    new Contact { Name = "Greta Hoffmann",    Email = "greta.hoffmann@example.de",       Phone = "+4915123456789", IsActive = true },
    new Contact { Name = "Hassan Jafari",     Email = "hassan.jafari@example.ir",        Phone = "+989121234567", IsActive = false },
    new Contact { Name = "Isabel Marquez",    Email = "isabel.marquez@example.co",       Phone = "+521555012345", IsActive = true },
    new Contact { Name = "Jonah Blake",       Email = "jonah.blake@sample.org",          Phone = "+14085550123", IsActive = true },
    new Contact { Name = "Keiko Suzuki",      Email = "keiko.suzuki@example.jp",         Phone = "+819012345678", IsActive = false },
    new Contact { Name = "Leo Martins",       Email = "leo.martins@company.br",          Phone = "+5511970012345", IsActive = true },
    new Contact { Name = "Maya Cohen",        Email = "maya.cohen@example.il",           Phone = "+972541234567", IsActive = true },
    new Contact { Name = "Noah Fischer",      Email = "noah.fischer@example.de",         Phone = "+4915212345678", IsActive = false }
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
