using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

public record DeleteDrugStoreByIdCommand(Guid id) : IRequest;