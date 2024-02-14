// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

extern "C" __declspec(dllexport) void __stdcall BubbleSort(int* nums, int count);

extern "C" __declspec(dllexport) void __stdcall BubbleSortCpp(int* nums, int count)
{
   for (int i = 0; i < count - 1; i++)
   {
      for (int j = 0; j < count - i - 1; j++)
      {
         if (nums[j] > nums[j + 1])
         {
            int tmp = nums[j];
            nums[j] = nums[j + 1];
            nums[j + 1] = tmp;
         }
      }
   }
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

