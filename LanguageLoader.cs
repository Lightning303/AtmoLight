﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using INIAccess;
using MediaPortal.Profile;
using System.Runtime.InteropServices;

namespace Language
{

  #region class Win32API
  public sealed class Win32API
  {
    private const int MAX_PATH = 260;

    public enum CSIDL
    {
      CSIDL_DESKTOP = 0x0000,          // <desktop>
      CSIDL_INTERNET = 0x0001,         // Internet Explorer (icon on desktop)
      CSIDL_PROGRAMS = 0x0002,         // Start Menu\Programs
      CSIDL_CONTROLS = 0x0003,         // My Computer\Control Panel
      CSIDL_PRINTERS = 0x0004,         // My Computer\Printers
      CSIDL_PERSONAL = 0x0005,         // My Documents
      CSIDL_FAVORITES = 0x0006,        // <user name>\Favorites
      CSIDL_STARTUP = 0x0007,          // Start Menu\Programs\Startup
      CSIDL_RECENT = 0x0008,           // <user name>\Recent
      CSIDL_SENDTO = 0x0009,           // <user name>\SendTo
      CSIDL_BITBUCKET = 0x000a,        // <desktop>\Recycle Bin
      CSIDL_STARTMENU = 0x000b,        // <user name>\Start Menu
      CSIDL_MYDOCUMENTS = 0x000c,      // logical "My Documents" desktop icon
      CSIDL_MYMUSIC = 0x000d,          // "My Music" folder
      CSIDL_MYVIDEO = 0x000e,          // "My Videos" folder
      CSIDL_DESKTOPDIRECTORY = 0x0010,        // <user name>\Desktop
      CSIDL_DRIVES = 0x0011,                  // My Computer
      CSIDL_NETWORK = 0x0012,                 // Network Neighborhood (My Network Places)
      CSIDL_NETHOOD = 0x0013,                 // <user name>\nethood
      CSIDL_FONTS = 0x0014,                   // windows\fonts
      CSIDL_TEMPLATES = 0x0015,
      CSIDL_COMMON_STARTMENU = 0x0016,        // All Users\Start Menu
      CSIDL_COMMON_PROGRAMS = 0X0017,         // All Users\Start Menu\Programs
      CSIDL_COMMON_STARTUP = 0x0018,          // All Users\Startup
      CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019, // All Users\Desktop
      CSIDL_APPDATA = 0x001a,                 // <user name>\Application Data
      CSIDL_PRINTHOOD = 0x001b,               // <user name>\PrintHood
      CSIDL_LOCAL_APPDATA = 0x001c,           // <user name>\Local Settings\Applicaiton Data (non roaming)
      CSIDL_ALTSTARTUP = 0x001d,              // non localized startup
      CSIDL_COMMON_ALTSTARTUP = 0x001e,       // non localized common startup
      CSIDL_COMMON_FAVORITES = 0x001f,
      CSIDL_INTERNET_CACHE = 0x0020,
      CSIDL_COOKIES = 0x0021,
      CSIDL_HISTORY = 0x0022,
      CSIDL_COMMON_APPDATA = 0x0023,          // All Users\Application Data
      CSIDL_WINDOWS = 0x0024,                 // GetWindowsDirectory()
      CSIDL_SYSTEM = 0x0025,                  // GetSystemDirectory()
      CSIDL_PROGRAM_FILES = 0x0026,           // C:\Program Files
      CSIDL_MYPICTURES = 0x0027,              // C:\Program Files\My Pictures
      CSIDL_PROFILE = 0x0028,                 // USERPROFILE
      CSIDL_SYSTEMX86 = 0x0029,               // x86 system directory on RISC
      CSIDL_PROGRAM_FILESX86 = 0x002a,        // x86 C:\Program Files on RISC
      CSIDL_PROGRAM_FILES_COMMON = 0x002b,    // C:\Program Files\Common
      CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c, // x86 Program Files\Common on RISC
      CSIDL_COMMON_TEMPLATES = 0x002d,        // All Users\Templates
      CSIDL_COMMON_DOCUMENTS = 0x002e,        // All Users\Documents
      CSIDL_COMMON_ADMINTOOLS = 0x002f,       // All Users\Start Menu\Programs\Administrative Tools
      CSIDL_ADMINTOOLS = 0x0030,              // <user name>\Start Menu\Programs\Administrative Tools
      CSIDL_CONNECTIONS = 0x0031,             // Network and Dial-up Connections
      CSIDL_COMMON_MUSIC = 0x0035,            // All Users\My Music
      CSIDL_COMMON_PICTURES = 0x0036,         // All Users\My Pictures
      CSIDL_COMMON_VIDEO = 0x0037,            // All Users\My Video
      CSIDL_CDBURN_AREA = 0x003b              // USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
    }

    [DllImport("shell32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SHGetPathFromIDListW(IntPtr pidl, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszPath);

    [DllImport("shell32.dll", SetLastError = true)]
    static extern int SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, ref IntPtr ppidl);

    public static string GetSpecialFolder(CSIDL nFolder)
    {
      IntPtr ptrAppData = IntPtr.Zero;
      SHGetSpecialFolderLocation(IntPtr.Zero, nFolder, ref ptrAppData);
      string dirAppData = "";
      StringBuilder sbAppData = new StringBuilder(MAX_PATH);

      if (true == SHGetPathFromIDListW(ptrAppData, sbAppData))
      {
        dirAppData = sbAppData.ToString();
      }

      sbAppData = null;
      Marshal.FreeCoTaskMem(ptrAppData);
      return dirAppData;
    }

  }
  #endregion

  public class LanguageLoader
  {
    // A static member to hold a reference to the singleton instance.
    private static LanguageLoader instance;

    // Public variables
    public static String strCurrentLanguageFile;
    public static ApplicationStrings appStrings = new ApplicationStrings();

    // A static constructor to create the singleton instance. Another
    // alternative is to use lazy initialization in the Instance property.
    static LanguageLoader()
    {
      instance = new LanguageLoader();

      using (Settings reader = new Settings(MediaPortal.Configuration.Config.GetFile(MediaPortal.Configuration.Config.Dir.Config, "MediaPortal.xml")))
        LanguageLoader.strCurrentLanguageFile = reader.GetValueAsString("atmolight", "CurrentLanguageFile", "");

      if ((strCurrentLanguageFile == null) || (strCurrentLanguageFile == ""))
      {
        string CommonAppDataDir = Win32API.GetSpecialFolder(Win32API.CSIDL.CSIDL_COMMON_APPDATA) + "\\Team MediaPortal\\MediaPortal\\language\\Atmolight";
        
        bool ifExists = Directory.Exists(CommonAppDataDir);
        if (!ifExists)
          Directory.CreateDirectory(CommonAppDataDir);

        strCurrentLanguageFile = CommonAppDataDir + "\\EnglishUS.lng";
      }

      if (!File.Exists(strCurrentLanguageFile))
        WriteLanguageFile(strCurrentLanguageFile);
      else
        LoadLanguageFile(strCurrentLanguageFile);
    }

    // A private constructor to stop code from creating additional 
    // instances of the singleton type.
    private LanguageLoader()
    {
    }

    // A public property to provide access to the singleton instance.
    public static LanguageLoader Instance
    {
      get { return instance; }
    }

    public static Boolean LoadLanguageFile(String strLanguageFile)
    {
      INIReaderForCE iniAccess = new INIReaderForCE(strLanguageFile);

      // this resets the strings to the defaults which helps in the event 
      // that the language file is missing entries
      appStrings = new ApplicationStrings();

      Object obj = appStrings;
      Type t = appStrings.GetType();

      FieldInfo[] fi = t.GetFields();
      String[] strArray;
      char[] strSeps = { '_' };
      String strSection;
      String strKey;
      String strValue;
      foreach (FieldInfo field in fi)
      {
        strArray = field.Name.Split(strSeps);
        strSection = strArray[0];
        strKey = strArray[1];
        strValue = iniAccess.ReadString(strSection, strKey, (String)(field.GetValue(obj)));
        field.SetValue(obj, strValue);
      }

      // re-write the file in case there are new strings in the application 
      // that are not yet in this language file
      WriteLanguageFile(strLanguageFile);

      return true;

    }

    public static Boolean WriteLanguageFile(String strLanguageFile)
    {
      INIWriterForCE iniAccess = new INIWriterForCE(strLanguageFile);

      Object obj = appStrings; // used in the "GetValue" call
      Type t = appStrings.GetType();
      FieldInfo[] fi = t.GetFields();

      String[] strArray;
      char[] strSeps = { '_' };
      String strSection;
      String strKey;
      String strValue;
      foreach (FieldInfo field in fi)
      {
        strArray = field.Name.Split(strSeps);
        strSection = strArray[0];
        strKey = strArray[1];
        try
        {
          strValue = (String)(field.GetValue(obj));
          iniAccess.WriteString(strSection, strKey, strValue);
        }
        catch (System.Exception e)
        {
          MessageBox.Show(e.ToString());
        }
      }

      iniAccess.CloseTheFile();

      return true;
    }
  }

  public class ApplicationStrings
  {
    public String SetupForm_lblPathInfoText = "Path+Filename of AtmoWinA.exe";
    public String SetupForm_grpModeText = "Atmolight Mode per content type";
    public String SetupForm_grpPluginOptionText = "Plugin options";
    public String SetupForm_lblVidTvRecText = "Video/TV/Recordings:";
    public String SetupForm_lblMusicText = "Music:";
    public String SetupForm_lblRadioText = "Radio:";
    public String SetupForm_lblLedsOnOffText = "LEDs OnOff RemoteKey:";
    public String SetupForm_lblProfileText = "Profile RemoteKey:";
    public String SetupForm_ckOnMediaStartText = "LEDs off on media start (manual mode)";
    public String SetupForm_ckLowCpuText = "low CPU";
    public String SetupForm_ckStartAtmoWinText = "Start AtmoWin with MediaPortal";
    public String SetupForm_ckExitAtmoWinText = "Exit AtmoWin with MediaPortal";
    public String SetupForm_grpMPCloseText = "MP close...";
    public String SetupForm_rbSwitchToLiveViewText = "Switch to AtmoWin's internal live view mode";
    public String SetupForm_rbDisableLEDsText = "Switch all LEDs off";
    public String SetupForm_btnSaveText = "Save";
    public String SetupForm_btnCancelText = "Cancel";
    public String SetupForm_btnLanguageText = "Load Language";
    public String SetupForm_lblHintText = "Hint: You can use the STOP button when nothing is playing to enable GDI Live-View, disable the LEDs or switch 3D-SBS Mode.";
    public String SetupForm_lblFramesText = "ms between Frames";
    public String SetupForm_lblStartText = "Start:";
    public String SetupForm_lblEndText = "End:";
    public String SetupForm_grpDeactivateText = "Deactive between...";
    public String SetupForm_lblMenu = "Menu/GUI:";
    public String SetupForm_grpStaticColor = "Static Color";
    public String SetupForm_lblRed = "Red:";
    public String SetupForm_lblGreen = "Green:";
    public String SetupForm_lblBlue = "Blue:";
    public String SetupForm_lblMenuButton = "Menu RemoteKey:";
  }
}

