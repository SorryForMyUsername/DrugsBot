using Application.Interfaces.Repositories.DrugStoreRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

public class GetDrugStoreByIdQueryHandler : IRequestHandler<GetDrugStoreByIdQuery, DrugStore?>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    public GetDrugStoreByIdQueryHandler(
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    public async Task<DrugStore?> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = 
            await _drugStoreReadRepository.GetByIdAsync(request.id, cancellationToken);

        if (responce == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistDrugStore);
        }
        
        return responce;
    }
}