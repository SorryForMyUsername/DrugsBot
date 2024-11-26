using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

public record DeleteProfileByIdCommand(Guid id) : IRequest;