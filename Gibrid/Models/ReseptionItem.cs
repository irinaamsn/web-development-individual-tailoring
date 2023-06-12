using Microsoft.CodeAnalysis;

namespace Gibrid.Models
{
    public class ReseptionItem
    {
        public int Id { get; set; }
        public int SpecialistId { get; set; }
        public  Specialist? specialist { get; set; }
        public int TimeId { get; set; }
        public Time? time { get; set; }
        public string? SpecialistName { get; set; }
        public DateTime Time { get; set; }

        public string? ReseptionId { get; set; }
        public string? userId { get; set; }
    }
}
