using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Repositories;
using Task = postgress.Entities.Task;

namespace postgress.Controller; 

[Route("api/[controller]")]
[ApiController]
public class TaskController : AppDbController<Task, TaskRepository>
{
    public TaskController(TaskRepository repository) : base(repository) { }
}