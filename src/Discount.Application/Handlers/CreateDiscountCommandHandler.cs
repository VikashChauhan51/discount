using Discount.Application.Commands;

namespace Discount.Application.Handlers;
public class CreateDiscountCommandHandler : ICommandHandler<CreateDiscountCommand, CouponModel>
{

    private readonly IDiscountRepository _discountRepository;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = request.Adapt<Coupon>();
        await _discountRepository.CreateDiscount(coupon);
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
}
