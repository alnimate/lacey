﻿using System;
using System.Collections.Generic;
using Lacey.Medusa.Common.Extensions.Base.Internal;

namespace Lacey.Medusa.Common.Extensions.Base.Types
{
    /// <summary>
    /// <see cref="IEqualityComparer{T}"/> implementation that uses a delegate to compare objects.
    /// </summary>
    public class DelegateEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparer;
        private readonly Func<T, int> _hashGenerator;

        /// <summary>
        /// Initializes with the given comparer and hash generator.
        /// </summary>
        public DelegateEqualityComparer([NotNull] Func<T, T, bool> comparer, [NotNull] Func<T, int> hashGenerator)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            _hashGenerator = hashGenerator ?? throw new ArgumentNullException(nameof(hashGenerator));
        }

        /// <summary>
        /// Initializes with the default comparer and default hash generator.
        /// </summary>
        public DelegateEqualityComparer()
            : this((x, y) => object.Equals(x, y), o => o.GetHashCode())
        {
        }

        /// <inheritdoc />
        public bool Equals(T x, T y)
        {
            return _comparer(x, y);
        }

        /// <inheritdoc />
        public int GetHashCode(T obj)
        {
            return _hashGenerator(obj);
        }
    }
}