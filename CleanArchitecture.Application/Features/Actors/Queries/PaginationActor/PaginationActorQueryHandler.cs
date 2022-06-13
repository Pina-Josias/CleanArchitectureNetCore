using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Actors.Queries.Vms;
using CleanArchitecture.Application.Features.Shared.Queries;
using CleanArchitecture.Application.Specifications.Actors;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Actors.Queries.PaginationActor
{
    public class PaginationActorQueryHandler : IRequestHandler<PaginationActorQuery, PaginationVm<ActorVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaginationActorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationVm<ActorVm>> Handle(PaginationActorQuery request, CancellationToken cancellationToken)
        {
            var actorSpecParams = new ActorSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort,
            };

            var spec = new ActorSpecification(actorSpecParams);

            var actors = await _unitOfWork.Repository<Actor>().GetAllWithSpecification(spec);

            var specCount = new ActorForCountingSpecification(actorSpecParams);

            var totalActors = await _unitOfWork.Repository<Actor>().CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalActors) / Convert.ToDecimal(actorSpecParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Actor>, IReadOnlyList<ActorVm>>(actors);

            var pagination = new PaginationVm<ActorVm>
            {
                Count = totalActors,
                Data = data,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };

            return pagination;

        }
    }
}
