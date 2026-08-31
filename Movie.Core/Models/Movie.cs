using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Models;

public class MovieModel
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(30)]
    public string Genre { get; set; }
    [MaxLength(50)]
    public string Director { get; set; }
    public int ReleaseYear { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int DurationMinutes { get; set; }
    
    [Range(0.0,10.0)]
    public double Rating { get; set; }
    public string? Description { get; set; }
}