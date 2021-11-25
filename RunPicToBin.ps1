$filesToConvert = Get-ChildItem -Path ./TestPicToBin
Set-Location -Path PicToBin
foreach ($picFile in $filesToConvert) {
    $inFile = $picFile.FullName
    Write-Host "blah $inFile blah"
    $outFile = "$inFile" + ".bin"
    dotnet run "$inFile" "$outFile"
}
Set-Location -Path ../