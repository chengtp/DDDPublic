using DDD.Develop.CQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Domain.Repository.Warehouse
{
    /// <summary>
    /// check exist result
    /// </summary>
    public class CheckExistResult
    {
        /// <summary>
        /// have data
        /// </summary>
        public bool IsExist
        {
            get; set;
        }

        /// <summary>
        /// check query
        /// </summary>
        public IQuery CheckQuery
        {
            get;set;
        }
    }
}
