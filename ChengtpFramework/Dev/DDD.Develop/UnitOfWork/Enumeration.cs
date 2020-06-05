using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.UnitOfWork
{
    /// <summary>
    /// activation operation
    /// </summary>
    public enum ActivationOperation
    {
        Package = 0,
        SaveObject = 2,
        ModifyByExpression = 4,
        RemoveByObject = 8,
        RemoveByCondition = 16
    }
}
