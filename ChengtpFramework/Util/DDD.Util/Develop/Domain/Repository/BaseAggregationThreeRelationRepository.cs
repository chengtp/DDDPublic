﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.DataAccess;
using DDD.Util.Develop.Domain.Aggregation;
using DDD.Util.Develop.Entity;
using DDD.Util.Develop.UnitOfWork;

namespace DDD.Util.Develop.Domain.Repository
{
    /// <summary>
    /// Base aggregation three relation repository
    /// </summary>
    /// <typeparam name="TModel">Aggregation model</typeparam>
    /// <typeparam name="TFirstRelationModel">The first relation model</typeparam>
    /// <typeparam name="TSecondRelationModel">The second relation model</typeparam>
    /// <typeparam name="TThirdRelationModel">The third relation model</typeparam>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDataAccess">Data access</typeparam>
    public abstract class BaseAggregationThreeRelationRepository<TModel, TFirstRelationModel, TSecondRelationModel, TThirdRelationModel, TEntity, TDataAccess> : DefaultAggregationRepository<TModel, TEntity, TDataAccess> where TModel : IAggregationRoot<TModel> where TEntity : BaseEntity<TEntity>, new() where TDataAccess : IDataAccess<TEntity>
    {
        #region Query

        /// <summary>
        /// Get list by first
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return data list</returns>
        public abstract List<TModel> GetListByFirst(IEnumerable<TFirstRelationModel> datas);

        /// <summary>
        /// Get list by first
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return data list</returns>
        public abstract Task<List<TModel>> GetListByFirstAsync(IEnumerable<TFirstRelationModel> datas);

        /// <summary>
        /// Get list by second
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return data list</returns>
        public abstract List<TModel> GetListBySecond(IEnumerable<TSecondRelationModel> datas);

        /// <summary>
        /// Get list by second
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return data list</returns>
        public abstract Task<List<TModel>> GetListBySecondAsync(IEnumerable<TSecondRelationModel> datas);

        /// <summary>
        /// Get list by third
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return data list</returns>
        public abstract List<TModel> GetListByThird(IEnumerable<TThirdRelationModel> datas);

        /// <summary>
        /// Get list by third
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return data list</returns>
        public abstract Task<List<TModel>> GetListByThirdAsync(IEnumerable<TThirdRelationModel> datas);

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
        /// <<param name="activationOption">Activation option</param>
        public abstract void RemoveBySecond(IEnumerable<TSecondRelationModel> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by third datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void RemoveByThird(IEnumerable<TThirdRelationModel> datas, ActivationOption activationOption = null);

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

        /// <summary>
        /// Remove by third
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void RemoveByThird(IQuery query, ActivationOption activationOption = null);

        #endregion
    }
}
