﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Domain.Event
{
    /// <summary>
    /// domain event
    /// </summary>
    public interface IDomainEvent
    {
        #region Propertys

        /// <summary>
        /// event id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// created date
        /// </summary>
        DateTimeOffset CreatedDate { get; set; }

        #endregion
    }
}
