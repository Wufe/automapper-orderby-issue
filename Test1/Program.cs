using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Database.EF6;

using DatabaseEntities = Test1.Database.Entities;
using DomainModels = Test1.Domain.Models;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DatabaseEntities.Product, DomainModels.Product>()
                    .ForMember(d => d.Price,
                        o => o.MapFrom(
                            source => source.Articles
                                .Where(
                                    x => x.IsDefault &&
                                        x.NationId == 1 &&
                                        source.ECommercePublished
                                )
                                .FirstOrDefault()
                        )
                    );

                cfg.CreateMap<DatabaseEntities.Article, DomainModels.Price>()
                    .ForMember(d => d.RegionId, o => o.MapFrom(s => s.NationId));
            });


            var firstBuggedQuery = context.Products.OrderBy(x => x.Id).ProjectTo<DomainModels.Product>();

            Console.WriteLine(firstBuggedQuery.ToString());

            Console.ReadKey();
        }
    }
}
