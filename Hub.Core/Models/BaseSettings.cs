namespace Hub.Core.Models
{
    public class BaseSettings
    {
        public string Environment { get; set; }
        public string BrowserType { get; set; }
        public PlaywrightSettings PlaywrightSettings { get; set; }
    }

    public class PlaywrightSettings
    {
        public bool Headless { get; set; }
        public int SlowMo { get; set; }
        public ScreenshotSettings ScreenshotSettings { get; set; }
        public RecordSettings RecordSettings { get; set; }
    }

    public class ScreenshotSettings
    {
        public string Toggle { get; set; }
        public string StoredDirectory { get; set; }
        public bool IsToggleOn => "on".Equals(Toggle.ToLower());
    }

    public class RecordSettings
    {
        public string Toggle { get; set; }
        public string StoredDirectory { get; set; }
        public bool IsToggleOn => "on".Equals(Toggle.ToLower());
    }
}