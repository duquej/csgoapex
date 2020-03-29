using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgocheats
{
    class WallVis
    {
        private static string process = "csgo";
        private static VAMemory vam;
        private Boolean isWallingEnabled = false;

        public WallVis() {
            vam = new VAMemory(process);

        }

        private void changeOtherPlayerGlow(int baseClientAddress, GlowStruct team, int otherPlayerGlowIndex) {


        }

        private void updateWallingIteration(int baseClientAddress, int myTeamId) {
            for (int i = 1; i < 65; i++) {
                int address = baseClientAddress + Utils.entityListOffset + (i - 1) * 0x10;
                int entityListAddr = vam.ReadInt32((IntPtr)address);

                address = entityListAddr + Utils.teamOffset;
                int otherTeamId = vam.ReadInt32((IntPtr)address);

                address = entityListAddr + Utils.dormantOffset;
                Boolean isOtherPlayerDormant = vam.ReadBoolean((IntPtr)address);

                if (!isOtherPlayerDormant) {
                    address = entityListAddr + Utils.glowIndexOffset;
                    int otherPlayerGlowIndex = vam.ReadInt32((IntPtr)address);

                    if (myTeamId == otherTeamId) {

                    }

                }


            }



        }
        public void enableWalling() {
            int clientBaseAddress = Utils.fetchClientBaseAddress(process);

            if (clientBaseAddress != -1)
            {
                GlowStruct enemyTeam = new GlowStruct()
                {
                    r = 1, g = 0, b = 0, a = 1, rwo = true, rwuo = true
                };

                GlowStruct myTeam = new GlowStruct()
                {
                    r = 0, g = 0, b = 1, a = 1, rwo = true, rwuo = true
                };

                int address = clientBaseAddress + Utils.localPlayerOffset;
                int playerAddress = vam.ReadInt32((IntPtr)address);

                address = playerAddress + Utils.teamOffset;
                int myTeamId = vam.ReadInt32((IntPtr)address);

                while (true) {





                }

            }
            else {
                //throw an exception?
                //an error occured message display.

            }

        }

        public struct GlowStruct
        {
            public float r;
            public float g;
            public float b;
            public float a;
            public bool rwo;
            public bool rwuo;

        }

    }
}
