param ($test) 

if ((get-command "vstest.console.exe" -ErrorAction Ignore) -eq $null) {
# TODO: should be smarter than this:
    $env:path = "$env:path;c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow" 
}

if ((get-command "vstest.console.exe" -ErrorAction Ignore) -eq $null) {
    throw "'vstest.console.exe' not found on PATH!"
}

$tests = @(
    @{ path = "tests\log4net.Tests\project.json"; type = "dotnet" }   
)

$reporoot = (get-item ".").FullName

foreach ($t in $tests) {    
    $dir = split-path -parent $t.path
    $file =  split-path -leaf $t.path

    pushd
    try {
        $testcmd = $t.type
        cd ($dir)

		if (test-path "TestResults") {
			rmdir -r "TestResults"
		}
        
        write-host "running: msbuild $file"
        
        if ($t.type -eq "dotnet") {
            dotnet build
        } else {
            msbuild $file 
        }

        if ($lastExitCode -ne 0) {
			write-error "failed to build test project '$file'"
			continue
        }
    } finally {
        popd
    }

    pushd 
        
    try {
        $bin = $t.bin
        if ($bin -eq $null) {
            $bin = "bin\Debug\$($file -replace ".csproj",".dll")"
        }

    
        if ($testcmd -eq "mstest") {
            $p =  @("/testcontainer:""$bin""")
            $p += @("/resultsfile:..\.results\$(split-path -leaf $dir).xml")

            if ($test -ne $null) {
                $p += "/test:""$test"""
            }        
        }
        if ($testcmd -eq "vstest.console") {
            $p =  @("$bin")
             if ($test -ne $null) {
                $p += "/tests:""$test"""
            }
            $testadapterpath="tests\bin\Debug" #split-path -parent $bin
            $p += @("/testAdapterPath:$testadapterpath")
            if ($t.testsettings -ne $null) {
                $p += "/settings:$reporoot\$($t.testsettings)"
            }

            if ($env:APPVEYOR -eq "True") {
                $p += @("/logger:AppVeyor")
            } else {
               $p += @("/logger:trx")
            }
        }
        if ($testcmd -eq "dotnet") {
            cd $dir
            $p = @("test")
        }
        write-host "running: $testcmd $p"
        & $testcmd $p
        if ($lastexitcode -ne 0) {
            write-warning "$testcmd exited with $lastexitcode"
        }

    } 
    finally {
        popd
    }
}

# pre-check results

$results = get-childitem "tests" -Filter "*.trx" -Recurse
foreach($trx in $results) {
    $xml = [xml](get-content $trx.fullname)
    $trxerrors = @($xml.testrun.ResultSummary.RunInfos.RunInfo | ? { $_.outcome -eq "Error" })
    if ($trxerrors.Length -gt 0) {
        throw "Test Run Failed totally: $($trxerrors.Text | out-string)"
    }
}