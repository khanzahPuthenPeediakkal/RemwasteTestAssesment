using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UiTestAutomation.Pages
{
    public class TodoPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions actions;

        private readonly By newTodoInput = By.ClassName("new-todo");
        private readonly By todoListItems = By.CssSelector(".todo-list li");
        private readonly By todoCheckbox = By.ClassName("toggle");
        private readonly By todoDeleteButton = By.CssSelector(".destroy");

        public TodoPage(IWebDriver driver)
        {
            this.driver = driver;
            this.actions = new Actions(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void WaitForPageToLoad()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(newTodoInput));
        }

        public void AddTodo(string text)
        {
            var input = wait.Until(ExpectedConditions.ElementIsVisible(newTodoInput));
            input.SendKeys(text);
            input.SendKeys(Keys.Enter);
        }

        public IList<IWebElement> GetAllTodos()
        {
            return wait.Until(driver => driver.FindElements(todoListItems));
        }

        public bool IsTodoPresent(string text)
        {
            return GetAllTodos().Any(item => item.Text.Contains(text));
        }

        public IWebElement WaitForTodoItem(string text)
        {
            return wait.Until(driver =>
            {
                var items = driver.FindElements(todoListItems);
                return items.FirstOrDefault(x => x.Text.Contains(text));
            });
        }

        public void MarkTodoAsCompleted(string text)
        {
            var item = WaitForTodoItem(text);
            var checkbox = item.FindElement(todoCheckbox);
            checkbox.Click();
        }

        public bool IsTodoCompleted(string text)
        {
            var item = WaitForTodoItem(text);
            return item.GetAttribute("class").Contains("completed");
        }

        public void DeleteTodo(string text)
        {
            var item = WaitForTodoItem(text);
            actions.MoveToElement(item).Perform();
            var deleteBtn = item.FindElement(todoDeleteButton);
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteBtn)).Click();
        }

        public void EditTodo(string oldText, string newText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var item = wait.Until(_ => GetAllTodos().FirstOrDefault(x => x.Text.Contains(oldText)));
            if (item == null)
                throw new NoSuchElementException($"Todo '{oldText}' not found.");

            var label = item.FindElement(By.CssSelector("label"));

            new Actions(driver).MoveToElement(label).DoubleClick().Perform();

            var input = wait.Until(drv =>
                item.FindElements(By.XPath("//input")).Last(el => el.Displayed));

            input.SendKeys(newText);
            input.SendKeys(Keys.Enter);

            wait.Until(d => !item.GetAttribute("class").Contains("editing"));
        }
    }
}
