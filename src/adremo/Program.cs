using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace adremo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("choose your service (notes : The program will not work without adjusting the settings! ignore this message if you have already set)");
            Console.WriteLine("1 ) Restore mods\n2 ) Delete all mods\n3 ) adjust settings ");
            string choose = Console.ReadLine();
            string patch = "";
            string mods = "";
            string[] mods_patch = {};
            int choose_toint = Convert.ToInt32(choose);
            string mainProgramDirectory = Directory.GetCurrentDirectory(); 
            if (File.Exists($@"{mainProgramDirectory}\adremoSettings.txt"))
                    {
                    try
                    {

                        using (StreamReader reader = new StreamReader($@"{mainProgramDirectory}\adremoSettings.txt"))
                        {

                            while (!reader.EndOfStream)
                            {
                                string satir = reader.ReadLine();
                                char[] strchar = satir.ToCharArray();
                                string fullchar = strchar[0].ToString() + strchar[1].ToString() + strchar[2].ToString() + strchar[3].ToString() + strchar[4].ToString();
                                if (fullchar == "patch")
                                {
                                    patch = satir.Substring(fullchar.Length + 1);
                                    
                                }else if(fullchar == "modss")
                                {
                                    mods = satir.Substring(fullchar.Length + 1);
                                    mods_patch = Directory.GetFiles(mods).Select(file => Path.GetFileName(file)).ToArray();
                            }  //Directory.GetFileSystemEntries(mods, "*", SearchOption.AllDirectories);   Directory.GetFiles(mods).Select(file => Path.GetFileName(file)).ToArray();

                        }
                    }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("file could not be read " + e.Message);
                    }
                }

           
               
            


            if (choose_toint == 0) { 
              Console.WriteLine("wrong number or you pressed a wrong key");
              Console.ReadKey();
            }else if (choose_toint == 1) {

         
                foreach (string i in mods_patch)
                {
                    try
                    {
                        
                        File.Copy(Path.Combine(mods, i), Path.Combine(patch, i), true);
                        Console.WriteLine("the file was copied successfully");
                      
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred while copying the file: " + e.Message);
                        Console.WriteLine(patch);
                        Console.WriteLine(i);
                    }
                }
                Console.ReadKey();
               
            }
            else if (choose_toint == 2) {
                Console.WriteLine("Before deleting all mods, you need to install them in a file !");
                string[] controlpatch =Directory.GetFileSystemEntries(patch, "*", SearchOption.AllDirectories); // Directory.GetFiles(patch, "*", SearchOption.AllDirectories);
                string[] patches = new string[48];
                patches[0] = $@"{patch}\.egstore";
                patches[1] = $@"{patch}\ReadMe";
                patches[2] = $@"{patch}\Redistributables";
                patches[3] = $@"{patch}\update";
                patches[4] = $@"{patch}\x64";
                patches[5] = $@"{patch}\bink2w64.dll";
                patches[6] = $@"{patch}\common.rpf";
                patches[7] = $@"{patch}\d3dcompiler_46.dll";
                patches[8] = $@"{patch}\d3dcsx_46.dll";
                patches[9] = $@"{patch}\EOSSDK-Win64-Shipping.dll";
                patches[10] = $@"{patch}\fvad.dll";
                patches[11] = $@"{patch}\GFSDK_ShadowLib.win64.dll";
                patches[12] = $@"{patch}\GFSDK_TXAA.win64.dll";
                patches[13] = $@"{patch}\GFSDK_TXAA_AlphaResolve.win64.dll";
                patches[14] = $@"{patch}\GPUPerfAPIDX11-x64.dll";
                patches[15] = $@"{patch}\GTA5.exe";
                patches[16] = $@"{patch}\libcurl.dll";
                patches[17] = $@"{patch}\NvPmApi.Core.win64.dll";
                patches[18] = $@"{patch}\opus.dll";
                patches[19] = $@"{patch}\opusenc.dll";
                patches[20] = $@"{patch}\PlayGTAV.exe";
                patches[21] = $@"{patch}\title.rgl";
                patches[22] = $@"{patch}\toxmod.dll";
                patches[23] = $@"{patch}\version.txt";
                patches[24] = $@"{patch}\x64a.rpf";
                patches[25] = $@"{patch}\x64b.rpf";
                patches[26] = $@"{patch}\x64c.rpf";
                patches[27] = $@"{patch}\x64d.rpf";
                patches[28] = $@"{patch}\x64e.rpf";
                patches[29] = $@"{patch}\x64f.rpf";
                patches[30] = $@"{patch}\x64g.rpf";
                patches[31] = $@"{patch}\x64h.rpf";
                patches[32] = $@"{patch}\x64i.rpf";
                patches[33] = $@"{patch}\x64j.rpf";
                patches[34] = $@"{patch}\x64k.rpf";
                patches[35] = $@"{patch}\x64l.rpf";
                patches[36] = $@"{patch}\x64m.rpf";
                patches[37] = $@"{patch}\x64n.rpf";
                patches[38] = $@"{patch}\x64o.rpf";
                patches[39] = $@"{patch}\x64p.rpf";
                patches[40] = $@"{patch}\x64q.rpf";
                patches[41] = $@"{patch}\x64r.rpf";
                patches[42] = $@"{patch}\x64s.rpf";
                patches[43] = $@"{patch}\x64t.rpf";
                patches[44] = $@"{patch}\x64u.rpf";
                patches[45] = $@"{patch}\x64v.rpf";
                patches[46] = $@"{patch}\x64w.rpf";
                patches[47] = $@"{patch}\zlib1.dll";
                Console.WriteLine($"the file path you gave {patch}");
                Console.WriteLine("Do you confirm the deletion? T(true)/F(false)");
                string confirm_str = Console.ReadLine();
                bool counter = false;
                int deleteFileCounter = 0;
                int verified = 0;
                foreach (string k in controlpatch) {
                    for (int a = 0; a < patches.Length; a++)
                    {
                        if (k == patches[a])
                        {
                            verified++;

                        }



                    }


                }
                if (confirm_str == "T" || confirm_str == "t" && verified >= patches.Length) {
                    foreach (string i in controlpatch)
                    {

                        for (int a = 0; a < patches.Length; a++)
                        {
                            if (i == patches[a])
                            {
                                counter = true;
                            }



                        }
                        if (counter == false)
                        {
                            try
                            {
                                if (File.Exists(i))
                                {
                                    File.Delete(i);
                                    Console.WriteLine("file deleted successfully");
                                    deleteFileCounter++;
                                }
                                else
                                {
                                    Console.WriteLine("file not found");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("An error occurred while deleting the file : " + e.Message);
                            }




                        }
                        else
                        {

                            counter = false;
                        }

                    }


                }
                else
                {
                    Console.WriteLine("canceling");
                    if (verified != patches.Length)
                    {
                        Console.WriteLine("wrong patch");

                    }
                }
                Console.WriteLine($"A total of {deleteFileCounter} files were deleted");
                Console.ReadKey();
            }else if(choose_toint == 3)
            {
                Console.WriteLine("Write the path to the mods file here");
                string mods_file = Console.ReadLine();
                Console.WriteLine("Write the path to the game(GTA V) file here");
                string game_file = Console.ReadLine();

                try
                {
                    
                    using (StreamWriter writer = new StreamWriter(mainProgramDirectory))
                    {                   
                        string data = $"patch:{game_file}\nmodss:{mods_file}";
                        writer.WriteLine(data);
                        Console.WriteLine("data printed successfully");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred while deleting the file : " + e.Message);
                }

            }











        }
    }
}
