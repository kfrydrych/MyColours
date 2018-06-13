using AutoMapper;
using MyColours.Website.Core.Domain.Products;
using MyColours.Website.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Mappings
{
    public class ProductsMappings : Profile
    {
        public ProductsMappings()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<Product, EditProductViewModel>()
                .ForMember(x => x.Manufacturers, opt => opt.Ignore())
                .ForMember(x => x.ProductTypes, opt => opt.Ignore());

            CreateMap<Transaction, TransactionViewModel>();

            CreateMap<Transaction, TransactionDetailsViewModel>();

            CreateMap<Transaction, CreditNoteFormViewModel>()
                .ForMember(x => x.TransactionId, opt => opt.Ignore())
                .ForMember(x => x.Balance, opt => opt.Ignore())
                .ForMember(x => x.CreditNoteNumber, opt => opt.Ignore())
                .ForMember(x => x.CreditNoteValue, opt => opt.Ignore());

            CreateMap<TransactionLine, TransactionLineModel>();
        }
    }
}