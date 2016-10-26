#! /bin/sh

home="`dirname \"$0\"`"/
src=$home/src
tmp="${TMPDIR}GitVersion"

mono "$src/.nuget/nuget.exe" restore "$src"

xbuild "$src/GitVersion.sln" || exit $?

rm -r "$tmp"
mkdir "$tmp" || exit $?

echo Copying tools to $tmp
cp -r "$home/build/NuGetCommandLineBuild/tools" "$tmp" || exit $?

mono $tmp/tools/GitVersion.exe -l console -output buildserver -updateAssemblyInfo || exit $?

rm -r "$tmp"
