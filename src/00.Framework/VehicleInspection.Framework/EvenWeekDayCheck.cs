namespace VehicleInspection.Framework
{
    public static class EvenWeekDayCheck
    {
        public static bool IsEvenInspectionDay(this DateOnly date)
        {
            return date.ToDateTime(TimeOnly.MinValue).DayOfWeek switch
            {
                DayOfWeek.Saturday => true,
                DayOfWeek.Monday => true,
                DayOfWeek.Wednesday => true,
                DayOfWeek.Friday => true,
                _ => false
            };
        }
    }
}