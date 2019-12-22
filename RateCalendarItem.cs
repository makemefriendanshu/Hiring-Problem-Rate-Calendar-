using System;

public class RateCalendarItem
{
    public DateTime StayDate;      	// Calendar date of stay
    public string RoomTypeId;       // Identifies room type
    public int AvailableRooms;  	// Number of rooms available
    public decimal RoomAmount;    	// Price of a room night
    public decimal TaxAmount;    	// Taxes for a room night
}
