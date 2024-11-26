using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.CountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand>
{
    private readonly ICountryWriteRepository _countryWriteRepository;

    public AddCountryCommandHandler(ICountryWriteRepository countryWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;
    }

    public async Task Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        Country? countryWithTheSameId =
            await _countryWriteRepository.ReadRepository.GetByIdAsync(request.country.Id, cancellationToken);

        if (countryWithTheSameId == null)
        {
            await _countryWriteRepository.AddAsync(request.country, cancellationToken);
        }
    }
}