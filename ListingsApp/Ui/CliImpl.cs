using ListingsApp.categories;
using ListingsApp.Listings;
using ListingsApp.Users;
using ListingsApp.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ListingsApp.Ui
{
    class CliImpl : UiInterface
    {
        private UserController userControllerObj;
        private ListingController listingControllerObj;
        private CategoryController categoryControllerObj;
        private Logger.CliLogger loggerObj;
        private IValidator validatorObj;

        public CliImpl()
        {
            userControllerObj = new UserController();
            loggerObj = new Logger.CliLogger();
            validatorObj = new InputDataValidator();
            listingControllerObj = new ListingController();
            categoryControllerObj = new CategoryController();
        }

        public void start(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Menu");
                Console.WriteLine("REGISTER");
                Console.WriteLine("CREATE_LISTING");
                Console.WriteLine("DELETE_LISTING");
                Console.WriteLine("GET_LISTING");
                Console.WriteLine("GET_CATEGORY");
                Console.WriteLine("GET_TOP_CATEGORY");
                Console.ResetColor();
                Console.Write("#");

                string inputStr = Console.ReadLine();

                //Below linq code from MSDN
                var inputTokens = inputStr.Trim().Split('"')
                     .Select((element, index) => index % 2 == 0  
                                           ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  
                                           : new string[] { element })  
                     .SelectMany(element => element).ToList();


                bool inputValidation = validatorObj.ValidateInputParams(inputTokens);
                if (inputValidation == false)
                {
                    Console.WriteLine("Invalid option or invalid/insufficient/unwanted params, try again");
                    continue;
                }

                if (inputTokens[0].ToUpper() != "REGISTER" && !userControllerObj.isUserExisting(inputTokens[1]))
                {
                    //loggerObj.log("user doesnt exist, User:" + inputTokens[1], true);
                    loggerObj.log("Error - unknown user");
                    continue;
                }


                switch (inputTokens[0].ToUpper())
                {
                    case "REGISTER": //User operationEnum instead of hard coded value
                        string user = inputTokens[1]; //Need validation here.
                        bool retValue = userControllerObj.addUser(user);
                        if (retValue)
                        {
                            //loggerObj.log("added user: " + user, true);
                            loggerObj.log("Success");
                        }
                        else
                        {
                            //loggerObj.log("cannot add user: " + user, true);
                            loggerObj.log("Error - user already existing");
                        }
                        break;

                    case "CREATE_LISTING":

                        ListingModel lm = new ListingModel(inputTokens[2], inputTokens[3], float.Parse(inputTokens[4], CultureInfo.InvariantCulture.NumberFormat), inputTokens[1], DateTime.Now, listingControllerObj.getNextListingId(), inputTokens[5]);
                        retValue = listingControllerObj.addListing(lm);
                        if (retValue)
                        {
                            retValue = categoryControllerObj.addListingToACategory(lm);
                        }
                        if (retValue)
                        {
                            //loggerObj.log("added listing: " + lm.getModelAsString(), true);
                            loggerObj.log(lm.ListingId);
                        }
                        else
                        {
                            listingControllerObj.deleteListing(lm.UserName, lm.ListingId);
                            loggerObj.log("cannot add listing: " + lm.getModelAsString(), true);
                        }
                        break;

                    case "DELETE_LISTING":
                        lm = listingControllerObj.getListing(inputTokens[1], inputTokens[2]); //Not an efficient way.
                        if (lm != null)
                            retValue = listingControllerObj.deleteListing(lm.UserName, lm.ListingId);
                        else retValue = false;

                        if (retValue)
                        {
                            retValue = categoryControllerObj.deleteListingFromACategory(lm);
                        }
                        if (retValue)
                        {
                            //loggerObj.log("deleted listing: " + inputTokens[2]);
                            loggerObj.log("Success");
                        }
                        else
                        {
                            //loggerObj.log("cannot delete listing: " + inputTokens[2], true);
                            loggerObj.log("Error - listing does not exist");
                        }
                        break;

                    case "GET_LISTING":

                        lm = listingControllerObj.getListing(inputTokens[1], inputTokens[2]);
                        if (lm != null)
                        {
                            //loggerObj.log("retrieved listing: " + lm.getModelAsString(), true);
                            loggerObj.log(lm.getModelAsString());
                        }
                        else
                        {
                            //loggerObj.log("There is no listing exists with given user or listing id");
                            loggerObj.log("Error - listing does not exist");
                        }
                        break;

                    case "GET_CATEGORY":

                        IList<ListingModel> lmList = categoryControllerObj.getListingsInCategory(inputTokens[1], inputTokens[2], inputTokens[3], inputTokens[4]);
                        if (lmList ==null || lmList.Count == 0)
                        {
                            //loggerObj.log("No listings exist in given category, for User:" + inputTokens[1], true);
                            loggerObj.log("Error - category not found");
                            break;
                        }
                        foreach (ListingModel lmLoop in lmList)
                        {
                            Console.WriteLine(lmLoop.getModelAsString());
                        }                            
                        break;

                    case "GET_TOP_CATEGORY":

                        if (!userControllerObj.isUserExisting(inputTokens[1]))
                        {
                            loggerObj.log("Error - unknown user");
                            break;
                        }

                        // commented block will get you all listings in top category.
                        /* 
                        lmList = categoryControllerObj.getListingsOfTopCategory();
                        if (lmList.Count == 0)
                        {
                            loggerObj.log("No listings exist in given category", true);
                            break;
                        }
                        foreach (ListingModel lmLoop in lmList)
                        {
                            Console.WriteLine(lmLoop.getModelAsString());
                        }
                        */
                        string topCat = categoryControllerObj.getTopCategory();
                        if (string.IsNullOrEmpty(topCat))
                        {
                            loggerObj.log("Error - no top category");
                        }
                        else
                        {
                            loggerObj.log(topCat);
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid option, select an option from below");
                        break;
                }
            }
        }
    }
}
