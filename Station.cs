namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : IRouteSection
{
    public double SpeedLimit { get; private set; }

    public double Workload { get; private set; }

    public Station(double speedLimit, double workload)
    {
        SpeedLimit = speedLimit;
        Workload = workload;
    }

    public CommunicationBetweenSegments InteractWithTrain(Train train, CommunicationBetweenSegments communicationBetweenSegments)
    {
        if (train.Speed > SpeedLimit)
        {
            return CommunicationBetweenSegments.CreateFailResult();
        }

        return CommunicationBetweenSegments.CreateTimeAndPartLengthResult(0, Workload);
    }
}