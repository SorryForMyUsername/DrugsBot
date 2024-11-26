using Application.Interfaces.Repositories.DrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

public class AddDrugStoreCommandHandler : IRequestHandler<AddDrugStoreCommand>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    public AddDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }

    public async Task Handle(AddDrugStoreCommand request, CancellationToken cancellationToken)
    {
        DrugStore? drugStoreWithTheSameId =
            await _drugStoreWriteRepository.ReadRepository.GetByIdAsync(request.drugStore.Id, cancellationToken);

        if (drugStoreWithTheSameId == null)
        {
            await _drugStoreWriteRepository.AddAsync(request.drugStore, cancellationToken);
        }
    }
}