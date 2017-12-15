del .\adapter\*.cs /f
swig -c++ -csharp -namespace Fbx -I"FBX\2018.1.1\include" -outdir adapter -o fbx_wrapper\wrapper_gen.cpp fbxwapper.i
pause