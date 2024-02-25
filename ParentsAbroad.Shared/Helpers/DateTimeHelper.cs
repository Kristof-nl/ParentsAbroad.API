namespace ParentsAbroad.Shared.Helpers
{
    public class DateTimeHelper
    {
        public static int GetDifferenceInYears(DateTime birthDay)
        {
            var todayDate = DateTime.Today;

            var yearsDifference = (todayDate.Year - birthDay.Year - 1) + (((todayDate.Month > birthDay.Month) ||
                ((todayDate.Month == birthDay.Month) && (todayDate.Day >= birthDay.Day))) ? 1 : 0);

            return yearsDifference;
        }
    }
}
