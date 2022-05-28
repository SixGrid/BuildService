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

        IPAddress IpAddress { get; set; }
        uint Port { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ID { get; set; }
    }
    public class ConnectionProfile : IConnectionProfile, bSerializable
    {
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        private void rUpdatedAt()
        {
            UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public ConnectionProfile()
        {
            ID = GeneralHelper.GenerateToken(32);
            AuthProfileID = @"";

            IpAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
            Port = 8090;
            Name = $@"Untitled Server ({CreatedAt}:{ID})";
            Description = @"";
        }

        public IPAddress IpAddress { get; set; }
        public uint Port { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string AuthProfileID { get; set; }

        public void ReadFromStream(SerializationReader sr)
        {
            IpAddress = IPAddress.Parse(sr.ReadString());
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
            rUpdatedAt();
            sw.Write(IpAddress.ToString());
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
