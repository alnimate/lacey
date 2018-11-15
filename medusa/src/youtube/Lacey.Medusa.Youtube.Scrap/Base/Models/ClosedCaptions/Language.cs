using Lacey.Medusa.Youtube.Scrap.Base.Internal;

namespace Lacey.Medusa.Youtube.Scrap.Base.Models.ClosedCaptions
{
    /// <summary>
    /// Language information.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// ISO 639-1 code of this language.
        /// </summary>
        [NotNull]
        public string Code { get; }

        /// <summary>
        /// Full English name of this language.
        /// </summary>
        [NotNull]
        public string Name { get; }

        /// <summary />
        public Language(string code, string name)
        {
            Code = code.GuardNotNull(nameof(code));
            Name = name.GuardNotNull(nameof(name));
        }

        /// <inheritdoc />
        public override string ToString() => $"{Code} ({Name})";
    }
}