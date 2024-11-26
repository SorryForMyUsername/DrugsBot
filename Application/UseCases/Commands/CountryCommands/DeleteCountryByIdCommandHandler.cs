using Application.Interfaces.Repositories.CountryRepositories;
using Application.Interfaces.Repositories.DrugRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

public class DeleteCountryByIdCommandHandler : IRequestHandler<DeleteCountryByIdCommand>
{
    private readonly ICountryWriteRepository _countryWriteRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    public DeleteCountryByIdCommandHandler(
        ICountryWriteRepository countryWriteRepository,
        IDrugWriteRepository drugWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _drugWriteRepository = drugWriteRepository;
    }

    public async Task Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
    {
        Country? country = await _countryWriteRepository.ReadRepository.GetByIdAsync(request.id, cancellationToken);
        
        if (country == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistCountry);
        }

        foreach (Drug drug in country.Drugs)
        {
            await _drugWriteRepository.DeleteAsync(drug.Id, cancellationToken);
        }
        
        await _countryWriteRepository.DeleteAsync(request.id, cancellationToken);
    }
}