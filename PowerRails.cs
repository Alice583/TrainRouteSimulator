namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PowerRails : IRouteSection
{
    public double Length { get; private set; }

    public double Force { get; private set; }

    public PowerRails(double length, double force)
    {
        this.Length = length;
        this.Force = force;
    }

    public CommunicationBetweenSegments InteractWithTrain(Train train, CommunicationBetweenSegments communicationBetweenSegments)
    {
        if (train.Speed == 0 && Force == 0)
        {
            return CommunicationBetweenSegments.CreateFailResult();
        }

        double distanceLeft = Length - communicationBetweenSegments.DistanceLeft ?? Length;
        double time = 0;
        while (distanceLeft >= 0)
        {
            bool isSuccess = train.RecalculateParameters(this.Force);
            if (!isSuccess)
            {
                return CommunicationBetweenSegments.CreateFailResult();
            }

            if (train.Speed < 0)
            {
                return CommunicationBetweenSegments.CreateFailResult();
            }

            time += train.Accuracy;
            distanceLeft -= train.Speed * train.Accuracy;
        }

        distanceLeft = double.Abs(distanceLeft);
        return CommunicationBetweenSegments.CreateTimeAndPartLengthResult(distanceLeft, time);
    }
}