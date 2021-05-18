How to build:
Windows
Please get Visual Studio 2019 or latest, (not VSCode)
Open solution file.
One small change would be needed the machine is not intel based.
Click build and run, or just hit F5.

Mac
Please get Visual Studio, and latest .net core.
run: dotnet migrate command at top level.
open solution file.
Use build and run from menus.

Caveats:
a. I assumed that we want to build application that is modular, easily scalable and can be migrated to microservices easily. So, i divided code into 5 main modules 1) categories,    2) Users 3) Listings 4) Common 5) UI.
b. But if we want to build the app in a monolith way or mobile app way, we can easily move around files and make it happen in < 5mins.
c. Data is duplicated for better performance, this can be further optimized though.
d. This is code is not thread safe at this point, but can me made thread safe in < 2-3 hours based on need.
e. Followed interface driven development principles as per the need. But didnt force interfaces at place where there was no need, these interfaces can be added during product        evolution.
f. top_category operation's implementation appears to be not efficient in first glance but sortedDictionary internally uses efficient implementation to get the required data in < O(N). This has to be tested with few lakhs of records and finetune the approach. 

