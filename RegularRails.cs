namespace Itmo.ObjectOrientedProgramming.Lab1;

public class RegularRails : IRouteSection
{
    public double Length { get; private set; }

    public RegularRails(double length)
    {
        this.Length = length;
    }

    public CommunicationBetweenSegments InteractWithTrain(Train train, CommunicationBetweenSegments communicationBetweenSegments)
    {
        if (train.Speed == 0)
        {
            return CommunicationBetweenSegments.CreateFailResult();
        }

        double distanceLeft = Length - communicationBetweenSegments.DistanceLeft ?? Length;
        double time = 0;
        while (distanceLeft >= 0)
        {
            time += train.Accuracy;
            distanceLeft -= train.Speed * train.Accuracy;
        }

        distanceLeft = double.Abs(distanceLeft);
        return CommunicationBetweenSegments.CreateTimeAndPartLengthResult(distanceLeft, time);
    }
}