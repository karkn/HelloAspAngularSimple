using AutoMapper;
using HelloAspAngular.Domain.TodoLists;
using HelloAspAngular.Web.Api.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloAspAngular.Web
{
    public class AutoMapConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<TodoList, TodoListResourceModel>();
            Mapper.CreateMap<TodoList, TodoListDetailResourceModel>();
            Mapper.CreateMap<Todo, TodoResourceModel>();

            Mapper.CreateMap<TodoResourceModel, Todo>().
                ForMember(t => t.TodoListId, opt => opt.Ignore()).
                ForMember(t => t.TodoList, opt => opt.Ignore());
            
            Mapper.AssertConfigurationIsValid();
        }
    }
}