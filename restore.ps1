# nuget restore src/log4net.vs2012.sln
dotnet restore src
if ($LASTEXITCODE -ne 0) { throw "'dotnet restore src' failed'" }
dotnet restore tests
if ($LASTEXITCODE -ne 0) { throw "'dotnet restore tests' failed'" }