# TideWebApp

This is my submission for the Tide development challenge.

# Requirements

* Visual Studio 2019

# Running the app

* Clone the repo and run it in Visual Studio
  * npm install should run automatically (so it may take a while to run for the first time), but if not, run `npm install` in the ClientApp folder.
* Input the county name, as well as the page number and page size into the query fields. You can view more details by clicking on the Details link on the table item.

# Notes

* Sometimes on running the application, you may run into an issue where the Angular CLI times out. Keep refreshing the page until it works. This is a known issue with SPAs running off .NET and I haven't found a good answer for it.
* The logger only logs to the debug console. This might be fine if the explicit logs weren't drowned out by all the other runtime logs (thanks Angular).

# What's missing

* Formal unit tests. The NUnit framework is there, however it's missing anything substantial.
