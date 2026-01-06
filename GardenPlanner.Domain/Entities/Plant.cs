namespace GardenPlanner.Domain.Entities;

/// <summary>
/// Defines the "Plant" class, contains the attributes of one specific plant.
/// </summary>
public class Plant{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    /// <remarks>In m² </remarks>
    public double SpaceRequired {get; set;}
    public DateTime PlantingDate {get; set;}
}