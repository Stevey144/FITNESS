using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos8Company.Web.Responses
{
    public interface IResponse
    {
        string Message { get; set; }

        bool DidError { get; set; }

        string ErrorMessage { get; set; }

    }
}
