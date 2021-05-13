﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Develop.Command.Modify;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.DataAccess;
using DDD.Util.Develop.Entity;
using DDD.Util.Develop.UnitOfWork;
using DDD.Util.Paging;

namespace DDD.Util.Develop.Domain.Repository.Warehouse
{
    /// <summary>
    /// Repository data warehouse contract
    /// </summary>
    public interface IRepositoryWarehouse<TEntity, TDataAccess> where TEntity : BaseEntity<TEntity>, new() where TDataAccess : IDataAccess<TEntity>
    {
        #region Save

        /// <summary>
        /// Save datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        IActivationRecord Save(IEnumerable<TEntity> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        IActivationRecord Save(TEntity data, ActivationOption activationOption = null);

        #endregion

        #region Remove

        /// <summary>
        /// Remove datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        IActivationRecord Remove(IEnumerable<TEntity> datas, ActivationOption activationOption = null);

        /// <summary>
        /// Remove data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        IActivationRecord Remove(TEntity data, ActivationOption activationOption = null);

        /// <summary>
        /// Remove by condition
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        IActivationRecord Remove(IQuery query, ActivationOption activationOption = null);

        #endregion

        #region Modify

        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="modifyExpression">Modify expression</param>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        IActivationRecord Modify(IModify modifyExpression, IQuery query, ActivationOption activationOption = null);

        #endregion

        #region Query

        /// <summary>
        /// Query data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data</returns>
        Task<TEntity> GetAsync(IQuery query);

        /// <summary>
        /// Query data list
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data list</returns>
        Task<List<TEntity>> GetListAsync(IQuery query);

        /// <summary>
        /// Query data paging
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data paging</returns>
        Task<IPaging<TEntity>> GetPagingAsync(IQuery query);

        /// <summary>
        /// Exist data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether data is exist</returns>
        Task<bool> ExistAsync(IQuery query);

        /// <summary>
        /// Get data count
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether data is exist</returns>
        Task<long> CountAsync(IQuery query);

        /// <summary>
        /// Get Max Value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        Task<TValue> MaxAsync<TValue>(IQuery query);

        /// <summary>
        /// Get min value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        Task<TValue> MinAsync<TValue>(IQuery query);

        /// <summary>
        /// Get Sum Value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the sum value</returns>
        Task<TValue> SumAsync<TValue>(IQuery query);

        /// <summary>
        /// Get Average Value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the average value</returns>
        Task<TValue> AvgAsync<TValue>(IQuery query);

        #endregion

        #region Life source

        /// <summary>
        /// Get life source
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Return the activation record</returns>
        DataLifeSource GetLifeSource(TEntity data);

        /// <summary>
        /// Modify life source
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="lifeSource">Life source</param>
        void ModifyLifeSource(TEntity data, DataLifeSource lifeSource);

        #endregion
    }
}
