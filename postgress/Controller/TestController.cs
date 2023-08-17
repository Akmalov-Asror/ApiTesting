using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestRepository _testRepository;
    public TestController(ITestRepository testRepository) => _testRepository = testRepository;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Test>))]
    public async Task<IActionResult> GetTestCollection() => Ok(await _testRepository.GetTestCollections());

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddTestCollection(TestDto testDto) => Ok(await _testRepository.AddTest(testDto));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTest(Guid id, TestDto testDto)
    {
        var testUpdate = await _testRepository.UpdateTest(id, testDto);
        if (testUpdate is null)
            return NotFound("This User is not Defined");
        return Ok(testUpdate);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Test>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTest(Guid id)
    {
        await _testRepository.DeleteTest(id);
        return Ok("Test is Deleted");
    }
}