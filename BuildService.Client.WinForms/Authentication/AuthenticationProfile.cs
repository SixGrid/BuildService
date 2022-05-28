using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BuildServiceCommon.Helpers;

namespace BuildService.Client.WinForms.Authentication
{
    public interface IAuthenticationProfile
    {
        long CreatedAt { get; set; }
        long UpdatedAt { get; set; }

        string ID { get; set; }
        string Username { get; set; }
        string Passphrase { get; set; }
        string Label { get; set; }
        string Description { get; set; }
    }
    public class AuthenticationProfile : bSerializable, IAuthenticationProfile
    {
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public void rUpdatedAt()
        {
            UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public string ID { get; set; }
        public string Username { get; set; }
        public string Passphrase { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public AuthenticationProfile()
        {
            CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            UpdatedAt = 0;

            ID = GeneralHelper.GenerateToken(32);

            Username = @"";
            Passphrase = @"";
            Label = $@"Untitled Authentication Profile ({CreatedAt}:{ID})";
            Description = @"";
        }

        public void ReadFromStream(SerializationReader sr)
        {
            Username = sr.ReadString();
            Passphrase = sr.ReadString();
            CreatedAt = sr.ReadInt64();
            UpdatedAt = sr.ReadInt64();
            Label = GeneralHelper.Base64Decode(sr.ReadString());
            ID = sr.ReadString();
            Description = GeneralHelper.Base64Decode(sr.ReadString());
        }

        public void WriteToStream(SerializationWriter sw)
        {
            sw.Write(Username);
            sw.Write(Passphrase);
            sw.Write(CreatedAt);
            sw.Write(UpdatedAt);
            sw.Write(GeneralHelper.Base64Encode(Label));
            sw.Write(ID);
            sw.Write(GeneralHelper.Base64Encode(Description));
        }
    }
}
