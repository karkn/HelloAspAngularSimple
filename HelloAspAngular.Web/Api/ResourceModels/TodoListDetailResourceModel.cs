using HelloAspAngular.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloAspAngular.Web.Api.ResourceModels
{
    public class TodoListDetailResourceModel: TodoListResourceModel
    {
        public IEnumerable<TodoResourceModel> Todos { get; set; }
    }
}