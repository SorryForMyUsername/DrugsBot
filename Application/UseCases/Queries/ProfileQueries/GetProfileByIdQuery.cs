using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

public record GetProfileByIdQuery(Guid id) : IRequest<Profile?>;