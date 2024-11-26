using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

public record GetDrugStoreByIdQuery(Guid id) : IRequest<DrugStore?>;