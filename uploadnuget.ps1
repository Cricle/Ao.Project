$version="1.0.0"
$accessToken=""
$paths=@("Ao.Project","Ao.Project.NewtonsoftJson");
for($x=0;$x -lt $paths.length; $x=$x+1)
{
$fp=-join ("src\",$paths[$x],"\bin\Release\",$paths[$x],".",$version,".nupkg");
nuget push $fp -ApiKey $accessToken -Source https://api.nuget.org/v3/index.json
}