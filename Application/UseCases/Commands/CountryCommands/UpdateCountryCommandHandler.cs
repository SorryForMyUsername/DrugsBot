using Application.Interfaces.Repositories.CountryRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
{
    private readonly ICountryWriteRepository _countryWriteRepository;

    public UpdateCountryCommandHandler(ICountryWriteRepository countryWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;
    }

    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        Country? country = await _countryWriteRepository.ReadRepository.GetByIdAsync(request.country.Id, cancellationToken);

        if (country == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistCountry);
        }

        await _countryWriteRepository.UpdateAsync(request.country, cancellationToken);
    }
}