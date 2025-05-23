// using System.ComponentModel.Design;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Simulator
{
    public double SpeedLimit { get; private set; }

    public double CounterTime { get; private set; }

    public Simulator(double speedLimit)
    {
        SpeedLimit = speedLimit;
        CounterTime = 0;
    }

    public CommunicationBetweenSegments StartTheTrain(IReadOnlyList<IRouteSection> route, Train train)
    {
        int routeSegments = 0;
        var overdue = CommunicationBetweenSegments.CreateSuccessPartLength(0);
        while (routeSegments != route.Count)
        {
            overdue = route[routeSegments].InteractWithTrain(train, overdue);
            if (!overdue.IsSuccess)
            {
                return overdue;
            }

            routeSegments++;

            if (train.Speed < 0)
            {
                return CommunicationBetweenSegments.CreateFailResult();
            }

            CounterTime += overdue.Time ?? 0;
        }

        if (train.Speed > SpeedLimit)
        {
            return CommunicationBetweenSegments.CreateFailResult();
        }

        return CommunicationBetweenSegments.CreateTimeResult(CounterTime);
    }
}