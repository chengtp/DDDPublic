﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.Domain.Aggregation;
using DDD.Util.Develop.UnitOfWork;

namespace DDD.Util.Develop.Domain.Repository
{
    /// <summary>
    /// Aggregation relation repository contract
    /// </summary>
    /// <typeparam name="TModel">Aggregation model</typeparam>
    /// <typeparam name="TFirstRelationModel">The first relation model</typeparam>
    /// <typeparam name="TSecondRelationModel">The second relation model</typeparam>
    public interface IAggregationRelationRepository<TModel, TFirstRelationModel, TSecondRelationModel> : IAggregationRepository<TModel> where TModel : IAggregationRoot<TModel> where TSecondRelationModel : IAggregationRoot<TSecondRelationModel> where TFirstRelationModel : IAggregationRoot<TFirstRelationModel>
    {
        #region Query

        /// <summary>
        /// Get list by first
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        List<TModel> GetListByFirst(IEnumerable<TFirstRelationModel> datas);

        /// <summary>
        /// Get list by first
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        Task<List<TModel>> GetListByFirstAsync(IEnumerable<TFirstRelationModel> datas);

        /// <summary>
        /// Get list by second
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        List<TModel> GetListBySecond(IEnumerable<TSecondRelationModel> datas);

        /// <summary>
        /// Get list by second
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <returns>Return datas</returns>
        Task<List<TModel>> GetListBySecondAsync(IEnumerable<TSecondRelationModel> datas);

        #endregion

        #region Remove

        /// <summary>
        /// Remove by first datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        void RemoveByFirst(IEnumerable<TFirstRelationModel> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by second datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        void RemoveBySecond(IEnumerable<TSecondRelationModel> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by first
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        void RemoveByFirst(IQuery query, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by second
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        void RemoveBySecond(IQuery query, ActivationOption activationOption = null);

        #endregion
    }
}
