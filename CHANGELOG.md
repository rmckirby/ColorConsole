# Change Log
All notable changes to this project will be documented in this file.
This project adheres to [Semantic Versioning](http://semver.org/).

## [0.2.0] - 2015-04-08
**Features**
 - Added Generic Write overloads. These will completely replace the existing string overloads
 on the first MAJOR release.

**Changes**
 - Obsoleted Write & WriteLine string overloads.

## [1.0.0] - 2015-13-08
**Changes**
 - Removed Obsolete methods from `ConsoleWriter` and `IConsoleWriter`.

## [1.0.1] - 2015-21-08
 **Changes**
 - Assembly is now targeted for any CPU rather than just x86.

**Fixes**
 - Fixed issue with building on Windows under the .NET runtime. Moq was unable to mock internal interfaces
 despite the mocked assembly being visible to DynamicProxy. This was resolved by removing the DynamicProxy public key.
