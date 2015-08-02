# ColorConsole


A very simple class library to aid in printing coloured output to the console.

**Build Status**

| master                                                                                                                   | develop            |
|--------------------------------------------------------------------------------------------------------------------------|--------------------|
| [![Build Status](https://travis-ci.org/RMCKirby/ColorConsole.svg?branch=master)](https://travis-ci.org/RMCKirby/ColorConsole) | [![Build Status](https://travis-ci.org/RMCKirby/ColorConsole.svg?branch=develop)](https://travis-ci.org/RMCKirby/ColorConsole) |

#### How?

The public API is small. Simply create an instance of `ConsoleWriter`:

```csharp
using System;
using ColorConsole;
...

var console = new ConsoleWriter();
```
and invoke the method of your choice:
```csharp
console.Write("Be seeing you!", ConsoleColor.Yellow);
```

#### Why?

The main motivation was to reduce the typical boilerplate code involved to output colored text to the console.
Quite often, you would see console applications defining/duplicating this behaviour in their own assembly each time it was required.

#### Where?
The easiest way to install `ColorConsole` is via Paket or Nuget.

**Paket**

Assuming your project has `paket.exe` under `.paket/paket.exe`

>Mono:
```
mono .paket/paket.exe add nuget ColorConsole
```
>.Net
```
.paket/paket.exe add nuget ColorConsole
```

**Nuget**

`Install-Package ColorConsole`
