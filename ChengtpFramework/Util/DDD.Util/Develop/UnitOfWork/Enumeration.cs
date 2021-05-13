﻿using System;

namespace DDD.Util.Develop.UnitOfWork
{
    /// <summary>
    /// Defines activation operation
    /// </summary>
    [Flags]
    [Serializable]
    public enum ActivationOperation
    {
        Package = 0,
        SaveObject = 2,
        ModifyByExpression = 4,
        RemoveByObject = 8,
        RemoveByCondition = 16
    }
}
