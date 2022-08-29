using AutoMapper;
using Doman.Model;
using Ui_Layer.Models;

namespace Ui_Layer.View_Model_Mapper
{
    public class ProfileMap:Profile

    {
        public ProfileMap()
        {
            CreateMap<Items, ItemView>();
            CreateMap<Customer, CustomerView>();
            CreateMap<OrderH, OrderHView>()
                .ForMember(d => d.OrderD, s => s.MapFrom(s => s.OrderD))
                .ForMember(d=>d.Customer,s=>s.MapFrom(s=>s.Customer));
        }
    }
}
