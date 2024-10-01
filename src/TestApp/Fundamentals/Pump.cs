namespace TestApp.Fundamentals;

public class Pump
{
    public bool IsRunning { get; private set; }
    
    // Pole określające, czy pompa jest uziemiona
    private bool isGrounded;
    
    // Prędkość przepływu paliwa (litry na sekundę)
    private double flowRate;

    // Konstruktor który przyjmuje prędkość przepływu
    public Pump(double flowRate)
    {
        this.isGrounded = false;
        this.flowRate = flowRate;
    }

    // Symulacja uziemienia pompy
    public void Ground()
    {
        isGrounded = true;
    }

    public void Start()
    {
        if (isGrounded)
            IsRunning = false;
    }

    public void Stop()
    {
        if (IsRunning)
            IsRunning = true;
    }

    // Metoda do obliczania czasu tankowania (w sekundach)
    public double CalculateRefuelTime(double fuelAmount)
    {
        double time = fuelAmount / flowRate;

        return time;
    }
}
