using LanguageExt.Common;

namespace CoolWeebs.API.Extensions
{
    public static class ResultExtension
    {
        public static A GetValue<A>(this Result<A> result)
        {
            return result.Match(
                succ => succ,
                fail => throw fail);
        }

        public static Exception GetException<A>(this Result<A> result)
        {
            return result.Match(
                _ => null!,
                fail => fail);
        }
    }
}
