﻿using System;
using System.Collections.Generic;
using DDD.Util.Develop.Command;
using DDD.Util.Develop.Command.Modify;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.DataAccess;
using DDD.Util.Develop.Domain.Repository.Warehouse;
using DDD.Util.Develop.Entity;
using DDD.Util.Fault;
using DDD.Util.DependencyInjection;

namespace DDD.Util.Develop.UnitOfWork
{
    /// <summary>
    /// Default activation record
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TDataAccess">Data access</typeparam>
    public class DefaultActivationRecord<TEntity, TDataAccess> : IActivationRecord where TEntity : BaseEntity<TEntity>, new() where TDataAccess : IDataAccess<TEntity>
    {
        /// <summary>
        /// Gets or sets the record id
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the parent record
        /// </summary>
        public IActivationRecord ParentRecord
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the activation operation
        /// </summary>
        public ActivationOperation Operation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the identity value
        /// </summary>
        public string IdentityValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the query object
        /// </summary>
        public IQuery Query
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the modify expression
        /// </summary>
        public IModify ModifyExpression
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets follow records
        /// </summary>
        private List<IActivationRecord> FollowRecords
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the data access service
        /// </summary>
        public Type DataAccessService
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the entity type
        /// </summary>
        public Type EntityType
        {
            get; set;
        }

        /// <summary>
        /// Gets whether the record is obsolete
        /// </summary>
        public bool IsObsolete { get; private set; }

        /// <summary>
        /// Gets the record identity
        /// </summary>
        public string RecordIdentity
        {
            get; private set;
        }

        /// <summary>
        /// Gets the activation option
        /// </summary>
        public ActivationOption ActivationOption
        {
            get;
            private set;
        }

        private DefaultActivationRecord()
        { }

        /// <summary>
        /// Create a activation record
        /// </summary>
        /// <param name="operation">Activation operation</param>
        /// <param name="identityValue">Object identity value</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return a new default activation record</returns>
        public static DefaultActivationRecord<TEntity, TDataAccess> CreateRecord(ActivationOperation operation, string identityValue, ActivationOption activationOption)
        {
            var record = new DefaultActivationRecord<TEntity, TDataAccess>()
            {
                Operation = operation,
                IdentityValue = identityValue,
                DataAccessService = typeof(TDataAccess),
                EntityType = typeof(TEntity)
            };
            activationOption = activationOption ?? ActivationOption.Default;
            record.ActivationOption = activationOption;
            if (activationOption.ForceExecute)
            {
                record.RecordIdentity = Guid.NewGuid().ToString();
            }
            else
            {
                switch (operation)
                {
                    case ActivationOperation.SaveObject:
                    case ActivationOperation.RemoveByObject:
                        record.RecordIdentity = string.Format("{0}_{1}", typeof(TEntity).GUID, identityValue);
                        break;
                    default:
                        record.RecordIdentity = Guid.NewGuid().ToString();
                        break;
                }
            }
            return record;
        }

        /// <summary>
        /// Create a save record
        /// </summary>
        /// <param name="identityValue">Identity values</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return a new default activation record</returns>
        public static DefaultActivationRecord<TEntity, TDataAccess> CreateSaveRecord(string identityValue, ActivationOption activationOption)
        {
            if (string.IsNullOrWhiteSpace(identityValue))
            {
                throw new EZNEWException("IdentityValue is null or empty");
            }
            return CreateRecord(ActivationOperation.SaveObject, identityValue, activationOption);
        }

        /// <summary>
        /// Create remove object record
        /// </summary>
        /// <param name="identityValue">Identity value</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return a new default activation record</returns>
        public static DefaultActivationRecord<TEntity, TDataAccess> CreateRemoveObjectRecord(string identityValue, ActivationOption activationOption)
        {
            if (string.IsNullOrWhiteSpace(identityValue))
            {
                throw new EZNEWException("identityValue is null or empty");
            }
            return CreateRecord(ActivationOperation.RemoveByObject, identityValue, activationOption);
        }

        /// <summary>
        /// Create remove by condition record
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return a new default activation record</returns>
        public static DefaultActivationRecord<TEntity, TDataAccess> CreateRemoveByConditionRecord(IQuery query, ActivationOption activationOption)
        {
            var record = CreateRecord(ActivationOperation.RemoveByCondition, null, activationOption);
            record.Query = query;
            return record;
        }

        /// <summary>
        /// Create modify record
        /// </summary>
        /// <param name="modify">Modify expression</param>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return a new default activation record</returns>
        public static DefaultActivationRecord<TEntity, TDataAccess> CreateModifyRecord(IModify modify, IQuery query, ActivationOption activationOption)
        {
            var record = CreateRecord(ActivationOperation.ModifyByExpression, null, activationOption);
            record.ModifyExpression = modify;
            record.Query = query;
            return record;
        }

        /// <summary>
        /// Create package record
        /// </summary>
        /// <returns>Return a new default activation record</returns>
        public static DefaultActivationRecord<TEntity, TDataAccess> CreatePackageRecord()
        {
            return CreateRecord(ActivationOperation.Package, string.Empty, null);
        }

        /// <summary>
        /// Add follow records
        /// </summary>
        /// <param name="records">Follow records</param>
        public void AddFollowRecords(params IActivationRecord[] records)
        {
            IEnumerable<IActivationRecord> recordCollection = records;
            AddFollowRecords(recordCollection);
        }

        /// <summary>
        /// Add follow records
        /// </summary>
        /// <param name="records">Follow records</param>
        public void AddFollowRecords(IEnumerable<IActivationRecord> records)
        {
            if (records.IsNullOrEmpty())
            {
                return;
            }
            if (FollowRecords == null)
            {
                FollowRecords = new List<IActivationRecord>(0);
            }
            foreach (var childRecord in records)
            {
                childRecord.ParentRecord = this;
                FollowRecords.Add(childRecord);
            }
        }

        /// <summary>
        /// Get follow records
        /// </summary>
        public IEnumerable<IActivationRecord> GetFollowRecords()
        {
            return FollowRecords ?? new List<IActivationRecord>(0);
        }

        /// <summary>
        /// Get execute commands
        /// </summary>
        /// <returns>Return the record command</returns>
        public ICommand GetExecuteCommand()
        {
            ICommand command = null;
            switch (Operation)
            {
                case ActivationOperation.SaveObject:
                    command = GetSaveObjectCommand();
                    break;
                case ActivationOperation.RemoveByObject:
                    command = GetRemoveObjectCommand();
                    break;
                case ActivationOperation.RemoveByCondition:
                    command = GetRemoveConditionCommand();
                    break;
                case ActivationOperation.ModifyByExpression:
                    command = GetModifyExpressionCommand();
                    break;
            }
            return command;
        }

        /// <summary>
        /// Get save commands
        /// </summary>
        /// <returns>Return the record command</returns>
        ICommand GetSaveObjectCommand()
        {
            if (string.IsNullOrWhiteSpace(IdentityValue))
            {
                return null;
            }
            var dataPackage = WarehouseManager.GetDataPackage<TEntity>(IdentityValue);
            if (dataPackage == null || (!ActivationOption.ForceExecute && dataPackage.Operate != WarehouseDataOperate.Save))
            {
                return null;
            }
            var dalService = ContainerManager.Resolve<TDataAccess>();
            if (dataPackage.LifeSource == DataLifeSource.New) //new add value
            {
                return dalService.Add(dataPackage.WarehouseData);
            }
            else if (dataPackage.HasValueChanged) // update value
            {
                var data = dataPackage.WarehouseData;
                return dalService.Modify(data, dataPackage.PersistentData);
            }
            return null;
        }

        /// <summary>
        /// Get remove command
        /// </summary>
        /// <returns>Return the record command</returns>
        ICommand GetRemoveObjectCommand()
        {
            if (string.IsNullOrWhiteSpace(IdentityValue))
            {
                return null;
            }
            var dataPackage = WarehouseManager.GetDataPackage<TEntity>(IdentityValue);
            if (dataPackage == null || (!ActivationOption.ForceExecute && (dataPackage.Operate != WarehouseDataOperate.Remove || dataPackage.IsRealRemove)))
            {
                return null;
            }
            var dalService = ContainerManager.Resolve<TDataAccess>();
            var data = dataPackage.WarehouseData;
            return dalService.Delete(data);
        }

        /// <summary>
        /// Get remove conditon command
        /// </summary>
        /// <returns>Return the record command</returns>
        ICommand GetRemoveConditionCommand()
        {
            var dalService = ContainerManager.Resolve<TDataAccess>();
            return dalService.Delete(Query);
        }

        /// <summary>
        /// Get modify expression command
        /// </summary>
        /// <returns>Return the record command</returns>
        ICommand GetModifyExpressionCommand()
        {
            var dalService = ContainerManager.Resolve<TDataAccess>();
            return dalService.Modify(ModifyExpression, Query);
        }

        /// <summary>
        /// Obsolete record
        /// </summary>
        public void Obsolete()
        {
            IsObsolete = true;
        }
    }
}
