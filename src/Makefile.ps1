if ($args.count -gt 1  )
{
	write-host "vela argumentov"
	exit 0
} 
if ($args[0] -eq "pack")
{
	$scriptPath =$MyInvocation.MyCommand.Path
	$scriptPath=$scriptPath.replace("repo\src\Makefile.ps1","")

	$source = $scriptPath+"repo"

	$destination = $scriptPath+"xmatej55_xdvors14_xbabic11_xbenov00.zip"


	if (Test-path $destination) 
	{
		Remove-item $destination
	}

	Add-Type -assembly "system.io.compression.filesystem"

	[io.compression.zipfile]::CreateFromDirectory($source, $destination)
}
elseif ( $args[0] -eq "all" -or $args[0] -eq "build" -or $args.count -eq 0 )
{
	write-host "Je podrebne zadat cestu k aplikacii:"
	$otaz = Read-Host -Prompt 'Zadat vlastnu cestu??[a/n]'
	if ( $otaz -eq "a")
	{
		$cesta = Read-Host -Prompt 'Zadajte cestu'
	}
	elseif ( $otaz -eq "n")
	{
		$cesta = 'C:\Program Files\xmatej55_xdvors14_xbabic11_xbenov00\Kalkulacka\src.exe'
	}
	else
	{
		write-host "zly znak"
		exit 0
	}
	if($cesta -eq "")
	{
		write-host "cesta nenajdena"
		exit 0
	}
	if (Test-Path -Path $cesta)
	{
		start-process -FilePath $cesta
	}
	else
	{
		write-host "cesta nenajdena"
	}
}
elseif ( $args[0] -eq "help" )
{
	write-host "je potrebne aby bola oplikacia nainstalovana"

}
