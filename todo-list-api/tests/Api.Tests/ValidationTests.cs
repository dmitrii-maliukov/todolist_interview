using System.Net.Http.Json;
using FluentAssertions;
using TodoList.Api.Models;

namespace Api.Tests;

public class ValidationTests
{
    private const string _conrollerUrl = "api/todo-lists";

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task CreateTodoList_NoTitle_ShouldReturnBadRequestWithMessage(
        string? theoryTitle)
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            TodoList = new CreateTodoListModel { Title = theoryTitle },
            TodoItems = [new CreateTodoListItemModel { Title = "test 1st item" }]
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        var content = await AssertBadRequestAsync(response);
        content.Should().Contain("'Todo List Title' must not be empty.");
        content.Should().NotContain("'Todo Items' must not be empty.");
    }


    public static IEnumerable<object?[]> EmptyTodoItemsTestData =>
        new List<object?[]>
        {
            new object?[] { new List<CreateTodoListItemModel>() },
            new object?[] { null }
        };

    [Theory]
    [MemberData(nameof(EmptyTodoItemsTestData))]
    public async Task CreateTodoList_NoTodoItems_ShouldReturnBadRequestWithMessage(
        IEnumerable<CreateTodoListItemModel> todoItems)
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            TodoList = new CreateTodoListModel { Title = "Test todo list" },
            TodoItems = todoItems
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        var content = await AssertBadRequestAsync(response);
        content.Should().Contain("'Todo Items' must not be empty.");
        content.Should().NotContain("'Todo List Title' must not be empty.");
    }

    [Fact]
    public async Task CreateTodoList_NoTitle_NoTodoItems_ShouldReturnBadRequestWithErrorMessages()
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            TodoList = null,
            TodoItems = null
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        var content = await AssertBadRequestAsync(response);
        content.Should().Contain("'Todo List' must not be empty.");
        content.Should().Contain("'Todo Items' must not be empty.");
    }

    [Fact]
    public async Task CreateTodoList_NoTitleInOneTodoItems_ShouldReturnBadRequestWithMessage()
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            TodoList = new CreateTodoListModel { Title = "Test todo list" },
            TodoItems = [
                new CreateTodoListItemModel() { Title = "Item 1" },
                new CreateTodoListItemModel() { Title = null },
                new CreateTodoListItemModel() { Title = "Item 2" }
            ]
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        var content = await AssertBadRequestAsync(response);
        content.Should().Contain("'Title' must not be empty.");
    }

    [Fact]
    public async Task CreateTodoList_ListTitleCharsOverflown_ShouldReturnBadRequestWithErrorMessage()
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            TodoList = new CreateTodoListModel { Title = "Very long title, definitely more than allowed in our API" },
            TodoItems = [new CreateTodoListItemModel { Title = "test 1st item" }]
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        var content = await AssertBadRequestAsync(response);
        content.Should().Contain("The length of 'Todo List Title' must be 50 characters or fewer. You entered 56 characters.");
    }

    [Fact]
    public async Task CreateTodoList_ListDescriptionCharsOverflown_ShouldReturnBadRequestWithErrorMessage()
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            TodoList = new CreateTodoListModel
            {
                Title = "Good Title",
                Description = "Very long description. There is no way that description can be so long. Like how many characters here... Too many for my taste",
            },
            TodoItems = [new CreateTodoListItemModel { Title = "test 1st item" }]
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        var content = await AssertBadRequestAsync(response);
        content.Should().Contain("The length of 'Todo List Description' must be 100 characters or fewer. You entered 126 characters.");
    }

    private async Task<string> AssertBadRequestAsync(HttpResponseMessage response)
    {
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        return await response.Content.ReadAsStringAsync();
    }
}
