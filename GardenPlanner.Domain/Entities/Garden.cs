using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace GardenPlanner.Domain.Entities;

///<summary>Defines one plot of the Garden </summary>
public class LandPlot{
    /// <remarks>Unique id of the landplot. Eg.: "Cucumber","1st plot","guid" </remarks>
    public required string Id {get; set;}
    /// <remarks>In meter </remarks>
    public int Width {get; set;}
    /// <remarks>In meter </remarks>
    public int Height {get; set;}
    /// <remarks>In m² </remarks>
    public double Area => Width * Height;
    public bool Available {get; set;}
}

public class Garden {
    public Garden(double totalSpace){
        SpaceAll = totalSpace;
    }

    /// <remarks>In m² </remarks>
    public double SpaceAll {get; set;}
    /// <remarks>In m² </remarks>
    public double SpaceAvailable => SpaceAll - SpaceUsed;
    /// <remarks>In m² </remarks>
    public double SpaceUsed {get; set;}
    private readonly List<LandPlot> landPlots = new();
    private void SetUsedSpace(List<LandPlot> landPlots){
        double SpaceUsed = 0;
        landPlots.ForEach(LandPlot =>{
            if(!LandPlot.Available) {
                SpaceUsed += SpaceUsed + LandPlot.Area;
            }
        });
    }
    public bool AddLandPlot(LandPlot landPlot)
    {
        if (landPlot.Area <= SpaceAvailable)
        {
            landPlots.Add(landPlot);
            SpaceUsed += landPlot.Area;
            SetUsedSpace(landPlots);
            return true;
        }
        return false;
    }
    public bool RemoveLandPlot(LandPlot landPlot)
    {
        int iRemovableIndex = landPlots.FindIndex(LandElement => LandElement.Id == landPlot.Id);
        if (iRemovableIndex != -1){
            landPlots.RemoveAt(iRemovableIndex);
            SetUsedSpace(landPlots);
            return true;
        }
        else{
            return false;
        }
    }
}