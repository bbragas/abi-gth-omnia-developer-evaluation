using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllCategories
{
    public class GetAllCategoriesProfile : Profile
    {
        public GetAllCategoriesProfile()
        {
            CreateMap<GetAllCategoriesCommand, string>();
        }
    }
}
