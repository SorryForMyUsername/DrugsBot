using Application.Interfaces.Repositories.CountryRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;

public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }

    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = 
            await _countryReadRepository.GetByIdAsync(request.id, cancellationToken);

        if (responce == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistCountry);
        }
        
        return responce;
    }
}