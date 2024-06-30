using Discount.Application.Commands;


namespace Discount.Application.Handlers;
public class UpdateDiscountCommandHandler : ICommandHandler<UpdateDiscountCommand, CouponModel>
{
    private readonly IDiscountRepository _discountRepository;

    public UpdateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = request.Adapt<Coupon>();
        await _discountRepository.UpdateDiscount(coupon);
        var couponModel = request.Adapt<CouponModel>();
        return couponModel;
    }
}
