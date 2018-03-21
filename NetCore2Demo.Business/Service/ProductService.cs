using System;
using System.Collections.Generic;
using System.Linq;
using NetCore2Demo.DataRepository.UnitOfWork;
using NetCore2Demo.Entities.Domain;

namespace NetCore2Demo.Business.Service
{
    public class ProductService : IProductService
    {
        #region Constructors

        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Operations

        public bool SaveProduct(Product productItem)
        {
            bool result = false;

            try
            {
                if (productItem != null)
                {
                    var productRepository = unitOfWork.GetRepository<Product>();
                    productRepository.Add(productItem);
                    unitOfWork.Commit();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return result;
        }

        public IList<Product> GetProductList()
        {
            var productRepository = unitOfWork.GetRepository<Product>();
            return productRepository.GetAll().OrderByDescending(x => x.Id).Take(10).ToList();
        }

        #endregion
    }

    public interface IProductService
    {
        bool SaveProduct(Product productItem);
        IList<Product> GetProductList();
    }
}