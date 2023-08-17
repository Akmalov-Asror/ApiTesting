using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface IContactRepository
{
    Task<List<Contact?>> GetContactAllAsync();
    Task<Contact?> GetContactByIdAsync(Guid id);
    Task<Contact> CreateContactAsync(ContactDto contactDto);
    Task<Contact?> UpdateContactAsync(string fullName, ContactDto contactDto);
    Task DeleteContactAsync(Guid id);
}