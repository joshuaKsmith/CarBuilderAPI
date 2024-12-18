namespace CarBuilderAPI.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int WheelsId { get; set; }
    public Wheels Wheels { get; set; }
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; }
    public int PaintColorId { get; set; }
    public PaintColor PaintColor { get; set; }
    public int InteriorId { get; set; }
    public Interior Interior { get; set; }
}