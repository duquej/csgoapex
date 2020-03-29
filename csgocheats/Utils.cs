
using System.Threading;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgocheats
{
    class Utils
    {        
        public static int localPlayerOffset = 0xD30B94;  //Likely works
        public static int teamOffset = 0xF4;
        public static int glowIndexOffset = 0xA428; //likely works
        public static int glowObjectOffset = 0x528C8D8; //likely works
        public static int entityListOffset = 0x4D44A24; //likely works
        public static int dormantOffset = 0xED; //likely works
        

        private static int getClientBaseAddressFromProcess(Process p) {

            foreach (ProcessModule module in p.Modules) {
                if (module.ModuleName == "client_panorama.dll")
                {
                    return (int)module.BaseAddress;

                }

            }
            return -1;
        }

        /** 
         * Returns -1 if an address could not be fetched from process.
         */
        public static int fetchClientBaseAddress(String process)
        {
            try {
                Process[] processes = Process.GetProcessesByName(process);
                if (process.Length != 0)
                {
                    int clientBaseAddress = getClientBaseAddressFromProcess(processes[0]);
                    return clientBaseAddress;
                }
                else {
                    return -1;
                }
            }
            catch (Exception e) {
                return -1;
            }

        }      
    }
}
