using CoolWebs.Model.TitleLIst;
using LanguageExt.Common;

namespace CoolWeebs.API.Interfaces
{
    public interface IBaseService<TResponse, TRequest, IType> where TResponse : class where TRequest : class
    {
    }
}
