param($installPath, $toolsPath, $package, $project)

$packagesPath = (Get-Item $installPath).Parent.FullName
$bootstrapperFolder = "$packagesPath\Bootstrapper\"
$exclude = @('Install.ps1')
Get-ChildItem $toolsPath -Recurse -Exclude $exclude | Copy-Item -Destination {Join-Path $bootstrapperFolder $_.FullName.Substring($toolsPath.length)}
