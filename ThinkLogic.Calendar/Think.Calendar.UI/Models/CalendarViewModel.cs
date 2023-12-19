using Think.Calendar.Application.Model;

namespace Think.Calendar.UI.Models
{
    public class CalendarViewModel
    {
        public int CurrentDay { get; private set; }
        public int CurrentMonth { get; private set; }
        public int CurrentYear { get; private set; }
        public DateTime CurrentDate { get; private set; }


        public int SelectedDay { get; set; }
        public DateTime SelectedDate { get; set; }

        public IEnumerable<CalendarEventDTO> Events { get; set; }

        public CalendarViewModel(DateTime selectedDate)
        {
            SetCurrentDate();
            SelectedDate = selectedDate;
            SelectedDay = selectedDate.Day;
           
        }

        public CalendarViewModel()
        {      
            SetCurrentDate();
            SelectedDay = CurrentDay;
            SelectedDate = CurrentDate;
        }

        private void SetCurrentDate()
        {
            CurrentDate = DateTime.Now.Date;
            CurrentDay = CurrentDate.Day;
            CurrentMonth = CurrentDate.Month;
            CurrentYear = CurrentDate.Year;
        }
    }
}
