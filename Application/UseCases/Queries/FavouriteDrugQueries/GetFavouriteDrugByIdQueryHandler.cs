using Application.Interfaces.Repositories.FavouriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries;

public class GetFavouriteDrugByIdQueryHandler : IRequestHandler<GetFavouriteDrugByIdQuery, FavouriteDrug?>
{
    private readonly IFavouriteDrugReadRepository _favouriteDrugReadRepository;

    public GetFavouriteDrugByIdQueryHandler(IFavouriteDrugReadRepository favouriteDrugReadRepository)
    {
        _favouriteDrugReadRepository = favouriteDrugReadRepository;
    }

    public async Task<FavouriteDrug?> Handle(GetFavouriteDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = 
            await _favouriteDrugReadRepository.GetByIdAsync(request.id, cancellationToken);

        if (responce == null)
        {
            throw new NullReferenceException();
        }
        
        return responce;
    }
}