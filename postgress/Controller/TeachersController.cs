using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : AppDbController<Teacher, TeacherRepository>
{
    public TeachersController(TeacherRepository repository) : base(repository) { }
}