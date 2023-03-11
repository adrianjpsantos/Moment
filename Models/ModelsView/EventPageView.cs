namespace Moment.Models.ModelsView
{
    public class EventPageView
    {

        public Guid Id;
        public string? Name;
        public string? Resume;
        public string? Description;
        public string? Image;

        public string? Date;

        public UserInfo? UserInfo;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string? Address { get; set; }

        public List<Convention>? Conventions { get; set; }
    }


}