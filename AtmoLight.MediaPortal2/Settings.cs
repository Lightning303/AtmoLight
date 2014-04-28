﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPortal.Common;
using MediaPortal.Common.Settings;

namespace AtmoLight
{
  public class Settings
  {
    [Setting(SettingScope.User, "C:\\ProgramData\\Team MediaPortal\\MediaPortal\\AtmoWin\\AtmoWinA.exe")]
    public string AtmoWinExe { get; set; }

    [Setting(SettingScope.User, ContentEffect.MediaPortalLiveMode)]
    public ContentEffect EffectVideo { get; set; }

    [Setting(SettingScope.User, ContentEffect.LEDsDisabled)]
    public ContentEffect EffectMusic { get; set; }

    [Setting(SettingScope.User, ContentEffect.LEDsDisabled)]
    public ContentEffect EffectRadio { get; set; }

    [Setting(SettingScope.User, ContentEffect.LEDsDisabled)]
    public ContentEffect EffectMenu { get; set; }

    [Setting(SettingScope.User, 1)]
    public int ButtonMenu { get; set; }

    [Setting(SettingScope.User, 2)]
    public int ButtonOnOff { get; set; }

    [Setting(SettingScope.User, 3)]
    public int ButtonProfile { get; set; }

    [Setting(SettingScope.User, true)]
    public bool DisableLEDsOnExit { get; set; }

    [Setting(SettingScope.User, false)]
    public bool EnableLiveviewonExit { get; set; }

    [Setting(SettingScope.User, "08:00")]
    public string ExcludeTimeStart { get; set; }

    [Setting(SettingScope.User, "21:00")]
    public string ExcludeTimeEnd { get; set; }

    [Setting(SettingScope.User, false)]
    public bool ManualMode { get; set; }

    [Setting(SettingScope.User, false)]
    public bool SBS3D { get; set; }

    [Setting(SettingScope.User, false)]
    public bool LowCPU { get; set; }

    [Setting(SettingScope.User, 0)]
    public int LowCPUTime { get; set; }
    
    [Setting(SettingScope.User, false)]
    public bool Delay { get; set; }
    
    [Setting(SettingScope.User, 0)]
    public int DelayTime { get; set; }
    
    [Setting(SettingScope.User, 50)]
    public int DelayRefreshRate { get; set; }
    
    [Setting(SettingScope.User, true)]
    public bool StopAtmoWinOnExit { get; set; }
    
    [Setting(SettingScope.User, true)]
    public bool StartAtmoWinOnStart { get; set; }
    
    [Setting(SettingScope.User, true)]
    public bool RestartAtmoWinOnError { get; set; }
    
    [Setting(SettingScope.User, 0)]
    public int StaticColorRed { get; set; }
        
    [Setting(SettingScope.User, 0)]
    public int StaticColorGreen { get; set; }
        
    [Setting(SettingScope.User, 0)]
    public int StaticColorBlue { get; set; }

    ISettingsManager settingsManager = ServiceRegistration.Get<ISettingsManager>();
    Settings settings;

    public bool LoadAll()
    {
      settings = settingsManager.Load<Settings>();
      AtmoWinExe = settings.AtmoWinExe;
      EffectVideo = settings.EffectVideo;
      EffectRadio = settings.EffectRadio;
      EffectMusic = settings.EffectMusic;
      EffectMenu = settings.EffectMenu;
      ButtonMenu = settings.ButtonMenu;
      ButtonOnOff = settings.ButtonOnOff;
      ButtonProfile = settings.ButtonProfile;
      DisableLEDsOnExit = settings.DisableLEDsOnExit;
      EnableLiveviewonExit = settings.EnableLiveviewonExit;
      ExcludeTimeStart = settings.ExcludeTimeStart;
      ExcludeTimeEnd = settings.ExcludeTimeEnd;
      ManualMode = settings.ManualMode;
      SBS3D = settings.SBS3D;
      LowCPU = settings.LowCPU;
      LowCPUTime = settings.LowCPUTime;
      Delay = settings.Delay;
      DelayTime = settings.DelayTime;
      DelayRefreshRate = settings.DelayRefreshRate;
      StopAtmoWinOnExit = settings.StopAtmoWinOnExit;
      StartAtmoWinOnStart = settings.StartAtmoWinOnStart;
      RestartAtmoWinOnError = settings.RestartAtmoWinOnError;
      StaticColorBlue = settings.StaticColorBlue;
      StaticColorGreen = settings.StaticColorGreen;
      StaticColorRed = settings.StaticColorRed;
      return true;
    }

    public bool SaveAll()
    {
      settings.AtmoWinExe = AtmoWinExe;
      settings.EffectVideo = EffectVideo;
      settings.EffectRadio = EffectRadio;
      settings.EffectMusic = EffectMusic;
      settings.EffectMenu = EffectMenu;
      settings.ButtonMenu = ButtonMenu;
      settings.ButtonOnOff = ButtonOnOff;
      settings.ButtonProfile = ButtonProfile;
      settings.DisableLEDsOnExit = DisableLEDsOnExit;
      settings.EnableLiveviewonExit = EnableLiveviewonExit;
      settings.ExcludeTimeStart = ExcludeTimeStart;
      settings.ExcludeTimeEnd = ExcludeTimeEnd;
      settings.ManualMode = ManualMode;
      settings.SBS3D = SBS3D;
      settings.LowCPU = LowCPU;
      settings.LowCPUTime = LowCPUTime;
      settings.Delay = Delay;
      settings.DelayTime = DelayTime;
      settings.DelayRefreshRate = DelayRefreshRate;
      settings.StopAtmoWinOnExit = StopAtmoWinOnExit;
      settings.StartAtmoWinOnStart = StartAtmoWinOnStart;
      settings.RestartAtmoWinOnError = RestartAtmoWinOnError;
      settings.StaticColorBlue = StaticColorBlue;
      settings.StaticColorGreen = StaticColorGreen;
      settings.StaticColorRed = StaticColorRed;
      settingsManager.Save(settings);
      return true;
    }
  }
}
