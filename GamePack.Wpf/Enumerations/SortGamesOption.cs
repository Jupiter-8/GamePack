using System.ComponentModel;

namespace GamePack.Wpf.Enumerations
{
    public enum SortGamesOption
    {
        [Description("Title ascending")]
        TitleAscending,

        [Description("Title descending")]
        TitleDescending,

        [Description("Last played ascending")]
        LastPlayedAscending,

        [Description("Last played descending")]
        LastPlayedDescending,
    }
}
