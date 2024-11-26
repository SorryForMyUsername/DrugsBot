using Application.Interfaces.Repositories.CountryRepositories;
using Application.Interfaces.Repositories.DrugRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

public class AddDrugCommandHandler : IRequestHandler<AddDrugCommand>
{
    private readonly IDrugWriteRepository _drugWriteRepository;
    private readonly ICountryReadRepository _countryReadRepository;

    public AddDrugCommandHandler(
        IDrugWriteRepository drugWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    public async Task Handle(AddDrugCommand request, CancellationToken cancellationToken)
    {
        Drug? drugWithTheSameId =
            await _drugWriteRepository.ReadRepository.GetByIdAsync(request.drug.Id, cancellationToken);

        if (drugWithTheSameId == null)
        {
            Country? country = await _countryReadRepository.GetByIdAsync(request.drug.Country.Id, cancellationToken);

            if (country == null)
            {
                throw new NullReferenceException(NullReferenceMessage.NotExistCountry);
            }

            await _drugWriteRepository.AddAsync(request.drug, cancellationToken);
        }
    }
}