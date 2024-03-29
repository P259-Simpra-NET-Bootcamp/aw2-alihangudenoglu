﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver
{
    public static class RepositoryResolver
    {
        public static void AddRepositoryResolver(this IServiceCollection services)
        {
            services.AddScoped<IStaffService, StaffManager>();
            services.AddScoped<IStaffDal, EfStaffDal>();
        }
    }
}
