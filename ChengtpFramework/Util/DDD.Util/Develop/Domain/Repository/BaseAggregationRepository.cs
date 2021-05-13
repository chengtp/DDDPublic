﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Develop.Command.Modify;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.Domain.Aggregation;
using DDD.Util.Develop.Domain.Repository.Warehouse;
using DDD.Util.Develop.UnitOfWork;
using DDD.Util.Paging;

namespace DDD.Util.Develop.Domain.Repository
{
    /// <summary>
    /// Base aggregation repository
    /// </summary>
    public abstract class BaseAggregationRepository<TModel>
    {
        #region Save data

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void Save(TModel data, ActivationOption activationOption = null);

        /// <summary>
        /// save datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void Save(IEnumerable<TModel> datas, ActivationOption activationOption = null);

        #endregion

        #region Remove data

        /// <summary>
        /// Remove data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void Remove(TModel data, ActivationOption activationOption = null);

        /// <summary>
        /// Remove datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void Remove(IEnumerable<TModel> datas, ActivationOption activationOption = null);

        #endregion

        #region Remove by condition

        /// <summary>
        /// Remove data by condition
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void Remove(IQuery query, ActivationOption activationOption = null);

        #endregion

        #region Modify

        /// <summary>
        /// Modify data
        /// </summary>
        /// <param name="expression">Modify expression</param>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        public abstract void Modify(IModify expression, IQuery query, ActivationOption activationOption = null);

        #endregion

        #region Get data

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data</returns>
        public abstract TModel Get(IQuery query);

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data</returns>
        public abstract Task<TModel> GetAsync(IQuery query);

        #endregion

        #region Get data list

        /// <summary>
        /// Get data list
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data list</returns>
        public abstract List<TModel> GetList(IQuery query);

        /// <summary>
        /// Get data list
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data list</returns>
        public abstract Task<List<TModel>> GetListAsync(IQuery query);

        #endregion

        #region Get data paging

        /// <summary>
        /// Get data paging
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data paging</returns>
        public abstract IPaging<TModel> GetPaging(IQuery query);

        /// <summary>
        /// Get data paging
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data paging</returns>
        public abstract Task<IPaging<TModel>> GetPagingAsync(IQuery query);

        #endregion

        #region Exist

        /// <summary>
        /// Exist data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether data is exist</returns>
        public abstract bool Exist(IQuery query);

        /// <summary>
        /// Exist data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether data is exist</returns>
        public abstract Task<bool> ExistAsync(IQuery query);

        #endregion

        #region Get data count

        /// <summary>
        /// Get data count
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data count</returns>
        public abstract long Count(IQuery query);

        /// <summary>
        /// Get data count
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data count</returns>
        public abstract Task<long> CountAsync(IQuery query);

        #endregion

        #region Get max value

        /// <summary>
        /// Get max value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        public abstract TValue Max<TValue>(IQuery query);

        /// <summary>
        /// Get max value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        public abstract Task<TValue> MaxAsync<TValue>(IQuery query);

        #endregion

        #region Get min value

        /// <summary>
        /// Get min value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the min value</returns>
        public abstract TValue Min<TValue>(IQuery query);

        /// <summary>
        /// Get min value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the min value</returns>
        public abstract Task<TValue> MinAsync<TValue>(IQuery query);

        #endregion

        #region get sum value

        /// <summary>
        /// Get sum value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the sum value</returns>
        public abstract TValue Sum<TValue>(IQuery query);

        /// <summary>
        /// Get sum value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the sum value</returns>
        public abstract Task<TValue> SumAsync<TValue>(IQuery query);

        #endregion

        #region Get average value

        /// <summary>
        /// Get average value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the average value</returns>
        public abstract TValue Avg<TValue>(IQuery query);

        /// <summary>
        /// Get average value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the average value</returns>
        public abstract Task<TValue> AvgAsync<TValue>(IQuery query);

        #endregion

        #region Get life status

        /// <summary>
        /// Get life status
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Return the data life source</returns>
        public abstract DataLifeSource GetLifeSource(IAggregationRoot data);

        #endregion

        #region Modify life source

        /// <summary>
        /// Modify life source
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="lifeSource">Life source</param>
        public abstract void ModifyLifeSource(IAggregationRoot data, DataLifeSource lifeSource);

        #endregion
    }
}
