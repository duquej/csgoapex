using System;
using System.Threading;
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
        private GlowStruct enemyTeam = new GlowStruct()
        {
            r = 1,
            g = 0,
            b = 0,
            a = 1,
            rwo = true,
            rwuo = true
        };

        private GlowStruct myTeam = new GlowStruct()
        {
            r = 0,
            g = 0,
            b = 1,
            a = 1,
            rwo = true,
            rwuo = true
        };

        public WallVis() {
            vam = new VAMemory(process);

        }

        private void changeOtherPlayerGlow(int baseClientAddress, GlowStruct team, int entityListAddr) {

            int address = entityListAddr + Utils.glowIndexOffset;
            int otherPlayerGlowIndex = vam.ReadInt32((IntPtr)address);

            address = baseClientAddress + Utils.glowObjectOffset;
            int glowObject = vam.ReadInt32((IntPtr)address);

            int calculation = otherPlayerGlowIndex * 0x38 + 0x4;
            int current = glowObject + calculation;
            vam.WriteFloat((IntPtr)current, team.r);

            calculation = otherPlayerGlowIndex * 0x38 + 0x8;
            current = glowObject + calculation;
            vam.WriteFloat((IntPtr)current, team.g);

            calculation = otherPlayerGlowIndex * 0x38 + 0xC;
            current = glowObject + calculation;
            vam.WriteFloat((IntPtr)current, team.b);

            calculation = otherPlayerGlowIndex * 0x38 + 0x10;
            current = glowObject + calculation;
            vam.WriteFloat((IntPtr)current, team.a);

            calculation = otherPlayerGlowIndex * 0x38 + 0x24;
            current = glowObject + calculation;
            vam.WriteBoolean((IntPtr)current, team.rwo);

            calculation = otherPlayerGlowIndex * 0x38 + 0x25;
            current = glowObject + calculation;
            vam.WriteBoolean((IntPtr)current, team.rwuo);


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

                    if (myTeamId == otherTeamId) {
                        changeOtherPlayerGlow(baseClientAddress, myTeam, entityListAddr);

                    } else
                    {
                        changeOtherPlayerGlow(baseClientAddress, enemyTeam, entityListAddr);
                    }
                }
            }
        }
        public void enableWalling() {
            int clientBaseAddress = Utils.fetchClientBaseAddress(process);

            if (clientBaseAddress != -1)
            {

                isWallingEnabled = true;
                int address = clientBaseAddress + Utils.localPlayerOffset;
                int playerAddress = vam.ReadInt32((IntPtr)address);

                address = playerAddress + Utils.teamOffset;
                int myTeamId = vam.ReadInt32((IntPtr)address);

                while (isWallingEnabled) {
                    updateWallingIteration(clientBaseAddress, myTeamId);
                    Thread.Sleep(10);

                }

            }
            else {
                throw new System.InvalidOperationException("CSGO is not running.");
                //throw an exception?
                //an error occured message display.

            }

        }

        public void disableWalling()
        {
            isWallingEnabled = false;

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
