﻿namespace DDD.Util.Cache.List.Response
{
    /// <summary>
    /// List insert before response
    /// </summary>
    public class ListInsertBeforeResponse : CacheResponse
    {
        /// <summary>
        /// Gets or sets the length of the list after the insert operation, or -1 when the value pivot was not found.
        /// </summary>
        public long NewListLength
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets whether has insert
        /// </summary>
        public bool HasInsert
        {
            get; set;
        }
    }
}
