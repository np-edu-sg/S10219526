namespace AssignmentFinal.Models;

public class Eatery
{
    public Eatery()
    {
        Dishes = new HashSet<Dish>();
        Reservations = new HashSet<Reservation>();
    }

    public int EatyId { get; set; }
    public string EatyName { get; set; } = null!;
    public TimeSpan EatyClHr { get; set; }
    public TimeSpan EatyOpHr { get; set; }
    public int EatyCapacity { get; set; }
    public string EatyLoc { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}