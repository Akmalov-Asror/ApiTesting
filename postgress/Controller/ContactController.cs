using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddContact([FromForm]ContactDto contactDto)
    {
        if (contactDto is null)
            return BadRequest("please check the request again");
        return Ok(await _contactRepository.CreateContactAsync(contactDto));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
    public async Task<IActionResult> GetContactById(Guid id)
    {
        return Ok(await _contactRepository.GetContactByIdAsync(id));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Contact>))]
    public async Task<IActionResult> GetAllContacts() => Ok(await _contactRepository.GetContactAllAsync() ?? new List<Contact?>());

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateContact(string fullName, ContactDto contactDto)
    {
        var contact = await _contactRepository.UpdateContactAsync(fullName, contactDto);
        if (contact is null)
            return NotFound("This Teacher is not Defined");
        return Ok(contact);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Teacher>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        await _contactRepository.DeleteContactAsync(id);
        return Ok("User is Deleted");
    }
}