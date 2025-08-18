public class RemoteControlCar
{
    public int speed;
    public int batteryDrain;
    public int battery = 100;
    public int distanceTravelled = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }
    
    public bool BatteryDrained()
    {
        return battery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceTravelled;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceTravelled += speed;
            battery -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

    public int GetSpeed() => speed;
    public int GetBatteryDrain() => batteryDrain;
}

public class RaceTrack
{
    public int distance; 
    
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxDrives = 100 / car.GetBatteryDrain();
        int maxDistance = maxDrives * car.GetSpeed();

        return maxDistance >= distance;
    }
}
