﻿using System.Collections.Generic;

namespace DDD.Util.Develop.Command.Modify
{
    /// <summary>
    /// Modify item
    /// </summary>
    public interface IModifyItem
    {
        /// <summary>
        /// Parse modify value
        /// </summary>
        /// <returns>Return modify values</returns>
        KeyValuePair<string, IModifyValue> ParseModifyValue();
    }
}
