using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldBrawlStarsModTools
{
    [System.Serializable]
    public class Tile
    {
        public Tile(string csvRow)
        {
            var data = csvRow.Split(',');

        }

        public string ToCsvRow()
        {
            return "\n";
        }
    }
}