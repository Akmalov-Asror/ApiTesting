using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
[Scoped]
public class ContactRepository : IContactRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public ContactRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact?>> GetContactAllAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(Guid id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact> CreateContactAsync(ContactDto contactDto)
    {
        var contact = contactDto.Adapt<Contact>();

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<Contact?> UpdateContactAsync(string fullName, ContactDto contactDto)
    {
        var findContact = await _context.Contacts.FirstOrDefaultAsync(u => u.Name == fullName);

        if (findContact == null) return findContact;

        findContact.Name = contactDto.Name;
        findContact.Number = contactDto.Number;
        findContact.ReturnCall = contactDto.ReturnCall;

        await _context.SaveChangesAsync();

        return findContact;
    }

    public async Task DeleteContactAsync(Guid id)
    {
        var deleteContact = await _context.Contacts.FirstOrDefaultAsync(i => i.Id == id);
        if (deleteContact != null) _context.Contacts.Remove(deleteContact);
        await _context.SaveChangesAsync();
    }
}