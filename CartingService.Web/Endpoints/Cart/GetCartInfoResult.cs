using CartingService.BusinessLogic.Models;

namespace CartingService.Web.Endpoints.Cart;

internal record GetCartInfoResult(Guid CartId, IEnumerable<Item> Items);