using Application.Interfaces.Repositories.DrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;

public class GetDrugItemByIdQueryHandler : IRequestHandler<GetDrugItemByIdQuery, DrugItem?>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;

    public GetDrugItemByIdQueryHandler(IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }

    public async Task<DrugItem?> Handle(GetDrugItemByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = 
            await _drugItemReadRepository.GetByIdAsync(request.id, cancellationToken);

        if (responce == null)
        {
            throw new NullReferenceException();
        }
        
        return responce;
    }
}