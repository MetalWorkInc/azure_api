#!/bin/bash
# Script para compilar y ejecutar la API ASP.NET Core desde la solución principal

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

echo "Building solution..."
dotnet build "$SCRIPT_DIR"

echo ""
echo "Running API..."
dotnet run --project "$SCRIPT_DIR/src/CSharpPOC001.Api"
