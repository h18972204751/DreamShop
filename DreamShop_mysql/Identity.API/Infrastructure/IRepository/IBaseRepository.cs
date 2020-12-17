using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.IRepository
{
    public interface IBaseRepository<T>: IDependency where T : class
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(long Id);

        /// <summary>
        /// 按需查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetLintAsunc();
        Task<List<T>> GetLintAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 分页未排序
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(List<T>, int)> GetListAsync(Expression<Func<T, bool>> expression, int? pageIndex, int? pageSize);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<(int, T)> AddAsync(T t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<(int, T)> UpdateAsync(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        Task<int> DeleteAsync(T t);

        Task<int> DeleteAsync(Expression<Func<T, bool>> expression);

        Task<int> DeleteIdAsync(long Id);
    }
}
