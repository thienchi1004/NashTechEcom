using AutoMapper;
using Ecom.Backend.Models;
using Ecom.Backend.Repositories;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public ProductDetailVm GetById(int id)
		{
			var product = _productRepository.GetById(id);

			if(product == null)
			{
				return null;
			}	

			var productVm = _mapper.Map<ProductDetailVm>(product);

			return productVm;
		}

		public List<ProductVm> GetListProduct()
		{
			var product = _productRepository.GetListProduct();

			if (product == null)
			{
				return null;
			}

			var listProductVm = _mapper.Map<List<ProductVm>>(product);

			return listProductVm;
		}

		public List<ProductVm> GetByCategory(int id)
		{
			var product = _productRepository.GetByCategory(id);

			if (product == null)
			{
				return null;
			}

			var listProductVm = _mapper.Map<List<ProductVm>>(product);

			return listProductVm;
		}

		

		public Product Create(ProductCreateVm newProduct)
		{
			var product = _mapper.Map<Product>(newProduct);
			product.RateStar = 0;
			product.CreateDate = DateTime.Now;
			product.UpdateDate = DateTime.Now;

			var result = _productRepository.Create(product);

			if(result == null)
			{
				return null;
			}

			return product;	
		}

		public Product Update(ProductUpdateVm productUp, int id)
		{
			var productExist = _productRepository.GetById(id);
			if (productExist == null)
			{
				throw new Exception("Product not exist with " + productExist.ProductID);
			}

			var product = _mapper.Map<Product>(productUp);
			product.ProductID = id;
			product.UpdateDate = DateTime.Now;
			var result = _productRepository.Update(product);
			return result;


		}

		public List<ProductVm> GetFeatureProducts(int number)
		{
			var product = _productRepository.GetFeatureProducts(number);

			if (product == null)
			{
				return null;
			}

			var listProductFeatuer = _mapper.Map<List<ProductVm>>(product);

			return listProductFeatuer;
		}

		public bool Delete(int id)
		{
			var result = _productRepository.Delete(id);
			return result;
		}
	}
}
