using DevFreela.Core.Entities;
using DevFreela.Core.Models;
using DevFreela.Core.Repositories;
using LinqKit;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PaginationResult<ProjectOutputModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<PaginationResult<ProjectOutputModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var where = BuildFilters(request.Filters);
            var pagedProjects = await _projectRepository.GetAllAsync(where, request.CurrentPage, request.PageSize);

            var data = pagedProjects.Data
                .Select(p => new ProjectOutputModel(p.Id, p.Title, p.Description, p.CreatedAt))
                .ToList();

            return new PaginationResult<ProjectOutputModel>(
                pagedProjects.CurrentPage,
                pagedProjects.TotalPages,
                pagedProjects.PageSize,
                pagedProjects.TotalCount,
                data);
        }

        private ExpressionStarter<Project>? BuildFilters(ProjectFiltersInputModel filters)
        {
            if (filters == null)
            {
                return null;
            }

            var predicate = PredicateBuilder.New<Project>(true);

            if (!string.IsNullOrWhiteSpace(filters.Title))
            {
                predicate = predicate.And(x => x.Title.Contains(filters.Title));
            }
            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                predicate = predicate.And(x => x.Description.Contains(filters.Description));
            }

            return predicate;
        }
    }
}
