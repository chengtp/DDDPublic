﻿using Dapper;
using DDD.Develop.Command;
using DDD.Develop.CQuery;
using DDD.Develop.Entity;
using DDD.Util.ExpressionUtil;
using DDD.Util.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DDD.Develop.Entity
{
    /// <summary>
    /// base entity
    /// </summary>
    public abstract class BaseEntity<T> where T : BaseEntity<T>, new()
    {
        protected Dictionary<string, dynamic> valueDict = new Dictionary<string, dynamic>();//field values
        string identityValue = string.Empty;
        bool loadedIdentityValue = false;
        protected static Type entityType = typeof(T);

        static BaseEntity()
        {
            EntityManager.ConfigEntity<T>();
        }

        #region Propertys

        /// <summary>
        /// page count
        /// </summary>
        protected int QueryDataTotalCount
        {
            get; set;
        }

        #endregion

        #region methods

        /// <summary>
        /// get has modifed values
        /// </summary>
        /// <returns>values</returns>
        internal Dictionary<string, dynamic> GetModifyValues(T oldValue)
        {
            if (oldValue == null)
            {
                return valueDict;
            }
            var oldValues = oldValue.GetAllPropertyValues();
            if (oldValues.IsNullOrEmpty())
            {
                return valueDict;
            }
            Dictionary<string, dynamic> modifyValues = new Dictionary<string, dynamic>(valueDict.Count);
            var versionField = EntityManager.GetVersionField(typeof(T));
            foreach (var valueItem in valueDict)
            {
                if (valueItem.Key != versionField && (!oldValues.ContainsKey(valueItem.Key) || oldValues[valueItem.Key] != valueItem.Value))
                {
                    modifyValues.Add(valueItem.Key, valueItem.Value);
                }
            }
            return modifyValues;
        }

        /// <summary>
        /// get object primary key value
        /// </summary>
        /// <returns></returns>
        internal Dictionary<string, dynamic> GetPrimaryKeyValues()
        {
            var primaryKeys = EntityManager.GetPrimaryKeys(typeof(T));
            if (primaryKeys == null || primaryKeys.Count <= 0)
            {
                return new Dictionary<string, dynamic>(0);
            }
            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>(primaryKeys.Count);
            foreach (var key in primaryKeys)
            {
                if (valueDict.ContainsKey(key))
                {
                    values.Add(key, valueDict[key]);
                }
            }
            return values;
        }

        /// <summary>
        /// compare two objects determine whether is equal
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            BaseEntity<T> targetObj = obj as BaseEntity<T>;
            if (targetObj == null)
            {
                return false;
            }
            var myIdentity = GetIdentityValue();
            var targetIdentity = targetObj.GetIdentityValue();
            return myIdentity == targetIdentity;
        }

        /// <summary>
        /// get identity value
        /// </summary>
        /// <returns></returns>
        public virtual string GetIdentityValue()
        {
            if (loadedIdentityValue)
            {
                return identityValue;
            }
            var primaryValues = GetPrimaryKeyValues();
            identityValue = primaryValues.IsNullOrEmpty() ? Guid.NewGuid().ToString() : string.Join("_", primaryValues.Values.OrderBy(c => c?.ToString() ?? string.Empty).ToArray());
            loadedIdentityValue = true;
            return identityValue;
        }

        /// <summary>
        /// get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// get paging count
        /// </summary>
        /// <returns></returns>
        public int GetTotalCount()
        {
            return QueryDataTotalCount;
        }

        /// <summary>
        /// get property name
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        public dynamic GetPropertyValue(string propertyName)
        {
            if (valueDict.ContainsKey(propertyName))
            {
                return valueDict[propertyName];
            }
            throw new Exception("error property");
        }

        /// <summary>
        /// get property value
        /// </summary>
        /// <typeparam name="VT"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public VT GetPropertyValue<VT>(string propertyName)
        {
            return valueDict.GetValue<VT>(propertyName);
        }

        /// <summary>
        /// set property value
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <param name="value">value</param>
        public void SetPropertyValue(string propertyName, dynamic value)
        {
            IEnumerableExtension.SetValue(valueDict, propertyName, value);
            if (loadedIdentityValue && EntityManager.IsPrimaryKey(entityType, propertyName))
            {
                loadedIdentityValue = false;
            }
        }

        /// <summary>
        /// get all property values
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> GetAllPropertyValues()
        {
            return valueDict;
        }

        /// <summary>
        /// get cmd parameters
        /// </summary>
        /// <returns></returns>
        public CmdParameters GetCmdParameters()
        {
            var parameters = new CmdParameters();
            var propertys = EntityManager.GetFields(entityType);
            foreach (var property in propertys)
            {
                var value = GetPropertyValue(property.PropertyName);
                var dbType = SqlMapper.LookupDbType(property.DataType, property.PropertyName, false, out ITypeHandler handler);
                parameters.Add(property.PropertyName, value, dbType: dbType);
            }
            return parameters;
        }

        /// <summary>
        /// copy new by identity
        /// </summary>
        /// <returns></returns>
        public T CopyOnlyWithIdentity()
        {
            var newData = new T();
            var primaryKeys = EntityManager.GetPrimaryKeys<T>();
            if (primaryKeys.IsNullOrEmpty())
            {
                return newData;
            }
            foreach (var pk in primaryKeys)
            {
                var value = GetPropertyValue(pk.PropertyName);
                newData.SetPropertyValue(pk.PropertyName, value);
            }
            return newData;
        }

        /// <summary>
        /// copy a new object
        /// </summary>
        /// <returns></returns>
        public T Copy()
        {
            var newData = new T();
            newData.valueDict = valueDict.Select(c => c).ToDictionary(c => c.Key, c => c.Value);
            newData.QueryDataTotalCount = QueryDataTotalCount;
            newData.loadedIdentityValue = loadedIdentityValue;
            newData.identityValue = identityValue;
            return newData;
        }

        #endregion
    }
}
