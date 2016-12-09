using AutoMapper;
using RealStoriesExposed.Common.Mapping;
using RealStoriesExposed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealStoriesExposed.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}