﻿using System;
using Lacey.Medusa.Common.Cli.Base.Models;

namespace Lacey.Medusa.Common.Cli.Base.Exceptions
{
    /// <summary>
    /// Thrown if underlying process reported an error.
    /// </summary>
    public class StandardErrorValidationException : ExecutionResultValidationException
    {
        /// <summary>
        /// Standard error data produced by underlying process.
        /// </summary>
        public string StandardError => ExecutionResult.StandardError;

        /// <summary>
        /// Initializes <see cref="StandardErrorValidationException"/> with given standard error data.
        /// </summary>
        public StandardErrorValidationException(ExecutionResult executionResult)
            : base(executionResult,
                $"Underlying process reported an error:{Environment.NewLine}{executionResult.StandardError}")
        {
        }
    }
}