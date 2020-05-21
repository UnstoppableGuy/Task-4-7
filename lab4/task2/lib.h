#ifndef CONSOLE_LIN_H
#define CONSOLE_LIB_H

#include <iostream>
#include <string>
#include <cstring>
#include <cstdio>
#include <array>
#include <cstdlib>

using namespace std;

#ifdef __cplusplus
    extern "C" {
#endif

#ifdef BUILD_MY_DLL
    #define CONSOLE_LIB __declspec(dllexport)
#else
    #define CONSOLE_LIB __declspec(dllimport)
#endif

    int CONSOLE_LIB Length(char *arr);
    void CONSOLE_LIB SyntaxError(string filename);


#ifdef __cplusplus
    }
#endif

#endif