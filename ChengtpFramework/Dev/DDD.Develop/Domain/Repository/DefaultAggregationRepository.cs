﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Develop.CQuery;
using DDD.Util.Paging;
using DDD.Develop.Domain.Aggregation;
using DDD.Util.Extension;
using DDD.Develop.Entity;
using DDD.Util.IoC;
using DDD.Util;
using DDD.Develop.DataAccess;
using DDD.Develop.Domain.Repository.Warehouse;
using DDD.Develop.UnitOfWork;
using DDD.Develop.Command.Modify;
using DDD.Develop.Domain.Repository.Event;

namespace DDD.Develop.Domain.Repository
{
    /// <summary>
    /// Default Repository
    /// </summary>
    public abstract class DefaultAggregationRepository<DT, ET, DAI> : DefaultAggregationRootRepository<DT> where DT : IAggregationRoot<DT> where ET : BaseEntity<ET>, new() where DAI : IDataAccess<ET>
    {
        protected IRepositoryWarehouse<ET, DAI> repositoryWarehouse = ContainerManager.Resolve<IRepositoryWarehouse<ET, DAI>>();
        static Type entityType = typeof(ET);

        static DefaultAggregationRepository()
        {
            WarehouseManager.RegisterDefaultWarehouse<ET, DAI>();
        }

        #region impl

        /// <summary>
        /// get life source
        /// </summary>
        /// <param name="data">data</param>
        /// <returns></returns>
        public sealed override DataLifeSource GetLifeSource(IAggregationRoot data)
        {
            if (data == null)
            {
                return DataLifeSource.New;
            }
            return repositoryWarehouse.GetLifeSource(data.MapTo<ET>());
        }

        /// <summary>
        /// modify life source
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="lifeSource">life source</param>
        public sealed override void ModifyLifeSource(IAggregationRoot data, DataLifeSource lifeSource)
        {
            if (data == null)
            {
                return;
            }
            repositoryWarehouse.ModifyLifeSource(data.MapTo<ET>(), lifeSource);
        }

        #endregion

        #region function

        /// <summary>
        /// execute save
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected override async Task<IActivationRecord> ExecuteSaveAsync(DT data, ActivationOption activationOption = null)
        {
            var entity = data?.MapTo<ET>();
            return await SaveEntityAsync(entity, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// execute remove
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected override async Task<IActivationRecord> ExecuteRemoveAsync(DT data, ActivationOption activationOption = null)
        {
            if (data == null)
            {
                return null;
            }
            var entity = data.MapTo<ET>();
            return await RemoveEntityAsync(entity, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// execute remove
        /// </summary>
        /// <param name="query">query object</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected override async Task<IActivationRecord> ExecuteRemoveAsync(IQuery query, ActivationOption activationOption = null)
        {
            return await repositoryWarehouse.RemoveAsync(query, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// get data
        /// </summary>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<DT> GetDataAsync(IQuery query)
        {
            var entityData = await repositoryWarehouse.GetAsync(query).ConfigureAwait(false);
            DT data = default;
            if (entityData != null)
            {
                data = entityData.MapTo<DT>();
            }
            return data;
        }

        /// <summary>
        /// get data list
        /// </summary>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<List<DT>> GetDataListAsync(IQuery query)
        {
            var entityDataList = await repositoryWarehouse.GetListAsync(query).ConfigureAwait(false);
            if (entityDataList.IsNullOrEmpty())
            {
                return new List<DT>(0);
            }
            var datas = entityDataList.Select(c => c.MapTo<DT>());
            return datas.ToList();
        }

        /// <summary>
        /// get object paging
        /// </summary>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<IPaging<DT>> GetDataPagingAsync(IQuery query)
        {
            var entityPaging = await repositoryWarehouse.GetPagingAsync(query).ConfigureAwait(false);
            var dataPaging = entityPaging.ConvertTo<DT>();
            return dataPaging;
        }

        /// <summary>
        /// check data
        /// </summary>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<bool> IsExistAsync(IQuery query)
        {
            return await repositoryWarehouse.ExistAsync(query).ConfigureAwait(false);
        }

        /// <summary>
        /// get data count
        /// </summary>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<long> CountValueAsync(IQuery query)
        {
            return await repositoryWarehouse.CountAsync(query).ConfigureAwait(false);
        }

        /// <summary>
        /// get max value
        /// </summary>
        /// <typeparam name="VT">Data Type</typeparam>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<VT> MaxValueAsync<VT>(IQuery query)
        {
            return await repositoryWarehouse.MaxAsync<VT>(query).ConfigureAwait(false);
        }

        /// <summary>
        /// get min value
        /// </summary>
        /// <typeparam name="VT">DataType</typeparam>
        /// <param name="query">query object</param>
        /// <returns>min value</returns>
        protected override async Task<VT> MinValueAsync<VT>(IQuery query)
        {
            return await repositoryWarehouse.MinAsync<VT>(query).ConfigureAwait(false);
        }

        /// <summary>
        /// get sum value
        /// </summary>
        /// <typeparam name="VT">DataType</typeparam>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<VT> SumValueAsync<VT>(IQuery query)
        {
            return await repositoryWarehouse.SumAsync<VT>(query).ConfigureAwait(false);
        }

        /// <summary>
        /// get average value
        /// </summary>
        /// <typeparam name="VT">DataType</typeparam>
        /// <param name="query">query object</param>
        /// <returns></returns>
        protected override async Task<VT> AvgValueAsync<VT>(IQuery query)
        {
            return await repositoryWarehouse.AvgAsync<VT>(query).ConfigureAwait(false);
        }

        /// <summary>
        /// execute modify
        /// </summary>
        /// <param name="expression">modify expression</param>
        /// <param name="query">query object</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected override async Task<IActivationRecord> ExecuteModifyAsync(IModify expression, IQuery query, ActivationOption activationOption = null)
        {
            return await repositoryWarehouse.ModifyAsync(expression, query, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// save entity
        /// </summary>
        /// <param name="datas">datas</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected virtual async Task<IActivationRecord> SaveEntityAsync(IEnumerable<ET> datas, ActivationOption activationOption = null)
        {
            return await repositoryWarehouse.SaveAsync(datas, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// save entity
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected virtual async Task<IActivationRecord> SaveEntityAsync(ET data, ActivationOption activationOption = null)
        {
            return await repositoryWarehouse.SaveAsync(data, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// save entity
        /// </summary>
        /// <param name="datas">datas</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected virtual void SaveEntity(IEnumerable<ET> datas, ActivationOption activationOption = null)
        {
            var record = SaveEntityAsync(datas, activationOption).Result;
            if (record != null)
            {
                WorkFactory.RegisterActivationRecord(record);
            }
        }

        /// <summary>
        /// remove entitys
        /// </summary>
        /// <param name="datas">datas</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected virtual async Task<IActivationRecord> RemoveEntityAsync(IEnumerable<ET> datas, ActivationOption activationOption = null)
        {
            return await repositoryWarehouse.RemoveAsync(datas, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// remove entity
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected virtual async Task<IActivationRecord> RemoveEntityAsync(ET data, ActivationOption activationOption = null)
        {
            return await repositoryWarehouse.RemoveAsync(data, activationOption).ConfigureAwait(false);
        }

        /// <summary>
        /// remove entitys
        /// </summary>
        /// <param name="datas">datas</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        protected virtual void RemoveEntity(IEnumerable<ET> datas, ActivationOption activationOption = null)
        {
            var record = RemoveEntityAsync(datas, activationOption).Result;
            if (record != null)
            {
                WorkFactory.RegisterActivationRecord(record);
            }
        }

        #endregion

        #region global condition

        #region append repository condition

        /// <summary>
        /// append repository condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        IQuery AppendRepositoryCondition(IQuery originalQuery, QueryUsageScene usageScene)
        {
            if (originalQuery == null)
            {
                originalQuery = QueryFactory.Create();
                originalQuery.SetEntityType(entityType);
            }
            else
            {
                originalQuery.SetEntityType(entityType);
            }

            //primary query
            GlobalConditionFilter conditionFilter = new GlobalConditionFilter()
            {
                OriginalQuery = originalQuery,
                UsageSceneEntityType = entityType,
                EntityType = entityType,
                SourceType = QuerySourceType.Repository,
                UsageScene = usageScene
            };
            var conditionFilterResult = QueryFactory.GlobalConditionFilter(conditionFilter);
            if (conditionFilterResult != null)
            {
                conditionFilterResult.AppendTo(originalQuery);
            }
            //subqueries
            if (!originalQuery.Subqueries.IsNullOrEmpty())
            {
                foreach (var squery in originalQuery.Subqueries)
                {
                    AppendSubqueryCondition(squery, conditionFilter);
                }
            }
            //join
            if (!originalQuery.JoinItems.IsNullOrEmpty())
            {
                foreach (var jitem in originalQuery.JoinItems)
                {
                    AppendJoinQueryCondition(jitem.JoinQuery, conditionFilter);
                }
            }
            return originalQuery;
        }

        #endregion

        #region append subqueries condition

        /// <summary>
        /// append subqueries condition
        /// </summary>
        /// <param name="subquery">subquery</param>
        /// <param name="conditionFilter">condition filter</param>
        void AppendSubqueryCondition(IQuery subquery, GlobalConditionFilter conditionFilter)
        {
            if (subquery == null)
            {
                return;
            }
            conditionFilter.SourceType = QuerySourceType.Subuery;
            conditionFilter.EntityType = subquery.GetEntityType();
            conditionFilter.OriginalQuery = subquery;
            var conditionFilterResult = QueryFactory.GlobalConditionFilter(conditionFilter);
            if (conditionFilterResult != null)
            {
                conditionFilterResult.AppendTo(subquery);
            }
            //subqueries
            if (!subquery.Subqueries.IsNullOrEmpty())
            {
                foreach (var squery in subquery.Subqueries)
                {
                    AppendSubqueryCondition(squery, conditionFilter);
                }
            }
            //join
            if (!subquery.JoinItems.IsNullOrEmpty())
            {
                foreach (var jitem in subquery.JoinItems)
                {
                    AppendJoinQueryCondition(jitem.JoinQuery, conditionFilter);
                }
            }
        }

        #endregion

        #region append join condition

        /// <summary>
        /// append join query condition
        /// </summary>
        /// <param name="joinQuery">join query</param>
        /// <param name="conditionFilter">condition filter</param>
        void AppendJoinQueryCondition(IQuery joinQuery, GlobalConditionFilter conditionFilter)
        {
            if (joinQuery == null)
            {
                return;
            }
            conditionFilter.SourceType = QuerySourceType.JoinQuery;
            conditionFilter.EntityType = joinQuery.GetEntityType();
            conditionFilter.OriginalQuery = joinQuery;
            var conditionFilterResult = QueryFactory.GlobalConditionFilter(conditionFilter);
            if (conditionFilterResult != null)
            {
                conditionFilterResult.AppendTo(joinQuery);
            }
            //subqueries
            if (!joinQuery.Subqueries.IsNullOrEmpty())
            {
                foreach (var squery in joinQuery.Subqueries)
                {
                    AppendSubqueryCondition(squery, conditionFilter);
                }
            }
            //join query
            if (!joinQuery.JoinItems.IsNullOrEmpty())
            {
                foreach (var jitem in joinQuery.JoinItems)
                {
                    AppendJoinQueryCondition(jitem.JoinQuery, conditionFilter);
                }
            }
        }

        #endregion

        #region append remove extra condition

        /// <summary>
        /// append remove condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendRemoveCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Remove);
        }

        #endregion

        #region append modify extra condition

        /// <summary>
        /// append modify condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendModifyCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Modify);
        }

        #endregion

        #region append query extra condition

        /// <summary>
        /// append query condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendQueryCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Query);
        }

        #endregion

        #region append exist extra condition

        /// <summary>
        /// append exist condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendExistCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Exist);
        }

        #endregion

        #region append count extra condition

        /// <summary>
        /// append count condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendCountCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Count);
        }

        #endregion

        #region append max extra condition

        /// <summary>
        /// append max condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendMaxCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Max);
        }

        #endregion

        #region append min extra condition

        /// <summary>
        /// append min condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendMinCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Min);
        }

        #endregion

        #region append sum extra condition

        /// <summary>
        /// append sum condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendSumCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Sum);
        }

        #endregion

        #region append avg extra condition

        /// <summary>
        /// append avg condition
        /// </summary>
        /// <param name="originalQuery">original query</param>
        /// <returns></returns>
        protected override IQuery AppendAvgCondition(IQuery originalQuery)
        {
            return AppendRepositoryCondition(originalQuery, QueryUsageScene.Avg);
        }

        #endregion

        #endregion
    }
}
