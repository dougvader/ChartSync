#!/bin/bash
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0
export PATH="$PATH:$HOME/.dotnet"
dotnet publish -c Release -o build