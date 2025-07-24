using FluentAssertions;
using NUnit.Framework;
using UiTestAutomation.Utils;

namespace UiTestAutomation.Tests
{
    [TestFixture]
    public class TodoTest : BaseTest
    {
        private string todoText;

        [SetUp]
        public void SetupEachTest()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            todoText = $"TODO - {date}";
        }

        [Test]
        public void Should_Create_New_Todo_Item()
        {
            TodoPage.AddTodo(todoText);
            TodoPage.IsTodoPresent(todoText).Should().BeTrue("the new todo should appear in the list");
        }

        [Test]
        public void Should_Delete_Todo_Item()
        {
            TodoPage.AddTodo(todoText);
            TodoPage.DeleteTodo(todoText);
            TodoPage.IsTodoPresent(todoText).Should().BeFalse("the deleted todo should no longer be present");
        }

        [Test]
        public void Should_Assert_Todo_Is_Completed()
        {
            TodoPage.AddTodo(todoText);
            TodoPage.MarkTodoAsCompleted(todoText);
            TodoPage.IsTodoCompleted(todoText).Should().BeTrue("the todo should be marked as completed");
        }

        [Test]
        public void Should_Edit_Existing_Todo_Item()
        {
            TodoPage.AddTodo(todoText);
            TodoPage.IsTodoPresent(todoText).Should().BeTrue("original todo should exist before editing");
            TodoPage.EditTodo(todoText, "[UPDATED]");
            TodoPage.IsTodoPresent("[UPDATED]").Should().BeTrue("the updated todo should appear in the list");
        }
    }
}
