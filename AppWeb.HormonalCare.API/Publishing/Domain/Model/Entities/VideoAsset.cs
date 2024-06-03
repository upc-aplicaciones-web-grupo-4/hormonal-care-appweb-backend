using AppWeb.HormonalCare.API.Publishing.Domain.Model.ValueObjects;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Model.Entities;

public class VideoAsset : Asset
{
    public Uri? VideoUri { get; private set; }
    
    public override bool Readable => false;
    public override bool Viewable => true;
    
    public VideoAsset() : base(EAssetType.Video) { VideoUri = null; }

    public VideoAsset(string videoUrl) : base(EAssetType.Video) => VideoUri = new Uri(videoUrl);

    public override string GetContent() => VideoUri != null ? VideoUri.AbsoluteUri : string.Empty;
}