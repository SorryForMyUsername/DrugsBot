using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

public record DeleteDrugByIdCommand(Guid id) : IRequest;