# bson_unreal
Example Unreal Engine 4.14 Project that links against libbson as a thirdparty library.
The supported platforms are windows x64 and linux.

## Usage notes
To see this plugin in action, drop a MyBSONActor in your scene and hit the Play Button in the Editor.
Open the log window and check the output there for the following json string: 
    { "foo" : { "baz" : 1 } }

## Build
- The windows library has been built with VS2015 Community on Win64
- The linux library has been built with gcc 4.8 via:

>    (export CFLAGS="$CFLAGS -fPIC"; ./configure --prefix=/tmp/libbson --enable-static=yes --enable-shared=no --enable-tests=no)
> 
>    make && make install

## Potential problems 
libbson comes with a configure scripts that adjusts the header files depending on your plattform.
If you run into compilation problems, 
you might be advised to build your own libbson on your platform and place the created header and lib files into the appropriate subdirectory of the ThirdParty/ folder.

- Building instructions: http://mongoc.org/libbson/1.3.5/installing.html
- Building instructions for Windows: http://mongoc.org/libbson/1.3.5/installing.html#building-windows
