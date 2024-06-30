

namespace Discount.Application.Queries;
public class GetDiscountQuery : IQuery<CouponModel>
{
    public string ProductName { get; set; }

    public GetDiscountQuery(string productName)
    {
        ProductName = productName;
    }
}
