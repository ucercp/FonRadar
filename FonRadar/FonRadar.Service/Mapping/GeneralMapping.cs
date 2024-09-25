using AutoMapper;
using FonRadar.DTOs.InvoceDto;
using FonRadar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Mapping
{
    public class GeneralMapping : Profile
    {


        public GeneralMapping()
        {
            CreateMap<Invoice, ResultInvoiceDto>().ReverseMap();
            CreateMap<Invoice, GetByIdInvoiceDto>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceDto>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceDto>().ReverseMap();
     
        }

    }
}
