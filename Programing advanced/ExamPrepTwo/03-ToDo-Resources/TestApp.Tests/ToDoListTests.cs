using System;
using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        //Arrange
        string taskName = "random Task";
        DateTime taskDate = DateTime.Now;
        

        this._toDoList.AddTask(taskName, taskDate);
        //Act
        var result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Does.Contain($"To-Do List:\r\n[ ] {taskName} - Due: "));

    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        //Arrange
        string taskName = "random Task";
        DateTime taskDate = DateTime.Now;
        this._toDoList.AddTask(taskName, taskDate);
        this._toDoList.CompleteTask(taskName);

        //Act
        var result = this._toDoList.DisplayTasks();
        //Assert
        Assert.That(result, Does.Contain($"[✓] {taskName} - Due:"));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        string taskName = "null";
       

        //Act & Assert
        Assert.That(() => this._toDoList.CompleteTask(taskName), Throws.ArgumentException);
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        //Arrange
       
        //Act
        var result = this._toDoList.DisplayTasks();
        //Assert

        Assert.That(result, Is.EqualTo("To-Do List:" + string.Empty));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        //Arrange
        string taskName = "random Task";
        DateTime taskDate = DateTime.Now;
        this._toDoList.AddTask(taskName, taskDate);

        string taskName2 = "random Task2";
        DateTime taskDate2 = DateTime.Now;
        this._toDoList.AddTask(taskName2, taskDate2);
        this._toDoList.CompleteTask(taskName2);

        //Act
        var result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Does.Contain($"[ ] {taskName} - Due:"));
        Assert.That(result, Does.Contain($"[✓] {taskName2} - Due:"));
    }
}
