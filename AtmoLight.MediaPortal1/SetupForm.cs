﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Language;

namespace AtmoLight
{
  public partial class SetupForm : Form
  {
    private Core coreObject = Core.GetInstance();

    public SetupForm()
    {
      InitializeComponent();
      UpdateLanguageOnControls();

      // AtmoWin
      if (Settings.atmoWinTarget)
      {
        coreObject.AddTarget(Target.AtmoWin);
      }
      // Boblight
      if (Settings.boblightTarget)
      {
        coreObject.AddTarget(Target.Boblight);
      }
      // Hyperion
      if (Settings.hyperionTarget)
      {
        coreObject.AddTarget(Target.Hyperion);
      }
      // Hue
      if (Settings.hueTarget)
      {
        coreObject.AddTarget(Target.Hue);
      }

      UpdateComboBoxes();

      lblVersionVal.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
      edFileAtmoWin.Text = Settings.atmowinExe;
      comboBox1.SelectedIndex = (int)Settings.killButton;
      comboBox2.SelectedIndex = (int)Settings.profileButton;
      cbMenuButton.SelectedIndex = (int)Settings.menuButton;
      edExcludeStart.Text = Settings.excludeTimeStart.ToString("HH:mm");
      edExcludeEnd.Text = Settings.excludeTimeEnd.ToString("HH:mm");
      lowCpuTime.Text = Settings.lowCPUTime.ToString();
      tbDelay.Text = Settings.delayReferenceTime.ToString();
      tbRefreshRate.Text = Settings.delayReferenceRefreshRate.ToString();
      tbRed.Text = Settings.staticColorRed.ToString();
      tbGreen.Text = Settings.staticColorGreen.ToString();
      tbBlue.Text = Settings.staticColorBlue.ToString();
      tbBlackbarDetectionTime.Text = Settings.blackbarDetectionTime.ToString();
      tbGIF.Text = Settings.gifFile;
      tbHyperionIP.Text = Settings.hyperionIP;
      tbHyperionPort.Text = Settings.hyperionPort.ToString();
      tbHyperionReconnectDelay.Text = Settings.hyperionReconnectDelay.ToString();
      tbHyperionReconnectAttempts.Text = Settings.hyperionReconnectAttempts.ToString();
      tbHyperionPriority.Text = Settings.hyperionPriority.ToString();
      tbHyperionPriorityStaticColor.Text = Settings.hyperionPriorityStaticColor.ToString();
      tbCaptureWidth.Text = Settings.captureWidth.ToString();
      tbCaptureHeight.Text = Settings.captureHeight.ToString();
      edFileHue.Text = Settings.hueExe;
      ckStartHue.Checked = Settings.hueStart;
      ckhueIsRemoteMachine.Checked = Settings.hueIsRemoteMachine;
      tbHueIP.Text = Settings.hueIP;
      tbHuePort.Text = Settings.huePort.ToString();
      tbHueReconnectDelay.Text = Settings.hueReconnectDelay.ToString();
      tbHueReconnectAttempts.Text = Settings.hueReconnectAttempts.ToString();
      tbHueMinimalColorDifference.Text = Settings.hueMinimalColorDifference.ToString();
      ckHueBridgeEnableOnResume.Checked = Settings.hueBridgeEnableOnResume;
      ckHueBridgeDisableOnSuspend.Checked = Settings.hueBridgeDisableOnSuspend;
      ckOnMediaStart.Checked = Settings.manualMode;
      ckLowCpu.Checked = Settings.lowCPU;
      ckDelay.Checked = Settings.delay;
      ckStartAtmoWin.Checked = Settings.startAtmoWin;
      ckExitAtmoWin.Checked = Settings.exitAtmoWin;
      ckRestartOnError.Checked = Settings.restartOnError;
      ckBlackbarDetection.Checked = Settings.blackbarDetection;
      ckAtmowinEnabled.Checked = Settings.atmoWinTarget;
      ckHyperionEnabled.Checked = Settings.hyperionTarget;
      ckHueEnabled.Checked = Settings.hueTarget;
      ckHyperionLiveReconnect.Checked = Settings.hyperionLiveReconnect;
      ckBoblightEnabled.Checked = Settings.boblightTarget;
      tbBoblightIP.Text = Settings.boblightIP;
      tbBoblightPort.Text = Settings.boblightPort.ToString();
      tbBoblightMaxReconnectAttempts.Text = Settings.boblightMaxReconnectAttempts.ToString();
      tbBoblightReconnectDelay.Text = Settings.boblightReconnectDelay.ToString();
      tbBoblightMaxFPS.Text = Settings.boblightMaxFPS.ToString();
      tbarBoblightSpeed.Value = (int)Settings.boblightSpeed;
      tbarBoblightAutospeed.Value = (int)Settings.boblightAutospeed;
      tbarBoblightSaturation.Value = (int)Settings.boblightSaturation;
      tbarBoblightValue.Value = (int)Settings.boblightValue;
      tbarBoblightThreshold.Value = Settings.boblightThreshold;
      tbarBoblightGamma.Value = (int)(Settings.boblightGamma * 10);
      ckBoblightInterpolation.Checked = Settings.boblightInterpolation;
      tbBoblightSpeed.Text = Settings.boblightSpeed.ToString();
      tbBoblightAutospeed.Text = Settings.boblightAutospeed.ToString();
      tbBoblightSaturation.Text = Settings.boblightSaturation.ToString();
      tbBoblightValue.Text = Settings.boblightValue.ToString();
      tbBoblightThreshold.Text = Settings.boblightThreshold.ToString();
      tbBoblightGamma.Text = Settings.boblightGamma.ToString();
      tbBlackbarDetectionThreshold.Text = Settings.blackbarDetectionThreshold.ToString();
      tbpowerModeChangedDelay.Text = Settings.powerModeChangedDelay.ToString();
    }

    private void UpdateLanguageOnControls()
    {
      // this function places language specific text on all "skin-able" text items.
      lblPathInfoAtmoWin.Text = LanguageLoader.appStrings.SetupForm_lblPathInfoAtmoWin;
      grpMode.Text = LanguageLoader.appStrings.SetupForm_grpModeText;
      grpPluginOption.Text = LanguageLoader.appStrings.SetupForm_grpPluginOptionText;
      lblVidTvRec.Text = LanguageLoader.appStrings.SetupForm_lblVidTvRecText;
      lblMusic.Text = LanguageLoader.appStrings.SetupForm_lblMusicText;
      lblRadio.Text = LanguageLoader.appStrings.SetupForm_lblRadioText;
      lblLedsOnOff.Text = LanguageLoader.appStrings.SetupForm_lblLedsOnOffText;
      lblProfile.Text = LanguageLoader.appStrings.SetupForm_lblProfileText;
      ckOnMediaStart.Text = LanguageLoader.appStrings.SetupForm_ckOnMediaStartText;
      ckLowCpu.Text = LanguageLoader.appStrings.SetupForm_ckLowCpuText;
      ckDelay.Text = LanguageLoader.appStrings.SetupForm_ckDelayText;
      ckStartAtmoWin.Text = LanguageLoader.appStrings.SetupForm_ckStartAtmoWinText;
      ckExitAtmoWin.Text = LanguageLoader.appStrings.SetupForm_ckExitAtmoWinText;
      btnSave.Text = LanguageLoader.appStrings.SetupForm_btnSaveText;
      btnCancel.Text = LanguageLoader.appStrings.SetupForm_btnCancelText;
      btnLanguage.Text = LanguageLoader.appStrings.SetupForm_btnLanguageText;
      lblHintMenuButtons.Text = LanguageLoader.appStrings.SetupForm_lblHintText;
      lblHintHardware.Text = LanguageLoader.appStrings.SetupForm_lblHintHardware;
      lblHintCaptureDimensions.Text = LanguageLoader.appStrings.SetupForm_lblHintCaptureDimensions;
      lblHintHue.Text = LanguageLoader.appStrings.SetupForm_lblHintHue;
      lblFrames.Text = LanguageLoader.appStrings.SetupForm_lblFramesText;
      lblDelay.Text = LanguageLoader.appStrings.SetupForm_lblDelay;
      lblStart.Text = LanguageLoader.appStrings.SetupForm_lblStartText;
      lblEnd.Text = LanguageLoader.appStrings.SetupForm_lblEndText;
      grpDeactivate.Text = LanguageLoader.appStrings.SetupForm_grpDeactivateText;
      lblMenu.Text = LanguageLoader.appStrings.SetupForm_lblMenu;
      grpStaticColor.Text = LanguageLoader.appStrings.SetupForm_grpStaticColor;
      lblRed.Text = LanguageLoader.appStrings.SetupForm_lblRed;
      lblGreen.Text = LanguageLoader.appStrings.SetupForm_lblGreen;
      lblBlue.Text = LanguageLoader.appStrings.SetupForm_lblBlue;
      lblMenuButton.Text = LanguageLoader.appStrings.SetupForm_lblMenuButton;
      ckRestartOnError.Text = LanguageLoader.appStrings.SetupForm_ckRestartOnError;
      lblRefreshRate.Text = LanguageLoader.appStrings.SetupForm_lblRefreshRate;
      ckBlackbarDetection.Text = LanguageLoader.appStrings.SetupForm_ckBlackbarDetection;
      lblBlackarDetectionMS.Text = LanguageLoader.appStrings.SetupForm_lblBlackbarDetectionThreshold;
      lblpowerModeChangedDelay.Text = LanguageLoader.appStrings.SetupForm_lblpowerModeChangedDelay;
      grpGIF.Text = LanguageLoader.appStrings.SetupForm_grpGIF;
      lblHyperionIP.Text = LanguageLoader.appStrings.SetupForm_lblHyperionIP;
      lblHyperionPort.Text = LanguageLoader.appStrings.SetupForm_lblHyperionPort;
      lblHyperionPriority.Text = LanguageLoader.appStrings.SetupForm_lblHyperionPriorty;
      lblHyperionReconnectDelay.Text = LanguageLoader.appStrings.SetupForm_lblHyperionReconnectDelay;
      lblHyperionReconnectAttempts.Text = LanguageLoader.appStrings.SetupForm_lblHyperionReconnectAttempts;
      lblHyperionPriorityStaticColor.Text = LanguageLoader.appStrings.SetupForm_lblHyperionPriorityStaticColor;
      ckHyperionLiveReconnect.Text = LanguageLoader.appStrings.SetupForm_ckHyperionLiveReconnect;
      lblCaptureWidth.Text = LanguageLoader.appStrings.SetupForm_lblCaptureWidth;
      lblCaptureHeight.Text = LanguageLoader.appStrings.SetupForm_lblCaptureHeight;
      tabPageGeneric.Text = LanguageLoader.appStrings.SetupForm_tabPageGeneric;
      grpTargets.Text = LanguageLoader.appStrings.SetupForm_grpTargets;
      grpAtmowinSettings.Text = LanguageLoader.appStrings.SetupForm_grpAtmowinSettings;
      grpHyperionNetworkSettings.Text = LanguageLoader.appStrings.SetupForm_grpHyperionNetworkSettings;
      grpHyperionPrioritySettings.Text = LanguageLoader.appStrings.SetupForm_grpHyperionPrioritySettings;
      grpCaptureDimensions.Text = LanguageLoader.appStrings.SetupForm_grpCaptureDimensions;
      lblPathInfoHue.Text = LanguageLoader.appStrings.SetupForm_lblPathInfoHue;
      ckStartHue.Text = LanguageLoader.appStrings.SetupForm_ckStartHue;
      ckhueIsRemoteMachine.Text = LanguageLoader.appStrings.SetupForm_ckhueIsRemoteMachine;
      lblHueIP.Text = LanguageLoader.appStrings.SetupForm_lblHueIP;
      lblHuePort.Text = LanguageLoader.appStrings.SetupForm_lblHuePort;
      lblHueReconnectDelay.Text = LanguageLoader.appStrings.SetupForm_lblHueReconnectDelay;
      lblHueReconnectAttempts.Text = LanguageLoader.appStrings.SetupForm_lblHueReconnectAttempts;
      lblHueMinimalColorDifference.Text = LanguageLoader.appStrings.SetupForm_lblHueMinimalColorDifference;
      ckHueBridgeEnableOnResume.Text = LanguageLoader.appStrings.SetupForm_ckHueBridgeEnableOnResume;
      lblMPExit.Text = LanguageLoader.appStrings.SetupForm_lblMPExit;
      lblBoblightIP.Text = LanguageLoader.appStrings.SetupForm_lblBoblightIP;
      lblBoblightPort.Text = LanguageLoader.appStrings.SetupForm_lblBoblightPort;
      lblBoblightMaxReconnectAttempts.Text = LanguageLoader.appStrings.SetupForm_lblBoblightMaxReconnectAttempts;
      lblBoblightReconnectDelay.Text = LanguageLoader.appStrings.SetupForm_lblBoblightReconnectDelay;
      lblBoblightMaxFPS.Text = LanguageLoader.appStrings.SetupForm_lblBoblightMaxFPS;
      lblBoblightSpeed.Text = LanguageLoader.appStrings.SetupForm_lblBoblightSpeed;
      lblBoblightAutospeed.Text = LanguageLoader.appStrings.SetupForm_lblBoblightAutospeed;
      lblBoblightSaturation.Text = LanguageLoader.appStrings.SetupForm_lblBoblightSaturation;
      lblBoblightValue.Text = LanguageLoader.appStrings.SetupForm_lblBoblightValue;
      lblBoblightThreshold.Text = LanguageLoader.appStrings.SetupForm_lblBoblightThreshold;
      ckBoblightInterpolation.Text = LanguageLoader.appStrings.SetupForm_lblBoblightInterpolation;
      grpBoblightGeneral.Text = LanguageLoader.appStrings.SetupForm_grpBoblightGeneral;
      grpBoblightSettings.Text = LanguageLoader.appStrings.SetupForm_grpBoblightSettings;
      lblBoblightGamma.Text = LanguageLoader.appStrings.SetupForm_lblBoblightGamma;
    }

    private void btnSelectFile_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        string filenameNoExtension = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
        string filename = filenameNoExtension.ToLower();
        if (filename == "atmowina")
        {
          edFileAtmoWin.Text = openFileDialog1.FileName;
        }
        else
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorAtmoWinA, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          edFileAtmoWin.Text = "";
          return;
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      //Validate user input


      //Time excluded Start
      if (validatorDateTime(edExcludeStart.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorStartTime + " - ["+lblStart.Text+"]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Time excluded Stop
      if (validatorDateTime(edExcludeEnd.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorEndTime + " - [" + lblEnd.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Low CPU
      if(validatorInt(lowCpuTime.Text,1,0,false) == false)
      {
        if (ckLowCpu.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds + " - [" + ckLowCpu.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        else

        {
          //Didn't pass validation so save cleanly with default value even if option isn't used
          lowCpuTime.Text = "0";
        }
      }

      //LED delay
      if (validatorInt(tbDelay.Text, 1, 0, false) == false)
      {
        if (ckDelay.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds + " - [" + ckDelay.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        else
        {
          //Didn't pass validation so save cleanly with default value even if option isn't used
          tbDelay.Text = "0";
        }
      }

      //Refresh rate
      if (validatorInt(tbRefreshRate.Text, 1, 0, false) == false)
      {
        if (ckDelay.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds + " - [" + lblRefreshRate.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        else
        {
          //Didn't pass validation so save cleanly with default value even if option isn't used
          tbRefreshRate.Text = "50";
        }
      }

      //Black bar detection
      if (validatorInt(tbBlackbarDetectionTime.Text, 1, 0, false) == false)
      {
        if (ckBlackbarDetection.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds + " - [" + ckBlackbarDetection.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        else
        {
          //Didn't pass validation so save cleanly with default value even if option isn't used
          tbBlackbarDetectionTime.Text = "0";
        }
      }
      
      //Static color RED
      if (validatorInt(tbRed.Text, 0, 255, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRed + " - [" + lblRed.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Static color GREEN
      if (validatorInt(tbGreen.Text, 0, 255, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorGreen + " - [" + lblGreen.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Static color BLUE
      if (validatorInt(tbBlue.Text, 0, 255, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorBlue + " - [" + lblBlue.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Menu buttons
      if ((cbMenuButton.SelectedIndex == comboBox1.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
          (cbMenuButton.SelectedIndex == comboBox2.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
          (comboBox1.SelectedIndex == comboBox2.SelectedIndex) && (comboBox1.SelectedIndex != 4))
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRemoteButtons, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //GIF path
      if (validatorPath(tbGIF.Text) == false && string.IsNullOrEmpty(tbGIF.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidPath + " - [" + grpGIF.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Atmowin path
      if (validatorPath(edFileAtmoWin.Text) == false && string.IsNullOrEmpty(edFileAtmoWin.Text) == false)
      {
        if (ckAtmowinEnabled.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidPath + " - [" + lblPathInfoAtmoWin.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }

      //Hyperion IP
      if (validatorIPAdress(tbHyperionIP.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIP + " - [" + lblHyperionIP.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      //Hue IP
      if (validatorIPAdress(tbHueIP.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIP + " - [" + lblHueIP.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }


      /*
       * Settings with specific Integer restrictions
       */

      int minValue = 0;
      int maxValue = 0;

      //Capture width
      minValue = 1;
      maxValue = 0;
      if (validatorInt(tbCaptureWidth.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()) + " - [" + lblCaptureWidth.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Capture height
      minValue = 1;
      maxValue = 0;
      if (validatorInt(tbCaptureHeight.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()) + " - [" + lblCaptureHeight.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hyperion port
      minValue = 1;
      maxValue = 65535;
      if (validatorInt(tbHyperionPort.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblHyperionPort.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hyperion reconnect attempts
      minValue = 1;
      maxValue = 0;
      if (validatorInt(tbHyperionReconnectAttempts.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()) + " - ["+ lblHyperionReconnectAttempts.Text +"]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hyperion reconnect delay
      minValue = 100;
      maxValue = 999999;
      if (validatorInt(tbHyperionReconnectDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblHyperionReconnectDelay.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hyperion priority
      minValue = 1;
      maxValue = 0;
      if (validatorInt(tbHyperionPriority.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()) + " - ["+ lblHyperionPriority.Text +"]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hyperion priority static color
      minValue = 1;
      maxValue = 0;
      if (validatorInt(tbHyperionPriorityStaticColor.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()) + " - ["+ lblHyperionPriorityStaticColor.Text +"]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hue path
      if (validatorPath(edFileHue.Text) == false && string.IsNullOrEmpty(edFileHue.Text) == false)
      {
        if (ckHueEnabled.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidPath + " - [" + lblPathInfoHue.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }

      //Hue port
      minValue = 1;
      maxValue = 65535;
      if (validatorInt(tbHuePort.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblHueIP.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hue reconnect attempts
      minValue = 1;
      maxValue = 0;
      if (validatorInt(tbHueReconnectAttempts.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()) + " - ["+ lblHueReconnectAttempts.Text +"]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Hue reconnect delay
      minValue = 100;
      maxValue = 999999;
      if (validatorInt(tbHueReconnectDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblHueReconnectDelay.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Boblight IP
      if (validatorIPAdress(tbBoblightIP.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIP + " - [" + tbBoblightIP.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Boblight Port
      minValue = 1;
      maxValue = 65535;
      if (validatorInt(tbBoblightPort.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblBoblightPort.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Boblight MaxReconnectAttempts
      minValue = 1;
      maxValue = 9999;
      if (validatorInt(tbBoblightMaxReconnectAttempts.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblBoblightMaxReconnectAttempts.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Boblight ReconnectDelay
      minValue = 100;
      maxValue = 999999;
      if (validatorInt(tbBoblightReconnectDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblBoblightSaturation.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Boblight MaxFPS
      minValue = 1;
      maxValue = 144;
      if (validatorInt(tbBoblightMaxFPS.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblBoblightMaxFPS.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Blackbar Detection Threshold
      minValue = 0;
      maxValue = 255;
      if (validatorInt(tbBlackbarDetectionThreshold.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + ckBlackbarDetection.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // Power mode change delay
      minValue = 0;
      maxValue = 999999;
      if (validatorInt(tbpowerModeChangedDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()) + " - [" + lblpowerModeChangedDelay.Text + "]", LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Settings.staticColorRed = int.Parse(tbRed.Text);
      Settings.staticColorGreen = int.Parse(tbGreen.Text);
      Settings.staticColorBlue = int.Parse(tbBlue.Text);
      Settings.atmowinExe = edFileAtmoWin.Text;
      Settings.excludeTimeStart = DateTime.Parse(edExcludeStart.Text);
      Settings.excludeTimeEnd = DateTime.Parse(edExcludeEnd.Text);
      Settings.killButton = comboBox1.SelectedIndex;
      Settings.profileButton = comboBox2.SelectedIndex;
      Settings.menuButton = cbMenuButton.SelectedIndex;
      Settings.manualMode = ckOnMediaStart.Checked;
      Settings.lowCPU = ckLowCpu.Checked;
      Settings.lowCPUTime = int.Parse(lowCpuTime.Text);
      Settings.delay = ckDelay.Checked;
      Settings.startAtmoWin = ckStartAtmoWin.Checked;
      Settings.exitAtmoWin = ckExitAtmoWin.Checked;
      Settings.restartOnError = ckRestartOnError.Checked;
      Settings.blackbarDetection = ckBlackbarDetection.Checked;
      Settings.blackbarDetectionTime = int.Parse(tbBlackbarDetectionTime.Text);
      Settings.delayReferenceRefreshRate = int.Parse(tbRefreshRate.Text);
      Settings.delayReferenceTime = int.Parse(tbDelay.Text);
      Settings.gifFile = tbGIF.Text;
      Settings.hyperionIP = tbHyperionIP.Text;
      Settings.hyperionPort = int.Parse(tbHyperionPort.Text);
      Settings.hyperionPriority = int.Parse(tbHyperionPriority.Text);
      Settings.hyperionReconnectDelay = int.Parse(tbHyperionReconnectDelay.Text);
      Settings.hyperionReconnectAttempts = int.Parse(tbHyperionReconnectAttempts.Text);
      Settings.hyperionPriorityStaticColor = int.Parse(tbHyperionPriorityStaticColor.Text);
      Settings.hyperionLiveReconnect = ckHyperionLiveReconnect.Checked;
      Settings.captureWidth = int.Parse(tbCaptureWidth.Text);
      Settings.captureHeight = int.Parse(tbCaptureHeight.Text);
      Settings.hueExe = edFileHue.Text;
      Settings.hueStart = ckStartHue.Checked;
      Settings.hueIsRemoteMachine = ckhueIsRemoteMachine.Checked;
      Settings.hueIP = tbHueIP.Text;
      Settings.huePort = int.Parse(tbHuePort.Text);
      Settings.hueReconnectDelay = int.Parse(tbHueReconnectDelay.Text);
      Settings.hueReconnectAttempts = int.Parse(tbHueReconnectAttempts.Text);
      Settings.hueMinimalColorDifference = int.Parse(tbHueMinimalColorDifference.Text);
      Settings.hueBridgeEnableOnResume = ckHueBridgeEnableOnResume.Checked;
      Settings.hueBridgeDisableOnSuspend = ckHueBridgeDisableOnSuspend.Checked;
      Settings.atmoWinTarget = ckAtmowinEnabled.Checked;
      Settings.hueTarget = ckHueEnabled.Checked;
      Settings.hyperionTarget = ckHyperionEnabled.Checked;
      Settings.boblightTarget = ckBoblightEnabled.Checked;
      Settings.boblightIP = tbBoblightIP.Text;
      Settings.boblightPort = int.Parse(tbBoblightPort.Text);
      Settings.boblightMaxReconnectAttempts = int.Parse(tbBoblightMaxReconnectAttempts.Text);
      Settings.boblightReconnectDelay = int.Parse(tbBoblightReconnectDelay.Text);
      Settings.boblightMaxFPS = int.Parse(tbBoblightMaxFPS.Text);
      Settings.boblightSpeed = tbarBoblightSpeed.Value;
      Settings.boblightAutospeed = tbarBoblightAutospeed.Value;
      Settings.boblightSaturation = tbarBoblightSaturation.Value;
      Settings.boblightValue = tbarBoblightValue.Value;
      Settings.boblightThreshold = tbarBoblightThreshold.Value;
      Settings.boblightInterpolation = ckBoblightInterpolation.Checked;
      Settings.boblightGamma = (double)tbarBoblightGamma.Value / 10;
      Settings.blackbarDetectionThreshold = int.Parse(tbBlackbarDetectionThreshold.Text);
      Settings.powerModeChangedDelay = int.Parse(tbpowerModeChangedDelay.Text);

      Settings.effectVideo = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbVideo.Text, "ContextMenu_").Remove(0, 12));
      Settings.effectMusic = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbMusic.Text, "ContextMenu_").Remove(0, 12));
      Settings.effectRadio = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbRadio.Text, "ContextMenu_").Remove(0, 12));
      Settings.effectMenu = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbMenu.Text, "ContextMenu_").Remove(0, 12));
      Settings.effectMPExit = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbMPExit.Text, "ContextMenu_").Remove(0, 12));

      Settings.SaveSettings();
      this.DialogResult = DialogResult.OK;
    }

    private void btnLanguage_Click(object sender, EventArgs e)
    {
      openFileDialog2.InitialDirectory = Path.GetDirectoryName(LanguageLoader.strCurrentLanguageFile);
      if (openFileDialog2.ShowDialog() == DialogResult.OK)
      {
        LanguageLoader.LoadLanguageFile(openFileDialog2.FileName);
        LanguageLoader.strCurrentLanguageFile = openFileDialog2.FileName;
        UpdateLanguageOnControls();
        UpdateComboBoxes();
        openFileDialog2.FileName = "";
      }
    }

    private void btnSelectGIF_Click(object sender, EventArgs e)
    {
      if (openFileDialog3.ShowDialog() == DialogResult.OK)
      {
        tbGIF.Text = openFileDialog3.FileName;
      }
    }

    #region input validators
    private Boolean validatorInt(string input, int minValue, int maxValue, Boolean validateMaxValue)
    {
      Boolean IsValid = false;
      Int32 value;
      bool IsInteger = Int32.TryParse(input, out value);

      if (IsInteger)
      {
        //Only check minValue
        if (validateMaxValue == false && value >= minValue)
        {
          IsValid = true;
        }
        //Check both min/max values
        else
        {
          if (value >= minValue && value <= maxValue)
          {
            IsValid = true;
          }
        }
      }
      return IsValid;
    }
    private Boolean validatorIPAdress(string input)
    {
      Boolean IsValid = false;

      System.Net.IPAddress address;
      if (System.Net.IPAddress.TryParse(input, out address))
      {
        switch (address.AddressFamily)
        {
          case System.Net.Sockets.AddressFamily.InterNetwork:
            // we have IPv4
            IsValid = true;
            break;
          case System.Net.Sockets.AddressFamily.InterNetworkV6:
            // we have IPv6
            break;
          default:
            // do something else
            break;
        }
      } 
      return IsValid;
    }
    private Boolean validatorDateTime(string input)
    {
      DateTime dt;
      Boolean IsValid = false;
      bool isDateTime = DateTime.TryParse(input, out dt);
      if (isDateTime)
      {
        IsValid = true;
      }

      return IsValid;
    }

    private Boolean validatorPath(string input)
    {
      Boolean IsValid = false;

      try
      {
        if (File.Exists(input))
        {
          IsValid = true;
        }
      }
      catch { };

      return IsValid;
    }
    private Boolean validatorRGB(string color, string range)
    {

      Boolean IsValid = false;
      return IsValid;
    }
    #endregion

    private void lowCpuTime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(lowCpuTime.Text, minValue, maxValue, false) == false)
      {
        if (ckLowCpu.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }
    private void tbDelay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbDelay.Text, minValue, maxValue, false) == false)
      {
        if (ckDelay.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void tbRefreshRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbRefreshRate.Text, minValue, maxValue, false) == false)
      {
        if (ckDelay.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRefreshRate, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void tbBlackbarDetectionTime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbBlackbarDetectionTime.Text, minValue, maxValue, false) == false)
      {
        if (ckBlackbarDetection.Checked)
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorMiliseconds, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void tbCaptureWidth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbCaptureWidth.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbCaptureHeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbCaptureHeight.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void edExcludeStart_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorDateTime(edExcludeStart.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorStartTime, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void edExcludeEnd_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorDateTime(edExcludeEnd.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorEndTime, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }


    private void tbRed_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 255;
      if (validatorInt(tbRed.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRed, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void tbGreen_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 255;
      if (validatorInt(tbGreen.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorGreen, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbBlue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 255;
      if (validatorInt(tbBlue.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorBlue, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbGIF_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorPath(tbGIF.Text) == false && string.IsNullOrEmpty(tbGIF.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidPath, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private void cbMenuButton_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if ((cbMenuButton.SelectedIndex == comboBox1.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
    (cbMenuButton.SelectedIndex == comboBox2.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
    (comboBox1.SelectedIndex == comboBox2.SelectedIndex) && (comboBox1.SelectedIndex != 4))
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRemoteButtons, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if ((cbMenuButton.SelectedIndex == comboBox1.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
    (cbMenuButton.SelectedIndex == comboBox2.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
    (comboBox1.SelectedIndex == comboBox2.SelectedIndex) && (comboBox1.SelectedIndex != 4))
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRemoteButtons, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void comboBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if ((cbMenuButton.SelectedIndex == comboBox1.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
    (cbMenuButton.SelectedIndex == comboBox2.SelectedIndex) && (cbMenuButton.SelectedIndex != 4) ||
    (comboBox1.SelectedIndex == comboBox2.SelectedIndex) && (comboBox1.SelectedIndex != 4))
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorRemoteButtons, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void edFile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorPath(edFileAtmoWin.Text) == false && string.IsNullOrEmpty(edFileAtmoWin.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidPath, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHyperionIP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorIPAdress(tbHyperionIP.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIP, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHyperionPort_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 65535;
      if (validatorInt(tbHyperionPort.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]",minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHyperionReconnectDelay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 10;
      int maxValue = 999999;
      if (validatorInt(tbHyperionReconnectDelay.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]",minValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void tbHyperionReconnectAttempts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbHyperionReconnectAttempts.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHyperionPriority_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbHyperionPriority.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHyperionPriorityStaticColor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 0;
      if (validatorInt(tbHyperionPriorityStaticColor.Text, minValue, maxValue, false) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerStarting.Replace("[minInteger]", minValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHueIP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorIPAdress(tbHueIP.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIP, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHuePort_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 65535;
      if (validatorInt(tbHuePort.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private void tbHueReconnectDelay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 100;
      int maxValue = 999999;
      if (validatorInt(tbHueReconnectDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbHueReconnectAttempts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 9999;
      if (validatorInt(tbHueReconnectAttempts.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    // Boblight
    private void tbBoblightIP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (validatorIPAdress(tbBoblightIP.Text) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIP, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbBoblightPort_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 65535;
      if (validatorInt(tbBoblightPort.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbBoblightMaxReconnectAttempts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 9999;
      if (validatorInt(tbBoblightMaxReconnectAttempts.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbBoblightReconnectDelay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 100;
      int maxValue = 999999;
      if (validatorInt(tbBoblightReconnectDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbBoblightMaxFPS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 1;
      int maxValue = 144;
      if (validatorInt(tbBoblightMaxFPS.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbBlackbarDetectionThreshold_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 255;
      if (validatorInt(tbBlackbarDetectionThreshold.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbpowerModeChangedDelay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      int minValue = 0;
      int maxValue = 999999;
      if (validatorInt(tbpowerModeChangedDelay.Text, minValue, maxValue, true) == false)
      {
        MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorInvalidIntegerBetween.Replace("[minInteger]", minValue.ToString()).Replace("[maxInteger]", maxValue.ToString()), LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void tbarBoblightSpeed_ValueChanged(Object sender, EventArgs e)
    {
      tbBoblightSpeed.Text = tbarBoblightSpeed.Value.ToString();
    }

    private void tbarBoblightAutospeed_ValueChanged(Object sender, EventArgs e)
    {
      tbBoblightAutospeed.Text = tbarBoblightAutospeed.Value.ToString();
    }

    private void tbarBoblightSaturation_ValueChanged(Object sender, EventArgs e)
    {
      tbBoblightSaturation.Text = tbarBoblightSaturation.Value.ToString();
    }

    private void tbarBoblightValue_ValueChanged(Object sender, EventArgs e)
    {
      tbBoblightValue.Text = tbarBoblightValue.Value.ToString();
    }

    private void tbarBoblightThreshold_ValueChanged(Object sender, EventArgs e)
    {
      tbBoblightThreshold.Text = tbarBoblightThreshold.Value.ToString();
    }

    private void tbarBoblightGamma_ValueChanged(Object sender, EventArgs e)
    {
      tbBoblightGamma.Text = ((double)tbarBoblightGamma.Value / 10).ToString();
    }

    // Dynamic effect changes
    public void UpdateComboBoxes()
    {
      List<ContentEffect> supportedEffects = coreObject.GetSupportedEffects();

      cbVideo.Items.Clear();
      cbMusic.Items.Clear();
      cbRadio.Items.Clear();
      cbMenu.Items.Clear();
      cbMPExit.Items.Clear();

      foreach (ContentEffect effect in Enum.GetValues(typeof(ContentEffect)))
      {
        if (supportedEffects.Contains(effect) && effect != ContentEffect.Undefined)
        {
          // Cases in which all effects are possible
          cbMusic.Items.Add(LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + effect.ToString()));
          cbRadio.Items.Add(LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + effect.ToString()));

          // Cases in which VU Meter is not possible
          if (effect != ContentEffect.VUMeter && effect != ContentEffect.VUMeterRainbow)
          {
            cbVideo.Items.Add(LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + effect.ToString()));
            cbMenu.Items.Add(LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + effect.ToString()));

            // Cases in which Vu Meter, MPLiveView and GifReader are not possible
            if (effect != ContentEffect.MediaPortalLiveMode && effect != ContentEffect.GIFReader)
            {
              cbMPExit.Items.Add(LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + effect.ToString()));
            }
          }
        }
      }

      cbVideo.Text = LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + Settings.effectVideo.ToString());
      cbMusic.Text = LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + Settings.effectMusic.ToString());
      cbRadio.Text = LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + Settings.effectRadio.ToString());
      cbMenu.Text = LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + Settings.effectMenu.ToString());
      cbMPExit.Text = LanguageLoader.GetTranslationFromFieldName("ContextMenu_" + Settings.effectMPExit.ToString());
    }

    private void ckAtmowinEnabled_CheckedChanged(Object sender, EventArgs e)
    {
      if (ckAtmowinEnabled.Checked)
      {
        coreObject.AddTarget(Target.AtmoWin);
      }
      else
      {
        coreObject.RemoveTarget(Target.AtmoWin);
      }
      UpdateComboBoxes();
    }

    private void ckBoblightEnabled_CheckedChanged(Object sender, EventArgs e)
    {
      if (ckBoblightEnabled.Checked)
      {
        coreObject.AddTarget(Target.Boblight);
      }
      else
      {
        coreObject.RemoveTarget(Target.Boblight);
      }
      UpdateComboBoxes();
    }

    private void ckHyperionEnabled_CheckedChanged(Object sender, EventArgs e)
    {
      if (ckHyperionEnabled.Checked)
      {
        coreObject.AddTarget(Target.Hyperion);
      }
      else
      {
        coreObject.RemoveTarget(Target.Hyperion);
      }
      UpdateComboBoxes();
    }

    private void ckHueEnabled_CheckedChanged(Object sender, EventArgs e)
    {
      if (ckHueEnabled.Checked)
      {
        coreObject.AddTarget(Target.Hue);
      }
      else
      {
        coreObject.RemoveTarget(Target.Hue);
      }
      UpdateComboBoxes();
    }

    private void cbVideo_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.effectVideo = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbVideo.Text, "ContextMenu_").Remove(0, 12));
    }

    private void cbMusic_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.effectMusic = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbMusic.Text, "ContextMenu_").Remove(0, 12));
    }

    private void cbRadio_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.effectRadio = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbRadio.Text, "ContextMenu_").Remove(0, 12));
    }

    private void cbMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.effectMenu = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbMenu.Text, "ContextMenu_").Remove(0, 12));
    }

    private void cbMPExit_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.effectMPExit = (ContentEffect)Enum.Parse(typeof(ContentEffect), LanguageLoader.GetFieldNameFromTranslation(cbMPExit.Text, "ContextMenu_").Remove(0, 12));
    }
    private void btnSelectFileHue_Click(object sender, EventArgs e)
    {
      if (openFileDialog4.ShowDialog() == DialogResult.OK)
      {
        string filenameNoExtension = Path.GetFileNameWithoutExtension(openFileDialog4.FileName);
        string filename = filenameNoExtension.ToLower();
        if (filename == "atmohue")
        {
          edFileHue.Text = openFileDialog4.FileName;
        }
        else
        {
          MessageBox.Show(LanguageLoader.appStrings.SetupForm_ErrorHue, LanguageLoader.appStrings.SetupForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
          edFileHue.Text = "";
          return;
        }
      }

    }
  }
}
