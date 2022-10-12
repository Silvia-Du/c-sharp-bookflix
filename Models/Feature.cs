using c_sharp_bookflix.Models;
using c_sharp_bookflix.Models.ValidationCustom;

public class Feature
{
    public int Id { get; set; }

    //[IsUniqueFeature]
    public string? Name { get; set; }
    public List<MediaInfo>? MediaInfos { get; set; }

}
