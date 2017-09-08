# GitHubExplorer
Test project to explore GitHub users

ASP.NET MVC Web Application that allows you to search for user from GitHub by his name using GitHubApi (https://developer.github.com/v3/).
You can use Google or Facebook for log in.
After you find user you can read the information about his name, location and the best of his repositories, also you can see his avatar.

Tools what i used:
- https://datatables.net/
- http://getbootstrap.com/

- IoC - Ninject
- Test - MSTest
- Logging - NLog

Solution contains:
- GitHubExplorer - ASP.NET MVC Application
- GitHubExplorer.Repository - project with repositories: 
    - GitHubApi - repository that allows get data directly from GitHubApi
    - MockedRepository - repository what I was used while doing frontend part of project (because GibHubApi imposes calls rate-limiting)
- GitHubExplorer.Shared - interfaces, data structures and helpers:
    - ConsoleLogger - provides to log info and exceptions to Output in Visual Studio
    - NLogHelper - uses NLog to log info and exceptions to locations definied in nlog.config
    - WebRequestHelper - provides to call GET request by passing url and returns resposne string

- GitHubExplorer.IntegrationTests - integration tests
- GitHubExplorer.Tests - unit tests
