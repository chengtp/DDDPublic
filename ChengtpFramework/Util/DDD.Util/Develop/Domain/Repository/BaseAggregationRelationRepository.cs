using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.DataAccess;
using DDD.Util.Develop.Domain.Aggregation;
using DDD.Util.Develop.Entity;
using DDD.Util.Develop.UnitOfWork;

namespace DDD.Util.Develop.Domain.Repository
{
    /// <summary>
    /// Base aggregation relation repository
    /// </summary>
    /// <typeparam name="TModel">Aggregation model type</typeparam>
    /// <typeparam name="TFirstRelationModel">The first relation model type</typeparam>
    /// <typeparam name="TSecondRelationModel">The second relation model type</typeparam>
    /// <typeparam name="TEntity">The entity type</typeparam>
    /// <typeparam name="TDataAccess">The data access</typeparam>
    public abstract class BaseAggregationRelationRepository<TModel, TFirstRelationModel, TSecondRelationModel, TEntity, TDataAccess> : DefaultAggregationRepository<TModel, TEntity, TDataAccess> where TModel : IAggregationRoot<TModel> where TEntity : BaseEntity<TEntity>, new() where TDataAccess : IDataAccess<TEntity>
    {
        #region Query

        /// <summary>
        /// Get list by first
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        public abstract List<TModel> GetListByFirst(IEnumerable<TFirstRelationModel> datas);

        /// <summary>
        /// Get list by first
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        public abstract Task<List<TModel>> GetListByFirstAsync(IEnumerable<TFirstRelationModel> datas);

        /// <summary>
        /// Get list by second
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        public abstract List<TModel> GetListBySecond(IEnumerable<TSecondRelationModel> datas);

        /// <summary>
        /// Get list by second
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        public abstract Task<List<TModel>> GetListBySecondAsync(IEnumerable<TSecondRelationModel> datas);

        #endregion

        #region Remove

        /// <summary>
        /// Remove by first datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void RemoveByFirst(IEnumerable<TFirstRelationModel> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by second datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void RemoveBySecond(IEnumerable<TSecondRelationModel> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by first
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void RemoveByFirst(IQuery query, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by second
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void RemoveBySecond(IQuery query, ActivationOption activationOption = null);

        #endregion
    }
}
