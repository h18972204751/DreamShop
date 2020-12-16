using Identity.API.Infrastructure.IRepository;
using Identity.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.Repository
{
    public class BaseRepository<T> : DreamShopUserAdminContext, IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = null;

        public BaseRepository(DbContextOptions<DreamShopUserAdminContext> options) : base(options)
        {
            this._dbSet = base.Set<T>();
        }



        //非跟踪查询
        //在只读方案中使用结果时，非跟踪查询十分有用。 可以更快速地执行非跟踪查询，因为无需设置更改跟踪信息。 如果不需要更新从数据库中检索到的实体，则应使用非跟踪查询。 可以将单个查询替换为非跟踪查询。

        /// <summary>
        /// 获取 <typeparamref name="TEntity"/> 不跟踪数据更改（NoTracking）的查询数据源
        /// </summary>
        public virtual IQueryable<T> Entities => _dbSet.AsNoTracking();

        /// <summary>
        /// 获取 <typeparamref name="TEntity"/> 跟踪数据更改（Tracking）的查询数据源
        /// </summary>
        public virtual IQueryable<T> TrackEntities => _dbSet;



        #region  查询

        /// <summary>
        /// 异步根据ID查询数据
        /// </summary>
        /// <param name="object Id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(long Id) => await _dbSet.FindAsync(Id);

        /// <summary>
        /// 按需查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetLintAsunc()
        {
            return await _dbSet.AsQueryable().ToListAsync();
        }


        /// <summary>
        /// 按需查询列表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetLintAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">一页多少条</param>
        /// <returns></returns>
        public virtual async Task<(List<T>, int)> GetListAsync(Expression<Func<T, bool>> expression, int? pageIndex, int? pageSize)
        {
            var query = _dbSet.AsQueryable().Where(expression);
            var count = query.Count();
            if (count == 0)
                return (new List<T>(), 0);
            if (pageIndex.HasValue)
            {
                pageIndex = pageIndex.Value > 0 ? pageIndex : 1;
                pageSize = pageSize.Value > 0 ? pageSize : 15;
                query = query.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return (await query.ToListAsync(), count);
        }


        #endregion


        #region 添加
        /// <summary>
        /// 根据实体异步添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(T t)
        {
            if (t != null)
            {
                await _dbSet.AddAsync(t);
                return await base.SaveChangesAsync();
            }
            return 0;
        }

        /// <summary>
        /// 根据实体异步批量添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<int> AddRangeAsync(T[] t)
        {
            if (t != null && t.Count() > 0)
            {
                await _dbSet.AddRangeAsync(t);
                return await base.SaveChangesAsync();
            }
            return 0;
        }


        #endregion


        #region 修改

        public async Task<int> UpdateAsync(T t)
        {
            if (t != null)
            {
                _dbSet.Update(t);
                return await base.SaveChangesAsync();
            }
            return 0;

        }

        #endregion

        #region 删除
        /// <summary>
        /// 异步根据ID删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<int> DeleteIdAsync(long Id)
        {

            if (Id > 0)
            {
                T t = await this.GetByIdAsync(Id);
                _dbSet.Remove(t);
                return await base.SaveChangesAsync();
            }
            return 0;
        }

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(T t)
        {

            if (t != null)
            {
                _dbSet.Remove(t);
                return await base.SaveChangesAsync();
            }
            return 0;
        }
        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = _dbSet.Where(expression);
            base.Remove(entity);
            return await base.SaveChangesAsync();
        }

        #endregion
    }
}
