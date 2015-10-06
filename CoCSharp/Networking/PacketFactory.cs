﻿using CoCSharp.Networking.Packets;
using System;
using System.Collections.Generic;

namespace CoCSharp.Networking
{
    /// <summary>
    /// Provides methods to create packet instances.
    /// </summary>
    public static class PacketFactory
    {
        static PacketFactory()
        {
            m_PacketDictionary.Add(new LoginRequestPacket().ID, typeof(LoginRequestPacket)); // 10101
            m_PacketDictionary.Add(new KeepAliveRequestPacket().ID, typeof(KeepAliveRequestPacket)); // 10108
            m_PacketDictionary.Add(new SetDeviceTokenPacket().ID, typeof(SetDeviceTokenPacket)); // 10113
            m_PacketDictionary.Add(new ChangeAvatarNamePacket().ID, typeof(ChangeAvatarNamePacket)); // 10212
            m_PacketDictionary.Add(new BindFacebookAccountPacket().ID, typeof(BindFacebookAccountPacket)); // 14201
            m_PacketDictionary.Add(new AllianceChatMessageClientPacket().ID, typeof(AllianceChatMessageClientPacket)); // 14315
            m_PacketDictionary.Add(new AvatarProfileRequestPacket().ID, typeof(AvatarProfileRequestPacket)); // 14325
            m_PacketDictionary.Add(new ChatMessageClientPacket().ID, typeof(ChatMessageClientPacket)); // 14715

            m_PacketDictionary.Add(new UpdateKeyPacket().ID, typeof(UpdateKeyPacket)); // 20000
            m_PacketDictionary.Add(new LoginFailedPacket().ID, typeof(LoginFailedPacket)); // 20103
            m_PacketDictionary.Add(new LoginSuccessPacket().ID, typeof(LoginSuccessPacket)); // 20104
            m_PacketDictionary.Add(new KeepAliveResponsePacket().ID, typeof(KeepAliveResponsePacket)); // 20108
            m_PacketDictionary.Add(new OwnHomeDataPacket().ID, typeof(OwnHomeDataPacket)); // 24101
            m_PacketDictionary.Add(new AllianceChatMessageServerPacket().ID, typeof(AllianceChatMessageServerPacket)); // 24312
            m_PacketDictionary.Add(new ChatMessageServerPacket().ID, typeof(ChatMessageServerPacket)); // 24715
        }

        private static Dictionary<ushort, Type> m_PacketDictionary = new Dictionary<ushort, Type>();

        /// <summary>
        /// Creates a new <see cref="IPacket"/> instance with the specified packet id.
        /// </summary>
        /// <param name="id">ID of packet.</param>
        /// <returns>Instance of <see cref="IPacket"/> created.</returns>
        public static IPacket Create(ushort id)
        {
            var packetType = (Type)null;
            if (!m_PacketDictionary.TryGetValue(id, out packetType))
                return new UnknownPacket();
            return (IPacket)Activator.CreateInstance(packetType);
        }
    }
}