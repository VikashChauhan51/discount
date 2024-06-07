using Discount.Core.protos.v1.api;
using Discount.Core.protos.v1.types;
using Grpc.Core;

namespace Discount.Grpc.Services.v1;

public class DiscountService: DiscountServiceCore.DiscountServiceCoreBase
{
    private readonly ILogger<DiscountService> _logger;
    public DiscountService(ILogger<DiscountService> logger)
    {
        _logger = logger;
    }


    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
         return await base.GetDiscount(request, context);
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        return await base.CreateDiscount(request, context);
    }


    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        return await base.UpdateDiscount(request, context);
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return await base.DeleteDiscount(request, context);
    }
}