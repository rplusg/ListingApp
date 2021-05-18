using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Validators
{
    interface IValidator
    {
        bool ValidateInputParams(List<string> inputTokens);
    }
}
