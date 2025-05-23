namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface IRouteSection
{
    CommunicationBetweenSegments InteractWithTrain(Train train, CommunicationBetweenSegments communicationBetweenSegments);
}
