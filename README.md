Create gRPC server and client example in C#
- https://www.c-sharpcorner.com/blogs/grpc-example-in-c-sharp
- Open `learning-grpc.sln` in Visual Studio 2022 and build

Create gRPC server and client example in C++
- https://sanoj.in/2020/05/07/working-with-grpc-in-windows.html
- Install [cmake](https://cmake.org/install)
- Install [vcpkg](https://github.com/Microsoft/vcpkg#quick-start-windows) and [grpc](https://github.com/grpc/grpc/blob/v1.50.0/src/cpp/README.md)
  - `cd c:\dev\vcpkg`
  - `bootstrap-vcpkg.bat`
  - `vcpkg install grpc`
  - `vcpkg integrate install`
- Download the [helloworld](https://github.com/grpc/grpc/tree/v1.50.0/examples/cpp) example
  - Save [helloworld.proto](https://github.com/grpc/grpc/blob/v1.50.0/examples/protos/helloworld.proto) in `helloworld\protos`
  - Save the [server](https://github.com/grpc/grpc/blob/v1.50.0/examples/cpp/helloworld/greeter_server.cc) as `helloworld\src\server.cpp`
  - Save the [client](https://github.com/grpc/grpc/blob/v1.50.0/examples/cpp/helloworld/greeter_client.cc) as `helloworld\src\client.cpp`
  - Put `CMakeLists.txt` in the helloworld folder
- Generate the source files for the proto file
  - `cd d:\helloworld\protos`
  - `c:\dev\vcpkg\packages\protobuf_x64-windows\tools\protobuf\protoc -I=. --cpp_out=..\src helloworld.proto`
  - `c:\dev\vcpkg\packages\protobuf_x64-windows\tools\protobuf\protoc -I=. --grpc_out=..\src --plugin=protoc-gen-grpc="C:\dev\vcpkg\packages\grpc_x64-windows\tools\grpc\grpc_cpp_plugin.exe" helloworld.proto`
- Build the server and client
  - `cd d:\helloworld\build`
  - `cmake -G "Visual Studio 17 2022" -A x64 ../ -DCMAKE_TOOLCHAIN_FILE=c:\dev\vcpkg\scripts\buildsystems\vcpkg.cmake`
  - `cmake --build .`
- Open the built `grpc_example.sln` with Visual Studio 2022