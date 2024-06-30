using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Core.protos.v1.api;
using Discount.Core.protos.v1.types;
using Grpc.Core;
using Mapster;
using MediatR;

namespace Discount.Grpc.Services.v1;

public class DiscountService: DiscountServiceCore.DiscountServiceCoreBase
{
    private readonly ILogger<DiscountService> _logger;
    private readonly IMediator _mediator;
    public DiscountService(ILogger<DiscountService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var query = request.Adapt<GetDiscountQuery>();
        var result = await _mediator.Send(query);
        _logger.LogInformation("Discount is retrieved for the Product Name: {ProductName} and Amount : {Amount}", request.ProductName, result.Amount);
        return result;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var cmd = request.Adapt<CreateDiscountCommand>();  
        var result = await _mediator.Send(cmd);
        _logger.LogInformation("Discount is successfully created for the Product Name: {ProductName}", result.ProductName);
        return result;
    }


    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var cmd = request.Adapt<UpdateDiscountCommand>();
        var result = await _mediator.Send(cmd);
        _logger.LogInformation("Discount is successfully updated Product Name: {ProductName}", result.ProductName);
        return result;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var cmd = request.Adapt<DeleteDiscountCommand>();
        var deleted = await _mediator.Send(cmd);
        var response = new DeleteDiscountResponse
        {
            Success = deleted
        };
        return response;
    }
}
