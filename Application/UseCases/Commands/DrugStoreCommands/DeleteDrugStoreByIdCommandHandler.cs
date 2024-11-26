using Application.Interfaces.Repositories.DrugItemRepositories;
using Application.Interfaces.Repositories.DrugStoreRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

public class DeleteDrugStoreByIdCommandHandler : IRequestHandler<DeleteDrugStoreByIdCommand>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    public DeleteDrugStoreByIdCommandHandler(
        IDrugStoreWriteRepository drugStoreWriteRepository,
        IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _drugItemWriteRepository = drugItemWriteRepository;
    }

    public async Task Handle(DeleteDrugStoreByIdCommand request, CancellationToken cancellationToken)
    {
        DrugStore? drugStore = await _drugStoreWriteRepository.ReadRepository.GetByIdAsync(request.id, cancellationToken);
        
        if (drugStore == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistDrugStore);
        }

        foreach (DrugItem drugItem in drugStore.DrugItems)
        {
            await _drugItemWriteRepository.DeleteAsync(drugItem.Id, cancellationToken);
        }
        
        await _drugStoreWriteRepository.DeleteAsync(request.id, cancellationToken);
    }
}