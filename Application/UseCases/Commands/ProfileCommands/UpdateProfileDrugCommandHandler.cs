using Application.Interfaces.Repositories.ProfileRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

public class UpdateProfileDrugCommandHandler : IRequestHandler<UpdateProfileDrugCommand>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    public UpdateProfileDrugCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }

    public async Task Handle(UpdateProfileDrugCommand request, CancellationToken cancellationToken)
    {
        Profile? profile = await _profileWriteRepository.ReadRepository.GetByIdAsync(request.profile.Id, cancellationToken);
        
        if (profile == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistProfile);
        }
        
        await _profileWriteRepository.UpdateAsync(request.profile, cancellationToken);
    }
}