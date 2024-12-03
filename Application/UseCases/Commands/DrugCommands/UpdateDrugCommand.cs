using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

public record UpdateDrugCommand(Drug drug) : IRequest;