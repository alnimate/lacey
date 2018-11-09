﻿using Lacey.Medusa.Common.Cli.Base.Models;

namespace Lacey.Medusa.Common.Cli.Base.Exceptions
{
    /// <summary>
    /// Thrown if underlying process reported a non-zero exit code.
    /// </summary>
    public class ExitCodeValidationException : ExecutionResultValidationException
    {
        /// <summary>
        /// Exit code reported by the underlying process.
        /// </summary>
        public int ExitCode => ExecutionResult.ExitCode;

        /// <summary>
        /// Initializes <see cref="ExitCodeValidationException"/> with given exit code.
        /// </summary>
        public ExitCodeValidationException(ExecutionResult executionResult)
            : base(executionResult, $"Underlying process reported a non-zero exit code: {executionResult.ExitCode}")
        {
        }
    }
}