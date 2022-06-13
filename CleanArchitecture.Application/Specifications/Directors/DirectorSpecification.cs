
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specifications.Directors
{
    public class DirectorSpecification : BaseSpecification<Director>
    {
        public DirectorSpecification(DirectorSpecificationParams directorSpecificationParams)
            : base(
                    x => string.IsNullOrEmpty(directorSpecificationParams.Search)
                        || x.Nombre!.Contains(directorSpecificationParams.Search)
                 )
        {
            AddPaging(
                directorSpecificationParams.PageSize * (directorSpecificationParams.PageIndex - 1),
                directorSpecificationParams.PageSize
            );

            if (!string.IsNullOrEmpty(directorSpecificationParams.Sort))
            {
                switch (directorSpecificationParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre!);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Nombre!);
                        break;
                    case "apellidoAsc":
                        AddOrderBy(p => p.Apellido!);
                        break;
                    case "apellidoDesc":
                        AddOrderByDescending(p => p.Apellido!);
                        break;
                    case "createDateAsc":
                        AddOrderBy(p => p.CreatedDate!);
                        break;
                    case "createDateDesc":
                        AddOrderByDescending(p => p.CreatedDate!);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre!);
                        break;
                }
            }
        }
    }
}
