﻿using DDD.Develop.Command;
using DDD.Develop.Command.Modify;
using DDD.Develop.CQuery;
using DDD.Develop.DataAccess;
using DDD.Develop.Domain.Repository.Warehouse;
using DDD.Develop.Entity;
using DDD.Util.Extension;
using DDD.Util.Fault;
using DDD.Util.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Develop.UnitOfWork
{
    /// <summary>
    /// default activation record
    /// </summary>
    /// <typeparam name="ET"></typeparam>
    public class DefaultActivationRecord<ET, DAI> : IActivationRecord where ET : BaseEntity<ET>,new() where DAI : IDataAccess<ET>
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// parent record
        /// </summary>
        public IActivationRecord ParentRecord { get; set; }

        /// <summary>
        /// operation
        /// </summary>
        public ActivationOperation Operation
        {
            get; set;
        }

        /// <summary>
        /// identity value
        /// </summary>
        public string IdentityValue
        {
            get; set;
        }

        /// <summary>
        /// query
        /// </summary>
        public IQuery Query
        {
            get; set;
        }

        /// <summary>
        /// modify expression
        /// </summary>
        public IModify ModifyExpression
        {
            get; set;
        }

        /// <summary>
        /// Follow Records
        /// </summary>
        private List<IActivationRecord> FollowRecords
        {
            get; set;
        }

        /// <summary>
        /// data access service
        /// </summary>
        public Type DataAccessService
        {
            get; set;
        }

        /// <summary>
        /// entity type
        /// </summary>
        public Type EntityType
        {
            get; set;
        }

        /// <summary>
        /// is obsolete
        /// </summary>
        public bool IsObsolete { get; private set; }

        /// <summary>
        /// record identity
        /// </summary>
        public string RecordIdentity
        {
            get; private set;
        }

        /// <summary>
        /// activation option
        /// </summary>
        public ActivationOption ActivationOption
        {
            get;
            private set;
        }

        private DefaultActivationRecord()
        { }

        /// <summary>
        /// create operation
        /// </summary>
        /// <param name="operation">operation</param>
        /// <param name="identityValue">object identity value</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        public static DefaultActivationRecord<ET, DAI> CreateRecord(ActivationOperation operation, string identityValue, ActivationOption activationOption)
        {
            var record = new DefaultActivationRecord<ET, DAI>()
            {
                Operation = operation,
                IdentityValue = identityValue,
                DataAccessService = typeof(DAI),
                EntityType = typeof(ET)
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
                        record.RecordIdentity = string.Format("{0}_{1}", typeof(ET).GUID, identityValue);
                        break;
                    default:
                        record.RecordIdentity = Guid.NewGuid().ToString();
                        break;
                }
            }
            return record;
        }

        /// <summary>
        /// create save operation
        /// </summary>
        /// <param name="identityValue">identity values</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        public static DefaultActivationRecord<ET, DAI> CreateSaveRecord(string identityValue, ActivationOption activationOption)
        {
            if (identityValue.IsNullOrEmpty())
            {
                throw new DDDException("identityValue is null or empty");
            }
            return CreateRecord(ActivationOperation.SaveObject, identityValue, activationOption);
        }

        /// <summary>
        /// create remove object operation
        /// </summary>
        /// <param name="identityValue"></param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        public static DefaultActivationRecord<ET, DAI> CreateRemoveObjectRecord(string identityValue, ActivationOption activationOption)
        {
            if (identityValue.IsNullOrEmpty())
            {
                throw new DDDException("identityValue is null or empty");
            }
            return CreateRecord(ActivationOperation.RemoveByObject, identityValue, activationOption);
        }

        /// <summary>
        /// create remove by condition record
        /// </summary>
        /// <param name="query">query object</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        public static DefaultActivationRecord<ET, DAI> CreateRemoveByConditionRecord(IQuery query, ActivationOption activationOption)
        {
            var record = CreateRecord(ActivationOperation.RemoveByCondition, null, activationOption);
            record.Query = query;
            return record;
        }

        /// <summary>
        /// create modify record
        /// </summary>
        /// <param name="modify">modify expression</param>
        /// <param name="query">query object</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        public static DefaultActivationRecord<ET, DAI> CreateModifyRecord(IModify modify, IQuery query, ActivationOption activationOption)
        {
            var record = CreateRecord(ActivationOperation.ModifyByExpression, null, activationOption);
            record.ModifyExpression = modify;
            record.Query = query;
            return record;
        }

        /// <summary>
        /// create package record
        /// </summary>
        /// <returns></returns>
        public static DefaultActivationRecord<ET, DAI> CreatePackageRecord()
        {
            return CreateRecord(ActivationOperation.Package, string.Empty, null);
        }

        /// <summary>
        /// add follow records
        /// </summary>
        /// <param name="records">records</param>
        public void AddFollowRecords(params IActivationRecord[] records)
        {
            if (records.IsNullOrEmpty())
            {
                return;
            }
            if (FollowRecords == null)
            {
                FollowRecords = new List<IActivationRecord>();
            }
            foreach (var childRecord in records)
            {
                childRecord.ParentRecord = this;
                FollowRecords.Add(childRecord);
            }
        }

        /// <summary>
        /// get follow records
        /// </summary>
        public List<IActivationRecord> GetFollowRecords()
        {
            return FollowRecords ?? new List<IActivationRecord>(0);
        }

        /// <summary>
        /// get execute commands
        /// </summary>
        /// <returns></returns>
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
        /// get save commands
        /// </summary>
        /// <returns></returns>
        ICommand GetSaveObjectCommand()
        {
            if (IdentityValue.IsNullOrEmpty())
            {
                return null;
            }
            var dataPackage = WarehouseManager.GetDataPackage<ET>(IdentityValue);
            if (dataPackage == null || (!ActivationOption.ForceExecute && dataPackage.Operate != WarehouseDataOperate.Save))
            {
                return null;
            }
            var dalService = ContainerManager.Resolve<DAI>();
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
        /// geet remove command
        /// </summary>
        /// <returns></returns>
        ICommand GetRemoveObjectCommand()
        {
            if (IdentityValue.IsNullOrEmpty())
            {
                return null;
            }
            var dataPackage = WarehouseManager.GetDataPackage<ET>(IdentityValue);
            if (dataPackage == null || (!ActivationOption.ForceExecute && (dataPackage.Operate != WarehouseDataOperate.Remove || dataPackage.IsRealRemove)))
            {
                return null;
            }
            var dalService = ContainerManager.Resolve<DAI>();
            var data = dataPackage.WarehouseData;
            return dalService.Delete(data);
        }

        /// <summary>
        /// get remove conditon command
        /// </summary>
        /// <returns></returns>
        ICommand GetRemoveConditionCommand()
        {
            var dalService = ContainerManager.Resolve<DAI>();
            return dalService.Delete(Query);
        }

        /// <summary>
        /// get modify expression command
        /// </summary>
        /// <returns></returns>
        ICommand GetModifyExpressionCommand()
        {
            var dalService = ContainerManager.Resolve<DAI>();
            return dalService.Modify(ModifyExpression, Query);
        }

        /// <summary>
        /// obsolete
        /// </summary>
        public void Obsolete()
        {
            IsObsolete = true;
        }
    }
}
