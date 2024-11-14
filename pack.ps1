param (
    [string]$version = "1.0.0",
    [switch]$push = $false,
    [Switch]$skipbuild = $false,
    [string]$apikey = "",
    [string]$source = "nuget.org"
 )

 # ##############################################
 # ##### URANIUMUI PACKING AND PUBLISHING #######
 # ##############################################
 # Usage:
 # 1. Run this script in a powershell terminal: 
 #
 # .\pack.ps1 <version> -push <nuget-api-key>
 #
 # Example:
 #
 # .\pack.ps1 2.3.3 -push abcdefeysomeapikeyherefromnugetabcdef
 #
 # ##############################################

 if (!$skipbuild) {
    Write-Host "UraniumUI packages packing started."

    Invoke-Expression "dotnet pack -c Release -o . -p:packageVersion=$version --include-symbols"
    
    Write-Host "UraniumUI packages packing completed."
}

if ($push) {
    Write-Host "UraniumUI packages pushing started."

    Invoke-Expression "dotnet nuget push '*.$version.symbols.nupkg' --api-key $apikey --skip-duplicate --source $source"
    Write-Host "UraniumUI packages has been pushed successfully." -ForegroundColor Green
}

Set-Location ./templates

if (!$skipbuild) {
    Write-Host "UraniumUI templates packing started."
    Invoke-Expression "dotnet pack -c Release -o . -p:packageVersion=$version --include-symbols"
    Write-Host "UraniumUI templates packing completed."
}
if ($push) {
    Write-Host "UraniumUI templates pushing started."
    Invoke-Expression "dotnet nuget push '*.$version.symbols.nupkg' --api-key $apikey --skip-duplicate --source $source"
    Write-Host "UraniumUI templates has been pushed successfully." -ForegroundColor Green
    Write-Host "Removing nupkg files..."
    
    Write-Host "Nupkg files has been removed successfully." -ForegroundColor Green
}

Set-Location ../ # back to root

Invoke-Expression "Remove-Item -Path '*.nupkg' -Force -Recurse"
Invoke-Expression "Remove-Item -Path '**\*.nupkg' -Force -Recurse"