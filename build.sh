#!/bin/bash
if [ "$OS" = "Windows_NT" ]; then
    #Use .NET
    .paket/paket.bootstrapper.exe
    .paket/paket.exe restore

    ./packages/FAKE/tools/FAKE.exe build.fsx
else
    #Use Mono
    mono .paket/paket.bootstrapper.exe
    mono .paket/paket.exe restore

    mono packages/FAKE/tools/FAKE.exe build.fsx
fi
