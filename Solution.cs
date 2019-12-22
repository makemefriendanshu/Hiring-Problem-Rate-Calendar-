using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;


namespace hiring_problem
{
    class Solution
    {
        public List<RateCalendarItem> GetRateCalendarItem(DataTable dataTable)
        {
            var rateCalendarItems = new List<RateCalendarItem>();
            int i = 0;
            for (i = 0; i < dataTable.Rows.Count; i++)
            {
                var rateCalendarItem = new RateCalendarItem();

                rateCalendarItem.StayDate = DateTime.Parse(dataTable.Rows[i].ItemArray[0].ToString());
                rateCalendarItem.RoomTypeId = dataTable.Rows[i].ItemArray[1].ToString();
                rateCalendarItem.AvailableRooms = Int32.Parse(dataTable.Rows[i].ItemArray[2].ToString());
                rateCalendarItem.RoomAmount = decimal.Parse(dataTable.Rows[i].ItemArray[3].ToString());
                rateCalendarItem.TaxAmount = decimal.Parse(dataTable.Rows[i].ItemArray[4].ToString());

                rateCalendarItems.Add(rateCalendarItem);
            }

            return rateCalendarItems;
        }
        public List<RateCalendarItem2> GetRateCalendarItems2(List<RateCalendarItem> rateCalendarItems)
        {
            var rateCalendarItems2 = new List<RateCalendarItem2>();
            int i = 0;
            while (i < rateCalendarItems.Count)
            {
                int j = i;
                while (j < rateCalendarItems.Count && rateCalendarItems[i].RoomAmount == rateCalendarItems[j].RoomAmount && rateCalendarItems[i].AvailableRooms == rateCalendarItems[j].AvailableRooms)
                {
                    j++;
                }
                var rateCalendarItem2 = new RateCalendarItem2();
                rateCalendarItem2.StayDateStart = rateCalendarItems[i].StayDate;
                rateCalendarItem2.StayDateEnd = rateCalendarItems[j - 1].StayDate;
                rateCalendarItem2.RoomTypeId = rateCalendarItems[i].RoomTypeId;
                rateCalendarItem2.AvailableRooms = rateCalendarItems[i].AvailableRooms;
                rateCalendarItem2.RoomAmount = rateCalendarItems[i].RoomAmount;
                rateCalendarItem2.TaxAmount = rateCalendarItems[i].TaxAmount;
                rateCalendarItems2.Add(rateCalendarItem2);
                i = j;
            }
            return rateCalendarItems2;
        }
        public DataTable ReadExcelDocument(string filePath, int sheetNo)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                var dataSet = reader.AsDataSet(conf);
                var dataTable = dataSet.Tables[sheetNo];

                return dataTable;
            }
        }
    }

}