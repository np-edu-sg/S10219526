namespace AssignmentFinal.Models;

public class PassengerContactNo
{
    public int PgrId { get; set; }
    public string ContactNo { get; set; } = null!;

    public virtual Passenger Pgr { get; set; } = null!;
}