using AutoMapper;
using NBP.Application.DTOs;
using NBP.Application.Mediator.Commands.Admin;
using NBP.Application.Mediator.Commands.Login_Commands;
using NBP.Application.Mediator.Commands.Receptionist_Commands;
using NBP.Application.Mediator.Commands.Seller_Commands;
using NBP.Application.Mediator.Commands.Sponsor_Commands;
using NBP.Application.Mediator.Commands.Trainer_Commands;
using NBP.Domain.Entities;
using NBP.Domain.Identity;
using System.Web.Http.Results;

namespace NBP.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<Member, MemberNameDto>();

            CreateMap<Administrator, AddAdminCommand>().ReverseMap();
            CreateMap<ManagerS, AddManagerCommand>().ReverseMap();
            CreateMap<Receptionist, AddReceptionistCommand>().ReverseMap();
            CreateMap<Payment, CreatePaymentCommand>().ReverseMap();
            CreateMap<RegistrationRequest, CreateRegistrationRequestCommand>().ReverseMap();
            CreateMap<EmailDto, SendEmailCommand>().ReverseMap();
            CreateMap<Product, AddProductCommand>().ReverseMap();
            CreateMap<Advertisement, AddAdCommand>().ReverseMap();
            CreateMap<CommentDto, AddCommentCommand>().ReverseMap();
            CreateMap<UserData, PostLoginDetailsCommand>().ReverseMap();






            //custom mapiranja
            CreateMap<Administrator, AdminDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<Member, MemberDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<ManagerS, ManagerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<Receptionist, ReceptionistDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<RegistrationRequest, RegistrationRequestDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<TrainerUser, TrainerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ValueDto, UserData>();

            CreateMap<User, UserInfoDto>();

            CreateMap<CommentDto, Comment>();

            CreateMap<Member, MemberByTrainerDto>();

            CreateMap<Payment, PaymentDto>();

        }
    }
}
