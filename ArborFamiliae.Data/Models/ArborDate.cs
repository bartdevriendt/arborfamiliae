namespace ArborFamiliae.Data.Models;

public class ArborDate : BaseModel
{
    public int Calendar { get; set;}
    public int Modifier { get; set; }
    public int Quality { get; set; }
    
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool SlashDate1 { get; set; }
    public int Year2 { get; set; }
    public int Month2 { get; set; }
    public int Day2 { get; set; }
    public bool SlashDate2 { get; set; }
    
    public string? Text { get; set; }
    public int SortValue { get; set; }
    public int NewYear { get; set; }
    
}