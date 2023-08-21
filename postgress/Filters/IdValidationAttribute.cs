using Microsoft.AspNetCore.Mvc;

namespace postgress.Filters;

public class IdValidationAttribute : TypeFilterAttribute
{
    public IdValidationAttribute() : base(typeof(IdCheckAttribute)) { }
}