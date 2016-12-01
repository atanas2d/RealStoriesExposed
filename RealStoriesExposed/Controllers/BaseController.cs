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
        public BaseController()
            :this (new RSEData())
        {

        }

        public BaseController(IRSEData data)
        {
            Data = data;
        }

        protected IRSEData Data {get; private set;}

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}