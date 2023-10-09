using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos8Company.Web.Responses
{
    public interface ISingleModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
