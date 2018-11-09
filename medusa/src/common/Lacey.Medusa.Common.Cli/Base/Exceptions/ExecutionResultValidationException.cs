﻿using System;
using Lacey.Medusa.Common.Cli.Base.Internal;
using Lacey.Medusa.Common.Cli.Base.Models;

namespace Lacey.Medusa.Common.Cli.Base.Exceptions
{
    /// <summary>
    /// Base class for exceptions that are thrown when an instance of <see cref="ExecutionResult"/> fails a certain validation.
    /// </summary>
    public abstract class ExecutionResultValidationException : Exception
    {
        /// <summary>
        /// Execution result.
        /// </summary>
        public ExecutionResult ExecutionResult { get; }

        /// <inheritdoc />
        protected ExecutionResultValidationException(ExecutionResult executionResult, string message)
            : base(message)
        {
            ExecutionResult = executionResult.GuardNotNull(nameof(executionResult));
        }
    }
}