using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MusicBox.Utils;

public static class Constants
{
    public static string OPENAI_API_KEY = "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";

    //spotify 
    //public static string CLIENT_ID = "7a0d479c405d475784b3a011c295b57d";
    //public static string CLIENT_SECRET = "ec31ee83f24c49ab8a1f947a2578b109";

    public static string CLIENT_ID = "c377f4c4f7f84a3d8091febc7692daf5";
    public static string CLIENT_SECRET = "ca4f3fd4f8234510bea543f34cc54ecf";

    public static string WebApiKey_Login = "AIzaSyAiOuFGLUVw-ahyBDief7Rd0bSU0F5JzLk";

    public static double ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
    public static double ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;


    public static string RockPlaylist = "0xTOjQjzCBKB8xLsU9XNlb";
    public static string PopPlaylist = "6pv75Rri5UysKxaiMySlh5";
    public static string RapPlaylist = "6Rw4qN34qjUNIVtjOHLvzA";
    public static string ElectronicPlaylist = "37i9dQZF1EQp9BVPsNVof1";
    public static string RBPlaylist = "37i9dQZF1EQoqCH7BwIYb7";
    public static string JazzPlaylist = "05Hd48jdQIz3s8WRrvGnzf";
    public static string CountryPlaylist = "5rjMAlfTXvN7vAmiM7452h";
    public static string ClassicalPlaylist = "72oczUf02H4RGoaUBC87JQ";
    public static string MetalPlaylist = "2iFHzm6F41h57HLSpqubyX";
    public static string BluesPlaylist = "6hWGn5O7jfRl0wqGI4PCgJ";

    public static string Zonga2Playlist = "6fCXJ0NYk9RkkL7TRIfRU3";
    public static string All2Playlist = "4r0W2KcPqDNJ2LlFNk8VGU";
    public static string GeneralPlaylist = "720BwWh67WfaW9saTVvK5Y";


    public const SQLite.SQLiteOpenFlags Flags =
       // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
       // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
       // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;

    public static Dictionary<string, string> Playlists = new Dictionary<string, string>
    {
        {"Rock", "0xTOjQjzCBKB8xLsU9XNlb" },
        {"Pop", "6pv75Rri5UysKxaiMySlh5" },
        {"Rap", "6Rw4qN34qjUNIVtjOHLvzA" },
        {"Electronic", "37i9dQZF1EQp9BVPsNVof1" },
        {"RB", "37i9dQZF1EQoqCH7BwIYb7" },
        {"Jazz", "05Hd48jdQIz3s8WRrvGnzf" },
        {"Country", "5rjMAlfTXvN7vAmiM7452h" },
        {"Classical", "72oczUf02H4RGoaUBC87JQ" },
        {"Metal", "2iFHzm6F41h57HLSpqubyX" },
        {"Blues", "6hWGn5O7jfRl0wqGI4PCgJ" },
        {"Zonga2", "6fCXJ0NYk9RkkL7TRIfRU3" },
        {"All2","4r0W2KcPqDNJ2LlFNk8VGU" },
        {"General","720BwWh67WfaW9saTVvK5Y" },
    };



}
