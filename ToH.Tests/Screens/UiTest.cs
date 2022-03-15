using Moq;
using ToH.Log;
using ToH.Screens;
using Xunit;

namespace ToH.Tests.Screens;

public class UiTest
{
    private readonly Ui uut;
    private Mock<Controller> _controller;
    private Mock<Screen> _screen;
    private Mock<ILog> _log;

    public UiTest()
    {
        _controller = new Mock<Controller>();
        _screen = new Mock<Screen>();
        _log = new Mock<ILog>();
        uut = new Ui(_controller.Object, _screen.Object, _log.Object);
    }

    [Fact]
    public void ShouldExecuteNoneActionOnScreen_WhenPrintIsCalled()
    {
        // Act
        uut.Print();
        
        // Assert
        _screen.Verify(screen => screen.None(It.Is<Ui>(ui => ui.Equals(uut))), Times.Once);
    }
    
    [Fact]
    public void ShouldExecuteNoneActionOnScreen_WhenUpdateIsCalledAndControllerActionIsNone()
    {
        // Arrange
        _controller.Setup(controller => controller.Action).Returns(Action.None);
        
        // Act
        uut.Update();
        
        // Assert
        _screen.Verify(screen => screen.None(It.Is<Ui>(ui => ui.Equals(uut))), Times.Once);
    }
    
    [Fact]
    public void ShouldExecuteDownActionOnScreen_WhenUpdateIsCalledAndControllerActionIsDown()
    {
        // Arrange
        _controller.Setup(controller => controller.Action).Returns(Action.Down);
        
        // Act
        uut.Update();
        
        // Assert
        _screen.Verify(screen => screen.Down(It.Is<Ui>(ui => ui.Equals(uut))), Times.Once);
    }
    
    [Fact]
    public void ShouldExecuteUpActionOnScreen_WhenUpdateIsCalledAndControllerActionIsUp()
    {
        // Arrange
        _controller.Setup(controller => controller.Action).Returns(Action.Up);
        
        // Act
        uut.Update();
        
        // Assert
        _screen.Verify(screen => screen.Up(It.Is<Ui>(ui => ui.Equals(uut))), Times.Once);
    }

}