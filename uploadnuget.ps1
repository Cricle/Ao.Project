$version="1.1.0"
$accessToken="oy2ihpgccbvgsptb6braid4hdnit5i7e7kqfxhbmfmihnu"
$paths=@("Ao.Project","Ao.Project.NewtonsoftJson");
for($x=0;$x -lt $paths.length; $x=$x+1)
{
$fp=-join ("src\",$paths[$x],"\bin\Release\",$paths[$x],".",$version,".nupkg");
dotnet nuget push $fp -k $accessToken -s https://api.nuget.org/v3/index.json
}