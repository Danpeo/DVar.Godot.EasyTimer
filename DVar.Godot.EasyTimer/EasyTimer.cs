using Godot;
using Timer = Godot.Timer;

namespace DVar.Godot.EasyTimer;

public class EasyTimer
{
    public Timer Timer { get; }

    public EasyTimer(Node node, Action timeOut, float waitTime = 1.0f, bool oneShot = true)
    {
        Timer = new Timer();
        Timer.OneShot = oneShot;
        Timer.WaitTime = waitTime;
        node.AddChild(Timer);
        Timer.Timeout += timeOut;
    }

    public void Start() => Timer.Start();

    public void Stop()
    {
        Timer.Stop();
        if (Timer.OneShot)
            Timer.QueueFree();
    }
}