﻿using System;
using System.Collections.Generic;

namespace DDD.Util.FileAccess.Configuration
{
    /// <summary>
    /// File access configuration
    /// </summary>
    [Serializable]
    public class FileAccessConfiguration
    {
        /// <summary>
        /// Gets or sets the default file access option
        /// </summary>
        public FileAccessOption Default
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the file objects configuration
        /// </summary>
        public List<FileObject> FileObjects
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the file access configuration name
        /// </summary>
        public static string FileAccessConfigurationName
        {
            get; set;
        } = nameof(FileAccessConfiguration);
    }
}
