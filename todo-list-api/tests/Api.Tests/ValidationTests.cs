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
    public async Task AddTodoList_NoTitle_ShouldReturnBadRequestWithMessage(
        string? theoryTitle)
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            Title = theoryTitle,
            TodoItems = ["test 1st item"]
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("'Title' must not be empty.");
        content.Should().NotContain("'Todo Items' must not be empty.");
    }


    public static IEnumerable<object?[]> EmptyTodoItemsTestData =>
        new List<object?[]>
        {
            new object?[] { new List<string>() },
            new object?[] { null }
        };

    [Theory]
    [MemberData(nameof(EmptyTodoItemsTestData))]
    public async Task AddTodoList_NoTodoItems_ShouldReturnBadRequestWithMessage(
        IEnumerable<string> todoItems)
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            Title = "Test todo list",
            TodoItems = todoItems
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("'Todo Items' must not be empty.");
        content.Should().NotContain("'Title' must not be empty.");
    }

    [Fact]
    public async Task AddTodoList_NoTitle_NoTodoItems_ShouldReturnBadRequestWithErrorMessages()
    {
        // arrange 
        var todoListToCreate = new CreateTodoListRequest
        {
            Title = null,
            TodoItems = null
        };

        var apiFactory = new TestApiFactory();
        var unitUnderTest = apiFactory.CreateClient();

        // act
        var response = await unitUnderTest.PostAsJsonAsync(_conrollerUrl, todoListToCreate);

        // assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("'Title' must not be empty.");
        content.Should().Contain("'Todo Items' must not be empty.");
    }
}
