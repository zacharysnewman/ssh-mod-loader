using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using UnityEngine;
using Renci.SshNet;
using OldBrawlStarsModTools;

public class OldModController : MonoBehaviour
{
    private RemoteFileTransfer fileTransfer;

    [HideInInspector]
    public List<KvtContainer> tutorial;
    // [HideInInspector]
    // public List<KvtContainer> areaEffects;
    [HideInInspector]
    private List<KvtContainer> characters;
    // [HideInInspector]
    // private List<KvtContainer> gadgets;
    // [HideInInspector]
    // private List<KvtContainer> items;
    [HideInInspector]
    private List<KvtContainer> locations;
    [HideInInspector]
    private List<KvtContainer> maps;
    [HideInInspector]
    private List<KvtContainer> projectiles;
    [HideInInspector]
    private List<KvtContainer> tiles;

    // public List<AreaEffect> areaEffects;
    // public List<Character> characters;
    // public List<Gadget> gadgets;
    // public List<Item> items;
    // public List<Location> locations;
    // public List<Map> maps;
    // public List<Projectile> projectiles;
    // public List<Tile> tiles;

    // Start is called before the first frame update
    void Start()
    {
        fileTransfer = GetComponent<RemoteFileTransfer>();
        LoadAllDataKvt();
    }

    // public void LoadAllData()
    // {
    //     LoadAreaEffects();
    //     LoadCharacters();
    //     LoadGadgets();
    //     LoadItems();
    //     LoadLocations();
    //     LoadMaps();
    //     LoadProjectiles();
    //     LoadTiles();
    // }

    public void LoadAllDataKvt()
    {
        // try
        // {
        LoadKvt(ref tutorial, fileTransfer.Tutorial);
        // LoadKvt(ref areaEffects, fileTransfer.AreaEffects);
        LoadKvt(ref characters, fileTransfer.Characters);
        // LoadKvt(ref gadgets, fileTransfer.Gadgets);
        // LoadKvt(ref items, fileTransfer.Items);
        LoadKvt(ref locations, fileTransfer.Locations);
        LoadKvt(ref maps, fileTransfer.Maps);
        LoadKvt(ref projectiles, fileTransfer.Projectiles);
        LoadKvt(ref tiles, fileTransfer.Tiles);
        // }
        // catch { Debug.Log("Failed."); }
    }

    public void LoadKvt(ref List<KvtContainer> kvt, string[] source)
    {
        kvt = new List<KvtContainer>();

        var csvRows = source;
        var keyRow = csvRows[0].Split(',');
        var typeRow = csvRows[1].Split(',');

        var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

        for (int i = 2; i < csvRows.Length - 1; i++)
        {
            var data = csvRows[i].Split(',');
            var keyValues = new List<KeyValueType>();

            for (int v = 0; v < keyRow.Length; v++)
            {
                try
                {
                    keyValues.Add(new KeyValueType(keyRow[v], data[v], typeRow[v]));
                }
                catch (IndexOutOfRangeException e)
                {
                    Debug.Log(string.Format("Current Index: {0}, KeyRow Length: {1}, Data Length: {2}, TypeRow Length: {3}",
                    v, keyRow.Length, data.Length, typeRow.Length));
                    Debug.LogError(e);
                }
            }

            kvt.Add(new KvtContainer(r.Replace(keyValues[0].Value, " "), keyValues));
        }
    }

    // public void LoadAreaEffects()
    // {
    //     areaEffects = new List<AreaEffect>();

    //     var csvRows = fileTransfer.AreaEffects;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             areaEffects.Add(new AreaEffect(csvRows[i]));
    //     }
    // }

    // public void LoadCharacters()
    // {
    //     characters = new List<Character>();

    //     var csvRows = fileTransfer.Characters;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             characters.Add(new Character(csvRows[i]));
    //     }
    // }

    // public void LoadGadgets()
    // {
    //     gadgets = new List<Gadget>();

    //     var csvRows = fileTransfer.Gadgets;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             gadgets.Add(new Gadget(csvRows[i]));
    //     }
    // }

    // public void LoadItems()
    // {
    //     items = new List<Item>();

    //     var csvRows = fileTransfer.Items;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             items.Add(new Item(csvRows[i]));
    //     }
    // }

    // public void LoadLocations()
    // {
    //     locations = new List<Location>();

    //     var csvRows = fileTransfer.Locations;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             locations.Add(new Location(csvRows[i]));
    //     }
    // }

    // public void LoadMaps()
    // {
    //     maps = new List<Map>();

    //     var csvRows = fileTransfer.Maps;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             maps.Add(new Map(csvRows[i]));
    //     }
    // }

    // public void LoadProjectiles()
    // {
    //     projectiles = new List<Projectile>();

    //     var csvRows = fileTransfer.Projectiles;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             projectiles.Add(new Projectile(csvRows[i]));
    //     }
    // }

    // public void LoadTiles()
    // {
    //     tiles = new List<Tile>();

    //     var csvRows = fileTransfer.Tiles;

    //     for (int i = 2; i < csvRows.Length; i++)
    //     {
    //         if (csvRows[i] != "")
    //             tiles.Add(new Tile(csvRows[i]));
    //     }
    // }
}
