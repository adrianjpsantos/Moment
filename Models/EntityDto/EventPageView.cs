using Moment.Models.Entity;

namespace Moment.Models.EntityDto
{
    public class EventPageView
    {

        public Guid Id;
        public string? Name;
        public string? Resume;
        public string? Description;
        public string? Image;
        public string? Terms;
        public string? Date;

        public UserInfo? UserInfo;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string? CityAndState { get; set; }

        public List<Convention>? Conventions { get; set; }
    }


}