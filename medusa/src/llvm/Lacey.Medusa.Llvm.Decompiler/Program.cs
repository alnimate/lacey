using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using LLVMSharp;

namespace Lacey.Medusa.Llvm.Decompiler
{
    internal sealed class Program
    {
        /// <summary>
        /// "1480643", "AAF0CD1C50D10BBCBC517779A6448DFA", "task_hash"
        /// </summary>
        private static void Main()
        {
            /*
            try
            {
                const string i16Regex = @"constant \[\d+ x i\d+\] \[(.*)\]";
                using var sr = File.OpenText(@"c:\live\gvs.txt");
                var matches = Regex.Matches(sr.ReadToEnd(), i16Regex, RegexOptions.Multiline);
                using var w = new StreamWriter(@"c:\live\01.txt", false);
                foreach (var m in matches)
                {
                    var match = (Match)m;
                    if (match.Groups.Count > 1)
                    {
                        var arr = match.Groups[1].Value
                            .Replace("i16", string.Empty)
                            .Replace(" ", string.Empty)
                            .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(byte.Parse)
                            .ToArray();

                        var value = Encoding.ASCII.GetString(arr);
                        w.WriteLine($"{value}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Process completed. Press any key.");
                Console.ReadLine();
            }

            return;
            */

            byte[] bytes = Encoding.UTF8.GetBytes(@"task_hash");
            string str = Encoding.ASCII.GetString(new byte[]
            {
                116, 97, 115, 107, 95, 104, 97, 115, 104
            });

            string str1 = Encoding.ASCII.GetString(new byte[]
            {
                37, 46, 52, 120, 37, 46, 52, 120, 0
            });

            LLVM.LinkInMCJIT();
            LLVM.InitializeX86TargetMC();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86AsmParser();
            LLVM.InitializeX86AsmPrinter();

            var success = new LLVMBool(0);
            var strPtr = Marshal.StringToHGlobalUni("1480643");
            LLVMExecutionEngineRef ee = default;

            try
            {
                if (LLVM.CreateMemoryBufferWithContentsOfFile(@"c:\live\lr01\lr_client.exe.bc",
                    out LLVMMemoryBufferRef outMemBuf,
                    out var memBufMsg) != success)
                {
                    Console.WriteLine($"Error: {memBufMsg}");
                    Console.ReadLine();
                    return;
                }

                if (LLVM.ParseBitcode(outMemBuf,
                    out LLVMModuleRef module,
                    out var pbMsg) != success)
                {
                    Console.WriteLine($"Error: {pbMsg}");
                    Console.ReadLine();
                    return;
                }

                if (LLVM.CreateExecutionEngineForModule(out ee, module,
                    out var eeMsg) != success)
                {
                    Console.WriteLine($"Error: {eeMsg}");
                    Console.ReadLine();
                    return;
                }

                /*
                if (LLVM.PrintModuleToFile(module, @"c:\live\out.ll", 
                        out var ptfMsg) != success)
                {
                    Console.WriteLine($"Error: {ptfMsg}");
                    Console.ReadLine();
                    return;
                }
                */

                using var sw = new StreamWriter(@"c:\live\01.txt", false);
                var g = LLVM.GetFirstGlobal(module);
                var i = 0;
                while (true)
                {
                    if (g.Equals(default(LLVMValueRef)))
                    {
                        break;
                    }
                    /*
                    var value = Marshal.PtrToStringAuto(g.Pointer);
                    if (!string.IsNullOrEmpty(value))
                    {
                        sw.WriteLine($"{value}");
                    }
                    */

                    sw.WriteLine($"{g}");

                    g = LLVM.GetNextGlobal(g);
                    i++;
                }

                /*
                var f = LLVM.GetFirstFunction(module);
                while (true)
                {
                    if (f.Equals(default(LLVMValueRef)))
                    {
                        break;
                    }

                    try
                    {
                        var res = LLVM.RunFunction(ee, f, new[]
                        {
                            new LLVMGenericValueRef(strPtr)
                        });
                        Console.WriteLine(Marshal.PtrToStringAuto(res.Pointer));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    f = LLVM.GetNextFunction(f);
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Marshal.FreeHGlobal(strPtr);
                LLVM.DisposeExecutionEngine(ee);
            }

            Console.ReadLine();
        }
    }
}