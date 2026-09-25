/// <summary>
/// Represents the top-level GeoJSON object returned by the USGS earthquake feed.
/// Only the pieces needed for this assignment (the list of features) are modeled.
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new();
}

/// <summary>
/// Represents a single earthquake event ("feature") within the FeatureCollection.
/// Each feature has a Properties object containing the details we care about.
/// </summary>
public class Feature
{
    public Properties Properties { get; set; } = new();
}

/// <summary>
/// Represents the 'properties' object for a single earthquake, containing
/// the place description and magnitude.
/// </summary>
public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; } = "";
}