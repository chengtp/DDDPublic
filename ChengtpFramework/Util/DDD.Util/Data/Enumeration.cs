﻿using System;

namespace DDD.Util.Data
{
    /// <summary>
    /// Defines server type
    /// </summary>
    [Serializable]
    public enum DatabaseServerType
    {
        Others = 0,
        SQLServer = 110,
        MySQL = 120,
        Oracle = 130,
        MongoDB = 140,
    }
}
