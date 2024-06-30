using Discount.Application.Queries;
using Grpc.Core;

namespace Discount.Application.Handlers;
public class GetDiscountQueryHandler : IQueryHandler<GetDiscountQuery, CouponModel>
{
    private readonly IDiscountRepository _discountRepository;

    public GetDiscountQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _discountRepository.GetDiscount(request.ProductName);
        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.ProductName} not found"));
        }
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
}
