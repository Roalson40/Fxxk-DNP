using System.ComponentModel.DataAnnotations;

namespace Domain;

public class HoleScore
{
    [Range(1,25)]
    public int HoleId { get; set; }
    
    [Key]
    public int RounderId { get; set; }
    
    [Range(1,10)]
    public int NumOfStrikes { get; set; }
}