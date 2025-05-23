namespace Itmo.ObjectOrientedProgramming.Lab1;

public class CommunicationBetweenSegments
{
    public bool IsSuccess { get; private set; }

    public double? DistanceLeft { get; private set; }

    public double? Time { get; private set; }

    private CommunicationBetweenSegments(bool isSuccess, double? distanceLeft, double? time)
    {
        IsSuccess = isSuccess;
        DistanceLeft = distanceLeft;
        Time = time;
    }

    public static CommunicationBetweenSegments CreateSuccessPartLength(double? distanceLeft)
    {
        return new CommunicationBetweenSegments(true, distanceLeft, null);
    }

    public static CommunicationBetweenSegments CreateFailResult()
    {
        return new CommunicationBetweenSegments(false,  null, null);
    }

    public static CommunicationBetweenSegments CreateTimeAndPartLengthResult(double? distanceLeft, double? time)
    {
        return new CommunicationBetweenSegments(true,  distanceLeft, time);
    }

    public static CommunicationBetweenSegments CreateTimeResult(double? time)
    {
        return new CommunicationBetweenSegments(true,  null, time);
    }
}