using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Models;
using DevFreela.Core.Repositories;
using Moq;
using System.Linq.Expressions;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectOutputModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Projeto 1", "Descrição 1", 1, 2, 10000),
                new Project("Projeto 2", "Descrição 2", 1, 2, 20000),
                new Project("Projeto 3", "Descrição 3", 1, 2, 30000)
            };

            var projectsMock = new PaginationResult<Project>
            {
                Data = projects,
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync(It.IsAny<Expression<Func<Project, bool>>>(), It.IsAny<int>(), It.IsAny<int>()).Result).Returns(projectsMock);

            var getAllProjectsQuery = new GetAllProjectsQuery { Filters = null, CurrentPage = 1, PageSize = 10 };
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var pagedProjects = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(pagedProjects);
            Assert.NotEmpty(pagedProjects.Data);
            Assert.Equal(projectsMock.Data.Count, pagedProjects.Data.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync(It.IsAny<Expression<Func<Project, bool>>>(), It.IsAny<int>(), It.IsAny<int>()).Result, Times.Once);
        }
    }
}
