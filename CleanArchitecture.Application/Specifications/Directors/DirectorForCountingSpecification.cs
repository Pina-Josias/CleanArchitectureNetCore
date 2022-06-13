using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specifications.Directors
{
    public class DirectorForCountingSpecification : BaseSpecification<Director>
    {
        public DirectorForCountingSpecification(DirectorSpecificationParams directorSpecificationParams)
            : base(
                  x => string.IsNullOrEmpty(directorSpecificationParams.Search)
                  || x.Nombre!.Contains(directorSpecificationParams.Search)
                  )
        { }
    }
}
