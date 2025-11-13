using FluentValidation;
using TodoList.Api.Models;

namespace TodoList.Api.Validations;

public class CreateTodoListRequestValidator
    : AbstractValidator<CreateTodoListRequest>
{
    public CreateTodoListRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.TodoItems)
            .NotNull()
            .NotEmpty();
    }
}