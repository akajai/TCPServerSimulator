namespace TCPServer.Models
{
    public struct SetSpeedCommand
    {
        //Command
        int Cmd=0x2004;// SetSpeedMult
        int SpeedMult;// Speed multiplier value(percent 1 – 100)

        public SetSpeedCommand(int speedMult)
        {
            SpeedMult = speedMult;
        }
    }
}
