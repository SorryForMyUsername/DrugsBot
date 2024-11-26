using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

public record AddDrugStoreCommand(DrugStore drugStore) : IRequest;