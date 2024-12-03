using Application.Interfaces.Repositories.DrugRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

public class UpdateDrugCommandHandler : IRequestHandler<UpdateDrugCommand>
{
    private readonly IDrugWriteRepository _drugWriteRepository;

    public UpdateDrugCommandHandler(IDrugWriteRepository drugWriteRepository)
    {
        _drugWriteRepository = drugWriteRepository;
    }

    public async Task Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        Drug? drug = await _drugWriteRepository.ReadRepository.GetByIdAsync(request.drug.Id, cancellationToken);
        
        if (drug == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistDrug);
        }
        
        await _drugWriteRepository.UpdateAsync(request.drug, cancellationToken);
    }
}