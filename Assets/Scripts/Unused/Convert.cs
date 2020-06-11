using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldBrawlStarsModTools
{
    public static class Convert
    {
        public static int ToInt(string strInt)
        {
            int i = 0;

            try
            {
                i = Int32.Parse(strInt);
            }
            catch { }

            return i;
        }

        public static string ToString(string strString)
        {
            return strString.Replace("\"", "");
        }

        public static bool ToBool(string strBool)
        {
            bool b = false;

            try
            {
                b = bool.Parse(strBool.Replace("\"", ""));
            }
            catch { }

            return b;
        }

        public static string ToCsvString(string input)
        {
            if (input.Length > 0)
                return "\"" + input + "\"";

            return "";
        }

        public static string ToCsvString(bool input)
        {
            if (input)
                return "\"true\"";

            return "";
        }

        public static string ToCsvString(int input)
        {
            if (input != 0)
                return input.ToString();

            return "";
        }
    }
}