using BuildServiceCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuildService.Client.WinForms.Network
{
    public interface IConnectionProfile
    {
        long CreatedAt { get; set; }
        long UpdatedAt { get; set; }

        string IpAddress { get; set; }
        uint Port { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ID { get; set; }
    }
    public class ConnectionProfile : IConnectionProfile, bSerializable
    {
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public void rUpdatedAt()
        {
            UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public ConnectionProfile()
        {
            ID = GeneralHelper.GenerateToken(32);
            AuthProfileID = @"";

            IpAddress = @"localhost";
            Port = 8090;
            Name = $@"Untitled Server ({CreatedAt}:{ID})";
            Description = @"";
        }

        public string IpAddress { get; set; }
        public uint Port { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string AuthProfileID { get; set; }

        public void ReadFromStream(SerializationReader sr)
        {
            IpAddress = GeneralHelper.Base64Decode(sr.ReadString());
            Port = sr.ReadUInt32();
            CreatedAt = sr.ReadInt64();
            UpdatedAt = sr.ReadInt64();

            Name = GeneralHelper.Base64Decode(sr.ReadString());
            Description = GeneralHelper.Base64Decode(sr.ReadString());

            AuthProfileID = sr.ReadString();
            ID = sr.ReadString();
            
        }

        public void WriteToStream(SerializationWriter sw)
        {
            sw.Write(GeneralHelper.Base64Encode(IpAddress));
            sw.Write(Port);
            sw.Write(CreatedAt);
            sw.Write(UpdatedAt);

            sw.Write(GeneralHelper.Base64Encode(Name));
            sw.Write(GeneralHelper.Base64Encode(Description));

            sw.Write(AuthProfileID);
            sw.Write(ID);
        }
    }
}
