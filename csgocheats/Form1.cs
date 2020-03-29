using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csgocheats
{
    public partial class main : Form
    {
        static int client;
        static string process = "csgo";
        static int address = 0x0;
        static VAMemory vam;
        public Boolean wallHacksEnabled = false;

        public main()
        {
            vam = new VAMemory(process);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GhostHackButton_Click(object sender, EventArgs e)
        {
            wallHacksEnabled = true;
            if (getModuleAddy()) {

                if (wallHacksEnabled)
                {
                    wallHacksDeactivate.Enabled = true;
                    ghostHackButton.Enabled = false;

                }
                


                while (wallHacksEnabled) {
                    
                    GlowStruct enemy = new GlowStruct() {
                        r = 1,
                        g = 0,
                        b = 0,
                        a = 1,
                        rwo = true,
                        rwuo = true
                    };

                    GlowStruct team = new GlowStruct()
                    {
                        r = 0,
                        g = 0,
                        b = 1,
                        a = 1,
                        rwo = true,
                        rwuo = true
                    };

                    int address;
                    int i = 1;

                    do
                    {
                        address = client + Offsets.oLocalPlayer;
                        int player = vam.ReadInt32((IntPtr)address);

                        address = player + Offsets.oTeam;
                        int myTeam = vam.ReadInt32((IntPtr)address);

                        address = client + Offsets.oEntityList + (i - 1) * 0x10;
                        int entityList = vam.ReadInt32((IntPtr)address);

                        address = entityList + Offsets.oTeam;
                        int otherTeam = vam.ReadInt32((IntPtr)address);

                        address = entityList + Offsets.oDormant;

                        if (!vam.ReadBoolean((IntPtr)address))
                        {
                            address = entityList + Offsets.oGlowIndex;
                            int glowIndex = vam.ReadInt32((IntPtr)address);

                            if (myTeam == otherTeam)
                            {
                                address = client + Offsets.oGlowObject;
                                int glowObject = vam.ReadInt32((IntPtr)address);

                                int calculation = glowIndex * 0x38 + 0x4;
                                int current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, team.r);

                                calculation = glowIndex * 0x38 + 0x8;
                                current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, team.g);

                                calculation = glowIndex * 0x38 + 0xC;
                                current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, team.b);

                                calculation = glowIndex * 0x38 + 0x10;
                                current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, team.a);

                                calculation = glowIndex * 0x38 + 0x24;
                                current = glowObject + calculation;
                                vam.WriteBoolean((IntPtr)current, team.rwo);

                                calculation = glowIndex * 0x38 + 0x25;
                                current = glowObject + calculation;
                                vam.WriteBoolean((IntPtr)current, team.rwuo);



                            }
                            else
                            {

                                address = client + Offsets.oGlowObject;
                                int glowObject = vam.ReadInt32((IntPtr)address);

                                int calculation = glowIndex * 0x38 + 0x4;
                                int current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, enemy.r);

                                calculation = glowIndex * 0x38 + 0x8;
                                current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, enemy.g);

                                calculation = glowIndex * 0x38 + 0xC;
                                current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, enemy.b);

                                calculation = glowIndex * 0x38 + 0x10;
                                current = glowObject + calculation;
                                vam.WriteFloat((IntPtr)current, enemy.a);

                                calculation = glowIndex * 0x38 + 0x24;
                                current = glowObject + calculation;
                                vam.WriteBoolean((IntPtr)current, enemy.rwo);

                                calculation = glowIndex * 0x38 + 0x25;
                                current = glowObject + calculation;
                                vam.WriteBoolean((IntPtr)current, enemy.rwuo);

                            }

                        }
                        i++;




                    }
                    while (i < 65);
                    Thread.Sleep(10);
                    //DO SOMETHING.


                }



            }
            




        }



        public bool getModuleAddy() {
            try {
                Process[] p = Process.GetProcessesByName(process);
                if (p.Length > 0)
                {
                    foreach (ProcessModule m in p[0].Modules)
                    {
                        if (m.ModuleName == "client_panorama.dll")
                        {
                            client = (int)m.BaseAddress;
                            return true;

                        }
                   
                    }
                    return true;


                }
                else {
                    return false;
                }


            }
            catch (Exception e) {
                return false;

            }


        }

        public struct GlowStruct {
            public float r;
            public float g;
            public float b;
            public float a;
            public bool rwo;
            public bool rwuo;

        }

        public class Offsets {
            public static int oLocalPlayer = 0xD30B94;  //Likely works
            public static int oTeam = 0xF4; 
            public static int oGlowIndex = 0xA428; //likely works
            public static int oGlowObject = 0x528C8D8; //likely works
            public static int oEntityList = 0x4D44A24; //likely works
            public static int oDormant = 0xED; //likely works
        }

        private void WallHacksDeactivate_Click(object sender, EventArgs e)
        {
            wallHacksEnabled = false;
            wallHacksDeactivate.Enabled = false;
            ghostHackButton.Enabled = true;



        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void DebugEnableWalls_Click(object sender, EventArgs e)
        {
            WallVis walls = new WallVis();
            walls.enableWalling();
        }
    }
}
