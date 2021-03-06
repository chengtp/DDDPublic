﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Develop.Command.Modify;
using DDD.Util.Develop.Domain.Repository.Warehouse;
using DDD.Util.Develop.UnitOfWork;
using DDD.Util.Develop.CQuery;
using DDD.Util.Paging;
using DDD.Util.Develop.Domain.Aggregation;

namespace DDD.Util.Develop.Domain.Repository
{
    /// <summary>
    /// Aggregation repository contract
    /// </summary>
    /// <typeparam name="TModel">Aggregation model</typeparam>
    public interface IAggregationRepository<TModel> where TModel : IAggregationRoot<TModel>
    {
        #region Save data

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        void Save(TModel data, ActivationOption activationOption = null);

        /// <summary>
        /// Save datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        void Save(IEnumerable<TModel> datas, ActivationOption activationOption = null);

        #endregion

        #region Remove data

        /// <summary>
        /// Remove data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        void Remove(TModel data, ActivationOption activationOption = null);

        /// <summary>
        /// Remove datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        void Remove(IEnumerable<TModel> datas, ActivationOption activationOption = null);

        #endregion

        #region Remove by condition

        /// <summary>
        /// Remove data by condition
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        void Remove(IQuery query, ActivationOption activationOption = null);

        #endregion

        #region Modify

        /// <summary>
        /// Modify data
        /// </summary>
        /// <param name="expression">Modify expression</param>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        void Modify(IModify expression, IQuery query, ActivationOption activationOption = null);

        #endregion

        #region Get data

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data</returns>
        TModel Get(IQuery query);

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data</returns>
        Task<TModel> GetAsync(IQuery query);

        #endregion

        #region Get data list

        /// <summary>
        /// Get data list
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data list</returns>
        List<TModel> GetList(IQuery query);

        /// <summary>
        /// Get data list
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data list</returns>
        Task<List<TModel>> GetListAsync(IQuery query);

        #endregion

        #region Get data paging

        /// <summary>
        /// Get data paging
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data paging</returns>
        IPaging<TModel> GetPaging(IQuery query);

        /// <summary>
        /// Get data paging
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data paging</returns>
        Task<IPaging<TModel>> GetPagingAsync(IQuery query);

        #endregion

        #region Exist

        /// <summary>
        /// Exist data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether data is exist</returns>
        bool Exist(IQuery query);

        /// <summary>
        /// Exist data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether data is exist</returns>
        Task<bool> ExistAsync(IQuery query);

        #endregion

        #region Get data count

        /// <summary>
        /// Get data count
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data count</returns>
        long Count(IQuery query);

        /// <summary>
        /// Get data count
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data count</returns>
        Task<long> CountAsync(IQuery query);

        #endregion

        #region Get max value

        /// <summary>
        /// Get max value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        TValue Max<TValue>(IQuery query);

        /// <summary>
        /// Get max value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        Task<TValue> MaxAsync<TValue>(IQuery query);

        #endregion

        #region Get min value

        /// <summary>
        /// Get min value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return min value</returns>
        TValue Min<TValue>(IQuery query);

        /// <summary>
        /// Get min value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return min value</returns>
        Task<TValue> MinAsync<TValue>(IQuery query);

        #endregion

        #region Get sum value

        /// <summary>
        /// Get sum value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the sum value</returns>
        TValue Sum<TValue>(IQuery query);

        /// <summary>
        /// Get sum value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the sum value</returns>
        Task<TValue> SumAsync<TValue>(IQuery query);

        #endregion

        #region Get average value

        /// <summary>
        /// Get average value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the average value</returns>
        TValue Avg<TValue>(IQuery query);

        /// <summary>
        /// Get average value
        /// </summary>
        /// <typeparam name="TValue">Vata type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the average value</returns>
        Task<TValue> AvgAsync<TValue>(IQuery query);

        #endregion

        #region Get life status

        /// <summary>
        /// Get life status
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Return the data life source</returns>
        DataLifeSource GetLifeSource(IAggregationRoot data);

        #endregion

        #region Modify life source

        /// <summary>
        /// Modify life source
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="lifeSource">Life source</param>
        void ModifyLifeSource(IAggregationRoot data, DataLifeSource lifeSource);

        #endregion
    }
}
