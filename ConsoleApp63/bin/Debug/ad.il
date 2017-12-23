
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly ConsoleApp63
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0C 43 6F 6E 73 6F 6C 65 41 70 70 36 33 00   // ...ConsoleApp63.
                                                                                              00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0C 43 6F 6E 73 6F 6C 65 41 70 70 36 33 00   // ...ConsoleApp63.
                                                                                                00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 31 37 00 00 )                            //  2017..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 34 65 31 32 33 64 36 38 2D 30 61 64 64   // ..$4e123d68-0add
                                                                                                  2D 34 30 63 63 2D 39 66 65 61 2D 39 37 35 36 39   // -40cc-9fea-97569
                                                                                                  65 30 37 30 63 63 36 00 00 )                      // e070cc6..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1A 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 37 01 00 54   // ,Version=v4.7..T
                                                                                                        0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C   // ..FrameworkDispl
                                                                                                        61 79 4E 61 6D 65 12 2E 4E 45 54 20 46 72 61 6D   // ayName..NET Fram
                                                                                                        65 77 6F 72 6B 20 34 2E 37 )                      // ework 4.7
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module ConsoleApp63.exe
// MVID: {26665DF4-8C1A-4B2A-9DD1-462B21F37B7A}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x0A1E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi sealed ConsoleApp63.MyGenericDelegate`1<T>
       extends [mscorlib]System.MulticastDelegate
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(object 'object',
                               native int 'method') runtime managed
  {
  } // end of method MyGenericDelegate`1::.ctor

  .method public hidebysig newslot virtual 
          instance void  Invoke(!T arg) runtime managed
  {
  } // end of method MyGenericDelegate`1::Invoke

  .method public hidebysig newslot virtual 
          instance class [mscorlib]System.IAsyncResult 
          BeginInvoke(!T arg,
                      class [mscorlib]System.AsyncCallback callback,
                      object 'object') runtime managed
  {
  } // end of method MyGenericDelegate`1::BeginInvoke

  .method public hidebysig newslot virtual 
          instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
  {
  } // end of method MyGenericDelegate`1::EndInvoke

} // end of class ConsoleApp63.MyGenericDelegate`1

.class private auto ansi beforefieldinit ConsoleApp63.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       69 (0x45)
    .maxstack  3
    .locals init ([0] class ConsoleApp63.Car myCar)
    IL_0000:  nop
    IL_0001:  ldstr      "*****Agh!No encapsulation!*****\n"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  newobj     instance void ConsoleApp63.Car::.ctor()
    IL_0011:  stloc.0
    IL_0012:  ldloc.0
    IL_0013:  ldnull
    IL_0014:  ldftn      void ConsoleApp63.Program::CallWhenExploded(string)
    IL_001a:  newobj     instance void ConsoleApp63.Car/CarEngineHandler::.ctor(object,
                                                                                native int)
    IL_001f:  stfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::listOfHandlers
    IL_0024:  ldloc.0
    IL_0025:  ldc.i4.s   10
    IL_0027:  callvirt   instance void ConsoleApp63.Car::Accelerate(int32)
    IL_002c:  nop
    IL_002d:  ldloc.0
    IL_002e:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::listOfHandlers
    IL_0033:  ldstr      "Hee,hee,hee...."
    IL_0038:  callvirt   instance void ConsoleApp63.Car/CarEngineHandler::Invoke(string)
    IL_003d:  nop
    IL_003e:  call       string [mscorlib]System.Console::ReadLine()
    IL_0043:  pop
    IL_0044:  ret
  } // end of method Program::Main

  .method private hidebysig static void  CallWhenExploded(string msgForCaller) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldstr      "\n\n"
    IL_0007:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_000c:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0011:  nop
    IL_0012:  ret
  } // end of method Program::CallWhenExploded

  .method private hidebysig static void  StringTarget(string arg) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "arg in uppercase is :{0}\n\n"
    IL_0006:  ldarg.0
    IL_0007:  callvirt   instance string [mscorlib]System.String::ToUpperInvariant()
    IL_000c:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object)
    IL_0011:  nop
    IL_0012:  ret
  } // end of method Program::StringTarget

  .method private hidebysig static void  IntTarget(int32 arg) cil managed
  {
    // Code size       24 (0x18)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "++arg is :{0}"
    IL_0006:  ldarg.0
    IL_0007:  ldc.i4.1
    IL_0008:  add
    IL_0009:  dup
    IL_000a:  starg.s    arg
    IL_000c:  box        [mscorlib]System.Int32
    IL_0011:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object)
    IL_0016:  nop
    IL_0017:  ret
  } // end of method Program::IntTarget

  .method private hidebysig static void  DisplayMessage(string msg,
                                                        valuetype [mscorlib]System.ConsoleColor txtColor,
                                                        int32 printCount) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  2
    .locals init ([0] valuetype [mscorlib]System.ConsoleColor previous,
             [1] int32 i,
             [2] bool V_2)
    IL_0000:  nop
    IL_0001:  call       valuetype [mscorlib]System.ConsoleColor [mscorlib]System.Console::get_ForegroundColor()
    IL_0006:  stloc.0
    IL_0007:  ldarg.1
    IL_0008:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_000d:  nop
    IL_000e:  ldc.i4.0
    IL_000f:  stloc.1
    IL_0010:  br.s       IL_0029

    IL_0012:  nop
    IL_0013:  ldarg.0
    IL_0014:  ldstr      "\n\n"
    IL_0019:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_001e:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0023:  nop
    IL_0024:  nop
    IL_0025:  ldloc.1
    IL_0026:  ldc.i4.1
    IL_0027:  add
    IL_0028:  stloc.1
    IL_0029:  ldloc.1
    IL_002a:  ldarg.2
    IL_002b:  clt
    IL_002d:  stloc.2
    IL_002e:  ldloc.2
    IL_002f:  brtrue.s   IL_0012

    IL_0031:  ldloc.0
    IL_0032:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0037:  nop
    IL_0038:  ret
  } // end of method Program::DisplayMessage

  .method private hidebysig static void  AddMethod(int32 x,
                                                   int32 y) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "{0}+{1}={2}\n"
    IL_0006:  ldarg.0
    IL_0007:  box        [mscorlib]System.Int32
    IL_000c:  ldarg.1
    IL_000d:  box        [mscorlib]System.Int32
    IL_0012:  ldarg.0
    IL_0013:  ldarg.1
    IL_0014:  add
    IL_0015:  box        [mscorlib]System.Int32
    IL_001a:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object,
                                                                  object)
    IL_001f:  nop
    IL_0020:  ret
  } // end of method Program::AddMethod

  .method private hidebysig static void  SubtractMethod(int32 x,
                                                        int32 y,
                                                        int32 z) cil managed
  {
    // Code size       59 (0x3b)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "{0}-{1}-{2}={3}\n"
    IL_0006:  ldc.i4.4
    IL_0007:  newarr     [mscorlib]System.Object
    IL_000c:  dup
    IL_000d:  ldc.i4.0
    IL_000e:  ldarg.0
    IL_000f:  box        [mscorlib]System.Int32
    IL_0014:  stelem.ref
    IL_0015:  dup
    IL_0016:  ldc.i4.1
    IL_0017:  ldarg.1
    IL_0018:  box        [mscorlib]System.Int32
    IL_001d:  stelem.ref
    IL_001e:  dup
    IL_001f:  ldc.i4.2
    IL_0020:  ldarg.2
    IL_0021:  box        [mscorlib]System.Int32
    IL_0026:  stelem.ref
    IL_0027:  dup
    IL_0028:  ldc.i4.3
    IL_0029:  ldarg.0
    IL_002a:  ldarg.1
    IL_002b:  sub
    IL_002c:  ldarg.2
    IL_002d:  sub
    IL_002e:  box        [mscorlib]System.Int32
    IL_0033:  stelem.ref
    IL_0034:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object[])
    IL_0039:  nop
    IL_003a:  ret
  } // end of method Program::SubtractMethod

  .method private hidebysig static int32 
          Add(int32 x,
              int32 y) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  2
    .locals init ([0] int32 V_0)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.1
    IL_0003:  add
    IL_0004:  stloc.0
    IL_0005:  br.s       IL_0007

    IL_0007:  ldloc.0
    IL_0008:  ret
  } // end of method Program::Add

  .method private hidebysig static string 
          SumToString(int32 x,
                      int32 y) cil managed
  {
    // Code size       17 (0x11)
    .maxstack  2
    .locals init ([0] int32 V_0,
             [1] string V_1)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.1
    IL_0003:  add
    IL_0004:  stloc.0
    IL_0005:  ldloca.s   V_0
    IL_0007:  call       instance string [mscorlib]System.Int32::ToString()
    IL_000c:  stloc.1
    IL_000d:  br.s       IL_000f

    IL_000f:  ldloc.1
    IL_0010:  ret
  } // end of method Program::SumToString

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class ConsoleApp63.Program

.class public auto ansi beforefieldinit ConsoleApp63.Car
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public CarEngineHandler
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method CarEngineHandler::.ctor

    .method public hidebysig newslot virtual 
            instance void  Invoke(string msgForCaller) runtime managed
    {
    } // end of method CarEngineHandler::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(string msgForCaller,
                        class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method CarEngineHandler::BeginInvoke

    .method public hidebysig newslot virtual 
            instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method CarEngineHandler::EndInvoke

  } // end of class CarEngineHandler

  .field private class ConsoleApp63.Car/CarEngineHandler Exploded
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private class ConsoleApp63.Car/CarEngineHandler AboutToBlow
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field public class ConsoleApp63.Car/CarEngineHandler listOfHandlers
  .field private bool carIsDead
  .field private int32 '<CurrentSpeed>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private int32 '<MaxSpeed>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname instance void 
          add_Exploded(class ConsoleApp63.Car/CarEngineHandler 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       41 (0x29)
    .maxstack  3
    .locals init (class ConsoleApp63.Car/CarEngineHandler V_0,
             class ConsoleApp63.Car/CarEngineHandler V_1,
             class ConsoleApp63.Car/CarEngineHandler V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::Exploded
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  stloc.1
    IL_0009:  ldloc.1
    IL_000a:  ldarg.1
    IL_000b:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_0010:  castclass  ConsoleApp63.Car/CarEngineHandler
    IL_0015:  stloc.2
    IL_0016:  ldarg.0
    IL_0017:  ldflda     class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::Exploded
    IL_001c:  ldloc.2
    IL_001d:  ldloc.1
    IL_001e:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class ConsoleApp63.Car/CarEngineHandler>(!!0&,
                                                                                                                              !!0,
                                                                                                                              !!0)
    IL_0023:  stloc.0
    IL_0024:  ldloc.0
    IL_0025:  ldloc.1
    IL_0026:  bne.un.s   IL_0007

    IL_0028:  ret
  } // end of method Car::add_Exploded

  .method public hidebysig specialname instance void 
          remove_Exploded(class ConsoleApp63.Car/CarEngineHandler 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       41 (0x29)
    .maxstack  3
    .locals init (class ConsoleApp63.Car/CarEngineHandler V_0,
             class ConsoleApp63.Car/CarEngineHandler V_1,
             class ConsoleApp63.Car/CarEngineHandler V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::Exploded
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  stloc.1
    IL_0009:  ldloc.1
    IL_000a:  ldarg.1
    IL_000b:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_0010:  castclass  ConsoleApp63.Car/CarEngineHandler
    IL_0015:  stloc.2
    IL_0016:  ldarg.0
    IL_0017:  ldflda     class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::Exploded
    IL_001c:  ldloc.2
    IL_001d:  ldloc.1
    IL_001e:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class ConsoleApp63.Car/CarEngineHandler>(!!0&,
                                                                                                                              !!0,
                                                                                                                              !!0)
    IL_0023:  stloc.0
    IL_0024:  ldloc.0
    IL_0025:  ldloc.1
    IL_0026:  bne.un.s   IL_0007

    IL_0028:  ret
  } // end of method Car::remove_Exploded

  .method public hidebysig specialname instance void 
          add_AboutToBlow(class ConsoleApp63.Car/CarEngineHandler 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       41 (0x29)
    .maxstack  3
    .locals init (class ConsoleApp63.Car/CarEngineHandler V_0,
             class ConsoleApp63.Car/CarEngineHandler V_1,
             class ConsoleApp63.Car/CarEngineHandler V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::AboutToBlow
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  stloc.1
    IL_0009:  ldloc.1
    IL_000a:  ldarg.1
    IL_000b:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_0010:  castclass  ConsoleApp63.Car/CarEngineHandler
    IL_0015:  stloc.2
    IL_0016:  ldarg.0
    IL_0017:  ldflda     class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::AboutToBlow
    IL_001c:  ldloc.2
    IL_001d:  ldloc.1
    IL_001e:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class ConsoleApp63.Car/CarEngineHandler>(!!0&,
                                                                                                                              !!0,
                                                                                                                              !!0)
    IL_0023:  stloc.0
    IL_0024:  ldloc.0
    IL_0025:  ldloc.1
    IL_0026:  bne.un.s   IL_0007

    IL_0028:  ret
  } // end of method Car::add_AboutToBlow

  .method public hidebysig specialname instance void 
          remove_AboutToBlow(class ConsoleApp63.Car/CarEngineHandler 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       41 (0x29)
    .maxstack  3
    .locals init (class ConsoleApp63.Car/CarEngineHandler V_0,
             class ConsoleApp63.Car/CarEngineHandler V_1,
             class ConsoleApp63.Car/CarEngineHandler V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::AboutToBlow
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  stloc.1
    IL_0009:  ldloc.1
    IL_000a:  ldarg.1
    IL_000b:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_0010:  castclass  ConsoleApp63.Car/CarEngineHandler
    IL_0015:  stloc.2
    IL_0016:  ldarg.0
    IL_0017:  ldflda     class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::AboutToBlow
    IL_001c:  ldloc.2
    IL_001d:  ldloc.1
    IL_001e:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class ConsoleApp63.Car/CarEngineHandler>(!!0&,
                                                                                                                              !!0,
                                                                                                                              !!0)
    IL_0023:  stloc.0
    IL_0024:  ldloc.0
    IL_0025:  ldloc.1
    IL_0026:  bne.un.s   IL_0007

    IL_0028:  ret
  } // end of method Car::remove_AboutToBlow

  .method public hidebysig specialname instance int32 
          get_CurrentSpeed() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 ConsoleApp63.Car::'<CurrentSpeed>k__BackingField'
    IL_0006:  ret
  } // end of method Car::get_CurrentSpeed

  .method private hidebysig specialname instance void 
          set_CurrentSpeed(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 ConsoleApp63.Car::'<CurrentSpeed>k__BackingField'
    IL_0007:  ret
  } // end of method Car::set_CurrentSpeed

  .method public hidebysig specialname instance int32 
          get_MaxSpeed() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 ConsoleApp63.Car::'<MaxSpeed>k__BackingField'
    IL_0006:  ret
  } // end of method Car::get_MaxSpeed

  .method private hidebysig specialname instance void 
          set_MaxSpeed(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 ConsoleApp63.Car::'<MaxSpeed>k__BackingField'
    IL_0007:  ret
  } // end of method Car::set_MaxSpeed

  .method public hidebysig instance void 
          Accelerate(int32 delta) cil managed
  {
    // Code size       176 (0xb0)
    .maxstack  3
    .locals init ([0] bool V_0,
             [1] bool V_1,
             [2] bool V_2,
             [3] bool V_3)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      bool ConsoleApp63.Car::carIsDead
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  brfalse    IL_00af

    IL_000e:  nop
    IL_000f:  ldarg.0
    IL_0010:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::Exploded
    IL_0015:  ldnull
    IL_0016:  cgt.un
    IL_0018:  stloc.1
    IL_0019:  ldloc.1
    IL_001a:  brfalse.s  IL_0031

    IL_001c:  nop
    IL_001d:  ldarg.0
    IL_001e:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::Exploded
    IL_0023:  ldstr      "Sorry,this car is dead..."
    IL_0028:  callvirt   instance void ConsoleApp63.Car/CarEngineHandler::Invoke(string)
    IL_002d:  nop
    IL_002e:  nop
    IL_002f:  br.s       IL_00ae

    IL_0031:  nop
    IL_0032:  ldarg.0
    IL_0033:  ldarg.0
    IL_0034:  call       instance int32 ConsoleApp63.Car::get_CurrentSpeed()
    IL_0039:  ldarg.1
    IL_003a:  add
    IL_003b:  call       instance void ConsoleApp63.Car::set_CurrentSpeed(int32)
    IL_0040:  nop
    IL_0041:  ldc.i4.s   10
    IL_0043:  ldarg.0
    IL_0044:  call       instance int32 ConsoleApp63.Car::get_MaxSpeed()
    IL_0049:  ldarg.0
    IL_004a:  call       instance int32 ConsoleApp63.Car::get_CurrentSpeed()
    IL_004f:  sub
    IL_0050:  bne.un.s   IL_005d

    IL_0052:  ldarg.0
    IL_0053:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::AboutToBlow
    IL_0058:  ldnull
    IL_0059:  cgt.un
    IL_005b:  br.s       IL_005e

    IL_005d:  ldc.i4.0
    IL_005e:  stloc.2
    IL_005f:  ldloc.2
    IL_0060:  brfalse.s  IL_0075

    IL_0062:  nop
    IL_0063:  ldarg.0
    IL_0064:  ldfld      class ConsoleApp63.Car/CarEngineHandler ConsoleApp63.Car::AboutToBlow
    IL_0069:  ldstr      "Carefully buddy!Gonna blow!"
    IL_006e:  callvirt   instance void ConsoleApp63.Car/CarEngineHandler::Invoke(string)
    IL_0073:  nop
    IL_0074:  nop
    IL_0075:  ldarg.0
    IL_0076:  call       instance int32 ConsoleApp63.Car::get_CurrentSpeed()
    IL_007b:  ldarg.0
    IL_007c:  call       instance int32 ConsoleApp63.Car::get_MaxSpeed()
    IL_0081:  clt
    IL_0083:  ldc.i4.0
    IL_0084:  ceq
    IL_0086:  stloc.3
    IL_0087:  ldloc.3
    IL_0088:  brfalse.s  IL_0095

    IL_008a:  nop
    IL_008b:  ldarg.0
    IL_008c:  ldc.i4.1
    IL_008d:  stfld      bool ConsoleApp63.Car::carIsDead
    IL_0092:  nop
    IL_0093:  br.s       IL_00ad

    IL_0095:  nop
    IL_0096:  ldstr      "CurrentSpeed={0}"
    IL_009b:  ldarg.0
    IL_009c:  call       instance int32 ConsoleApp63.Car::get_CurrentSpeed()
    IL_00a1:  box        [mscorlib]System.Int32
    IL_00a6:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object)
    IL_00ab:  nop
    IL_00ac:  nop
    IL_00ad:  nop
    IL_00ae:  nop
    IL_00af:  ret
  } // end of method Car::Accelerate

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   100
    IL_0003:  stfld      int32 ConsoleApp63.Car::'<MaxSpeed>k__BackingField'
    IL_0008:  ldarg.0
    IL_0009:  call       instance void [mscorlib]System.Object::.ctor()
    IL_000e:  nop
    IL_000f:  ret
  } // end of method Car::.ctor

  .event ConsoleApp63.Car/CarEngineHandler Exploded
  {
    .addon instance void ConsoleApp63.Car::add_Exploded(class ConsoleApp63.Car/CarEngineHandler)
    .removeon instance void ConsoleApp63.Car::remove_Exploded(class ConsoleApp63.Car/CarEngineHandler)
  } // end of event Car::Exploded
  .event ConsoleApp63.Car/CarEngineHandler AboutToBlow
  {
    .addon instance void ConsoleApp63.Car::add_AboutToBlow(class ConsoleApp63.Car/CarEngineHandler)
    .removeon instance void ConsoleApp63.Car::remove_AboutToBlow(class ConsoleApp63.Car/CarEngineHandler)
  } // end of event Car::AboutToBlow
  .property instance int32 CurrentSpeed()
  {
    .get instance int32 ConsoleApp63.Car::get_CurrentSpeed()
    .set instance void ConsoleApp63.Car::set_CurrentSpeed(int32)
  } // end of property Car::CurrentSpeed
  .property instance int32 MaxSpeed()
  {
    .get instance int32 ConsoleApp63.Car::get_MaxSpeed()
    .set instance void ConsoleApp63.Car::set_MaxSpeed(int32)
  } // end of property Car::MaxSpeed
} // end of class ConsoleApp63.Car


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file D:\D\ConsoleApp63\ConsoleApp63\bin\Debug\ad.res
