// Ignore Spelling: CPW

using System.ComponentModel.DataAnnotations;

namespace CPW219eCommerceSite.Models
{
    /// <summary>
    /// Represents a single game for purchase
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Unique identifier for the game product
        /// </summary>
        [Key]
        public int GameId { get; set; }

        /// <summary>
        /// The official title of the video game
        /// </summary>
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// The sales price of the video game
        /// </summary>
        [Range(0, 1000)]
        public double Price { get; set; }

        //Todo: Add Rating
    }
}
