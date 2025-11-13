using FluentValidation;
using TodoList.Api.Models;

namespace TodoList.Api.Validations;

public class CreateTodoListRequestValidator
    : AbstractValidator<CreateTodoListRequest>
{
    public CreateTodoListRequestValidator()
    {
        RuleFor(x => x.TodoList)
            .NotNull();

        // list title should exist and have loq 50 chars
        When(x => x.TodoList != null, () =>
            {
                RuleFor(x => x.TodoList!.Title)
                    .NotNull()
                    .NotEmpty()
                    .MaximumLength(50);

                RuleFor(x => x.TodoList!.Description)
                    .MaximumLength(100);
            }
        );

        // list should have items
        RuleFor(x => x.TodoItems)
            .NotNull()
            .NotEmpty();


        // if items exist, then each of them should have title (max 50 chars),
        // and if each items description exists, then it should have loq 100 chars
        When(x => x.TodoItems != null && x.TodoItems.Any(), () =>
            {
                RuleForEach(x => x.TodoItems)
                    .ChildRules(item =>
                    {
                        item.RuleFor(t => t.Title)
                            .NotNull()
                            .NotEmpty()
                            .MaximumLength(50);

                        item.RuleFor(t => t.Description)
                        .MaximumLength(100);
                    });
            });
    }
}