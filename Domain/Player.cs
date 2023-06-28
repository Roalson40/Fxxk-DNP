using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Range(18,99)]
    public int Age { get; set; }
    
    public string? Phone { get; set; }
    
    [Range(1000.00,5000.00)]
    public double MembershipFee { get; set; }
    
    [Required]
    public string MembershipType { get; set; }
    
    public ICollection<HoleScore> HoleScores { get; set; }

    public Player(string name, int age, string? phone, double membershipFee, string membershipType)
    {
        Name = name;

        Age = age;

        Phone = phone;

        MembershipFee = membershipFee;

        MembershipType = membershipType;

        HoleScores = new List<HoleScore>();
    }
}