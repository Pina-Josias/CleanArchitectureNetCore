using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Directors.Queries.Vms;
using CleanArchitecture.Application.Features.Shared.Queries;
using CleanArchitecture.Application.Specifications.Directors;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Directors.Queries.PaginationDirector
{
    public class PaginationDirectorsQueryHandler : IRequestHandler<PaginationDirectorsQuery, PaginationVm<DirectorVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaginationDirectorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationVm<DirectorVm>> Handle(PaginationDirectorsQuery request, CancellationToken cancellationToken)
        {
            var directorSpecParams = new DirectorSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort
            };

            var spec = new DirectorSpecification(directorSpecParams);
            var directors = await _unitOfWork.Repository<Director>().GetAllWithSpecification(spec);

            var specCount = new DirectorForCountingSpecification(directorSpecParams);
            var totalDirectos = await _unitOfWork.Repository<Director>().CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalDirectos) / Convert.ToDecimal(request.PageSize));

            var totalPages = Convert.ToInt32(rounded);

            var dataResponse = _mapper.Map<IReadOnlyList<Director>, IReadOnlyList<DirectorVm>>(directors);

            var pagination = new PaginationVm<DirectorVm>
            {
                Count = totalDirectos,
                Data = dataResponse,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return pagination;
        }
    }
}
