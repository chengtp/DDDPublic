﻿using System.Collections.Generic;

namespace DDD.Util.Token
{
    /// <summary>
    /// Token engine contract
    /// </summary>
    public interface ITokenEngine
    {
        /// <summary>
        /// Encode token
        /// </summary>
        /// <param name="tokenOption">Token option</param>
        /// <returns>Return token value</returns>
        TokenValue Encode(TokenOption tokenOption);

        /// <summary>
        /// Decode token value
        /// </summary>
        /// <param name="tokenOption">Token option</param>
        /// <returns>Return token string</returns>
        string Decode(TokenOption tokenOption);

        /// <summary>
        /// Decode token to dictionary
        /// </summary>
        /// <param name="tokenOption">Token option</param>
        /// <returns>Return dictionary value</returns>
        Dictionary<string, object> DecodeToDictionary(TokenOption tokenOption);

        /// <summary>
        /// Decode token to a object
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="tokenOption">Token option</param>
        /// <returns>Return the token object</returns>
        T DecodeToObject<T>(TokenOption tokenOption);
    }
}
