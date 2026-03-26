using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Models;

namespace ERP.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, productDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<productDto, Product>().ForMember(dest => dest.ProductImages, opt => opt.Ignore());
            CreateMap<CreateProductDto, Product>().ForMember(dest => dest.ProductImages, opt => opt.Ignore());
            CreateMap<ProductAttributeDto, ProductAttribute>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductAttributeValueDto,ProductAttributeValue>().ReverseMap();
            CreateMap<Branch,BranchDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<Order,CreateOrderDto>().ReverseMap();
            CreateMap<OrderItem,OrderItemDto>().ReverseMap();
            CreateMap<Supplier,SupplierDto>().ReverseMap();

        }
    }

 }