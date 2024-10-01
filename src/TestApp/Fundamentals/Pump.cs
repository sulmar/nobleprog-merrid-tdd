using System;

namespace TestApp.Fundamentals;

public interface IPumpService
{
    bool Open();
    bool Close();
}

public class RealPumpService : IPumpService
{
    public bool Open()
    {
        Console.WriteLine("Send open signal");

        return true;
    }

    public bool Close()
    {
        Console.WriteLine("Send close signal");

        return true;
    }


}

public class Pump
{
    private IPumpService pumpService;

    public bool IsRunning { get; private set; }

    // Pole określające, czy pompa jest uziemiona
    private bool isGrounded;

    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
    }

    // Prędkość przepływu paliwa (litry na sekundę)
    private double flowRate;

    // Konstruktor który przyjmuje prędkość przepływu
    public Pump(IPumpService pumpService, double flowRate)
    {
        this.isGrounded = false;
        this.flowRate = flowRate;
        this.pumpService = pumpService;
    }


    public Pump(double flowRate)
        : this(new RealPumpService(), flowRate)
    {

    }

    // Symulacja uziemienia pompy
    public void Ground()
    {
        isGrounded = true;
    }

    public void Start()
    {

        if (!IsGrounded)
            throw new System.InvalidOperationException();



        if (isGrounded)
        {
            pumpService.Open();

            IsRunning = true;
        }
    }

    public void Stop()
    {
        if (IsRunning)
            IsRunning = false;
    }

    // Metoda do obliczania czasu tankowania (w sekundach)
    public double CalculateRefuelTime(double fuelAmount)
    {
        double time = fuelAmount / flowRate;

        return time;
    }
}
