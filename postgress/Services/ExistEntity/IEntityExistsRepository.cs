namespace postgress.Services.ExistEntity;

public interface IEntityExistsRepository
{
    Task<bool> IsExists(object? id);
}