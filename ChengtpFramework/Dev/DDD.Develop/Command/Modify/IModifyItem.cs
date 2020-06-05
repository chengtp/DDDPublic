using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Command.Modify
{
    public interface IModifyItem
    {
        /// <summary>
        /// parse modify value
        /// </summary>
        /// <returns></returns>
        KeyValuePair<string, IModifyValue> ParseModifyValue();
    }
}
