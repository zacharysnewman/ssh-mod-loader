using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldBrawlStarsModTools
{
    public static class Paths
    {
        public static string basePath = "/var/containers/Bundle/Application/75141517-2DC7-46B2-8F95-F508DBC2D6C2/Brawl Stars.app/res/";
        public static string updatePath = "/var/mobile/Containers/Data/Application/80AED36C-C211-40AC-8431-8DE7A87D8164/Documents/updated/";

        public static string modsPath = "Assets/Bundles/";
        public static string tutorial { get { return "csv_client/tutorial.csv"; } }
        // public static string gadgets { get { return "csv_logic/accessories.csv"; } }
        // public static string areaEffects { get { return "csv_logic/area_effects.csv"; } }
        public static string characters { get { return "csv_logic/characters.csv"; } }
        // public static string items { get { return "csv_logic/items.csv"; } }
        public static string locations { get { return "csv_logic/locations.csv"; } }
        public static string maps { get { return "csv_logic/maps.csv"; } }
        public static string projectiles { get { return "csv_logic/projectiles.csv"; } }
        public static string skills { get { return "csv_logic/skills.csv"; } }
        public static string tiles { get { return "csv_logic/tiles.csv"; } }
    }
}
