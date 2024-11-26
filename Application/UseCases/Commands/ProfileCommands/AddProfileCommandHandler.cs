using Application.Interfaces.Repositories.ProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    public AddProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }

    public async Task Handle(AddProfileCommand request, CancellationToken cancellationToken)
    {
        Profile? profileWithTheSameId =
            await _profileWriteRepository.ReadRepository.GetByIdAsync(request.profile.Id, cancellationToken);

        if (profileWithTheSameId == null)
        {
            await _profileWriteRepository.AddAsync(request.profile, cancellationToken);
        }
    }
}