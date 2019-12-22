using System;

namespace hiring_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "Hiring Problem (Rate Calendar).xlsx";
            var sheetNo = 0;
            var solution = new Solution();
            var dataTable = solution.ReadExcelDocument(filePath, sheetNo);
            var rateCalendarItems = solution.GetRateCalendarItem(dataTable);
            var rateCalendarItems2 = solution.GetRateCalendarItems2(rateCalendarItems);
            for (int i = 0; i < rateCalendarItems2.Count; i++)
                Console.WriteLine(rateCalendarItems2[i].StayDateStart + " " + rateCalendarItems2[i].StayDateEnd + " " + rateCalendarItems2[i].RoomTypeId + " " + rateCalendarItems2[i].AvailableRooms + " " + rateCalendarItems2[i].RoomAmount + " " + rateCalendarItems2[i].TaxAmount);
        }

    }
}
