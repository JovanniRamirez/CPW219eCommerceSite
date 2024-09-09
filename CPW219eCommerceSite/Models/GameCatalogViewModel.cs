namespace CPW219eCommerceSite.Models
{
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int lastPage, int currentPage)
        {
            Games = games;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Game> Games { get; private set; }

        /// <summary>
        /// Current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Last page of the catalog. Calculated by having the total
        /// number of products divided by the number of products per page
        /// </summary>
        public int LastPage { get; private set; }
    }
}
