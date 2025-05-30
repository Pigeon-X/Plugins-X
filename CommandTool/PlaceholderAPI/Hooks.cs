using System.Collections.Generic;
using TShockAPI;

namespace PlaceholderAPI;

public class Hooks
{
    public delegate void GetTextD(GetTextArgs args);

    public class GetTextArgs
    {
        public Dictionary<string, string> List = new ();

        public TSPlayer Player { get; set; }

        public GetTextArgs(Dictionary<string, string> list, TSPlayer plr)
        {
            this.List = list;
            this.Player = plr;
        }
    }

    public static event GetTextD? PreGetText;

    public static void OnGetText(Dictionary<string, string> list, TSPlayer player)
    {
        if (PreGetText != null)
        {
            PreGetText!(new GetTextArgs(list, player));
        }
    }
}