using AutoMapper;

using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.MessageViewModels;
using MenaberManagement.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Mappings
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        { // test
            CreateMap<Message, MessageViewModel>()
                .ForMember(dst => dst.From, opt => opt.MapFrom(x => x.FromUser.UserName))
                .ForMember(dst => dst.Room, opt => opt.MapFrom(x => x.ToRoom.Name))
                .ForMember(dst => dst.Avatar, opt => opt.MapFrom(x => x.FromUser.Avatar))
                .ForMember(dst => dst.Content, opt => opt.MapFrom(x => BasicEmojis.ParseEmojis(x.Content)))
                .ForMember(dst => dst.Timestamp, opt => opt.MapFrom(x => x.Timestamp));
            CreateMap<MessageViewModel, Message>();
        }
    }
}
