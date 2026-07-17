#!/bin/bash
# Script para ejecutar pruebas de la solución CSharpPOC001

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

dotnet test "$SCRIPT_DIR/CSharpPOC001.slnx"
