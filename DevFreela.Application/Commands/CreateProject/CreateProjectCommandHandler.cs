using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(
                request.Title,
                request.Description,
                request.ClientId,
                request.FreelancerId,
                request.TotalCost);

            await _unitOfWork.BeginTransactionAsync();

            var projectId = await _projectRepository.CreateAsync(project);

            await _unitOfWork.CommitTransactionAsync();

            return projectId;
        }
    }
}
