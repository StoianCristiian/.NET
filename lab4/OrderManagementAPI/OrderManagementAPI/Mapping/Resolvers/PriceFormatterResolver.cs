using AutoMapper;

namespace OrderManagementAPI.Mapping.Resolvers {};

public class PriceFormatterResolver : IValueResolver<Order, OrderProfileDto, string>
{
    public string Resolve(Order source, OrderProfileDto destination, string destMember, ResolutionContext context)
        => source.Price.ToString("C2");
}