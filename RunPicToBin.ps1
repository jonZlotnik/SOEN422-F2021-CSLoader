$filesToConvert = Get-ChildItem -Path ./TestPicToBin
Set-Location -Path PicToBin
dotnet build -o bin
foreach ($picFile in $filesToConvert) {
    $inFile = $picFile.FullName
    $outFile = "$inFile" + ".bin"
    ./bin/PicToBin.exe "$inFile" "$outFile"
}
Set-Location -Path ../