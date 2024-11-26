using Application.Interfaces.Repositories.DrugRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

public class GetDrugByIdQueryHandler : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    private readonly IDrugReadRepository _drugReadRepository;

    public GetDrugByIdQueryHandler(IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }

    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = 
           await _drugReadRepository.GetByIdAsync(request.id, cancellationToken);

        if (responce == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistDrug);
        }
        
        return responce;
    }
}