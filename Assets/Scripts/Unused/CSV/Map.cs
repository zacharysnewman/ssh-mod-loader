using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldBrawlStarsModTools
{
    [System.Serializable]
    public class Map
    {
        public string CodeName;
        public string Group;
        public string Data;
        public bool ConstructFromBlocks;

        public Map(string csvRow)
        {
            var data = csvRow.Split(',');

            CodeName = Convert.ToString(data[0]);
            Group = Convert.ToString(data[1]);
            Data = Convert.ToString(data[2]);
            ConstructFromBlocks = Convert.ToBool(data[3]);
        }

        public string ToCsvRow()
        {
            return
            Convert.ToCsvString(CodeName) + "," +
            Convert.ToCsvString(Group) + "," +
            Convert.ToCsvString(Data) + "," +
            Convert.ToCsvString(ConstructFromBlocks) + "\n";
        }
    }
}