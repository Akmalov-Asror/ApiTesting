using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface ITestRepository
{
    Task<List<Test>> GetTestCollections();
    Task<Test> AddTest(TestDto testDto);
    Task<Test?> UpdateTest(Guid id, TestDto testDto);
    Task DeleteTest(Guid id);
}