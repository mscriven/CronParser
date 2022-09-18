# CronParser

> A simple console app that parses a cron string and expands each field to show the times at which it will run.

Supports standard cron format. Does not support special time strings such as "@yearly". [Learn more at crontab.guru here!](https://crontab.guru/)

There's three projects.
	- A class library containing all the domain logic for parsing a cron expression
	- A Console Host application, adding all the logic specific to the application being hosted as a console application.
	- A unit test library for the class library, testing all the domain logic developed using TDD.

# Building

To build and run the app on Windows or Linux you will need to install the Net6 SDK: https://dotnet.microsoft.com/en-us/download/dotnet/6.0.
To just run the app, you only need the Net6 Runtime installed.

# Example Usage

When running the Console app, you need to a valid cron expression, and a command to be executed for every time that matches the cron expression, as a single argument.

E.g.
```console
CronosParser.ConsoleHost.exe "*/15 0 1,15 * 1-5 /usr/bin/find"
```

would return the output:

```console
minutes       0 15 30 45
hour          0
day of month  1 15
month         1 2 3 4 5 6 7 8 9 10 11 12
day of week   1 2 3 4 5
command       /usr/bin/find
```

# ToDo

- Convert to uint to avoid negative numbers natively and resolve some edge cases.
- Use dependency injection to avoid static calls, duplicated code, and enable more unit test coverage.
- Add support for month names.
- Refactor to remove classes that ended up being defined purely for configuration. Potential opportunity to have each symbol parser be it's own strategy, and build a bag of valid strategies for each applicable token.