using JFA.DependencyInjection;
using Mapster;
using postgress.Entities;
using postgress.Services.Generics;

namespace postgress.Repositories;

public class ContactRepository : GenericService<Contact, AppDbContext.AppDbContext>
{
    public ContactRepository(AppDbContext.AppDbContext context) : base(context)
    {

    }
}