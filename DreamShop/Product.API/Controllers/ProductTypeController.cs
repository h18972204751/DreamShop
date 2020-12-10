using CommonHelp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Product.API.Data;
using Product.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductTypeController : ControllerBase
    {
        //private readonly ILogger<ProductTypeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ProductDbContext _context;


        public ProductTypeController(IConfiguration configuration, ProductDbContext context)
        {
            this._configuration = configuration;
            this._context = context;
        }

        [HttpGet]
        public async Task<MessageModel<List<ProductType>>> Get()
        {
            var productType =  _context.ProductType.AsQueryable().ToList();
            return new MessageModel<List<ProductType>>() { Msg = "成功!", Success = true, Response = productType };
        }

        /// <summary>
        /// 查询ID=id类型的所有商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<MessageModel<List<Products>>> Get(int id)
        {
            var products = _context.Products.AsQueryable().Where(o=>o.ProductTypeId==id).ToList();
            return new MessageModel<List<Products>>() { Msg = "成功!", Success = true, Response = products };
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<MessageModel<ProductType>> Post([FromForm] ProductType productType)
        {
            var productTypeModel= await _context.ProductType.AddAsync(productType);
            return new MessageModel<ProductType>() { Msg = "成功!", Success = true, Response = productTypeModel.Entity };
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<MessageModel<ProductType>> Put([FromForm] ProductType productType)
        {
            var productTypeModel =_context.ProductType.Update(productType);
            int i=await _context.SaveChangesAsync();
            if(i>0)
                return new MessageModel<ProductType>() { Msg = "成功!", Success = false, Response = productTypeModel.Entity };
            else
                return new MessageModel<ProductType>() { Msg = "失败!", Success = true, Response = productTypeModel.Entity };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        [Authorize]
        public async Task<MessageModel<bool>> Delete(int id)
        {
            if (id<1)
                return new MessageModel<bool>() { Msg = "信息有误,请稍后再试!" };
            var productType = await _context.ProductType.FindAsync(id);
            if (productType==null)
                return new MessageModel<bool>() { Msg = "信息有误,请稍后再试!", Success =false };
            var productTypeModel = _context.ProductType.Remove(productType);
            int i = await _context.SaveChangesAsync();
            return new MessageModel<bool>() { Msg = i > 0?"删除成功!":"删除失败", Success = i > 0, Response =i>0  };
        }

    }
}
