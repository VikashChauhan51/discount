
namespace Discount.Application.Commands;
public class DeleteDiscountCommand : ICommand<bool>
{
    public string ProductName { get; set; }

    public DeleteDiscountCommand(string productName)
    {
        ProductName = productName;
    }
}
