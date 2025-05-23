namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public double Weight { get; private set; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double Accuracy { get; private set; }

    public double MaxForce { get; private set; }

    public Train(double weight, double maxForce, double accuracy)
    {
        this.Weight = weight;
        this.Speed = 0;
        this.Acceleration = 0;
        this.MaxForce = maxForce;
        this.Accuracy = accuracy;
    }

    public bool RecalculateParameters(double force)
    {
        if (force > MaxForce)
        {
            return false;
        }

        this.Acceleration = force / Weight;
        this.Speed += Acceleration * Accuracy;
        return true;
    }
}