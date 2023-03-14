using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer.Models
{
    public struct GetState
    {
        int Cmd = 0x11;// GetState
        int J1PoseCurrent;// Current pose of Joint 1
        int J1PoseTarget;// Target pose of Joint 1
        int J1SpeedCurrent;// Current speed of Joint 1
        int J2PoseCurrent;// Current pose of Joint 2
        int J2PoseTarget;// Target pose of Joint 2
        int J2SpeedCurrent;// Corrent speed of Joint 2
        int J3PoseCurrent;// Current pose of Joint 3
        int J3PoseTarget;// Target pose of Joint 3
        int J3SpeedCurrent;// Current speed of Joint 3
        int J4PoseCurrent;// Current pose of Joint 4
        int J4PoseTarget;// Target pose of Joint 4
        int J4SpeedCurrent;// Current speed of Joint 4
        byte IsAtTargets;// bits 0..3 represents Joint 1..4 being on target(1) or not(0)
        byte HomingStates;// bits 0..1 Joint 1, 2..3 Joint 2, etc.homing state.See Homing
        byte UnwindLevels;// bits 0..1 Joint 1, 2..3 Joint 2, etc.unwind levels. See Unwind
        byte OperatingMode;// Global operating mode of device (not per Joint)
        ushort EStopSensorsSHS;// State of E-Stop and sensors and summed homing state
                               //bits 0: Estop
                               //bits 1..3: A-End/B-End/Home of Joint 1,
                               //bits 4..6: A-End/B-End/Home of Joint 2,
                               //bits 7..9: A-End/B-End/Home of Joint 3,
                               //bits 10..12: A-End/B-End/Home of Joint 4,
                               //bit 13: summed homing state(smallest value per Joints)
        byte SpdMult;// Current speed multiplier(in percent
        int extra = 0;

        public GetState(int j1PoseCurrent, int j1PoseTarget, int j1SpeedCurrent, int j2PoseCurrent, int j2PoseTarget, int j2SpeedCurrent, int j3PoseCurrent, int j3PoseTarget, int j3SpeedCurrent, int j4PoseCurrent, int j4PoseTarget, int j4SpeedCurrent, byte isAtTargets, byte homingStates, byte unwindLevels, byte operatingMode, ushort eStopSensorsSHS, byte spdMult)
        {
            //Cmd = cmd;
            J1PoseCurrent = j1PoseCurrent;
            J1PoseTarget = j1PoseTarget;
            J1SpeedCurrent = j1SpeedCurrent;
            J2PoseCurrent = j2PoseCurrent;
            J2PoseTarget = j2PoseTarget;
            J2SpeedCurrent = j2SpeedCurrent;
            J3PoseCurrent = j3PoseCurrent;
            J3PoseTarget = j3PoseTarget;
            J3SpeedCurrent = j3SpeedCurrent;
            J4PoseCurrent = j4PoseCurrent;
            J4PoseTarget = j4PoseTarget;
            J4SpeedCurrent = j4SpeedCurrent;
            IsAtTargets = isAtTargets;
            HomingStates = homingStates;
            UnwindLevels = unwindLevels;
            OperatingMode = operatingMode;
            EStopSensorsSHS = eStopSensorsSHS;
            SpdMult = spdMult;
        }
    }
}
