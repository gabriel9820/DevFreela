using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var createProjectCommand = new CreateProjectCommand()
            {
                Title = "Título 1",
                Description = "Descrição 1",
                TotalCost = 0,
                ClientId = 1,
                FreelancerId = 2,
            };
            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            projectRepositoryMock.Verify(pr => pr.CreateAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
