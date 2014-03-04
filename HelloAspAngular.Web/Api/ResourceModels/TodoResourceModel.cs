using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloAspAngular.Web.Api.ResourceModels
{
    public class TodoResourceModel
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public string Text { get; set; }
    }
}