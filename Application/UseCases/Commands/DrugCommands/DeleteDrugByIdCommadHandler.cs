using Application.Interfaces.Repositories.DrugItemRepositories;
using Application.Interfaces.Repositories.DrugRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

public class DeleteDrugByIdCommadHandler : IRequestHandler<DeleteDrugByIdCommand>
{
    private readonly IDrugWriteRepository _drugWriteRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    public DeleteDrugByIdCommadHandler(
        IDrugWriteRepository drugWriteRepository,
        IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugItemWriteRepository = drugItemWriteRepository;
    }

    public async Task Handle(DeleteDrugByIdCommand request, CancellationToken cancellationToken)
    {
        Drug? drug = await _drugWriteRepository.ReadRepository.GetByIdAsync(request.id, cancellationToken);
        
        if (drug == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistDrug);
        }

        foreach (DrugItem drugItem in drug.DrugItems)
        {
            await _drugItemWriteRepository.DeleteAsync(drugItem.Id, cancellationToken);
        }
        
        await _drugWriteRepository.DeleteAsync(request.id, cancellationToken);
    }
}