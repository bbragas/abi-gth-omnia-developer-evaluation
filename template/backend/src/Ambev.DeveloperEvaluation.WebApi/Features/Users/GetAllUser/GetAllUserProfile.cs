using Ambev.DeveloperEvaluation.Application.Users.GetAllUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.Base;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUser;

public class GetAllUserProfile : Profile
{
    public GetAllUserProfile()
    {
        CreateMap<GetAllUserRequest, GetAllUserCommand>();
        CreateMap<GetAllUserResult, GetAllUserResponse>()
            .ForMember(response => response.Name, result => result.MapFrom(r =>
                new Name
                {
                    FirstName = r.Firstname,
                    LastName = r.Lastname
                }))
            .ForMember(response => response.Address, result => result.MapFrom(r =>
                new Address
                {
                    City = r.City,
                    Street = r.Street,
                    Number = r.Number,
                    Zipcode = r.Zipcode,
                    Geolocation = new Geolocation
                    {
                        Lat = r.Lat,
                        Long = r.Long
                    }
                }))
            ;
    }
}