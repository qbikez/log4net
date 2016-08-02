if (!(test-path .scripts)) { $null = mkdir .scripts }
wget http://bit.ly/qbootstrap1 -outfile ".scripts/bootstrap.ps1"
./.scripts/bootstrap.ps1

if ((get-command choco -erroraction ignore) -eq $null) {
	iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex
}
choco install -y nant