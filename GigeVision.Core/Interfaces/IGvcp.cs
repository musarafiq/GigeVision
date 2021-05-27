﻿using GenICam;
using GigeVision.Core.Enums;
using GigeVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GigeVision.Core.Interfaces
{
    /// <summary>
    /// General interface for GVCP procotol
    /// </summary>
    public interface IGvcp
    {
        /// <summary>
        /// It can be used for any thing, to update fps to check devices (library use this for Heartbeat)
        /// </summary>
        EventHandler ElapsedOneSecond { get; set; }

        /// <summary>
        /// This event will be fired when camera ip is changed
        /// </summary>
        EventHandler CameraIpChanged { get; set; }

        /// <summary>
        /// Camera IP
        /// </summary>
        string CameraIp { get; set; }

        /// <summary>
        /// Controlling port for GVCP
        /// </summary>
        int PortControl { get; }

        /// <summary>
        /// Bool to keep the heartbeat of Gige Camera alive
        /// </summary>
        bool IsKeepingAlive { get; }

        /// <summary>
        /// Dictionary for registers
        /// </summary>
        Dictionary<string, string> RegistersDictionary { get; set; }
        public Dictionary<string, IPValue> RegistersDictionaryValues { get; set; }

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified socket
        /// </summary>
        /// <param name="socket">Socket already connected with the camera IP</param>
        /// <param name="registerAddress">Address of register [4 hex bytes]</param>
        /// <param name="valueToWrite">Value to write on register</param>
        /// <returns></returns>
        Task<GvcpReply> WriteRegisterAsync(UdpClient socket, byte[] registerAddress, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified socket
        /// </summary>
        /// <param name="socket">Socket already connected with the camera IP</param>
        /// <param name="registerAddress">
        /// Address of register [Hex string "0x014578a0", "14578a0" both format are valid]
        /// </param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(UdpClient socket, string registerAddress, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified IP, take control first
        /// then leave the control
        /// </summary>
        /// <param name="Ip">Camera IP</param>
        /// <param name="registerAddress">Address of register [4 hex bytes]</param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(string Ip, byte[] registerAddress, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified IP, take control first
        /// then leave the control
        /// </summary>
        /// <param name="Ip">Camera IP</param>
        /// <param name="registerAddress">
        /// Address of register [Hex string "0x014578a0", "14578a0" both format are valid]
        /// </param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(string Ip, string registerAddress, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified IP, take control first
        /// then leave the control
        /// </summary>
        /// <param name="registerAddress">Address of register [4 hex bytes]</param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(byte[] registerAddress, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the IP that is supposed to be already
        /// assigned then leave the control
        /// </summary>
        /// <param name="registerAddress">Address of register [4 hex bytes]</param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(string registerAddress, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified socket
        /// </summary>
        /// <param name="socket">Socket already connected with the camera IP</param>
        /// <param name="registerAddress">
        /// Address of register array [Hex string "0x014578a0", "14578a0" both format are valid]
        /// </param>
        /// <param name="valuesToWrite">Values to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(UdpClient socket, string[] registerAddress, uint[] valuesToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified IP, take control first
        /// then leave the control
        /// </summary>
        /// <param name="Ip">Camera IP</param>
        /// <param name="registerAddress">
        /// Address of register [Hex string "0x014578a0", "14578a0" both format are valid]
        /// </param>
        /// <param name="valuesToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(string Ip, string[] registerAddress, uint[] valuesToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the IP that is supposed to be already
        /// assigned then leave the control
        /// </summary>
        /// <param name="registerAddress">Address of register [4 hex bytes]</param>
        /// <param name="valuesToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(string[] registerAddress, uint[] valuesToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the IP that is supposed to be already
        /// assigned then leave the control
        /// </summary>
        /// <param name="register">Fixed GigE registers</param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(GvcpRegister register, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified IP, take control first
        /// assigned then leave the control
        /// </summary>
        /// <param name="Ip">Camera IP</param>
        /// <param name="register">Fixed GigE registers</param>
        /// <param name="valueToWrite">Value to write on register</param>
        Task<GvcpReply> WriteRegisterAsync(string Ip, GvcpRegister register, uint valueToWrite);

        /// <summary>
        /// Write Register: it will send the GVCP command to the specified IP, take control first
        /// assigned then leave the control
        /// </summary>
        /// <returns>Command Status</returns>
        Task<GvcpReply> WriteRegisterAsync(UdpClient socket, GvcpRegister register, uint valueToWrite);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(GvcpRegister register);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(string Ip, GvcpRegister register);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(string Ip, byte[] registerAddress);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(string Ip, string registerAddress);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(byte[] registerAddressOrKey);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(string registerAddressOrKey);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(string Ip, string[] registerAddresses);

        /// <summary>
        /// Read Register
        /// </summary>
        /// <returns>Acknowledgement</returns>
        Task<GvcpReply> ReadRegisterAsync(string[] registerAddresses);

        /// <summary>
        /// Read Memory Address
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="memoryAddress"></param>
        /// <returns></returns>
        Task<GvcpReply> ReadMemoryAsync(string ip, byte[] memoryAddress, ushort count);

        /// <summary>
        /// Read Memory Address
        /// </summary>
        /// <param name="memoryAddressOrKey"></param>
        /// <returns></returns>
        Task<GvcpReply> ReadMemoryAsync(string memoryAddressOrKey, ushort count);

        /// <summary>
        /// Write Memory
        /// </summary>
        /// <param name="registerAddress"></param>
        /// <param name="valueToWrite"></param>
        /// <returns></returns>
        Task<GvcpReply> WriteMemoryAsync(string memoryAddress, uint valueToWrite);

        /// <summary>
        /// Read all Register
        /// </summary>
        /// <returns>Dictionary of registers</returns>
        Task<Dictionary<string, string>> ReadAllRegisterAddressFromCameraAsync(string cameraIp);

        /// <summary>
        /// Read all Register
        /// </summary>
        /// <returns>Dictionary of registers</returns>
        Task<Dictionary<string, string>> ReadAllRegisterAddressFromCameraAsync();

        /// <summary>
        /// Read all Register
        /// </summary>
        /// <param name="gvcp"></param>
        /// <returns></returns>
        Task<Dictionary<string, string>> ReadAllRegisterAddressFromCameraAsync(IGvcp gvcp);

        /// <summary>
        /// Forces the IP of camera to be changed to the given IP
        /// </summary>
        /// <param name="macAddress">MAC address of the camera</param>
        /// <param name="iPToSet">IP of camera that needs to be set</param>
        /// <returns>Success Status</returns>
        Task<bool> ForceIPAsync(byte[] macAddress, string iPToSet);

        /// <summary>
        /// Forces the IP of camera to be changed to the given IP
        /// </summary>
        /// <param name="macAddress">MAC address of the camera</param>
        /// <param name="iPToSet">IP of camera that needs to be set</param>
        /// <returns>Success Status</returns>
        Task<bool> ForceIPAsync(string macAddress, string iPToSet);

        /// <summary>
        /// It will get all the devices from the network and then fires the event for updated list
        /// </summary>
        /// <param name="listUpdated">Event that will be fired once list is ready</param>
        void GetAllGigeDevicesInNetworkAsnyc(Action<List<CameraInformation>> listUpdated);

        /// <summary>
        /// It will broadcast discovery command and get all the available devices in the network
        /// </summary>
        /// <returns>List of Camera Information</returns>
        Task<List<CameraInformation>> GetAllGigeDevicesInNetworkAsnyc();

        /// <summary>
        /// Check camera status
        /// </summary>
        /// <param name="ip">Ip Camera</param>
        /// <returns>Camera Status: Available/Incontrol or Unavailable</returns>
        Task<CameraStatus> CheckCameraStatusAsync(string ip);

        /// <summary>
        /// Check camera status
        /// </summary>
        /// <returns>Camera Status: Available/Incontrol or Unavailable</returns>
        Task<CameraStatus> CheckCameraStatusAsync();

        /// <summary>
        /// Take control of camera
        /// </summary>
        /// <param name="KeepAlive">If true it will keep the heartbeat alive</param>
        /// <returns>Control Status</returns>
        Task<bool> TakeControl(bool KeepAlive = true);

        /// <summary>
        /// It will leave the control of the camera CCP=0
        /// </summary>
        /// <returns>Leave Status</returns>
        Task<bool> LeaveControl();

        List<ICategory> CategoryDictionary { get; }
    }
}