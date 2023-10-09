using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos8Company.Web.Responses
{
    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
