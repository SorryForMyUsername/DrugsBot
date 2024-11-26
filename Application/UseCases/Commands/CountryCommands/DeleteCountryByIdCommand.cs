using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

public record DeleteCountryByIdCommand(Guid id) : IRequest;