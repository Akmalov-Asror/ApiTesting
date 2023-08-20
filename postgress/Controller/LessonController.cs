using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class LessonController : AppDbController<Lesson, LessonRepository>
{
    public LessonController(LessonRepository repository) : base(repository) { }
}