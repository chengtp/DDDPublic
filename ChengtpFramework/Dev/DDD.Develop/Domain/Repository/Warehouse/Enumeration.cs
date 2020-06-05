using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Domain.Repository.Warehouse
{
    /// <summary>
    /// data operate
    /// </summary>
    public enum WarehouseDataOperate
    {
        None = 2,
        Save = 4,
        Remove = 8
    }

    /// <summary>
    /// warehouse life source
    /// </summary>
    public enum DataLifeSource
    {
        DataSource = 2,
        New = 4
    }
}
