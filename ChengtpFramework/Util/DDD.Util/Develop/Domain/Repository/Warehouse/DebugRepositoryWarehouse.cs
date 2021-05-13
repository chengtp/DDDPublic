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
    /// Debug repository datta warehouses
    /// </summary>
    public class DebugRepositoryWarehouse<TEntity, TDataAccess> : IRepositoryWarehouse<TEntity, TDataAccess> where TEntity : BaseEntity<TEntity>, new() where TDataAccess : IDataAccess<TEntity>
    {
        #region Save

        /// <summary>
        /// Save datas
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        public IActivationRecord Save(IEnumerable<TEntity> datas, ActivationOption activationOption = null)
        {
            if (datas.IsNullOrEmpty())
            {
                return null;
            }
            var packageRecord = DefaultActivationRecord<TEntity, TDataAccess>.CreatePackageRecord();
            foreach (var data in datas)
            {
                var dataRecord = Save(data, activationOption);
                packageRecord.AddFollowRecords(packageRecord);
            }
            return packageRecord;
        }

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        public IActivationRecord Save(TEntity data, ActivationOption activationOption = null)
        {
            WarehouseManager.Save(data);
            var identityValue = data.GetIdentityValue();
            return DefaultActivationRecord<TEntity, TDataAccess>.CreateSaveRecord(identityValue, activationOption);
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove data
        /// </summary>
        /// <param name="datas">Datas</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        public IActivationRecord Remove(IEnumerable<TEntity> datas, ActivationOption activationOption = null)
        {
            if (datas.IsNullOrEmpty())
            {
                return null;
            }
            var packageRecord = DefaultActivationRecord<TEntity, TDataAccess>.CreatePackageRecord();
            foreach (var data in datas)
            {
                var dataRecord = Remove(data, activationOption);
                packageRecord.AddFollowRecords(dataRecord);
            }
            return packageRecord;
        }

        /// <summary>
        /// Remove data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return the activation record</returns>
        public IActivationRecord Remove(TEntity data, ActivationOption activationOption = null)
        {
            WarehouseManager.Save(data);
            var identityValue = data.GetIdentityValue();
            return DefaultActivationRecord<TEntity, TDataAccess>.CreateRemoveObjectRecord(identityValue, activationOption);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return the activation record</returns>
        public IActivationRecord Remove(IQuery query, ActivationOption activationOption = null)
        {
            WarehouseManager.Remove<TEntity>(query);
            var record = DefaultActivationRecord<TEntity, TDataAccess>.CreateRemoveByConditionRecord(query, activationOption);
            return record;
        }

        #endregion

        #region Modify

        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="modifyExpression">Modify expression</param>
        /// <param name="query">Query object</param>
        /// <returns>Return activation record</returns>
        public IActivationRecord Modify(IModify modifyExpression, IQuery query, ActivationOption activationOption = null)
        {
            WarehouseManager.Modify<TEntity>(modifyExpression, query);
            var record = DefaultActivationRecord<TEntity, TDataAccess>.CreateModifyRecord(modifyExpression, query, activationOption);
            return record;
        }

        #endregion

        #region Query

        /// <summary>
        /// Query data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return entity data</returns>
        public async Task<TEntity> GetAsync(IQuery query)
        {
            TEntity data = null;
            data = WarehouseManager.Merge(data, query);
            return await Task.FromResult(data).ConfigureAwait(false);
        }

        /// <summary>
        /// Query data list
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data list</returns>
        public async Task<List<TEntity>> GetListAsync(IQuery query)
        {
            var datas = new List<TEntity>(0);
            datas = WarehouseManager.Merge(datas, query);
            return await Task.FromResult(datas).ConfigureAwait(false);
        }

        /// <summary>
        /// Query data paging
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data paging</returns>
        public async Task<IPaging<TEntity>> GetPagingAsync(IQuery query)
        {
            var paging = Pager.Empty<TEntity>();
            paging = WarehouseManager.MergePaging(paging, query);
            return await Task.FromResult(paging).ConfigureAwait(false);
        }

        /// <summary>
        /// Exist data
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return whether has data</returns>
        public async Task<bool> ExistAsync(IQuery query)
        {
            var result = WarehouseManager.Exist<TEntity>(query);
            var isExist = result.IsExist;
            return await Task.FromResult(isExist).ConfigureAwait(false); ;
        }

        /// <summary>
        /// Get data count
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>Return data count</returns>
        public async Task<long> CountAsync(IQuery query)
        {
            long allCount = 0;
            var countResult = WarehouseManager.Count<TEntity>(query);
            allCount = allCount - countResult.PersistentDataCount + countResult.NewDataCount;
            return await Task.FromResult(allCount).ConfigureAwait(false);
        }

        /// <summary>
        /// Get max value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the max value</returns>
        public async Task<TValue> MaxAsync<TValue>(IQuery query)
        {
            var maxResult = WarehouseManager.Max<TEntity, TValue>(query);
            dynamic resultVal = maxResult.Value;
            return await Task.FromResult(resultVal).ConfigureAwait(false);
        }

        /// <summary>
        /// Get min value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the min value</returns>
        public async Task<TValue> MinAsync<TValue>(IQuery query)
        {
            var minResult = WarehouseManager.Min<TEntity, TValue>(query);
            dynamic resultVal = minResult.Value;
            return await Task.FromResult(resultVal).ConfigureAwait(false);
        }

        /// <summary>
        /// Get sum value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the sum value</returns>
        public async Task<TValue> SumAsync<TValue>(IQuery query)
        {
            var sumResult = WarehouseManager.Sum<TEntity, TValue>(query);
            dynamic resultVal = sumResult.Value;
            return await Task.FromResult(resultVal).ConfigureAwait(false);
        }

        /// <summary>
        /// Get average value
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="query">Query object</param>
        /// <returns>Return the average value</returns>
        public async Task<TValue> AvgAsync<TValue>(IQuery query)
        {
            dynamic sum = await SumAsync<TValue>(query).ConfigureAwait(false);
            var count = await CountAsync(query).ConfigureAwait(false);
            return sum / count;
        }

        #endregion

        #region Life source

        /// <summary>
        /// Get life source
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Return data life source</returns>
        public DataLifeSource GetLifeSource(TEntity data)
        {
            if (data == null)
            {
                return DataLifeSource.New;
            }
            return WarehouseManager.GetLifeSource(data);
        }

        /// <summary>
        /// Modify life status
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="lifeSource">Life source</param>
        public void ModifyLifeSource(TEntity data, DataLifeSource lifeSource)
        {
            WarehouseManager.ModifyLifeSource(data, lifeSource);
        }

        #endregion
    }
}
