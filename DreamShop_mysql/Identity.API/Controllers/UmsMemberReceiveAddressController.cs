using CommonHelp;
using CommonHelp.Redis;
using Identity.API.Infrastructure.IRepository;
using Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UmsMemberReceiveAddressController : ControllerBase
    {
        readonly IUmsMemberReceiveAddressRepository _umsMemberReceiveAddressRepository;
        readonly IRedisBasketRepository _redis;

        public UmsMemberReceiveAddressController(IUmsMemberReceiveAddressRepository umsMemberReceiveAddressRepository,IRedisBasketRepository redis)
        {
            this._umsMemberReceiveAddressRepository = umsMemberReceiveAddressRepository;
            this._redis = redis;
        }

        /// <summary>
        /// 获取用户个人的地址详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAddress")]
        public async Task<MessageModel<UmsMemberReceiveAddress>> Get(long id)
        {
            //获取用户id
            var memberId = await _redis.GetValue("memberId");
            if (string.IsNullOrWhiteSpace(memberId))
                return new MessageModel<UmsMemberReceiveAddress>() { Msg = "用户信息获取失败，请尝试重新登录!" };
            var address = await _umsMemberReceiveAddressRepository.GetAsync(o => o.MemberId.ToString() == memberId&&o.Id== id);
            return new MessageModel<UmsMemberReceiveAddress>() { Msg = "获取成功", Success = true, Response = address };
        }


        /// <summary>
        /// 获取用户个人的地址列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetListAddress")]
        public async Task<MessageModel<List<UmsMemberReceiveAddress>>> Get()
        {
            //获取用户id
            var memberId =await _redis.GetValue("memberId");
            if (string.IsNullOrWhiteSpace(memberId))
                return new MessageModel<List<UmsMemberReceiveAddress>> () { Msg = "用户信息获取失败，请尝试重新登录!" };
            var address = await _umsMemberReceiveAddressRepository.GetLintAsync(o => o.MemberId.ToString() == memberId);
            return new MessageModel<List<UmsMemberReceiveAddress>> () { Msg = "获取成功",Success=true, Response = address};
        }

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("EditAddress")]
        public async Task<MessageModel<UmsMemberReceiveAddress>> EditAddress([FromForm] UmsMemberReceiveAddress memberAddress)
        {
            //获取用户id
            var memberId = await _redis.GetValue("memberId");
            if (string.IsNullOrWhiteSpace(memberId))
                return new MessageModel<UmsMemberReceiveAddress>() { Msg = "用户信息获取失败，请尝试重新登录!" };
            var model = await _umsMemberReceiveAddressRepository.UpdateAsync(memberAddress);
            return new MessageModel<UmsMemberReceiveAddress>() { Msg = model.Item1>0?"修改成功":"修改失败", Success = model.Item1 > 0 ?true:false, Response = model.Item2 };
        }


        /// <summary>
        /// 添加地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAddress")]
        public async Task<MessageModel<UmsMemberReceiveAddress>> AddAddress([FromForm] UmsMemberReceiveAddress memberAddress)
        {
            if (memberAddress.MemberId < 0)
                return new MessageModel<UmsMemberReceiveAddress>() { Msg = "添加失败,用户信息获取错误" };
            var model = await _umsMemberReceiveAddressRepository.AddAsync(memberAddress);
            return new MessageModel<UmsMemberReceiveAddress>() { Msg = model.Item1 > 0 ? "添加成功" : "添加失败", Success = model.Item1 > 0 ? true : false, Response = model.Item2 };
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteAddress")]
        public async Task<MessageModel<bool>> DeleteAddress(long id)
        {
            var model = await _umsMemberReceiveAddressRepository.DeleteIdAsync(id);
            return new MessageModel<bool>() { Msg = model> 0 ? "删除成功" : "删除失败", Success = model > 0 ? true : false};
        }
    }
}
