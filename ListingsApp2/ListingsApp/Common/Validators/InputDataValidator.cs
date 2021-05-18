using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Validators
{
    class InputDataValidator : IValidator
    {
        public bool ValidateInputParams(List<string> inputTokens)
        {
            bool retVal = false;
            if (inputTokens.Count < 1)
                return retVal;

            switch (inputTokens[0].ToUpper())
            {
                case "REGISTER": //User operationEnum instead of hard coded value
                    if (inputTokens.Count == 2)
                        retVal = true; //Set this after all validations
                    break;

                case "CREATE_LISTING":
                    if (inputTokens.Count == 6)
                        retVal = true; //Set this after all validations
                    break;

                case "DELETE_LISTING":
                    if (inputTokens.Count == 3)
                        retVal = true; //Set this after all validations
                    break;

                case "GET_LISTING":
                    if (inputTokens.Count == 3)
                        retVal = true; //Set this after all validations
                    break;

                case "GET_CATEGORY":
                    if (inputTokens.Count == 5)
                        retVal = true; //Set this after all validations
                    break;

                case "GET_TOP_CATEGORY":
                    if (inputTokens.Count >= 1)
                        retVal = true; //Set this after all validations
                    break;

                default:
                    retVal = false;
                    break;
            }
            return retVal;
        }
    }
}
