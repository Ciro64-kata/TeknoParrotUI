﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using SharpDX;
using SharpDX.DirectInput;
using TeknoParrotUi.Common.InputProfiles.Helpers;
using TeknoParrotUi.Common.Jvs;
using DeviceType = SharpDX.DirectInput.DeviceType;

namespace TeknoParrotUi.Common.InputListening
{
    public class InputListenerDirectInput
    {
        private static GameProfile _gameProfile;
        public static bool KillMe;
        public static bool DisableTestButton;
        private static readonly DirectInput _diInput = new DirectInput();
        private static short _minX;
        private static short _maxX;
        private static short _minY;
        private static short _maxY;
        private static double _DivideX;
        private static double _DivideY;
        private static bool GunGame = false;
        private static bool _invertedMouseAxis = false;
        private static bool mkdxTest = false;
        private static bool changeWmmt5GearUp = false;
        private static bool changeWmmt5GearDown = false;
        private static bool changeFnfGearUp = false;
        private static bool changeFnfGearDown = false;
        private static bool changeSrcGearUp = false;
        private static bool changeSrcGearDown = false;
        private static bool changeIDZGearUp = false;
        private static bool changeIDZGearDown = false;
        private static bool bg4Key = false;
        private static bool KeyboardGasDown = false;
        private static bool P2KeyboardGasDown = false;
        private static bool P3KeyboardGasDown = false;
        private static bool P4KeyboardGasDown = false;
        private static bool P5KeyboardGasDown = false;
        private static bool P6KeyboardGasDown = false;
        private static bool KeyboardBrakeDown = false;
        private static bool KeyboardWheelLeft = false;
        private static bool KeyboardWheelRight = false;
        private static bool P2KeyboardWheelLeft = false;
        private static bool P2KeyboardWheelRight = false;
        private static bool P3KeyboardWheelLeft = false;
        private static bool P3KeyboardWheelRight = false;
        private static bool P4KeyboardWheelLeft = false;
        private static bool P4KeyboardWheelRight = false;
        private static bool P5KeyboardWheelLeft = false;
        private static bool P5KeyboardWheelRight = false;
        private static bool P6KeyboardWheelLeft = false;
        private static bool P6KeyboardWheelRight = false;
        private static bool KeyboardAnalogLeft = false;
        private static bool KeyboardAnalogRight = false;
        private static bool KeyboardAnalogDown = false;
        private static bool KeyboardAnalogUp = false;
        private static bool P2KeyboardAnalogLeft = false;
        private static bool P2KeyboardAnalogRight = false;
        private static bool P2KeyboardAnalogDown = false;
        private static bool P2KeyboardAnalogUp = false;
        private static bool P3KeyboardAnalogLeft = false;
        private static bool P3KeyboardAnalogRight = false;
        private static bool P3KeyboardAnalogDown = false;
        private static bool P3KeyboardAnalogUp = false;
        private static bool P4KeyboardAnalogLeft = false;
        private static bool P4KeyboardAnalogRight = false;
        private static bool P4KeyboardAnalogDown = false;
        private static bool P4KeyboardAnalogUp = false;
        private static bool KeyboardAnalogYDown = false;
        private static bool KeyboardAnalogYUp = false;
        private static bool KeyboardAnalogYLeft = false;
        private static bool KeyboardAnalogYRight = false;
        private static bool P2KeyboardAnalogYDown = false;
        private static bool P2KeyboardAnalogYUp = false;
        private static bool P2KeyboardAnalogYLeft = false;
        private static bool P2KeyboardAnalogYRight = false;
        private static bool P3KeyboardAnalogYDown = false;
        private static bool P3KeyboardAnalogYUp = false;
        private static bool P3KeyboardAnalogYLeft = false;
        private static bool P3KeyboardAnalogYRight = false;
        private static bool P4KeyboardAnalogYDown = false;
        private static bool P4KeyboardAnalogYUp = false;
        private static bool P4KeyboardAnalogYLeft = false;
        private static bool P4KeyboardAnalogYRight = false;
        private static bool KeyboardAnalogReverseDown = false;
        private static bool KeyboardAnalogReverseUp = false;
        private static bool KeyboardAnalogReverseLeft = false;
        private static bool KeyboardAnalogReverseRight = false;
        private static bool P2KeyboardAnalogReverseDown = false;
        private static bool P2KeyboardAnalogReverseUp = false;
        private static bool P2KeyboardAnalogReverseLeft = false;
        private static bool P2KeyboardAnalogReverseRight = false;
        private static bool P3KeyboardAnalogReverseDown = false;
        private static bool P3KeyboardAnalogReverseUp = false;
        private static bool P3KeyboardAnalogReverseLeft = false;
        private static bool P3KeyboardAnalogReverseRight = false;
        private static bool P4KeyboardAnalogReverseDown = false;
        private static bool P4KeyboardAnalogReverseUp = false;
        private static bool P4KeyboardAnalogReverseLeft = false;
        private static bool P4KeyboardAnalogReverseRight = false;
        private static bool KeyboardSWThrottleDown = false;
        private static bool KeyboardSWThrottleUp = false;
        private static bool KeyboardHandlebarLeft = false;
        private static bool KeyboardHandlebarRight = false;
        private static bool KeyboardorButtonAxis = false;
        private static bool ReverseYAxis = false;
        private static bool ReverseSWThrottleAxis = false;
        private static bool KeyboardWheelActivate = false;
        private static bool KeyboardWheelActivate2P = false;
        private static bool KeyboardWheelActivate3P = false;
        private static bool KeyboardWheelActivate4P = false;
        private static bool KeyboardWheelActivate5P = false;
        private static bool KeyboardWheelActivate6P = false;
        private static bool KeyboardGasActivate = false;
        private static bool KeyboardGasActivate2P = false;
        private static bool KeyboardGasActivate3P = false;
        private static bool KeyboardGasActivate4P = false;
        private static bool KeyboardGasActivate5P = false;
        private static bool KeyboardGasActivate6P = false;
        private static bool KeyboardBrakeActivate = false;
        private static bool KeyboardAnalogXActivate = false;
        private static bool KeyboardAnalogYActivate = false;
        private static bool KeyboardAnalogXActivate2P = false;
        private static bool KeyboardAnalogYActivate2P = false;
        private static bool KeyboardAnalogXActivate3P = false;
        private static bool KeyboardAnalogYActivate3P = false;
        private static bool KeyboardAnalogXActivate4P = false;
        private static bool KeyboardAnalogYActivate4P = false;
        private static bool KeyboardSWThrottleActivate = false;
        private static bool KeyboardHandlebarActivate = false;
        private static bool StartButtonInitialD = false;
        private static bool TestButtonInitialD = false;
        private static bool RelativeInput = false;
        private static bool RelativeTimer = false;
        private static bool KeyboardForAxisTimer = false;
        private static System.Timers.Timer timer = new System.Timers.Timer(16);
        private static System.Timers.Timer Relativetimer = new System.Timers.Timer(32);
        private static int minValWheel;
        private static int cntVal;
        private static int maxValWheel;
        private static int maxGasBrake;
        private static int minGasBrake;
        private static int KeyboardWheelValue;
        private static int KeyboardWheelValue2P;
        private static int KeyboardWheelValue3P;
        private static int KeyboardWheelValue4P;
        private static int KeyboardWheelValue5P;
        private static int KeyboardWheelValue6P;
        private static int KeyboardGasValue;
        private static int KeyboardGasValue2P;
        private static int KeyboardGasValue3P;
        private static int KeyboardGasValue4P;
        private static int KeyboardGasValue5P;
        private static int KeyboardGasValue6P;
        private static int KeyboardBrakeValue;
        private static int KeyboardAnalogXValue;
        private static int KeyboardAnalogYValue;
        private static int KeyboardAnalogXValue2P;
        private static int KeyboardAnalogYValue2P;
        private static int KeyboardAnalogXValue3P;
        private static int KeyboardAnalogYValue3P;
        private static int KeyboardAnalogXValue4P;
        private static int KeyboardAnalogYValue4P;
        private static int RelativeAnalogXValue1p;
        private static int RelativeAnalogYValue1p;
        private static int RelativeAnalogXValue2p;
        private static int RelativeAnalogYValue2p;
        private static int RelativeAnalogXValue3p;
        private static int RelativeAnalogYValue3p;
        private static int RelativeAnalogXValue4p;
        private static int RelativeAnalogYValue4p;
        private static int KeyboardThrottleValue;
        private static int KeyboardHandlebarValue;
        private static int KeyboardAnalogAxisSensitivity;
        private static int KeyboardAcclBrakeAxisSensitivity;
        private static int KeyboardHandlebarAxisSensitivity;
        private static int RelativeP1Sensitivity;
        private static int RelativeP2Sensitivity;
        private static int RelativeP3Sensitivity;
        private static int RelativeP4Sensitivity;
        private static int WheelAnalogByteValue = -1;
        private static int P2WheelAnalogByteValue = -1;
        private static int P3WheelAnalogByteValue = -1;
        private static int P4WheelAnalogByteValue = -1;
        private static int P5WheelAnalogByteValue = -1;
        private static int P6WheelAnalogByteValue = -1;
        private static int GasAnalogByteValue = -1;
        private static int P2GasAnalogByteValue = -1;
        private static int P3GasAnalogByteValue = -1;
        private static int P4GasAnalogByteValue = -1;
        private static int P5GasAnalogByteValue = -1;
        private static int P6GasAnalogByteValue = -1;
        private static int BrakeAnalogByteValue = -1;
        private static int AnalogXAnalogByteValue = -1;
        private static int AnalogYAnalogByteValue = -1;
        private static int P2AnalogXAnalogByteValue = -1;
        private static int P2AnalogYAnalogByteValue = -1;
        private static int P3AnalogXAnalogByteValue = -1;
        private static int P3AnalogYAnalogByteValue = -1;
        private static int P4AnalogXAnalogByteValue = -1;
        private static int P4AnalogYAnalogByteValue = -1;
        private static int ThrottleAnalogByteValue = -1;
        private static int HandlebarAnalogByteValue = -1;
        private static int AnalogXByteValue1p = -1;
        private static int AnalogYByteValue1p = -1;
        private static int AnalogXByteValue2p = -1;
        private static int AnalogYByteValue2p = -1;
        private static int AnalogXByteValue3p = -1;
        private static int AnalogYByteValue3p = -1;
        private static int AnalogXByteValue4p = -1;
        private static int AnalogYByteValue4p = -1;

        /// <summary>
        /// Checks if joystick or gamepad GUID is found.
        /// </summary>
        /// <param name="joystickGuid">Joystick GUID;:</param>
        /// <returns></returns>
        private bool DoesJoystickExist(Guid joystickGuid)
        {
            if (File.Exists("DirectInputOverride.txt"))
            {
                // Don't care about filters when using override!
                return _diInput.GetDevices().Any(x => x.InstanceGuid == joystickGuid);
            }

            return _diInput.GetDevices()
                .Any(
                    x => x.InstanceGuid == joystickGuid && x.Type != DeviceType.Device);
        }

        public void ListenDirectInput(List<JoystickButtons> joystickButtons, GameProfile gameProfile)
        {
            _gameProfile = gameProfile;
            var guids = new List<Guid>();
            changeWmmt5GearUp = false;
            changeWmmt5GearDown = false;
            changeFnfGearUp = false;
            changeFnfGearDown = false;
            changeSrcGearDown = false;
            changeSrcGearUp = false;
            changeIDZGearUp = false;
            changeIDZGearDown = false;
            mkdxTest = false;
            bg4Key = false;

            KeyboardorButtonAxis = gameProfile.ConfigValues.Any(x => x.FieldName == "Use Keyboard/Button For Axis" && x.FieldValue == "1");
            ReverseYAxis = gameProfile.ConfigValues.Any(x => x.FieldName == "Reverse Y Axis" && x.FieldValue == "1");
            ReverseSWThrottleAxis = gameProfile.ConfigValues.Any(x => x.FieldName == "Reverse Throttle Axis" && x.FieldValue == "1");
            RelativeInput = gameProfile.ConfigValues.Any(x => x.FieldName == "Use Relative Input" && x.FieldValue == "1");
            GunGame = gameProfile.GunGame;

            switch (_gameProfile.EmulationProfile)
            {
                case EmulationProfile.SegaInitialD:
                case EmulationProfile.SegaInitialDLindbergh:
                    minValWheel = 0x1F;
                    maxValWheel = 0xE1;
                    cntVal = 0x80;
                    minGasBrake = 0x00;
                    maxGasBrake = 0xFF;
                    break;
                case EmulationProfile.IDZ:
                    minValWheel = 0x36;
                    maxValWheel = 0xCA;
                    cntVal = 0x80;
                    minGasBrake = 0x00;
                    maxGasBrake = 0xFF;
                    break;
                case EmulationProfile.SegaSonicAllStarsRacing:
                    minValWheel = 0x1D;
                    maxValWheel = 0xED;
                    cntVal = 0x80;
                    minGasBrake = 0x00;
                    maxGasBrake = 0xFF;
                    break;
                case EmulationProfile.HummerExtreme:
                    minGasBrake = 0x20;
                    maxGasBrake = 0xD0;
                    cntVal = 0x80;
                    minValWheel = 0x1D;
                    maxValWheel = 0xE0;
                    break;
                case EmulationProfile.HotWheels:
                    minGasBrake = 0x05;
                    maxGasBrake = 0xE1;
                    cntVal = 0x7F;
                    minValWheel = 0x00;
                    maxValWheel = 0xFE;
                    break;
                default:
                    minValWheel = 0x00;
                    maxValWheel = 0xFF;
                    cntVal = 0x80;
                    minGasBrake = 0x00;
                    maxGasBrake = 0xFF;
                    break;
            }

            //Center values upon startup & Keyboard Axis Values
            if (_gameProfile.EmulationProfile == EmulationProfile.AfterBurnerClimax || _gameProfile.EmulationProfile == EmulationProfile.BlazingAngels)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                InputCode.AnalogBytes[4] = 0x80;
                AnalogXAnalogByteValue = 0;
                AnalogYAnalogByteValue = 2;
                ThrottleAnalogByteValue = 4;
            }


            if (_gameProfile.EmulationProfile == EmulationProfile.WonderlandWars || _gameProfile.EmulationProfile == EmulationProfile.SavageQuest)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                AnalogXAnalogByteValue = 0;
                AnalogYAnalogByteValue = 2;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.BorderBreak)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                AnalogXAnalogByteValue = 2;
                AnalogYAnalogByteValue = 0;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.ALLSFGO)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[4] = 0x80;
                AnalogXAnalogByteValue = 0;
                AnalogYAnalogByteValue = 4;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.NamcoMachStorm)
            {
                InputCode.AnalogBytes[2] = 0x80;
                InputCode.AnalogBytes[4] = 0x80;
                InputCode.AnalogBytes[6] = 0x80;
                ThrottleAnalogByteValue = 2;
                AnalogXAnalogByteValue = 4;
                AnalogYAnalogByteValue = 6;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.SAO)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                AnalogXAnalogByteValue = 0;
                AnalogYAnalogByteValue = 2;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.TMNT)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                InputCode.AnalogBytes[4] = 0x80;
                InputCode.AnalogBytes[6] = 0x80;
                InputCode.AnalogBytes[8] = 0x80;
                InputCode.AnalogBytes[10] = 0x80;
                InputCode.AnalogBytes[12] = 0x80;
                InputCode.AnalogBytes[14] = 0x80;
                AnalogXAnalogByteValue = 0;
                AnalogYAnalogByteValue = 2;
                P2AnalogXAnalogByteValue = 4;
                P2AnalogYAnalogByteValue = 6;
                P3AnalogXAnalogByteValue = 8;
                P3AnalogYAnalogByteValue = 10;
                P4AnalogXAnalogByteValue = 12;
                P4AnalogYAnalogByteValue = 14;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                InputCode.AnalogBytes[4] = 0x80;
                InputCode.AnalogBytes[6] = 0x80;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.TokyoCop)
            {
                InputCode.AnalogBytes[0] = 0x80;
                WheelAnalogByteValue = 0;
                GasAnalogByteValue = 2;
                BrakeAnalogByteValue = 4;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.RingRiders)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[6] = 0x80;
                WheelAnalogByteValue = 0;
                GasAnalogByteValue = 2;
                BrakeAnalogByteValue = 4;
                HandlebarAnalogByteValue = 6;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.Harley)
            {
                InputCode.AnalogBytes[2] = 0x80;
                WheelAnalogByteValue = 2;
                GasAnalogByteValue = 0;
                BrakeAnalogByteValue = 6;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.RadikalBikers)
            {
                InputCode.AnalogBytes[0] = 0x80;
                HandlebarAnalogByteValue = 0;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.TaitoTypeXBattleGear)
            {
                InputCode.PlayerDigitalButtons[0].Right = true; // Ensure Key sensor is pressed on boot (So its off)
                JvsHelper.StateView.Write(4, 0x80);
                WheelAnalogByteValue = 20;
                GasAnalogByteValue = 6;
                BrakeAnalogByteValue = 8;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.VirtuaRLimit)
            {
                JvsHelper.StateView.Write(4, 0x80);
                WheelAnalogByteValue = 20;
                GasAnalogByteValue = 2;
                BrakeAnalogByteValue = 4;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.ChaseHq2 || _gameProfile.EmulationProfile == EmulationProfile.WackyRaces)
            {
                InputCode.AnalogBytes[4] = 0x80;
                WheelAnalogByteValue = 4;
                GasAnalogByteValue = 6;
                BrakeAnalogByteValue = 8;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.ALLSSWDC || _gameProfile.EmulationProfile == EmulationProfile.ALLSIDTA)
            {
                InputCode.AnalogBytes[1] = 0x80;
                WheelAnalogByteValue = 1;
                GasAnalogByteValue = 3;
                BrakeAnalogByteValue = 5;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.Daytona3 || _gameProfile.EmulationProfile == EmulationProfile.EuropaRFordRacing || _gameProfile.EmulationProfile == EmulationProfile.EuropaRSegaRally3 || _gameProfile.EmulationProfile == EmulationProfile.FNFDrift || _gameProfile.EmulationProfile == EmulationProfile.GRID || _gameProfile.EmulationProfile == EmulationProfile.DeadHeat || _gameProfile.EmulationProfile == EmulationProfile.Nirin ||
                _gameProfile.EmulationProfile == EmulationProfile.GtiClub3 || _gameProfile.EmulationProfile == EmulationProfile.NamcoMkdx || _gameProfile.EmulationProfile == EmulationProfile.NamcoMkdxUsa || _gameProfile.EmulationProfile == EmulationProfile.NamcoWmmt5 || _gameProfile.EmulationProfile == EmulationProfile.DeadHeatRiders || _gameProfile.EmulationProfile == EmulationProfile.Outrun2SPX || _gameProfile.EmulationProfile == EmulationProfile.RawThrillsFNF || _gameProfile.EmulationProfile == EmulationProfile.RawThrillsFNFH2O ||
                _gameProfile.EmulationProfile == EmulationProfile.SegaInitialD || _gameProfile.EmulationProfile == EmulationProfile.SegaInitialDLindbergh || _gameProfile.EmulationProfile == EmulationProfile.SegaRTuned || _gameProfile.EmulationProfile == EmulationProfile.SegaRacingClassic || _gameProfile.EmulationProfile == EmulationProfile.SegaRtv || _gameProfile.EmulationProfile == EmulationProfile.SegaSonicAllStarsRacing || _gameProfile.EmulationProfile == EmulationProfile.SegaToolsIDZ ||
                _gameProfile.EmulationProfile == EmulationProfile.NamcoWmmt3 || _gameProfile.EmulationProfile == EmulationProfile.IDZ || _gameProfile.EmulationProfile == EmulationProfile.NamcoWmmt6RR)
            {
                InputCode.AnalogBytes[0] = 0x80;
                WheelAnalogByteValue = 0;
                GasAnalogByteValue = 2;
                BrakeAnalogByteValue = 4;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.MarioKartGP || _gameProfile.EmulationProfile == EmulationProfile.MarioKartGP2)
            {
                InputCode.AnalogBytes[0] = 0x80;
                WheelAnalogByteValue = 0;
                GasAnalogByteValue = 4;
                BrakeAnalogByteValue = 6;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.FZeroAX || _gameProfile.EmulationProfile == EmulationProfile.FZeroAXMonster)
            {
                InputCode.AnalogBytes[0] = 0x80;
                InputCode.AnalogBytes[2] = 0x80;
                WheelAnalogByteValue = 0;
                AnalogYAnalogByteValue = 2;
                GasAnalogByteValue = 4;
                BrakeAnalogByteValue = 6;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.HotWheels)
            {
                InputCode.AnalogBytes[0] = 0x7F;
                InputCode.AnalogBytes[4] = 0x7F;
                InputCode.AnalogBytes[8] = 0x7F;
                InputCode.AnalogBytes[12] = 0x7F;
                InputCode.AnalogBytes[16] = 0x7F;
                InputCode.AnalogBytes[20] = 0x7F;

                WheelAnalogByteValue = 0;
                GasAnalogByteValue = 2;
                P2WheelAnalogByteValue = 4;
                P2GasAnalogByteValue = 6;
                P3WheelAnalogByteValue = 8;
                P3GasAnalogByteValue = 10;
                P4WheelAnalogByteValue = 12;
                P4GasAnalogByteValue = 14;
                P5WheelAnalogByteValue = 16;
                P5GasAnalogByteValue = 18;
                P6WheelAnalogByteValue = 20;
                P6GasAnalogByteValue = 22;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.HummerExtreme)
            {
                InputCode.AnalogBytes[0] = 0x62;
                InputCode.AnalogBytes[2] = 0x20;
                InputCode.AnalogBytes[4] = 0x20;
                WheelAnalogByteValue = 0;
                GasAnalogByteValue = 2;
                BrakeAnalogByteValue = 4;
            }

            if (_gameProfile.EmulationProfile == EmulationProfile.FrenzyExpress || _gameProfile.EmulationProfile == EmulationProfile.LGS)
            {
                InputCode.AnalogBytes[0] = 0x80;
                WheelAnalogByteValue = 0;
            }

            if (GunGame)
            {
                _minX = gameProfile.xAxisMin;
                _maxX = gameProfile.xAxisMax;
                _minY = gameProfile.yAxisMin;
                _maxY = gameProfile.yAxisMax;
                _invertedMouseAxis = gameProfile.InvertedMouseAxis;

                _DivideX = 255.0 / (_maxX - _minX);
                _DivideY = 255.0 / (_maxY - _minY);

                if (_gameProfile.EmulationProfile == EmulationProfile.LuigisMansion || (!_invertedMouseAxis))
                {
                    InputCode.AnalogBytes[0] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[2] = (byte)((_maxX + _minX) / 2.0);
                    InputCode.AnalogBytes[4] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[6] = (byte)((_maxX + _minX) / 2.0);
                    InputCode.AnalogBytes[8] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[10] = (byte)((_maxX + _minX) / 2.0);
                    InputCode.AnalogBytes[12] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[14] = (byte)((_maxX + _minX) / 2.0);

                    if (RelativeInput)
                    {
                        AnalogXByteValue1p = 2;
                        AnalogYByteValue1p = 0;
                        AnalogXByteValue2p = 6;
                        AnalogYByteValue2p = 4;
                        AnalogXByteValue3p = 10;
                        AnalogYByteValue3p = 8;
                        AnalogXByteValue4p = 14;
                        AnalogYByteValue4p = 12;
                    }
                }
                else
                {
                    InputCode.AnalogBytes[0] = (byte)((_maxX + _minX) / 2.0);
                    InputCode.AnalogBytes[2] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[4] = (byte)((_maxX + _minX) / 2.0);
                    InputCode.AnalogBytes[6] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[8] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[10] = (byte)((_maxX + _minX) / 2.0);
                    InputCode.AnalogBytes[12] = (byte)((_maxY + _minY) / 2.0);
                    InputCode.AnalogBytes[14] = (byte)((_maxX + _minX) / 2.0);

                    if (RelativeInput)
                    {
                        AnalogXByteValue1p = 0;
                        AnalogYByteValue1p = 2;
                        AnalogXByteValue2p = 4;
                        AnalogYByteValue2p = 6;
                        AnalogXByteValue3p = 8;
                        AnalogYByteValue3p = 10;
                        AnalogXByteValue4p = 12;
                        AnalogYByteValue4p = 14;
                    }
                }

                if (RelativeInput)
                {
                    RelativeAnalogXValue1p = (byte)((_maxX + _minX) / 2.0);
                    RelativeAnalogYValue1p = (byte)((_maxY + _minY) / 2.0);
                    RelativeAnalogXValue2p = (byte)((_maxX + _minX) / 2.0);
                    RelativeAnalogYValue2p = (byte)((_maxY + _minY) / 2.0);
                    RelativeAnalogXValue3p = (byte)((_maxX + _minX) / 2.0);
                    RelativeAnalogYValue3p = (byte)((_maxY + _minY) / 2.0);
                    RelativeAnalogXValue4p = (byte)((_maxX + _minX) / 2.0);
                    RelativeAnalogYValue4p = (byte)((_maxY + _minY) / 2.0);


                    var P1SensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Player 1 Relative Sensitivity");
                    if (P1SensitivityA != null)
                        RelativeP1Sensitivity = System.Convert.ToInt32(P1SensitivityA.FieldValue);

                    var P2SensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Player 2 Relative Sensitivity");
                    if (P2SensitivityA != null)
                        RelativeP2Sensitivity = System.Convert.ToInt32(P2SensitivityA.FieldValue);

                    var P3SensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Player 3 Relative Sensitivity");
                    if (P3SensitivityA != null)
                        RelativeP3Sensitivity = System.Convert.ToInt32(P3SensitivityA.FieldValue);

                    var P4SensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Player 4 Relative Sensitivity");
                    if (P4SensitivityA != null)
                        RelativeP4Sensitivity = System.Convert.ToInt32(P4SensitivityA.FieldValue);

                    if (!RelativeTimer)
                    {
                        RelativeTimer = true;
                        Relativetimer.Elapsed += ListenRelativeAnalog;
                    }

                    Relativetimer.Start();
                }
            }

            if (KeyboardorButtonAxis)
            {
                if (_gameProfile.EmulationProfile == EmulationProfile.AfterBurnerClimax || _gameProfile.EmulationProfile == EmulationProfile.NamcoMachStorm || _gameProfile.EmulationProfile == EmulationProfile.BlazingAngels || _gameProfile.EmulationProfile == EmulationProfile.WonderlandWars || _gameProfile.EmulationProfile == EmulationProfile.ALLSFGO || _gameProfile.EmulationProfile == EmulationProfile.BorderBreak || _gameProfile.EmulationProfile == EmulationProfile.SavageQuest || _gameProfile.EmulationProfile == EmulationProfile.SAO || _gameProfile.EmulationProfile == EmulationProfile.TMNT)
                {
                    var KeyboardAnalogAxisSensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Keyboard/Button Axis X/Y Sensitivity");
                    if (KeyboardAnalogAxisSensitivityA != null)
                        KeyboardAnalogAxisSensitivity = System.Convert.ToInt32(KeyboardAnalogAxisSensitivityA.FieldValue);

                    var KeyboardAcclBrakeAxisSensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Keyboard/Button Axis Throttle Sensitivity");
                    if (KeyboardAcclBrakeAxisSensitivityA != null)
                        KeyboardAcclBrakeAxisSensitivity = System.Convert.ToInt32(KeyboardAcclBrakeAxisSensitivityA.FieldValue);
                }
                else if (_gameProfile.EmulationProfile == EmulationProfile.Daytona3 || _gameProfile.EmulationProfile == EmulationProfile.EuropaRFordRacing || _gameProfile.EmulationProfile == EmulationProfile.EuropaRSegaRally3 || _gameProfile.EmulationProfile == EmulationProfile.FNFDrift || _gameProfile.EmulationProfile == EmulationProfile.GRID || _gameProfile.EmulationProfile == EmulationProfile.ALLSSWDC || _gameProfile.EmulationProfile == EmulationProfile.DeadHeat || _gameProfile.EmulationProfile == EmulationProfile.Nirin ||
                _gameProfile.EmulationProfile == EmulationProfile.GtiClub3 || _gameProfile.EmulationProfile == EmulationProfile.NamcoMkdx || _gameProfile.EmulationProfile == EmulationProfile.NamcoMkdxUsa || _gameProfile.EmulationProfile == EmulationProfile.NamcoWmmt5 || _gameProfile.EmulationProfile == EmulationProfile.DeadHeatRiders || _gameProfile.EmulationProfile == EmulationProfile.Outrun2SPX || _gameProfile.EmulationProfile == EmulationProfile.RawThrillsFNF || _gameProfile.EmulationProfile == EmulationProfile.RawThrillsFNFH2O ||
                _gameProfile.EmulationProfile == EmulationProfile.SegaInitialD || _gameProfile.EmulationProfile == EmulationProfile.SegaInitialDLindbergh || _gameProfile.EmulationProfile == EmulationProfile.SegaRTuned || _gameProfile.EmulationProfile == EmulationProfile.SegaRacingClassic || _gameProfile.EmulationProfile == EmulationProfile.SegaRtv || _gameProfile.EmulationProfile == EmulationProfile.SegaSonicAllStarsRacing ||
                _gameProfile.EmulationProfile == EmulationProfile.SegaToolsIDZ || _gameProfile.EmulationProfile == EmulationProfile.ChaseHq2 || _gameProfile.EmulationProfile == EmulationProfile.WackyRaces || _gameProfile.EmulationProfile == EmulationProfile.VirtuaRLimit || _gameProfile.EmulationProfile == EmulationProfile.TaitoTypeXBattleGear || _gameProfile.EmulationProfile == EmulationProfile.TokyoCop || _gameProfile.EmulationProfile == EmulationProfile.RingRiders || _gameProfile.EmulationProfile == EmulationProfile.RadikalBikers ||
                _gameProfile.EmulationProfile == EmulationProfile.FrenzyExpress || _gameProfile.EmulationProfile == EmulationProfile.NamcoWmmt3 || _gameProfile.EmulationProfile == EmulationProfile.HummerExtreme || _gameProfile.EmulationProfile == EmulationProfile.Harley || _gameProfile.EmulationProfile == EmulationProfile.IDZ || _gameProfile.EmulationProfile == EmulationProfile.HotWheels || _gameProfile.EmulationProfile == EmulationProfile.ALLSIDTA || _gameProfile.EmulationProfile == EmulationProfile.LGS || _gameProfile.EmulationProfile == EmulationProfile.NamcoWmmt6RR
                || _gameProfile.EmulationProfile == EmulationProfile.MarioKartGP || _gameProfile.EmulationProfile == EmulationProfile.MarioKartGP2 || _gameProfile.EmulationProfile == EmulationProfile.FZeroAX || _gameProfile.EmulationProfile == EmulationProfile.FZeroAXMonster)
                {
                    var KeyboardAnalogAxisSensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Keyboard/Button Axis Wheel Sensitivity");
                    if (KeyboardAnalogAxisSensitivityA != null)
                        KeyboardAnalogAxisSensitivity = System.Convert.ToInt32(KeyboardAnalogAxisSensitivityA.FieldValue);

                    var KeyboardAcclBrakeAxisSensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Keyboard/Button Axis Pedal Sensitivity");
                    if (KeyboardAcclBrakeAxisSensitivityA != null)
                        KeyboardAcclBrakeAxisSensitivity = System.Convert.ToInt32(KeyboardAcclBrakeAxisSensitivityA.FieldValue);

                    if (_gameProfile.EmulationProfile == EmulationProfile.RingRiders || _gameProfile.EmulationProfile == EmulationProfile.RadikalBikers)
                    {
                        var KeyboardHandleBarAxisSensitivityA = gameProfile.ConfigValues.FirstOrDefault(x => x.FieldName == "Keyboard/Button Axis Handlebar Sensitivity");
                        if (KeyboardHandleBarAxisSensitivityA != null)
                            KeyboardHandlebarAxisSensitivity = System.Convert.ToInt32(KeyboardHandleBarAxisSensitivityA.FieldValue);
                    }
                }

                if (GasAnalogByteValue >= 0)
                    KeyboardGasValue = InputCode.AnalogBytes[GasAnalogByteValue];

                if (P2GasAnalogByteValue >= 0)
                    KeyboardGasValue2P = InputCode.AnalogBytes[P2GasAnalogByteValue];

                if (P3GasAnalogByteValue >= 0)
                    KeyboardGasValue3P = InputCode.AnalogBytes[P3GasAnalogByteValue];

                if (P4GasAnalogByteValue >= 0)
                    KeyboardGasValue4P = InputCode.AnalogBytes[P4GasAnalogByteValue];

                if (P5GasAnalogByteValue >= 0)
                    KeyboardGasValue5P = InputCode.AnalogBytes[P5GasAnalogByteValue];

                if (P6GasAnalogByteValue >= 0)
                    KeyboardGasValue6P = InputCode.AnalogBytes[P6GasAnalogByteValue];

                if (BrakeAnalogByteValue >= 0)
                    KeyboardBrakeValue = InputCode.AnalogBytes[BrakeAnalogByteValue];

                if (ThrottleAnalogByteValue >= 0)
                    KeyboardThrottleValue = InputCode.AnalogBytes[ThrottleAnalogByteValue];

                if (AnalogXAnalogByteValue >= 0)
                    KeyboardAnalogXValue = InputCode.AnalogBytes[AnalogXAnalogByteValue];

                if (AnalogYAnalogByteValue >= 0)
                    KeyboardAnalogYValue = InputCode.AnalogBytes[AnalogYAnalogByteValue];

                if (P2AnalogXAnalogByteValue >= 0)
                    KeyboardAnalogXValue2P = InputCode.AnalogBytes[P2AnalogXAnalogByteValue];

                if (P2AnalogYAnalogByteValue >= 0)
                    KeyboardAnalogYValue2P = InputCode.AnalogBytes[P2AnalogYAnalogByteValue];

                if (HandlebarAnalogByteValue >= 0)
                    KeyboardHandlebarValue = InputCode.AnalogBytes[HandlebarAnalogByteValue];

                if (WheelAnalogByteValue >= 0)
                {
                    switch (_gameProfile.EmulationProfile)
                    {
                        case EmulationProfile.TaitoTypeXBattleGear:
                        case EmulationProfile.VirtuaRLimit:
                            JvsHelper.StateView.ReadByte(4);
                            break;
                        default:
                            KeyboardWheelValue = InputCode.AnalogBytes[WheelAnalogByteValue];
                            break;
                    }
                }

                if (P2WheelAnalogByteValue >= 0)
                    KeyboardWheelValue2P = InputCode.AnalogBytes[P2WheelAnalogByteValue];

                if (P3WheelAnalogByteValue >= 0)
                    KeyboardWheelValue3P = InputCode.AnalogBytes[P3WheelAnalogByteValue];

                if (P4WheelAnalogByteValue >= 0)
                    KeyboardWheelValue4P = InputCode.AnalogBytes[P4WheelAnalogByteValue];

                if (P5WheelAnalogByteValue >= 0)
                    KeyboardWheelValue5P = InputCode.AnalogBytes[P5WheelAnalogByteValue];

                if (P6WheelAnalogByteValue >= 0)
                    KeyboardWheelValue6P = InputCode.AnalogBytes[P6WheelAnalogByteValue];

                if (!KeyboardForAxisTimer)
                {
                    KeyboardForAxisTimer = true;
                    timer.Elapsed += ListenKeyboardButton;
                }
                timer.Start();
            }

            // Find individual guis so we can listen.

            var nonNullButtons = joystickButtons.Where(x => x?.DirectInputButton != null).ToList();

            foreach (var t in nonNullButtons)
            {
                if (guids.All(x => x != t.DirectInputButton?.JoystickGuid))
                {
                    guids.Add(t.DirectInputButton.JoystickGuid);
                }
            }

            // Remove guids that we cannot listen!
            for (int i = 0; i < guids.Count; i++)
            {
                if (!DoesJoystickExist(guids[i]))
                {
                    guids.RemoveAt(i);
                    i = 0;
                }
            }

            // Spawn listeners
            foreach (var guid in guids)
            {
                var joystick = new Joystick(_diInput, guid);
                // Set BufferSize in order to use buffered data.
                joystick.Properties.BufferSize = 512;
                joystick.Acquire();
                var thread = new Thread(() => ListenJoystick(nonNullButtons.Where(x => x.DirectInputButton.JoystickGuid == guid).ToList(), joystick));
                thread.Start();
            }

            while (!KillMe)
                Thread.Sleep(5000);
        }

        private void ListenRelativeAnalog(object sender, ElapsedEventArgs e)
        {
            // P1
            if (AnalogXByteValue1p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[0].RelativeLeftPressed())
                    RelativeAnalogXValue1p = (byte)Math.Max(_minX, RelativeAnalogXValue1p - RelativeP1Sensitivity);
                else if (InputCode.PlayerDigitalButtons[0].RelativeRightPressed())
                    RelativeAnalogXValue1p = (byte)Math.Min(_maxX, RelativeAnalogXValue1p + RelativeP1Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogXByteValue1p] = (byte)RelativeAnalogXValue1p;
                else
                    InputCode.AnalogBytes[AnalogXByteValue1p] = (byte)~RelativeAnalogXValue1p;
            }

            if (AnalogYByteValue1p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[0].RelativeUpPressed())
                    RelativeAnalogYValue1p = (byte)Math.Max(_minY, RelativeAnalogYValue1p - RelativeP1Sensitivity);
                else if (InputCode.PlayerDigitalButtons[0].RelativeDownPressed())
                    RelativeAnalogYValue1p = (byte)Math.Min(_maxY, RelativeAnalogYValue1p + RelativeP1Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogYByteValue1p] = (byte)RelativeAnalogYValue1p;
                else
                    InputCode.AnalogBytes[AnalogYByteValue1p] = (byte)~RelativeAnalogYValue1p;
            }

            // P2
            if (AnalogXByteValue2p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[1].RelativeLeftPressed())
                    RelativeAnalogXValue2p = (byte)Math.Max(_minX, RelativeAnalogXValue2p - RelativeP2Sensitivity);
                else if (InputCode.PlayerDigitalButtons[1].RelativeRightPressed())
                    RelativeAnalogXValue2p = (byte)Math.Min(_maxX, RelativeAnalogXValue2p + RelativeP2Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogXByteValue2p] = (byte)RelativeAnalogXValue2p;
                else
                    InputCode.AnalogBytes[AnalogXByteValue2p] = (byte)~RelativeAnalogXValue2p;
            }

            if (AnalogYByteValue2p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[1].RelativeUpPressed())
                    RelativeAnalogYValue2p = (byte)Math.Max(_minY, RelativeAnalogYValue2p - RelativeP2Sensitivity);
                else if (InputCode.PlayerDigitalButtons[1].RelativeDownPressed())
                    RelativeAnalogYValue2p = (byte)Math.Min(_maxY, RelativeAnalogYValue2p + RelativeP2Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogYByteValue2p] = (byte)RelativeAnalogYValue2p;
                else
                    InputCode.AnalogBytes[AnalogYByteValue2p] = (byte)~RelativeAnalogYValue2p;
            }

            // P3
            if (AnalogXByteValue3p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[2].RelativeLeftPressed())
                    RelativeAnalogXValue3p = (byte)Math.Max(_minX, RelativeAnalogXValue3p - RelativeP3Sensitivity);
                else if (InputCode.PlayerDigitalButtons[2].RelativeRightPressed())
                    RelativeAnalogXValue3p = (byte)Math.Min(_maxX, RelativeAnalogXValue3p + RelativeP3Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogXByteValue3p] = (byte)RelativeAnalogXValue3p;
                else
                    InputCode.AnalogBytes[AnalogXByteValue3p] = (byte)~RelativeAnalogXValue3p;
            }

            if (AnalogYByteValue3p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[2].RelativeUpPressed())
                    RelativeAnalogYValue3p = (byte)Math.Max(_minY, RelativeAnalogYValue3p - RelativeP3Sensitivity);
                else if (InputCode.PlayerDigitalButtons[2].RelativeDownPressed())
                    RelativeAnalogYValue3p = (byte)Math.Min(_maxY, RelativeAnalogYValue3p + RelativeP3Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogYByteValue3p] = (byte)RelativeAnalogYValue3p;
                else
                    InputCode.AnalogBytes[AnalogYByteValue3p] = (byte)~RelativeAnalogYValue3p;
            }

            // P4
            if (AnalogXByteValue4p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[3].RelativeLeftPressed())
                    RelativeAnalogXValue4p = (byte)Math.Max(_minX, RelativeAnalogXValue4p - RelativeP4Sensitivity);
                else if (InputCode.PlayerDigitalButtons[3].RelativeRightPressed())
                    RelativeAnalogXValue4p = (byte)Math.Min(_maxX, RelativeAnalogXValue4p + RelativeP4Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogXByteValue4p] = (byte)RelativeAnalogXValue4p;
                else
                    InputCode.AnalogBytes[AnalogXByteValue4p] = (byte)~RelativeAnalogXValue4p;
            }

            if (AnalogYByteValue4p >= 0)
            {
                if (InputCode.PlayerDigitalButtons[3].RelativeUpPressed())
                    RelativeAnalogYValue4p = (byte)Math.Max(_minY, RelativeAnalogYValue4p - RelativeP4Sensitivity);
                else if (InputCode.PlayerDigitalButtons[3].RelativeDownPressed())
                    RelativeAnalogYValue4p = (byte)Math.Min(_maxY, RelativeAnalogYValue4p + RelativeP4Sensitivity);

                if (_invertedMouseAxis)
                    InputCode.AnalogBytes[AnalogYByteValue4p] = (byte)RelativeAnalogYValue4p;
                else
                    InputCode.AnalogBytes[AnalogYByteValue4p] = (byte)~RelativeAnalogYValue4p;
            }

            if (KillMe)
            {
                RelativeTimer = false;
                Relativetimer.Stop();
                Relativetimer.Enabled = false;
                Relativetimer.Elapsed -= ListenRelativeAnalog;
                AnalogXByteValue1p = -1;
                AnalogYByteValue1p = -1;
                AnalogXByteValue2p = -1;
                AnalogYByteValue2p = -1;
                AnalogXByteValue3p = -1;
                AnalogYByteValue3p = -1;
                AnalogXByteValue4p = -1;
                AnalogYByteValue4p = -1;
                RelativeAnalogXValue1p = 0;
                RelativeAnalogYValue1p = 0;
                RelativeAnalogXValue2p = 0;
                RelativeAnalogYValue2p = 0;
                RelativeAnalogXValue3p = 0;
                RelativeAnalogYValue3p = 0;
                RelativeAnalogXValue4p = 0;
                RelativeAnalogYValue4p = 0;
                RelativeP1Sensitivity = 0;
                RelativeP2Sensitivity = 0;
                RelativeP3Sensitivity = 0;
                RelativeP4Sensitivity = 0;
            }
        }

        private void ListenKeyboardButton(object sender, ElapsedEventArgs e)
        {
            if (WheelAnalogByteValue >= 0 && KeyboardWheelActivate)
            {
                if (KeyboardWheelRight && KeyboardWheelLeft)
                {
                    switch (_gameProfile.EmulationProfile)
                    {
                        case EmulationProfile.TaitoTypeXBattleGear:
                        case EmulationProfile.VirtuaRLimit:
                            JvsHelper.StateView.Write(4, KeyboardWheelValue);
                            break;
                        default:
                            InputCode.AnalogBytes[WheelAnalogByteValue] = (byte)KeyboardWheelValue;
                            break;
                    }
                }
                else if (KeyboardWheelRight)
                {
                    switch (_gameProfile.EmulationProfile)
                    {
                        case EmulationProfile.TaitoTypeXBattleGear:
                        case EmulationProfile.VirtuaRLimit:
                            JvsHelper.StateView.Write(4, (byte)Math.Min(maxValWheel, KeyboardWheelValue + KeyboardAnalogAxisSensitivity));
                            break;
                        default:
                            InputCode.AnalogBytes[WheelAnalogByteValue] = (byte)Math.Min(maxValWheel, KeyboardWheelValue + KeyboardAnalogAxisSensitivity);
                            break;
                    }
                }
                else if (KeyboardWheelLeft)
                {
                    switch (_gameProfile.EmulationProfile)
                    {
                        case EmulationProfile.TaitoTypeXBattleGear:
                        case EmulationProfile.VirtuaRLimit:
                            JvsHelper.StateView.Write(4, (byte)Math.Max(minValWheel, KeyboardWheelValue - KeyboardAnalogAxisSensitivity));
                            break;
                        default:
                            InputCode.AnalogBytes[WheelAnalogByteValue] = (byte)Math.Max(minValWheel, KeyboardWheelValue - KeyboardAnalogAxisSensitivity);
                            break;
                    }
                }
                else
                {
                    if (KeyboardWheelValue < cntVal)
                    {
                        switch (_gameProfile.EmulationProfile)
                        {
                            case EmulationProfile.TaitoTypeXBattleGear:
                            case EmulationProfile.VirtuaRLimit:
                                JvsHelper.StateView.Write(4, (byte)Math.Min(cntVal, KeyboardWheelValue + KeyboardAnalogAxisSensitivity));
                                break;
                            default:
                                InputCode.AnalogBytes[WheelAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardWheelValue + KeyboardAnalogAxisSensitivity);
                                break;
                        }
                    }
                    else if (KeyboardWheelValue > cntVal)
                    {
                        switch (_gameProfile.EmulationProfile)
                        {
                            case EmulationProfile.TaitoTypeXBattleGear:
                            case EmulationProfile.VirtuaRLimit:
                                JvsHelper.StateView.Write(4, (byte)Math.Max(cntVal, KeyboardWheelValue - KeyboardAnalogAxisSensitivity));
                                break;
                            default:
                                InputCode.AnalogBytes[WheelAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardWheelValue - KeyboardAnalogAxisSensitivity);
                                break;
                        }
                    }
                    else
                    {
                        switch (_gameProfile.EmulationProfile)
                        {
                            case EmulationProfile.TaitoTypeXBattleGear:
                            case EmulationProfile.VirtuaRLimit:
                                JvsHelper.StateView.Write(4, (byte)cntVal);
                                break;
                            default:
                                InputCode.AnalogBytes[WheelAnalogByteValue] = (byte)cntVal;
                                break;
                        }
                    }
                }

                switch (_gameProfile.EmulationProfile)
                {
                    case EmulationProfile.TaitoTypeXBattleGear:
                    case EmulationProfile.VirtuaRLimit:
                        KeyboardWheelValue = JvsHelper.StateView.ReadByte(4);
                        break;
                    default:
                        KeyboardWheelValue = InputCode.AnalogBytes[WheelAnalogByteValue];
                        break;
                }
            }

            if (P2WheelAnalogByteValue >= 0 && KeyboardWheelActivate2P)
            {
                if (P2KeyboardWheelRight && P2KeyboardWheelLeft)
                    InputCode.AnalogBytes[P2WheelAnalogByteValue] = (byte)KeyboardWheelValue2P;
                else if (P2KeyboardWheelRight)
                    InputCode.AnalogBytes[P2WheelAnalogByteValue] = (byte)Math.Min(maxValWheel, KeyboardWheelValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardWheelLeft)
                    InputCode.AnalogBytes[P2WheelAnalogByteValue] = (byte)Math.Max(minValWheel, KeyboardWheelValue2P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardWheelValue2P < cntVal)
                        InputCode.AnalogBytes[P2WheelAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardWheelValue2P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardWheelValue2P > cntVal)
                        InputCode.AnalogBytes[P2WheelAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardWheelValue2P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P2WheelAnalogByteValue] = (byte)cntVal;
                }
                KeyboardWheelValue2P = InputCode.AnalogBytes[P2WheelAnalogByteValue];
            }

            if (P3WheelAnalogByteValue >= 0 && KeyboardWheelActivate3P)
            {
                if (P3KeyboardWheelRight && P3KeyboardWheelLeft)
                    InputCode.AnalogBytes[P3WheelAnalogByteValue] = (byte)KeyboardWheelValue3P;
                else if (P3KeyboardWheelRight)
                    InputCode.AnalogBytes[P3WheelAnalogByteValue] = (byte)Math.Min(maxValWheel, KeyboardWheelValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardWheelLeft)
                    InputCode.AnalogBytes[P3WheelAnalogByteValue] = (byte)Math.Max(minValWheel, KeyboardWheelValue3P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardWheelValue3P < cntVal)
                        InputCode.AnalogBytes[P3WheelAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardWheelValue3P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardWheelValue3P > cntVal)
                        InputCode.AnalogBytes[P3WheelAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardWheelValue3P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P3WheelAnalogByteValue] = (byte)cntVal;
                }
                KeyboardWheelValue3P = InputCode.AnalogBytes[P3WheelAnalogByteValue];
            }

            if (P4WheelAnalogByteValue >= 0 && KeyboardWheelActivate4P)
            {
                if (P4KeyboardWheelRight && P4KeyboardWheelLeft)
                    InputCode.AnalogBytes[P4WheelAnalogByteValue] = (byte)KeyboardWheelValue4P;
                else if (P4KeyboardWheelRight)
                    InputCode.AnalogBytes[P4WheelAnalogByteValue] = (byte)Math.Min(maxValWheel, KeyboardWheelValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardWheelLeft)
                    InputCode.AnalogBytes[P4WheelAnalogByteValue] = (byte)Math.Max(minValWheel, KeyboardWheelValue4P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardWheelValue4P < cntVal)
                        InputCode.AnalogBytes[P4WheelAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardWheelValue4P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardWheelValue4P > cntVal)
                        InputCode.AnalogBytes[P4WheelAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardWheelValue4P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P4WheelAnalogByteValue] = (byte)cntVal;
                }
                KeyboardWheelValue4P = InputCode.AnalogBytes[P4WheelAnalogByteValue];
            }

            if (P5WheelAnalogByteValue >= 0 && KeyboardWheelActivate5P)
            {
                if (P5KeyboardWheelRight && P5KeyboardWheelLeft)
                    InputCode.AnalogBytes[P5WheelAnalogByteValue] = (byte)KeyboardWheelValue5P;
                else if (P5KeyboardWheelRight)
                    InputCode.AnalogBytes[P5WheelAnalogByteValue] = (byte)Math.Min(maxValWheel, KeyboardWheelValue5P + KeyboardAnalogAxisSensitivity);
                else if (P5KeyboardWheelLeft)
                    InputCode.AnalogBytes[P5WheelAnalogByteValue] = (byte)Math.Max(minValWheel, KeyboardWheelValue5P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardWheelValue5P < cntVal)
                        InputCode.AnalogBytes[P5WheelAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardWheelValue5P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardWheelValue5P > cntVal)
                        InputCode.AnalogBytes[P5WheelAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardWheelValue5P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P5WheelAnalogByteValue] = (byte)cntVal;
                }
                KeyboardWheelValue5P = InputCode.AnalogBytes[P5WheelAnalogByteValue];
            }

            if (P6WheelAnalogByteValue >= 0 && KeyboardWheelActivate6P)
            {
                if (P6KeyboardWheelRight && P6KeyboardWheelLeft)
                    InputCode.AnalogBytes[P6WheelAnalogByteValue] = (byte)KeyboardWheelValue6P;
                else if (P6KeyboardWheelRight)
                    InputCode.AnalogBytes[P6WheelAnalogByteValue] = (byte)Math.Min(maxValWheel, KeyboardWheelValue6P + KeyboardAnalogAxisSensitivity);
                else if (P6KeyboardWheelLeft)
                    InputCode.AnalogBytes[P6WheelAnalogByteValue] = (byte)Math.Max(minValWheel, KeyboardWheelValue6P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardWheelValue6P < cntVal)
                        InputCode.AnalogBytes[P6WheelAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardWheelValue6P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardWheelValue6P > cntVal)
                        InputCode.AnalogBytes[P6WheelAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardWheelValue6P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P6WheelAnalogByteValue] = (byte)cntVal;
                }
                KeyboardWheelValue6P = InputCode.AnalogBytes[P6WheelAnalogByteValue];
            }

            if (BrakeAnalogByteValue >= 0 && KeyboardBrakeActivate)
            {
                if (KeyboardBrakeDown)
                    InputCode.AnalogBytes[BrakeAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardBrakeValue + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[BrakeAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardBrakeValue - KeyboardAcclBrakeAxisSensitivity);

                KeyboardBrakeValue = InputCode.AnalogBytes[BrakeAnalogByteValue];
            }

            if (GasAnalogByteValue >= 0 && KeyboardGasActivate)
            {
                if (KeyboardGasDown)
                    InputCode.AnalogBytes[GasAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardGasValue + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[GasAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardGasValue - KeyboardAcclBrakeAxisSensitivity);

                KeyboardGasValue = InputCode.AnalogBytes[GasAnalogByteValue];
            }

            if (P2GasAnalogByteValue >= 0 && KeyboardGasActivate2P)
            {
                if (P2KeyboardGasDown)
                    InputCode.AnalogBytes[P2GasAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardGasValue2P + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[P2GasAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardGasValue2P - KeyboardAcclBrakeAxisSensitivity);

                KeyboardGasValue2P = InputCode.AnalogBytes[P2GasAnalogByteValue];
            }

            if (P3GasAnalogByteValue >= 0 && KeyboardGasActivate3P)
            {
                if (P3KeyboardGasDown)
                    InputCode.AnalogBytes[P3GasAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardGasValue3P + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[P3GasAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardGasValue3P - KeyboardAcclBrakeAxisSensitivity);

                KeyboardGasValue3P = InputCode.AnalogBytes[P3GasAnalogByteValue];
            }

            if (P4GasAnalogByteValue >= 0 && KeyboardGasActivate4P)
            {
                if (P4KeyboardGasDown)
                    InputCode.AnalogBytes[P4GasAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardGasValue4P + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[P4GasAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardGasValue4P - KeyboardAcclBrakeAxisSensitivity);

                KeyboardGasValue4P = InputCode.AnalogBytes[P4GasAnalogByteValue];
            }

            if (P5GasAnalogByteValue >= 0 && KeyboardGasActivate5P)
            {
                if (P5KeyboardGasDown)
                    InputCode.AnalogBytes[P5GasAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardGasValue5P + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[P5GasAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardGasValue5P - KeyboardAcclBrakeAxisSensitivity);

                KeyboardGasValue5P = InputCode.AnalogBytes[P5GasAnalogByteValue];
            }

            if (P6GasAnalogByteValue >= 0 && KeyboardGasActivate6P)
            {
                if (P6KeyboardGasDown)
                    InputCode.AnalogBytes[P6GasAnalogByteValue] = (byte)Math.Min(maxGasBrake, KeyboardGasValue6P + KeyboardAcclBrakeAxisSensitivity);
                else
                    InputCode.AnalogBytes[P6GasAnalogByteValue] = (byte)Math.Max(minGasBrake, KeyboardGasValue6P - KeyboardAcclBrakeAxisSensitivity);

                KeyboardGasValue6P = InputCode.AnalogBytes[P6GasAnalogByteValue];
            }

            if (AnalogXAnalogByteValue >= 0 && KeyboardAnalogXActivate)
            {
                if (KeyboardAnalogYRight && KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue;
                else if (KeyboardAnalogYRight)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue + KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue - KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogRight && KeyboardAnalogLeft)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue;
                else if (KeyboardAnalogRight)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue + KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogLeft)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue - KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogReverseRight && KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue;
                else if (KeyboardAnalogReverseRight)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Min(0x00, KeyboardAnalogXValue + KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Max(0xFF, KeyboardAnalogXValue - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogXValue < cntVal)
                        InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogXValue + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogXValue > cntVal)
                        InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogXValue - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[AnalogXAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogXValue = InputCode.AnalogBytes[AnalogXAnalogByteValue];
            }

            if (AnalogYAnalogByteValue >= 0 && KeyboardAnalogYActivate)
            {
                if (KeyboardAnalogYDown && KeyboardAnalogYUp)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue;
                else if (KeyboardAnalogYDown)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue - KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogYUp)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue + KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogReverseDown && KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue;
                else if (KeyboardAnalogReverseDown)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue + KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue - KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogDown && KeyboardAnalogUp)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue;
                else if (KeyboardAnalogUp)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue + KeyboardAnalogAxisSensitivity);
                else if (KeyboardAnalogDown)
                    InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogYValue < cntVal)
                        InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogYValue + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogYValue > cntVal)
                        InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogYValue - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[AnalogYAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogYValue = InputCode.AnalogBytes[AnalogYAnalogByteValue];
            }

            if (P2AnalogXAnalogByteValue >= 0 && KeyboardAnalogXActivate2P)
            {
                if (P2KeyboardAnalogYRight && P2KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue2P;
                else if (P2KeyboardAnalogYRight)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue2P - KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogRight && P2KeyboardAnalogLeft)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue2P;
                else if (P2KeyboardAnalogRight)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogLeft)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue2P - KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogReverseRight && P2KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue2P;
                else if (P2KeyboardAnalogReverseRight)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Min(0x00, KeyboardAnalogXValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Max(0xFF, KeyboardAnalogXValue2P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogXValue2P < cntVal)
                        InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogXValue2P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogXValue2P > cntVal)
                        InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogXValue2P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P2AnalogXAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogXValue2P = InputCode.AnalogBytes[P2AnalogXAnalogByteValue];
            }

            if (P2AnalogYAnalogByteValue >= 0 && KeyboardAnalogYActivate2P)
            {
                if (P2KeyboardAnalogYDown && P2KeyboardAnalogYUp)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue2P;
                else if (P2KeyboardAnalogYDown)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue2P - KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogYUp)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogReverseDown && P2KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue2P;
                else if (P2KeyboardAnalogReverseDown)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue2P - KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogDown && P2KeyboardAnalogUp)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue2P;
                else if (P2KeyboardAnalogUp)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue2P + KeyboardAnalogAxisSensitivity);
                else if (P2KeyboardAnalogDown)
                    InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue2P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogYValue2P < cntVal)
                        InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogYValue2P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogYValue2P > cntVal)
                        InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogYValue2P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P2AnalogYAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogYValue2P = InputCode.AnalogBytes[P2AnalogYAnalogByteValue];
            }

            if (P3AnalogXAnalogByteValue >= 0 && KeyboardAnalogXActivate3P)
            {
                if (P3KeyboardAnalogYRight && P3KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue3P;
                else if (P3KeyboardAnalogYRight)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue3P - KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogRight && P3KeyboardAnalogLeft)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue3P;
                else if (P3KeyboardAnalogRight)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogLeft)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue3P - KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogReverseRight && P3KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue3P;
                else if (P3KeyboardAnalogReverseRight)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Min(0x00, KeyboardAnalogXValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Max(0xFF, KeyboardAnalogXValue3P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogXValue3P < cntVal)
                        InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogXValue3P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogXValue3P > cntVal)
                        InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogXValue3P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P3AnalogXAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogXValue3P = InputCode.AnalogBytes[P3AnalogXAnalogByteValue];
            }

            if (P3AnalogYAnalogByteValue >= 0 && KeyboardAnalogYActivate3P)
            {
                if (P3KeyboardAnalogYDown && P3KeyboardAnalogYUp)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue3P;
                else if (P3KeyboardAnalogYDown)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue3P - KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogYUp)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogReverseDown && P3KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue3P;
                else if (P3KeyboardAnalogReverseDown)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue3P - KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogDown && P3KeyboardAnalogUp)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue3P;
                else if (P3KeyboardAnalogUp)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue3P + KeyboardAnalogAxisSensitivity);
                else if (P3KeyboardAnalogDown)
                    InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue3P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogYValue3P < cntVal)
                        InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogYValue3P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogYValue3P > cntVal)
                        InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogYValue3P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P3AnalogYAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogYValue3P = InputCode.AnalogBytes[P3AnalogYAnalogByteValue];
            }

            if (P4AnalogXAnalogByteValue >= 0 && KeyboardAnalogXActivate4P)
            {
                if (P4KeyboardAnalogYRight && P4KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue4P;
                else if (P4KeyboardAnalogYRight)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogYLeft)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue4P - KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogRight && P4KeyboardAnalogLeft)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue4P;
                else if (P4KeyboardAnalogRight)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogXValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogLeft)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogXValue4P - KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogReverseRight && P4KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)KeyboardAnalogXValue4P;
                else if (P4KeyboardAnalogReverseRight)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Min(0x00, KeyboardAnalogXValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogReverseLeft)
                    InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Max(0xFF, KeyboardAnalogXValue4P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogXValue4P < cntVal)
                        InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogXValue4P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogXValue4P > cntVal)
                        InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogXValue4P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P4AnalogXAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogXValue4P = InputCode.AnalogBytes[P4AnalogXAnalogByteValue];
            }

            if (P4AnalogYAnalogByteValue >= 0 && KeyboardAnalogYActivate4P)
            {
                if (P4KeyboardAnalogYDown && P4KeyboardAnalogYUp)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue4P;
                else if (P4KeyboardAnalogYDown)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue4P - KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogYUp)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogReverseDown && P4KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue4P;
                else if (P4KeyboardAnalogReverseDown)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogReverseUp)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue4P - KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogDown && P4KeyboardAnalogUp)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)KeyboardAnalogYValue4P;
                else if (P4KeyboardAnalogUp)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardAnalogYValue4P + KeyboardAnalogAxisSensitivity);
                else if (P4KeyboardAnalogDown)
                    InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Max(0x00, KeyboardAnalogYValue4P - KeyboardAnalogAxisSensitivity);
                else
                {
                    if (KeyboardAnalogYValue4P < cntVal)
                        InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardAnalogYValue4P + KeyboardAnalogAxisSensitivity);
                    else if (KeyboardAnalogYValue4P > cntVal)
                        InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardAnalogYValue4P - KeyboardAnalogAxisSensitivity);
                    else
                        InputCode.AnalogBytes[P4AnalogYAnalogByteValue] = (byte)cntVal;
                }
                KeyboardAnalogYValue4P = InputCode.AnalogBytes[P4AnalogYAnalogByteValue];
            }

            if (ThrottleAnalogByteValue >= 0 && KeyboardSWThrottleActivate)
            {
                if (KeyboardSWThrottleDown && KeyboardSWThrottleUp)
                    InputCode.AnalogBytes[ThrottleAnalogByteValue] = (byte)KeyboardThrottleValue;
                else if (KeyboardSWThrottleDown)
                    InputCode.AnalogBytes[ThrottleAnalogByteValue] = (byte)Math.Max(0x00, KeyboardThrottleValue - KeyboardAcclBrakeAxisSensitivity);
                else if (KeyboardSWThrottleUp)
                    InputCode.AnalogBytes[ThrottleAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardThrottleValue + KeyboardAcclBrakeAxisSensitivity);
                else
                {
                    if (KeyboardThrottleValue < cntVal)
                        InputCode.AnalogBytes[ThrottleAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardThrottleValue + KeyboardAcclBrakeAxisSensitivity);
                    else if (KeyboardThrottleValue > cntVal)
                        InputCode.AnalogBytes[ThrottleAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardThrottleValue + KeyboardAcclBrakeAxisSensitivity);
                    else
                        InputCode.AnalogBytes[ThrottleAnalogByteValue] = (byte)cntVal;
                }
                KeyboardThrottleValue = InputCode.AnalogBytes[ThrottleAnalogByteValue];
            }

            if (HandlebarAnalogByteValue >= 0 && KeyboardHandlebarActivate)
            {
                if (KeyboardHandlebarRight && KeyboardHandlebarLeft)
                    InputCode.AnalogBytes[HandlebarAnalogByteValue] = (byte)KeyboardHandlebarValue;
                else if (KeyboardHandlebarRight)
                    InputCode.AnalogBytes[HandlebarAnalogByteValue] = (byte)Math.Min(0xFF, KeyboardHandlebarValue + KeyboardHandlebarAxisSensitivity);
                else if (KeyboardHandlebarLeft)
                    InputCode.AnalogBytes[HandlebarAnalogByteValue] = (byte)Math.Max(0x00, KeyboardHandlebarValue - KeyboardHandlebarAxisSensitivity);
                else
                {
                    if (KeyboardHandlebarValue < cntVal)
                        InputCode.AnalogBytes[HandlebarAnalogByteValue] = (byte)Math.Min(cntVal, KeyboardHandlebarValue + KeyboardHandlebarAxisSensitivity);
                    else if (KeyboardHandlebarValue > cntVal)
                        InputCode.AnalogBytes[HandlebarAnalogByteValue] = (byte)Math.Max(cntVal, KeyboardHandlebarValue - KeyboardHandlebarAxisSensitivity);
                    else
                        InputCode.AnalogBytes[HandlebarAnalogByteValue] = (byte)cntVal;
                }
                KeyboardHandlebarValue = InputCode.AnalogBytes[HandlebarAnalogByteValue];
            }

            if (KillMe)
            {
                KeyboardForAxisTimer = false;
                timer.Enabled = false;
                timer.Stop();
                timer.Elapsed -= ListenKeyboardButton;
                KeyboardGasDown = false;
                P2KeyboardGasDown = false;
                P3KeyboardGasDown = false;
                P4KeyboardGasDown = false;
                P5KeyboardGasDown = false;
                P6KeyboardGasDown = false;
                KeyboardBrakeDown = false;
                KeyboardWheelLeft = false;
                KeyboardWheelRight = false;
                P2KeyboardWheelLeft = false;
                P2KeyboardWheelRight = false;
                P3KeyboardWheelLeft = false;
                P3KeyboardWheelRight = false;
                P4KeyboardWheelLeft = false;
                P4KeyboardWheelRight = false;
                P5KeyboardWheelLeft = false;
                P5KeyboardWheelRight = false;
                P6KeyboardWheelLeft = false;
                P6KeyboardWheelRight = false;
                KeyboardAnalogLeft = false;
                KeyboardAnalogRight = false;
                KeyboardAnalogDown = false;
                KeyboardAnalogUp = false;
                P2KeyboardAnalogLeft = false;
                P2KeyboardAnalogRight = false;
                P2KeyboardAnalogDown = false;
                P2KeyboardAnalogUp = false;
                P3KeyboardAnalogLeft = false;
                P3KeyboardAnalogRight = false;
                P3KeyboardAnalogDown = false;
                P3KeyboardAnalogUp = false;
                P4KeyboardAnalogLeft = false;
                P4KeyboardAnalogRight = false;
                P4KeyboardAnalogDown = false;
                P4KeyboardAnalogUp = false;
                KeyboardAnalogYDown = false;
                KeyboardAnalogYUp = false;
                KeyboardAnalogYLeft = false;
                KeyboardAnalogYRight = false;
                P2KeyboardAnalogYDown = false;
                P2KeyboardAnalogYUp = false;
                P2KeyboardAnalogYLeft = false;
                P2KeyboardAnalogYRight = false;
                P3KeyboardAnalogYDown = false;
                P3KeyboardAnalogYUp = false;
                P3KeyboardAnalogYLeft = false;
                P3KeyboardAnalogYRight = false;
                P4KeyboardAnalogYDown = false;
                P4KeyboardAnalogYUp = false;
                P4KeyboardAnalogYLeft = false;
                P4KeyboardAnalogYRight = false;
                KeyboardAnalogReverseDown = false;
                KeyboardAnalogReverseUp = false;
                KeyboardAnalogReverseLeft = false;
                KeyboardAnalogReverseRight = false;
                P2KeyboardAnalogReverseDown = false;
                P2KeyboardAnalogReverseUp = false;
                P2KeyboardAnalogReverseLeft = false;
                P2KeyboardAnalogReverseRight = false;
                P3KeyboardAnalogReverseDown = false;
                P3KeyboardAnalogReverseUp = false;
                P3KeyboardAnalogReverseLeft = false;
                P3KeyboardAnalogReverseRight = false;
                P4KeyboardAnalogReverseDown = false;
                P4KeyboardAnalogReverseUp = false;
                P4KeyboardAnalogReverseLeft = false;
                P4KeyboardAnalogReverseRight = false;
                KeyboardSWThrottleDown = false;
                KeyboardSWThrottleUp = false;
                KeyboardHandlebarLeft = false;
                KeyboardHandlebarRight = false;
                KeyboardorButtonAxis = false;
                KeyboardWheelActivate = false;
                KeyboardWheelActivate2P = false;
                KeyboardWheelActivate3P = false;
                KeyboardWheelActivate4P = false;
                KeyboardWheelActivate5P = false;
                KeyboardWheelActivate6P = false;
                KeyboardGasActivate = false;
                KeyboardGasActivate2P = false;
                KeyboardGasActivate3P = false;
                KeyboardGasActivate4P = false;
                KeyboardGasActivate5P = false;
                KeyboardGasActivate6P = false;
                KeyboardBrakeActivate = false;
                KeyboardAnalogXActivate = false;
                KeyboardAnalogYActivate = false;
                KeyboardAnalogXActivate2P = false;
                KeyboardAnalogYActivate2P = false;
                KeyboardAnalogXActivate3P = false;
                KeyboardAnalogYActivate3P = false;
                KeyboardAnalogXActivate4P = false;
                KeyboardAnalogYActivate4P = false;
                KeyboardSWThrottleActivate = false;
                KeyboardHandlebarActivate = false;
                GasAnalogByteValue = -1;
                P2GasAnalogByteValue = -1;
                P3GasAnalogByteValue = -1;
                P4GasAnalogByteValue = -1;
                P5GasAnalogByteValue = -1;
                P6GasAnalogByteValue = -1;
                BrakeAnalogByteValue = -1;
                ThrottleAnalogByteValue = -1;
                AnalogXAnalogByteValue = -1;
                AnalogYAnalogByteValue = -1;
                P2AnalogXAnalogByteValue = -1;
                P2AnalogYAnalogByteValue = -1;
                P3AnalogXAnalogByteValue = -1;
                P3AnalogYAnalogByteValue = -1;
                P4AnalogXAnalogByteValue = -1;
                P4AnalogYAnalogByteValue = -1;
                HandlebarAnalogByteValue = -1;
                WheelAnalogByteValue = -1;
                P2WheelAnalogByteValue = -1;
                P3WheelAnalogByteValue = -1;
                P4WheelAnalogByteValue = -1;
                P5WheelAnalogByteValue = -1;
                P6WheelAnalogByteValue = -1;
                KeyboardAnalogAxisSensitivity = 0;
                KeyboardAcclBrakeAxisSensitivity = 0;
                KeyboardHandlebarAxisSensitivity = 0;
                KeyboardWheelValue = 0;
                KeyboardWheelValue2P = 0;
                KeyboardWheelValue3P = 0;
                KeyboardWheelValue4P = 0;
                KeyboardWheelValue5P = 0;
                KeyboardWheelValue6P = 0;
                KeyboardGasValue = 0;
                KeyboardGasValue2P = 0;
                KeyboardGasValue3P = 0;
                KeyboardGasValue4P = 0;
                KeyboardGasValue5P = 0;
                KeyboardGasValue6P = 0;
                KeyboardBrakeValue = 0;
                KeyboardAnalogXValue = 0;
                KeyboardAnalogYValue = 0;
                KeyboardAnalogXValue2P = 0;
                KeyboardAnalogYValue2P = 0;
                KeyboardAnalogXValue3P = 0;
                KeyboardAnalogYValue3P = 0;
                KeyboardAnalogXValue4P = 0;
                KeyboardAnalogYValue4P = 0;
                KeyboardThrottleValue = 0;
                KeyboardHandlebarValue = 0;
            }
        }
        private void ListenJoystick(List<JoystickButtons> joystickButtons, Joystick joystick)
        {
            // Poll events from joystick
            try
            {
                Lazydata.Joystick = joystick;
                while (!KillMe)
                {
                    joystick.Poll();
                    foreach (var state in joystick.GetBufferedData())
                    {
                        foreach (var t in joystickButtons)
                        {
                            HandleDirectInput(t, state);
                        }
                    }
                    Thread.Sleep(10);
                }
                joystick.Unacquire();
            }
            catch (Exception)
            {
                // ignored
                joystick.Unacquire();
            }
        }

        private void HandleDirectInput(JoystickButtons joystickButtons, JoystickUpdate state)
        {
            var button = joystickButtons.DirectInputButton;
            switch (joystickButtons.InputMapping)
            {
                case InputMapping.Test:
                    {
                        if (DisableTestButton)
                        {
                            if (_gameProfile.EmulationProfile == EmulationProfile.SegaInitialD || _gameProfile.EmulationProfile == EmulationProfile.SegaInitialDLindbergh)
                            {
                                if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                                {
                                    if (!TestButtonInitialD)
                                    {
                                        TestButtonInitialD = true;
                                    }
                                }
                                else
                                {
                                    if (TestButtonInitialD)
                                    {
                                        TestButtonInitialD = false;
                                    }
                                }
                                if ((StartButtonInitialD) && (TestButtonInitialD))
                                {
                                    InputCode.PlayerDigitalButtons[0].Test = true;
                                }
                                else
                                {
                                    InputCode.PlayerDigitalButtons[0].Test = false;
                                }
                            }
                            break;
                        }

                        if ((InputCode.ButtonMode == EmulationProfile.NamcoMkdx ||
                                InputCode.ButtonMode == EmulationProfile.NamcoMkdxUsa ||
                                InputCode.ButtonMode == EmulationProfile.NamcoMachStorm ||
                                InputCode.ButtonMode == EmulationProfile.NamcoWmmt5 ||
                                InputCode.ButtonMode == EmulationProfile.DeadHeatRiders ||
                                InputCode.ButtonMode == EmulationProfile.NamcoGundamPod ||
                                InputCode.ButtonMode == EmulationProfile.NamcoWmmt6RR ||
                                InputCode.ButtonMode == EmulationProfile.PlayInput ||
                                InputCode.ButtonMode == EmulationProfile.System147) && _gameProfile.ProfileName != "superdbz")
                        {
                            var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                            if (result != null && result.Value)
                            {
                                if (mkdxTest)
                                {
                                    InputCode.PlayerDigitalButtons[0].Test = false;
                                    mkdxTest = false;
                                }
                                else
                                {
                                    InputCode.PlayerDigitalButtons[0].Test = true;
                                    mkdxTest = true;
                                }
                            }
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].Test = DigitalHelper.GetButtonPressDirectInput(button, state);
                        }
                        break;
                    }
                case InputMapping.Service1:
                    InputCode.PlayerDigitalButtons[0].Service = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.Service2:
                    InputCode.PlayerDigitalButtons[1].Service = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.Coin1:
                    InputCode.PlayerDigitalButtons[0].Coin = DigitalHelper.GetButtonPressDirectInput(button, state);
                    JvsPackageEmulator.UpdateCoinCount(0);
                    if (_gameProfile.EmulationProfile == EmulationProfile.EADP)
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (result != null && result.Value)
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_7 = true;
                        else
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_7 = false;
                    }
                    break;
                case InputMapping.Coin2:
                    InputCode.PlayerDigitalButtons[1].Coin = DigitalHelper.GetButtonPressDirectInput(button, state);
                    JvsPackageEmulator.UpdateCoinCount(1);
                    break;
                case InputMapping.P1Button1:
                    if (_gameProfile.EmulationProfile == EmulationProfile.Theatrhythm || _gameProfile.EmulationProfile == EmulationProfile.SegaOlympic2016)
                    {
                        DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.FFUp);
                    }
                    else
                    {
                        InputCode.PlayerDigitalButtons[0].Button1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    break;
                case InputMapping.P1Button2:
                    if (_gameProfile.EmulationProfile == EmulationProfile.Theatrhythm)
                    {
                        DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.FFDown);
                    }
                    else if (_gameProfile.EmulationProfile == EmulationProfile.GSEVO)
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (result != null && result.Value)
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_8 = true;
                        else
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_8 = false;

                        InputCode.PlayerDigitalButtons[0].Button2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    else
                    {
                        InputCode.PlayerDigitalButtons[0].Button2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    break;
                case InputMapping.P1Button3:
                    if (_gameProfile.EmulationProfile == EmulationProfile.Theatrhythm || _gameProfile.EmulationProfile == EmulationProfile.SegaOlympic2016)
                    {
                        DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.FFLeft);
                    }
                    else
                    {
                        InputCode.PlayerDigitalButtons[0].Button3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    break;
                case InputMapping.P1Button4:
                    if (_gameProfile.EmulationProfile == EmulationProfile.Theatrhythm)
                    {
                        DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.FFRight);
                    }
                    else
                    {
                        InputCode.PlayerDigitalButtons[0].Button4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    break;
                case InputMapping.P1Button5:
                    InputCode.PlayerDigitalButtons[0].Button5 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P1Button6:
                    InputCode.PlayerDigitalButtons[0].Button6 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P1ButtonUp:
                    {
                        if (InputCode.ButtonMode == EmulationProfile.TaitoTypeXBattleGear)
                            InputCode.PlayerDigitalButtons[0].Up = DigitalHelper.GetButtonPressDirectInput(button, state);
                        else
                            DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.Up);
                    }
                    break;
                case InputMapping.P1ButtonDown:
                    {
                        if (InputCode.ButtonMode == EmulationProfile.TaitoTypeXBattleGear)
                            InputCode.PlayerDigitalButtons[0].Down = DigitalHelper.GetButtonPressDirectInput(button, state);
                        else
                            DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.Down);
                    }
                    break;
                case InputMapping.P1ButtonLeft:
                    {
                        if (InputCode.ButtonMode == EmulationProfile.TaitoTypeXBattleGear)
                            InputCode.PlayerDigitalButtons[0].Left = DigitalHelper.GetButtonPressDirectInput(button, state);
                        else
                            DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.Left);
                    }
                    break;
                case InputMapping.P1ButtonRight:
                    {
                        if (InputCode.ButtonMode == EmulationProfile.TaitoTypeXBattleGear)
                        {
                            if (DigitalHelper.GetButtonPressDirectInput(button, state) == true)
                            {
                                InputCode.PlayerDigitalButtons[0].Right = bg4Key;
                                bg4Key = !bg4Key;
                            }
                        }
                        else
                            DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.Right);
                    }
                    break;
                case InputMapping.P1RelativeUp:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.RelativeUp);
                    break;
                case InputMapping.P1RelativeDown:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.RelativeDown);
                    break;
                case InputMapping.P1RelativeLeft:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.RelativeLeft);
                    break;
                case InputMapping.P1RelativeRight:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[0], button, state, Direction.RelativeRight);
                    break;
                case InputMapping.P1ButtonStart:
                    if (DisableTestButton)
                    {
                        if (_gameProfile.EmulationProfile == EmulationProfile.SegaInitialD || _gameProfile.EmulationProfile == EmulationProfile.SegaInitialDLindbergh)
                        {
                            if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                            {
                                if (!StartButtonInitialD)
                                {
                                    StartButtonInitialD = true;
                                }
                            }
                            else
                            {
                                if (StartButtonInitialD)
                                {
                                    StartButtonInitialD = false;
                                }
                            }
                        }
                    }
                    InputCode.PlayerDigitalButtons[0].Start = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P2Button1:
                    if (_gameProfile.EmulationProfile == EmulationProfile.SegaOlympic2016)
                    {
                        DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.FFUp);
                    }
                    else if (_gameProfile.EmulationProfile == EmulationProfile.GSEVO)
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (result != null && result.Value)
                            InputCode.PlayerDigitalButtons[1].ExtensionButton1_8 = true;
                        else
                            InputCode.PlayerDigitalButtons[1].ExtensionButton1_8 = false;
                    }
                    else
                    {
                        InputCode.PlayerDigitalButtons[1].Button1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    break;
                case InputMapping.P2Button2:
                    InputCode.PlayerDigitalButtons[1].Button2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P2Button3:
                    if (_gameProfile.EmulationProfile == EmulationProfile.SegaOlympic2016)
                    {
                        DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.FFLeft);
                    }
                    else
                    {
                        InputCode.PlayerDigitalButtons[1].Button3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    }
                    break;
                case InputMapping.P2Button4:
                    InputCode.PlayerDigitalButtons[1].Button4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P2Button5:
                    InputCode.PlayerDigitalButtons[1].Button5 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P2Button6:
                    InputCode.PlayerDigitalButtons[1].Button6 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P2ButtonUp:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.Up);
                    break;
                case InputMapping.P2ButtonDown:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.Down);
                    break;
                case InputMapping.P2ButtonLeft:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.Left);
                    break;
                case InputMapping.P2ButtonRight:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.Right);
                    break;
                case InputMapping.P2RelativeUp:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.RelativeUp);
                    break;
                case InputMapping.P2RelativeDown:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.RelativeDown);
                    break;
                case InputMapping.P2RelativeLeft:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.RelativeLeft);
                    break;
                case InputMapping.P2RelativeRight:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[1], button, state, Direction.RelativeRight);
                    break;
                case InputMapping.P2ButtonStart:
                    InputCode.PlayerDigitalButtons[1].Start = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.Analog0:
                    InputCode.SetAnalogByte(0, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog1:
                    InputCode.SetAnalogByte(1, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog2:
                    InputCode.SetAnalogByte(2, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog3:
                    InputCode.SetAnalogByte(3, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog4:
                    InputCode.SetAnalogByte(4, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog5:
                    InputCode.SetAnalogByte(5, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog6:
                    InputCode.SetAnalogByte(6, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog7:
                    InputCode.SetAnalogByte(7, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog8:
                    InputCode.SetAnalogByte(8, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog9:
                    InputCode.SetAnalogByte(9, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog10:
                    InputCode.SetAnalogByte(10, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog11:
                    InputCode.SetAnalogByte(11, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog12:
                    InputCode.SetAnalogByte(12, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog13:
                    InputCode.SetAnalogByte(13, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog14:
                    InputCode.SetAnalogByte(14, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog15:
                    InputCode.SetAnalogByte(15, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog16:
                    InputCode.SetAnalogByte(16, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog17:
                    InputCode.SetAnalogByte(17, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog18:
                    InputCode.SetAnalogByte(18, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog19:
                    InputCode.SetAnalogByte(19, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog20:
                    InputCode.SetAnalogByte(20, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog22:
                    InputCode.SetAnalogByte(22, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.SrcGearChange1:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            DigitalHelper.ChangeSrcGear(1);
                        }
                    }
                    break;
                case InputMapping.SrcGearChange2:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            DigitalHelper.ChangeSrcGear(2);
                        }
                    }
                    break;
                case InputMapping.SrcGearChange3:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            DigitalHelper.ChangeSrcGear(3);
                        }
                    }
                    break;
                case InputMapping.SrcGearChange4:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            DigitalHelper.ChangeSrcGear(4);
                        }
                    }
                    break;
                case InputMapping.ExtensionOne1:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne2:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton2 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton2 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne3:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton3 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton3 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne4:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton4 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton4 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne11:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_1 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_1 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne12:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_2 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_2 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne13:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_3 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_3 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne14:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.NamcoGundamPod)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_4 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_4 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne15:
                    InputCode.PlayerDigitalButtons[0].ExtensionButton1_5 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionOne16:
                    InputCode.PlayerDigitalButtons[0].ExtensionButton1_6 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionOne17:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.HauntedMuseum || _gameProfile.EmulationProfile == EmulationProfile.HauntedMuseum2)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_7 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_7 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionOne18:
                    {
                        var result = DigitalHelper.GetButtonPressDirectInput(button, state);
                        if (_gameProfile.EmulationProfile == EmulationProfile.HauntedMuseum || _gameProfile.EmulationProfile == EmulationProfile.HauntedMuseum2)
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_8 = !result;
                        }
                        else
                        {
                            InputCode.PlayerDigitalButtons[0].ExtensionButton1_8 = result;
                        }
                    }
                    break;
                case InputMapping.ExtensionTwo1:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo2:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton2 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo3:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton3 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo4:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton4 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo11:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_1 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo12:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_2 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo13:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_3 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo14:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_4 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo15:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_5 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo16:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_6 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo17:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_7 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.ExtensionTwo18:
                    InputCode.PlayerDigitalButtons[1].ExtensionButton1_8 =
                        DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.Analog0Special1:
                case InputMapping.Analog0Special2:
                    InputCode.SetAnalogByte(0, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog2Special1:
                case InputMapping.Analog2Special2:
                    InputCode.SetAnalogByte(2, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog0Positive:
                case InputMapping.Analog0Negative:
                    InputCode.SetAnalogByte(0, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog2Positive:
                case InputMapping.Analog2Negative:
                    InputCode.SetAnalogByte(2, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog4Positive:
                case InputMapping.Analog4Negative:
                    InputCode.SetAnalogByte(4, ModifyAnalog(joystickButtons, state));
                    break;
                case InputMapping.Analog6Positive:
                case InputMapping.Analog6Negative:
                    InputCode.SetAnalogByte(6, ModifyAnalog(joystickButtons, state));
                    break;

                // Jvs Board 2

                case InputMapping.JvsTwoService1:
                    InputCode.PlayerDigitalButtons[2].Service = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoService2:
                    InputCode.PlayerDigitalButtons[3].Service = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoCoin1:
                    InputCode.PlayerDigitalButtons[2].Coin = DigitalHelper.GetButtonPressDirectInput(button, state);
                    JvsPackageEmulator.UpdateCoinCount(2);
                    break;
                case InputMapping.JvsTwoCoin2:
                    InputCode.PlayerDigitalButtons[3].Coin = DigitalHelper.GetButtonPressDirectInput(button, state);
                    JvsPackageEmulator.UpdateCoinCount(3);
                    break;
                case InputMapping.JvsTwoP1Button1:
                    InputCode.PlayerDigitalButtons[2].Button1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP1Button2:
                    InputCode.PlayerDigitalButtons[2].Button2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP1Button3:
                    InputCode.PlayerDigitalButtons[2].Button3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP1Button4:
                    InputCode.PlayerDigitalButtons[2].Button4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP1Button5:
                    InputCode.PlayerDigitalButtons[2].Button5 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP1Button6:
                    InputCode.PlayerDigitalButtons[2].Button6 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP1ButtonUp:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.Up);
                    break;
                case InputMapping.JvsTwoP1ButtonDown:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.Down);
                    break;
                case InputMapping.JvsTwoP1ButtonLeft:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.Left);
                    break;
                case InputMapping.JvsTwoP1ButtonRight:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.Right);
                    break;
                case InputMapping.JvsTwoP1ButtonStart:
                    InputCode.PlayerDigitalButtons[2].Start = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2Button1:
                    InputCode.PlayerDigitalButtons[3].Button1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2Button2:
                    InputCode.PlayerDigitalButtons[3].Button2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2Button3:
                    InputCode.PlayerDigitalButtons[3].Button3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2Button4:
                    InputCode.PlayerDigitalButtons[3].Button4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2Button5:
                    InputCode.PlayerDigitalButtons[3].Button5 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2Button6:
                    InputCode.PlayerDigitalButtons[3].Button6 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoP2ButtonUp:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.Up);
                    break;
                case InputMapping.JvsTwoP2ButtonDown:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.Down);
                    break;
                case InputMapping.JvsTwoP2ButtonLeft:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.Left);
                    break;
                case InputMapping.JvsTwoP2ButtonRight:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.Right);
                    break;
                case InputMapping.JvsTwoP2ButtonStart:
                    InputCode.PlayerDigitalButtons[3].Start = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;

                case InputMapping.JvsTwoExtensionOne1:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne2:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne3:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne4:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne11:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne12:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne13:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne14:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne15:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_5 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne16:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_6 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne17:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_7 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionOne18:
                    InputCode.PlayerDigitalButtons[2].ExtensionButton1_8 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo1:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo2:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo3:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo4:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo11:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_1 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo12:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_2 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo13:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_3 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo14:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_4 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo15:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_5 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo16:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_6 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo17:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_7 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.JvsTwoExtensionTwo18:
                    InputCode.PlayerDigitalButtons[3].ExtensionButton1_8 = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;

                case InputMapping.JvsTwoAnalog0:
                    InputCode.SetAnalogByte(0, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog1:
                    InputCode.SetAnalogByte(1, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog2:
                    InputCode.SetAnalogByte(2, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog3:
                    InputCode.SetAnalogByte(3, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog4:
                    InputCode.SetAnalogByte(4, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog5:
                    InputCode.SetAnalogByte(5, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog6:
                    InputCode.SetAnalogByte(6, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog7:
                    InputCode.SetAnalogByte(7, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog8:
                    InputCode.SetAnalogByte(8, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog9:
                    InputCode.SetAnalogByte(9, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog10:
                    InputCode.SetAnalogByte(10, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog11:
                    InputCode.SetAnalogByte(11, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog12:
                    InputCode.SetAnalogByte(12, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog13:
                    InputCode.SetAnalogByte(13, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog14:
                    InputCode.SetAnalogByte(14, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog15:
                    InputCode.SetAnalogByte(15, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog16:
                    InputCode.SetAnalogByte(16, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog17:
                    InputCode.SetAnalogByte(17, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog18:
                    InputCode.SetAnalogByte(18, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog19:
                    InputCode.SetAnalogByte(19, ModifyAnalog(joystickButtons, state), true);
                    break;
                case InputMapping.JvsTwoAnalog20:
                    InputCode.SetAnalogByte(20, ModifyAnalog(joystickButtons, state), true);
                    break;

                case InputMapping.Wmmt5GearChange1:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeWmmt5Gear((bool)pressed ? 1 : 0);
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChange2:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeWmmt5Gear((bool)pressed ? 2 : 0);
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChange3:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeWmmt5Gear((bool)pressed ? 3 : 0);
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChange4:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeWmmt5Gear((bool)pressed ? 4 : 0);
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChange5:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeWmmt5Gear((bool)pressed ? 5 : 0);
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChange6:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeWmmt5Gear((bool)pressed ? 6 : 0);
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChangeUp:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeWmmt5GearUp)
                                DigitalHelper.ChangeWmmt5GearUp();
                            changeWmmt5GearUp = true;
                        }
                        else
                        {
                            changeWmmt5GearUp = false;
                        }
                    }
                    break;
                case InputMapping.Wmmt5GearChangeDown:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeWmmt5GearDown)
                                DigitalHelper.ChangeWmmt5GearDown();
                            changeWmmt5GearDown = true;
                        }
                        else
                        {
                            changeWmmt5GearDown = false;
                        }
                    }
                    break;
                case InputMapping.FnfGearChange1:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeFnfGear((bool)pressed ? 1 : 0);
                        }
                    }
                    break;
                case InputMapping.FnfGearChange2:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeFnfGear((bool)pressed ? 2 : 0);
                        }
                    }
                    break;
                case InputMapping.FnfGearChange3:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeFnfGear((bool)pressed ? 3 : 0);
                        }
                    }
                    break;
                case InputMapping.FnfGearChange4:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeFnfGear((bool)pressed ? 4 : 0);
                        }
                    }
                    break;
                case InputMapping.FnfGearChangeUp:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeFnfGearUp)
                                DigitalHelper.ChangeFnfGearUp();
                            changeFnfGearUp = true;
                        }
                        else
                        {
                            changeFnfGearUp = false;
                        }
                    }
                    break;
                case InputMapping.FnfGearChangeDown:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeFnfGearDown)
                                DigitalHelper.ChangeFnfGearDown();
                            changeFnfGearDown = true;
                        }
                        else
                        {
                            changeFnfGearDown = false;
                        }
                    }
                    break;
                case InputMapping.IDZGearChange1:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeIDZGear((bool)pressed ? 1 : 0);
                        }
                    }
                    break;
                case InputMapping.IDZGearChange2:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeIDZGear((bool)pressed ? 2 : 0);
                        }
                    }
                    break;
                case InputMapping.IDZGearChange3:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeIDZGear((bool)pressed ? 3 : 0);
                        }
                    }
                    break;
                case InputMapping.IDZGearChange4:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeIDZGear((bool)pressed ? 4 : 0);
                        }
                    }
                    break;
                case InputMapping.IDZGearChange5:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeIDZGear((bool)pressed ? 5 : 0);
                        }
                    }
                    break;
                case InputMapping.IDZGearChange6:
                    {
                        var pressed = DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state);
                        if (pressed != null)
                        {
                            DigitalHelper.ChangeIDZGear((bool)pressed ? 6 : 0);
                        }
                    }
                    break;
                case InputMapping.IDZGearChangeUp:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeIDZGearUp)
                                DigitalHelper.ChangeIDZGearUp();
                            changeIDZGearUp = true;
                        }
                        else
                        {
                            changeIDZGearUp = false;
                        }
                    }
                    break;
                case InputMapping.IDZGearChangeDown:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeIDZGearDown)
                                DigitalHelper.ChangeIDZGearDown();
                            changeIDZGearDown = true;
                        }
                        else
                        {
                            changeIDZGearDown = false;
                        }
                    }
                    break;
                case InputMapping.SrcGearChangeUp:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeSrcGearUp)
                                DigitalHelper.ChangeSrcGearUp();
                            changeSrcGearUp = true;
                        }
                        else
                        {
                            changeSrcGearUp = false;
                        }
                    }
                    break;
                case InputMapping.SrcGearChangeDown:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            if (!changeSrcGearDown)
                                DigitalHelper.ChangeSrcGearDown();
                            changeSrcGearDown = true;
                        }
                        else
                        {
                            changeSrcGearDown = false;
                        }
                    }
                    break;
                case InputMapping.PokkenButtonUp:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PokkenInputButtons, button, state, Direction.Up);
                    break;
                case InputMapping.PokkenButtonDown:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PokkenInputButtons, button, state, Direction.Down);
                    break;
                case InputMapping.PokkenButtonLeft:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PokkenInputButtons, button, state, Direction.Left);
                    break;
                case InputMapping.PokkenButtonRight:
                    DigitalHelper.GetDirectionPressDirectInput(InputCode.PokkenInputButtons, button, state, Direction.Right);
                    break;
                case InputMapping.PokkenButtonStart:
                    InputCode.PokkenInputButtons.Start = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.PokkenButtonA:
                    InputCode.PokkenInputButtons.ButtonA = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.PokkenButtonB:
                    InputCode.PokkenInputButtons.ButtonB = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.PokkenButtonX:
                    InputCode.PokkenInputButtons.ButtonX = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.PokkenButtonY:
                    InputCode.PokkenInputButtons.ButtonY = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.PokkenButtonL:
                    InputCode.PokkenInputButtons.ButtonL = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.PokkenButtonR:
                    InputCode.PokkenInputButtons.ButtonR = DigitalHelper.GetButtonPressDirectInput(button, state);
                    break;
                case InputMapping.P3RelativeUp:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.RelativeUp);
                    break;
                case InputMapping.P3RelativeDown:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.RelativeDown);
                    break;
                case InputMapping.P3RelativeLeft:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.RelativeLeft);
                    break;
                case InputMapping.P3RelativeRight:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[2], button, state, Direction.RelativeRight);
                    break;
                case InputMapping.P4RelativeUp:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.RelativeUp);
                    break;
                case InputMapping.P4RelativeDown:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.RelativeDown);
                    break;
                case InputMapping.P4RelativeLeft:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.RelativeLeft);
                    break;
                case InputMapping.P4RelativeRight:
                    DigitalHelper.GetRelativeDirectionPressDirectInput(InputCode.PlayerDigitalButtons[3], button, state, Direction.RelativeRight);
                    break;
                case InputMapping.Wmmt3InsertCard:
                    {
                        if (DigitalHelper.GetButtonPressDirectInput(joystickButtons.DirectInputButton, state) == true)
                        {
                            WMMT3Cards.InsertCard();
                        }
                    }
                    break;
                default:
                    break;
                    //throw new ArgumentOutOfRangeException();
            }
        }

        private byte? ModifyAnalog(JoystickButtons joystickButtons, JoystickUpdate state)
        {
            if (joystickButtons.DirectInputButton == null)
                return null;
            if ((JoystickOffset)joystickButtons.DirectInputButton.Button != state.Offset)
                return null;

            switch (joystickButtons.AnalogType)
            {
                case AnalogType.None:
                    break;
                case AnalogType.AnalogJoystick:
                    {
                        var analogPos = JvsHelper.CalculateWheelPos(state.Value);

                        if (_gameProfile.EmulationProfile == EmulationProfile.Mballblitz)
                        {
                            if (joystickButtons.InputMapping == InputMapping.Analog0)
                                JvsHelper.StateView.Write(8, analogPos);
                            if (joystickButtons.InputMapping == InputMapping.Analog2)
                                JvsHelper.StateView.Write(12, analogPos);
                        }

                        if (GunGame)
                        {
                            if (RelativeInput)
                                break;

                            analogPos = (byte)(_minX + analogPos / _DivideX);

                            if (!_invertedMouseAxis)
                                analogPos = (byte)~analogPos;
                        }

                        if (KeyboardorButtonAxis)
                        {
                            string[] baseAnalogButtons = { "Joystick Analog X", "Analog X", "Joystick Analog Y", "Analog Y", "Player 1 Joystick X", "Player 2 Joystick X", "Player 1 Joystick Y", "Player 2 Joystick Y" };
                            if (baseAnalogButtons.Contains(joystickButtons.ButtonName))
                                break;

                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (_gameProfile.EmulationProfile == EmulationProfile.TMNT)
                            {
                                if (joystickButtons.ButtonName.Contains("Player 1") && isKeyboardOrButton)
                                {
                                    if (!KeyboardAnalogXActivate)
                                        KeyboardAnalogXActivate = true;

                                    if (!KeyboardAnalogYActivate)
                                        KeyboardAnalogYActivate = true;

                                    var analogDirections = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                    {
                                        ["Right"] = (() => KeyboardAnalogRight, val => KeyboardAnalogRight = val),
                                        ["Left"] = (() => KeyboardAnalogLeft, val => KeyboardAnalogLeft = val),
                                        ["Down"] = (() => KeyboardAnalogDown, val => KeyboardAnalogDown = val),
                                        ["Up"] = (() => KeyboardAnalogUp, val => KeyboardAnalogUp = val)
                                    };

                                    foreach (var direction in analogDirections.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(direction))
                                        {
                                            var (getter, setter) = analogDirections[direction];
                                            setter(!getter());
                                            break;
                                        }
                                    }
                                }

                                if (joystickButtons.ButtonName.Contains("Player 2") && isKeyboardOrButton)
                                {
                                    if (!KeyboardAnalogXActivate2P)
                                        KeyboardAnalogXActivate2P = true;

                                    if (!KeyboardAnalogYActivate2P)
                                        KeyboardAnalogYActivate2P = true;

                                    var analogDirections = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                    {
                                        ["Right"] = (() => P2KeyboardAnalogRight, val => P2KeyboardAnalogRight = val),
                                        ["Left"] = (() => P2KeyboardAnalogLeft, val => P2KeyboardAnalogLeft = val),
                                        ["Down"] = (() => P2KeyboardAnalogDown, val => P2KeyboardAnalogDown = val),
                                        ["Up"] = (() => P2KeyboardAnalogUp, val => P2KeyboardAnalogUp = val)
                                    };

                                    foreach (var direction in analogDirections.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(direction))
                                        {
                                            var (getter, setter) = analogDirections[direction];
                                            setter(!getter());
                                            break;
                                        }
                                    }
                                }

                                if (joystickButtons.ButtonName.Contains("Player 3") && isKeyboardOrButton)
                                {
                                    if (!KeyboardAnalogXActivate3P)
                                        KeyboardAnalogXActivate3P = true;

                                    if (!KeyboardAnalogYActivate3P)
                                        KeyboardAnalogYActivate3P = true;

                                    var analogDirections = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                    {
                                        ["Right"] = (() => P3KeyboardAnalogRight, val => P3KeyboardAnalogRight = val),
                                        ["Left"] = (() => P3KeyboardAnalogLeft, val => P3KeyboardAnalogLeft = val),
                                        ["Down"] = (() => P3KeyboardAnalogDown, val => P3KeyboardAnalogDown = val),
                                        ["Up"] = (() => P3KeyboardAnalogUp, val => P3KeyboardAnalogUp = val)
                                    };

                                    foreach (var direction in analogDirections.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(direction))
                                        {
                                            var (getter, setter) = analogDirections[direction];
                                            setter(!getter());
                                            break;
                                        }
                                    }
                                }

                                if (joystickButtons.ButtonName.Contains("Player 4") && isKeyboardOrButton)
                                {
                                    if (!KeyboardAnalogXActivate4P)
                                        KeyboardAnalogXActivate4P = true;

                                    if (!KeyboardAnalogYActivate4P)
                                        KeyboardAnalogYActivate4P = true;

                                    var analogDirections = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                    {
                                        ["Right"] = (() => P4KeyboardAnalogRight, val => P4KeyboardAnalogRight = val),
                                        ["Left"] = (() => P4KeyboardAnalogLeft, val => P4KeyboardAnalogLeft = val),
                                        ["Down"] = (() => P4KeyboardAnalogDown, val => P4KeyboardAnalogDown = val),
                                        ["Up"] = (() => P4KeyboardAnalogUp, val => P4KeyboardAnalogUp = val)
                                    };

                                    foreach (var direction in analogDirections.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(direction))
                                        {
                                            var (getter, setter) = analogDirections[direction];
                                            setter(!getter());
                                            break;
                                        }
                                    }
                                }

                                if (!isKeyboardOrButton)
                                {
                                    if (KeyboardAnalogXActivate)
                                        KeyboardAnalogXActivate = false;
                                    if (KeyboardAnalogYActivate)
                                        KeyboardAnalogYActivate = false;

                                    if (KeyboardAnalogXActivate2P)
                                        KeyboardAnalogXActivate2P = false;
                                    if (KeyboardAnalogYActivate2P)
                                        KeyboardAnalogYActivate2P = false;

                                    if (KeyboardAnalogXActivate3P)
                                        KeyboardAnalogXActivate3P = false;
                                    if (KeyboardAnalogYActivate3P)
                                        KeyboardAnalogYActivate3P = false;

                                    if (KeyboardAnalogXActivate4P)
                                        KeyboardAnalogXActivate4P = false;
                                    if (KeyboardAnalogYActivate4P)
                                        KeyboardAnalogYActivate4P = false;
                                }
                                break;
                            }
                            else
                            {
                                if (isKeyboardOrButton)
                                {
                                    if (!KeyboardAnalogXActivate)
                                        KeyboardAnalogXActivate = true;

                                    if (!KeyboardAnalogYActivate)
                                        KeyboardAnalogYActivate = true;

                                    var analogDirections = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                    {
                                        ["Right"] = (() => KeyboardAnalogRight, val => KeyboardAnalogRight = val),
                                        ["Left"] = (() => KeyboardAnalogLeft, val => KeyboardAnalogLeft = val),
                                        ["Down"] = (() => KeyboardAnalogDown, val => KeyboardAnalogDown = val),
                                        ["Up"] = (() => KeyboardAnalogUp, val => KeyboardAnalogUp = val)
                                    };

                                    foreach (var direction in analogDirections.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(direction))
                                        {
                                            var (getter, setter) = analogDirections[direction];
                                            setter(!getter());
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    if (KeyboardAnalogXActivate)
                                        KeyboardAnalogXActivate = false;
                                    if (KeyboardAnalogYActivate)
                                        KeyboardAnalogYActivate = false;
                                }
                            }
                        }
                        else
                        {
                            string[] analogDirectionalButtons = { "Joystick Analog X Left", "Joystick Analog X Right", "Analog X Left", "Analog X Right", "Joystick Analog Y Up", "Joystick Analog Y Down", "Analog Y Up", "Analog Y Down" };

                            if (analogDirectionalButtons.Contains(joystickButtons.ButtonName))
                                break;
                        }

                        return analogPos;
                    }
                case AnalogType.AnalogJoystickY:
                    {
                        byte analogPos;

                        if (ReverseYAxis)
                            analogPos = JvsHelper.CalculateWheelPos(state.Value);
                        else
                        {
                            analogPos = (byte)~JvsHelper.CalculateWheelPos(state.Value);

                            if (GunGame)
                            {
                                if (RelativeInput)
                                    break;

                                analogPos = (byte)(_minY + (analogPos) / _DivideY);

                                if (_invertedMouseAxis)
                                    analogPos = (byte)~analogPos;
                            }
                        }

                        if (KeyboardorButtonAxis)
                        {
                            string[] baseAnalogButtons = { "Joystick Analog X", "Analog X", "Joystick Analog Y", "Analog Y" };
                            if (baseAnalogButtons.Contains(joystickButtons.ButtonName))
                                break;

                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (isKeyboardOrButton)
                            {
                                if (!KeyboardAnalogXActivate)
                                    KeyboardAnalogXActivate = true;
                                if (!KeyboardAnalogYActivate)
                                    KeyboardAnalogYActivate = true;

                                var analogDirections = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                {
                                    ["Right"] = (() => KeyboardAnalogYRight, val => KeyboardAnalogYRight = val),
                                    ["Left"] = (() => KeyboardAnalogYLeft, val => KeyboardAnalogYLeft = val),
                                    ["Down"] = (() => KeyboardAnalogYDown, val => KeyboardAnalogYDown = val),
                                    ["Up"] = (() => KeyboardAnalogYUp, val => KeyboardAnalogYUp = val)
                                };

                                foreach (var direction in analogDirections.Keys)
                                {
                                    if (joystickButtons.ButtonName.Contains(direction))
                                    {
                                        var (getter, setter) = analogDirections[direction];
                                        setter(!getter());
                                        break;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                if (KeyboardAnalogXActivate)
                                    KeyboardAnalogXActivate = false;
                                if (KeyboardAnalogYActivate)
                                    KeyboardAnalogYActivate = false;
                            }
                        }
                        else
                        {
                            string[] analogDirectionalButtons = { "Joystick Analog X Left", "Joystick Analog X Right", "Analog X Left", "Analog X Right", "Joystick Analog Y Up", "Joystick Analog Y Down", "Analog Y Up", "Analog Y Down" };

                            if (analogDirectionalButtons.Contains(joystickButtons.ButtonName))
                                break;
                        }
                        return analogPos;
                    }
                case AnalogType.AnalogJoystickReverse:
                    {
                        byte analogReversePos;

                        if (ReverseYAxis)
                            analogReversePos = (byte)~JvsHelper.CalculateWheelPos(state.Value);
                        else
                        {
                            analogReversePos = JvsHelper.CalculateWheelPos(state.Value);

                            if (GunGame)
                            {
                                if (RelativeInput)
                                    break;

                                analogReversePos = (byte)(_minY + (analogReversePos) / _DivideY);

                                if (!_invertedMouseAxis)
                                    analogReversePos = (byte)~analogReversePos;
                            }
                        }

                        if (KeyboardorButtonAxis)
                        {
                            string[] baseAnalogButtons = { "Joystick Analog X", "Analog X", "Joystick Analog Y", "Analog Y", "Player 1 Joystick X", "Player 2 Joystick X", "Player 1 Joystick Y", "Player 2 Joystick Y" };
                            if (baseAnalogButtons.Contains(joystickButtons.ButtonName))
                                break;

                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (_gameProfile.EmulationProfile == EmulationProfile.TMNT)
                            {
                                var playerMapping = new Dictionary<string, (Action activateX, Action activateY, Dictionary<string, (Func<bool> getter, Action<bool> setter)> directions)>
                                {
                                    ["Player 1"] = (
                                        () => { if (!KeyboardAnalogXActivate) KeyboardAnalogXActivate = true; if (!KeyboardAnalogYActivate) KeyboardAnalogYActivate = true; }, () => { },
                                        new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                        {
                                            ["Right"] = (() => KeyboardAnalogReverseRight, val => KeyboardAnalogReverseRight = val),
                                            ["Left"] = (() => KeyboardAnalogReverseLeft, val => KeyboardAnalogReverseLeft = val),
                                            ["Down"] = (() => KeyboardAnalogReverseDown, val => KeyboardAnalogReverseDown = val),
                                            ["Up"] = (() => KeyboardAnalogReverseUp, val => KeyboardAnalogReverseUp = val)
                                        }
                                    ),
                                    ["Player 2"] = (
                                        () => { if (!KeyboardAnalogXActivate2P) KeyboardAnalogXActivate2P = true; if (!KeyboardAnalogYActivate2P) KeyboardAnalogYActivate2P = true; }, () => { },
                                        new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                        {
                                            ["Right"] = (() => P2KeyboardAnalogReverseRight, val => P2KeyboardAnalogReverseRight = val),
                                            ["Left"] = (() => P2KeyboardAnalogReverseLeft, val => P2KeyboardAnalogReverseLeft = val),
                                            ["Down"] = (() => P2KeyboardAnalogReverseDown, val => P2KeyboardAnalogReverseDown = val),
                                            ["Up"] = (() => P2KeyboardAnalogReverseUp, val => P2KeyboardAnalogReverseUp = val)
                                        }
                                    ),
                                    ["Player 3"] = (
                                        () => { if (!KeyboardAnalogXActivate3P) KeyboardAnalogXActivate3P = true; if (!KeyboardAnalogYActivate3P) KeyboardAnalogYActivate3P = true; }, () => { },
                                        new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                        {
                                            ["Right"] = (() => P3KeyboardAnalogReverseRight, val => P3KeyboardAnalogReverseRight = val),
                                            ["Left"] = (() => P3KeyboardAnalogReverseLeft, val => P3KeyboardAnalogReverseLeft = val),
                                            ["Down"] = (() => P3KeyboardAnalogReverseDown, val => P3KeyboardAnalogReverseDown = val),
                                            ["Up"] = (() => P3KeyboardAnalogReverseUp, val => P3KeyboardAnalogReverseUp = val)
                                        }
                                    ),
                                    ["Player 4"] = (
                                        () => { if (!KeyboardAnalogXActivate4P) KeyboardAnalogXActivate4P = true; if (!KeyboardAnalogYActivate4P) KeyboardAnalogYActivate4P = true; }, () => { },
                                        new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                        {
                                            ["Right"] = (() => P4KeyboardAnalogReverseRight, val => P4KeyboardAnalogReverseRight = val),
                                            ["Left"] = (() => P4KeyboardAnalogReverseLeft, val => P4KeyboardAnalogReverseLeft = val),
                                            ["Down"] = (() => P4KeyboardAnalogReverseDown, val => P4KeyboardAnalogReverseDown = val),
                                            ["Up"] = (() => P4KeyboardAnalogReverseUp, val => P4KeyboardAnalogReverseUp = val)
                                        }
                                    )
                                };

                                if (isKeyboardOrButton)
                                {
                                    foreach (var player in playerMapping.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(player))
                                        {
                                            var (activateX, activateY, directions) = playerMapping[player];
                                            activateX();
                                            activateY();

                                            foreach (var direction in directions.Keys)
                                            {
                                                if (joystickButtons.ButtonName.Contains(direction))
                                                {
                                                    var (getter, setter) = directions[direction];
                                                    setter(!getter());
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    var deactivateFlags = new Action[]
                                    {
                        () => { KeyboardAnalogXActivate = false; KeyboardAnalogYActivate = false; },
                        () => { KeyboardAnalogXActivate2P = false; KeyboardAnalogYActivate2P = false; },
                        () => { KeyboardAnalogXActivate3P = false; KeyboardAnalogYActivate3P = false; },
                        () => { KeyboardAnalogXActivate4P = false; KeyboardAnalogYActivate4P = false; }
                                    };

                                    foreach (var deactivate in deactivateFlags)
                                    {
                                        deactivate();
                                    }
                                }
                                break;
                            }
                            else
                            {
                                if (isKeyboardOrButton)
                                {
                                    if (!KeyboardAnalogXActivate)
                                        KeyboardAnalogXActivate = true;
                                    if (!KeyboardAnalogYActivate)
                                        KeyboardAnalogYActivate = true;

                                    var directions = new Dictionary<string, (Func<bool> getter, Action<bool> setter)>
                                    {
                                        ["Right"] = (() => KeyboardAnalogReverseRight, val => KeyboardAnalogReverseRight = val),
                                        ["Left"] = (() => KeyboardAnalogReverseLeft, val => KeyboardAnalogReverseLeft = val),
                                        ["Down"] = (() => KeyboardAnalogReverseDown, val => KeyboardAnalogReverseDown = val),
                                        ["Up"] = (() => KeyboardAnalogReverseUp, val => KeyboardAnalogReverseUp = val)
                                    };

                                    foreach (var direction in directions.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(direction))
                                        {
                                            var (getter, setter) = directions[direction];
                                            setter(!getter());
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    if (KeyboardAnalogXActivate)
                                        KeyboardAnalogXActivate = false;
                                    if (KeyboardAnalogYActivate)
                                        KeyboardAnalogYActivate = false;
                                }
                            }
                        }
                        else
                        {
                            string[] analogDirectionalButtons = { "Joystick Analog X Left", "Joystick Analog X Right", "Player 1 Joystick Up", "Player 1 Joystick Down", "Player 1 Joystick Left", "Player 1 Joystick Right", "Player 2 Joystick Up", "Player 2 Joystick Down", "Player 2 Joystick Left", "Player 2 Joystick Right", "Analog X Left", "Analog X Right", "Joystick Analog Y Up", "Joystick Analog Y Down", "Analog Y Up", "Analog Y Down" };

                            if (analogDirectionalButtons.Contains(joystickButtons.ButtonName))
                                break;
                        }
                        return analogReversePos;
                    }
                case AnalogType.Gas:
                    {
                        var gas = HandleGasBrakeForJvs(state.Value, joystickButtons.DirectInputButton?.IsAxisMinus, Lazydata.ParrotData.ReverseAxisGas, Lazydata.ParrotData.FullAxisGas, true);
                        //Console.WriteLine("Gas: " + gas.ToString("X2"));
                        if (InputCode.ButtonMode == EmulationProfile.NamcoWmmt5)
                        {
                            gas /= 3;
                        }

                        if (KeyboardorButtonAxis)
                        {
                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (_gameProfile.EmulationProfile == EmulationProfile.HotWheels)
                            {
                                if (isKeyboardOrButton)
                                {
                                    var playerGasStates = new Dictionary<string, (Action activateGetter, Action<bool> gasStateSetter, Func<bool> gasStateGetter)>
                                    {
                                        ["P1"] = (() => { if (!KeyboardGasActivate) KeyboardGasActivate = true; }, val => KeyboardGasDown = val, () => KeyboardGasDown),
                                        ["P2"] = (() => { if (!KeyboardGasActivate2P) KeyboardGasActivate2P = true; }, val => P2KeyboardGasDown = val, () => P2KeyboardGasDown),
                                        ["P3"] = (() => { if (!KeyboardGasActivate3P) KeyboardGasActivate3P = true; }, val => P3KeyboardGasDown = val, () => P3KeyboardGasDown),
                                        ["P4"] = (() => { if (!KeyboardGasActivate4P) KeyboardGasActivate4P = true; }, val => P4KeyboardGasDown = val, () => P4KeyboardGasDown),
                                        ["P5"] = (() => { if (!KeyboardGasActivate5P) KeyboardGasActivate5P = true; }, val => P5KeyboardGasDown = val, () => P5KeyboardGasDown),
                                        ["P6"] = (() => { if (!KeyboardGasActivate6P) KeyboardGasActivate6P = true; }, val => P6KeyboardGasDown = val, () => P6KeyboardGasDown)
                                    };

                                    foreach (var player in playerGasStates.Keys)
                                    {
                                        if (joystickButtons.ButtonName.Contains(player))
                                        {
                                            var (activateGetter, gasStateSetter, gasStateGetter) = playerGasStates[player];
                                            activateGetter();
                                            gasStateSetter(!gasStateGetter());
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                            else
                            {
                                if (isKeyboardOrButton)
                                {
                                    if (!KeyboardGasActivate)
                                        KeyboardGasActivate = true;

                                    KeyboardGasDown = !KeyboardGasDown;
                                    break;
                                }
                            }
                        }
                        return gas;
                    }
                case AnalogType.SWThrottle:
                    {
                        byte gas;

                        if (ReverseSWThrottleAxis)
                            gas = HandleGasBrakeForJvs(state.Value, joystickButtons.DirectInputButton?.IsAxisMinus, false, true, false);
                        else
                            gas = HandleGasBrakeForJvs(state.Value, joystickButtons.DirectInputButton?.IsAxisMinus, true, true, false);

                        if (KeyboardorButtonAxis)
                        {
                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (isKeyboardOrButton)
                            {
                                if (!KeyboardSWThrottleActivate)
                                    KeyboardSWThrottleActivate = true;

                                if (joystickButtons.ButtonName.Contains("Brake"))
                                    KeyboardSWThrottleDown = !KeyboardSWThrottleDown;
                                else
                                    KeyboardSWThrottleUp = !KeyboardSWThrottleUp;
                                break;
                            }
                            else
                            {
                                if (KeyboardSWThrottleActivate)
                                    KeyboardSWThrottleActivate = false;
                            }
                        }
                        else
                        {
                            if (joystickButtons.ButtonName == "Throttle Brake")
                                break;
                        }
                        return gas;
                    }
                case AnalogType.SWThrottleReverse:
                    {
                        byte gas;
                        if (ReverseSWThrottleAxis)
                            gas = HandleGasBrakeForJvs(state.Value, joystickButtons.DirectInputButton?.IsAxisMinus, true, true, false);
                        else
                            gas = HandleGasBrakeForJvs(state.Value, joystickButtons.DirectInputButton?.IsAxisMinus, false, true, false);

                        if (KeyboardorButtonAxis)
                        {
                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (isKeyboardOrButton)
                            {
                                if (!KeyboardSWThrottleActivate)
                                    KeyboardSWThrottleActivate = true;

                                if (joystickButtons.ButtonName.Contains("Brake"))
                                    KeyboardSWThrottleDown = !KeyboardSWThrottleDown;
                                else
                                    KeyboardSWThrottleUp = !KeyboardSWThrottleUp;
                                break;
                            }
                            else
                            {
                                if (KeyboardSWThrottleActivate)
                                    KeyboardSWThrottleActivate = false;
                            }
                        }
                        else
                        {
                            if (joystickButtons.ButtonName == "Throttle Brake")
                                break;
                        }
                        return gas;
                    }
                case AnalogType.Brake:
                    {
                        var brake = HandleGasBrakeForJvs(state.Value, joystickButtons.DirectInputButton?.IsAxisMinus, Lazydata.ParrotData.ReverseAxisGas, Lazydata.ParrotData.FullAxisGas, false);
                        if (InputCode.ButtonMode == EmulationProfile.NamcoWmmt5)
                        {
                            brake /= 3;
                        }

                        if (KeyboardorButtonAxis)
                        {
                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (isKeyboardOrButton)
                            {
                                if (!KeyboardBrakeActivate)
                                    KeyboardBrakeActivate = true;

                                KeyboardBrakeDown = !KeyboardBrakeDown;
                                break;
                            }
                            else
                            {
                                if (KeyboardBrakeActivate)
                                    KeyboardBrakeActivate = false;
                            }
                        }
                        return brake;
                    }
                case AnalogType.Wheel:
                    {
                        var wheelPos = Lazydata.ParrotData.UseSto0ZDrivingHack
                            ? JvsHelper.CalculateSto0ZWheelPos(state.Value, Lazydata.ParrotData.StoozPercent)
                            : JvsHelper.CalculateWheelPos(state.Value, false, false, minValWheel, maxValWheel);

                        if (KeyboardorButtonAxis)
                        {
                            if (joystickButtons.ButtonName == "Wheel Axis" || joystickButtons.ButtonName == "Leaning Axis" || joystickButtons.ButtonName == "Handlebar Axis")
                                break;

                            bool isKeyboardOrButton = joystickButtons.BindNameDi.Contains("Keyboard") || joystickButtons.BindNameDi.Contains("Buttons");

                            if (isKeyboardOrButton)
                            {
                                string buttonName = joystickButtons.ButtonName;

                                if (!KeyboardHandlebarActivate && (_gameProfile.EmulationProfile == EmulationProfile.RingRiders || _gameProfile.EmulationProfile == EmulationProfile.RadikalBikers))
                                    KeyboardHandlebarActivate = true;

                                if (!KeyboardWheelActivate && (buttonName.Contains("Wheel Axis") || buttonName.Contains("Leaning Axis")))
                                    KeyboardWheelActivate = true;

                                if (_gameProfile.EmulationProfile == EmulationProfile.HotWheels)
                                {
                                    var playerActivations = new Dictionary<string, Action>
                                    {
                                        ["P2"] = () => { if (!KeyboardWheelActivate2P) KeyboardWheelActivate2P = true; },
                                        ["P3"] = () => { if (!KeyboardWheelActivate3P) KeyboardWheelActivate3P = true; },
                                        ["P4"] = () => { if (!KeyboardWheelActivate4P) KeyboardWheelActivate4P = true; },
                                        ["P5"] = () => { if (!KeyboardWheelActivate5P) KeyboardWheelActivate5P = true; },
                                        ["P6"] = () => { if (!KeyboardWheelActivate6P) KeyboardWheelActivate6P = true; }
                                    };

                                    foreach (var player in playerActivations.Keys)
                                    {
                                        if (buttonName.StartsWith(player + " Wheel Axis"))
                                        {
                                            playerActivations[player]();
                                            break;
                                        }
                                    }
                                }

                                var allPlayerActivations = new Dictionary<string, Action>
                                {
                                    ["P2 Wheel Axis Right"] = () => { if (!KeyboardWheelActivate2P) KeyboardWheelActivate2P = true; },
                                    ["P2 Wheel Axis Left"] = () => { if (!KeyboardWheelActivate2P) KeyboardWheelActivate2P = true; },
                                    ["P3 Wheel Axis Right"] = () => { if (!KeyboardWheelActivate3P) KeyboardWheelActivate3P = true; },
                                    ["P3 Wheel Axis Left"] = () => { if (!KeyboardWheelActivate3P) KeyboardWheelActivate3P = true; },
                                    ["P4 Wheel Axis Right"] = () => { if (!KeyboardWheelActivate4P) KeyboardWheelActivate4P = true; },
                                    ["P4 Wheel Axis Left"] = () => { if (!KeyboardWheelActivate4P) KeyboardWheelActivate4P = true; },
                                    ["P5 Wheel Axis Right"] = () => { if (!KeyboardWheelActivate5P) KeyboardWheelActivate5P = true; },
                                    ["P5 Wheel Axis Left"] = () => { if (!KeyboardWheelActivate5P) KeyboardWheelActivate5P = true; },
                                    ["P6 Wheel Axis Right"] = () => { if (!KeyboardWheelActivate6P) KeyboardWheelActivate6P = true; },
                                    ["P6 Wheel Axis Left"] = () => { if (!KeyboardWheelActivate6P) KeyboardWheelActivate6P = true; }
                                };

                                if (allPlayerActivations.ContainsKey(buttonName))
                                    allPlayerActivations[buttonName]();

                                var wheelStates = new Dictionary<string, (Func<bool> get, Action<bool> set)>
                                {
                                    ["Wheel Axis Right"] = (() => KeyboardWheelRight, val => KeyboardWheelRight = val),
                                    ["P1 Wheel Axis Right"] = (() => KeyboardWheelRight, val => KeyboardWheelRight = val),
                                    ["Leaning Axis Right"] = (() => KeyboardWheelRight, val => KeyboardWheelRight = val),
                                    ["Wheel Axis Left"] = (() => KeyboardWheelLeft, val => KeyboardWheelLeft = val),
                                    ["P1 Wheel Axis Left"] = (() => KeyboardWheelLeft, val => KeyboardWheelLeft = val),
                                    ["Leaning Axis Left"] = (() => KeyboardWheelLeft, val => KeyboardWheelLeft = val),

                                    ["P2 Wheel Axis Right"] = (() => P2KeyboardWheelRight, val => P2KeyboardWheelRight = val),
                                    ["P2 Wheel Axis Left"] = (() => P2KeyboardWheelLeft, val => P2KeyboardWheelLeft = val),
                                    ["P3 Wheel Axis Right"] = (() => P3KeyboardWheelRight, val => P3KeyboardWheelRight = val),
                                    ["P3 Wheel Axis Left"] = (() => P3KeyboardWheelLeft, val => P3KeyboardWheelLeft = val),
                                    ["P4 Wheel Axis Right"] = (() => P4KeyboardWheelRight, val => P4KeyboardWheelRight = val),
                                    ["P4 Wheel Axis Left"] = (() => P4KeyboardWheelLeft, val => P4KeyboardWheelLeft = val),
                                    ["P5 Wheel Axis Right"] = (() => P5KeyboardWheelRight, val => P5KeyboardWheelRight = val),
                                    ["P5 Wheel Axis Left"] = (() => P5KeyboardWheelLeft, val => P5KeyboardWheelLeft = val),
                                    ["P6 Wheel Axis Right"] = (() => P6KeyboardWheelRight, val => P6KeyboardWheelRight = val),
                                    ["P6 Wheel Axis Left"] = (() => P6KeyboardWheelLeft, val => P6KeyboardWheelLeft = val),

                                    ["Handlebar Axis Right"] = (() => KeyboardHandlebarRight, val => KeyboardHandlebarRight = val),
                                    ["Handlebar Axis Left"] = (() => KeyboardHandlebarLeft, val => KeyboardHandlebarLeft = val)
                                };

                                if (wheelStates.ContainsKey(buttonName))
                                {
                                    var (getter, setter) = wheelStates[buttonName];
                                    setter(!getter());
                                }
                                break;
                            }
                            else
                            {
                                if (KeyboardWheelActivate)
                                    KeyboardWheelActivate = false;

                                if (KeyboardHandlebarActivate && (_gameProfile.EmulationProfile == EmulationProfile.RingRiders || _gameProfile.EmulationProfile == EmulationProfile.RadikalBikers))
                                    KeyboardHandlebarActivate = false;
                            }
                        }
                        else
                        {
                            string[] axisButtons = { "Wheel Axis Left", "Wheel Axis Right", "Leaning Axis Left", "Leaning Axis Right", "Handlebar Axis Left", "Handlebar Axis Right", "P1 Wheel Axis Left", "P1 Wheel Axis Right", "P2 Wheel Axis Left", "P2 Wheel Axis Right", "P3 Wheel Axis Left", "P3 Wheel Axis Right", "P4 Wheel Axis Left", "P4 Wheel Axis Right", "P5 Wheel Axis Left", "P5 Wheel Axis Right", "P6 Wheel Axis Left", "P6 Wheel Axis Right" };

                            if (axisButtons.Contains(joystickButtons.ButtonName))
                                break;
                        }

                        if (_gameProfile.EmulationProfile == EmulationProfile.TaitoTypeXBattleGear ||
                            _gameProfile.EmulationProfile == EmulationProfile.VirtuaRLimit)
                            JvsHelper.StateView.Write(4, wheelPos);

                        return wheelPos;
                    }
                case AnalogType.Minimum:
                    if (state.Value == 0x80)
                        return 0x00;
                    else
                        return 0x7F;
                case AnalogType.Maximum:
                    if (state.Value == 0x80)
                        return 0xFF;
                    else
                        return 0x7F;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }

        public byte HandleGasBrakeForJvs(int value, bool? isAxisMinus, bool isReverseAxis, bool isFullAxis, bool isGas)
        {
            if (isFullAxis)
            {
                return JvsHelper.CalculateGasPos(value, true, isReverseAxis, _gameProfile.GasAxisMin, _gameProfile.GasAxisMax);
            }

            // Dual Axis
            if (isAxisMinus.HasValue && isAxisMinus.Value)
            {
                if (value <= short.MaxValue)
                {
                    if (isGas)
                    {
                        return JvsHelper.CalculateGasPos(-value + short.MaxValue, false, isReverseAxis, _gameProfile.GasAxisMin, _gameProfile.GasAxisMax);
                    }
                    return JvsHelper.CalculateGasPos(-value + short.MaxValue, false, isReverseAxis, _gameProfile.GasAxisMin, _gameProfile.GasAxisMax);
                }
                return 0;
            }

            if (value <= short.MaxValue)
            {
                return 0;
            }

            return JvsHelper.CalculateGasPos(value + short.MaxValue, false, isReverseAxis, _gameProfile.GasAxisMin, _gameProfile.GasAxisMax);
        }
    }
}
