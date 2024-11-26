using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries;

public record GetFavouriteDrugByIdQuery(Guid id) : IRequest<FavouriteDrug?>;