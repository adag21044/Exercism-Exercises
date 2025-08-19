static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime dt = DateTime.Parse(appointmentDateDescription);
        return dt;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        if( DateTime.Now > appointmentDate)
        {
            return true;
        }

        return false;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if(appointmentDate.Hour >= 12 && appointmentDate.Hour < 18)
            return true;
        
        return false;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}.";
    }


    public static DateTime AnniversaryDate()
    {
        int thisYear = DateTime.Now.Year;
        DateTime anniversary = new DateTime(thisYear, 9, 15);
        return anniversary;
    }
}
