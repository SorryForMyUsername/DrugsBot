using Application.Interfaces.Repositories.ProfileRepositories;
using Domain.Entities;
using Domain.Primitives;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, Profile?>
{
    private readonly IProfileReadRepository _profileReadRepository;

    public GetProfileByIdQueryHandler(IProfileReadRepository profileReadRepository)
    {
        _profileReadRepository = profileReadRepository;
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = 
            await _profileReadRepository.GetByIdAsync(request.id, cancellationToken);

        if (responce == null)
        {
            throw new NullReferenceException(NullReferenceMessage.NotExistProfile);
        }
        
        return responce;
    }
}