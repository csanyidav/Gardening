namespace GardenPlanner.Domain.Entities;

public class Seed{
    public int Id {get; set;}

    ///External source reference (e.g. OpenFarm ID)
    public string? ExternalId {get; set;}

    public string Name {get; set;} = string.Empty;
    public int PlantId {get; set;}
    public Plant Plant {get; set;} = null!;
    public DateTime? PlantingPeriodStart {get; set;}
    public DateTime? PlantingPeriodEnd {get; set;}
    public double SpaceRequiredPerUnit {get; set;}
    public int PlannedPlanting {get; set;}
    public double TotalSpaceRequired => SpaceRequiredPerUnit * PlannedPlanting;
}