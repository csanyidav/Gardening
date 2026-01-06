namespace GardenPlanner.Domain.Entities;

public class Task
{
    public required string Name {get; set;}
    public string Id => Name.GetHashCode().ToString()

}