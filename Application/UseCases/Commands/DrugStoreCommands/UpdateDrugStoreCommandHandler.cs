using Application.Interfaces.Repositories.DrugStoreRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

public class UpdateDrugStoreCommandHandler : IRequestHandler<UpdateDrugStoreCommand>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    public UpdateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }

    public async Task Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        DrugStore? drugStore = await _drugStoreWriteRepository.ReadRepository.GetByIdAsync(request.drugStore.Id, cancellationToken);
        
        if (drugStore == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistDrugStore);
        }
        
        await _drugStoreWriteRepository.UpdateAsync(request.drugStore, cancellationToken);    
    }
}