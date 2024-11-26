using Application.Interfaces.Repositories.FavouriteDrugRepositories;
using Application.Interfaces.Repositories.ProfileRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

public class DeleteProfileByIdCommandHandler : IRequestHandler<DeleteProfileByIdCommand>
{
    private readonly IProfileWriteRepository _profileWriteRepository;
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;

    public DeleteProfileByIdCommandHandler(
        IProfileWriteRepository profileWriteRepository,
        IFavouriteDrugWriteRepository favouriteDrugWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
        _favouriteDrugWriteRepository = favouriteDrugWriteRepository;
    }

    public async Task Handle(DeleteProfileByIdCommand request, CancellationToken cancellationToken)
    {
        Profile? profile = await _profileWriteRepository.ReadRepository.GetByIdAsync(request.id, cancellationToken);
        
        if (profile == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistProfile);
        }
        
        await _profileWriteRepository.DeleteAsync(request.id, cancellationToken);
    }
}