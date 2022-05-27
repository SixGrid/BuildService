using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BuildServiceCommon.Helpers;

namespace BuildService.Client.WinForms.Authentication
{
    public class AuthenticationProfile : bSerializable
    {
        public long CreatedAt
        {
            get;
            private set;
        }
        internal long UpdatedAt
        {
            get;
            private set;
        }

        private Dictionary<string, string> data = new Dictionary<string, string>();

        public string Username
        {
            get
            {
                return data[@"username"];
            }
            set
            {
                UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                data[@"username"] = value;
            }
        }
        public string Passphrase
        {
            get
            {
                return data[@"passphrase"];
            }
            set
            {
                UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                data[@"passphrase"] = value;
            }
        }

        public AuthenticationProfile()
            : this(new Dictionary<string, string>()) { }

        internal AuthenticationProfile(Dictionary<string, string> _data)
        {
            if (!_data.ContainsKey(@"username"))
                _data.Add(@"username", @"");
            if (!_data.ContainsKey(@"passphrase"))
                _data.Add(@"passphrase", @"");
            if (!_data.ContainsKey(@"createdAt"))
                _data.Add(@"createdAt", @"0");
            if (!_data.ContainsKey(@"updatedAt"))
                _data.Add(@"updatedAt", @"0");
            if (!_data.ContainsKey(@"label"))
                _data.Add(@"label", $@"Unnamed Authentication Profile ({DateTimeOffset.UtcNow.ToUnixTimeSeconds()})");

            ImportDictionary(_data);
        }

        public static string[] Base64EncodedDictionaryKeys = new string[]
        {
            @"username",
            @"passphrase"
        };
        private void ImportDictionary(Dictionary<string, string> _data)
        {
            data.Clear();
            foreach (KeyValuePair<string, string> pair in _data)
            {
                data.Add(pair.Key, pair.Value);
            }
            foreach (string key in Base64EncodedDictionaryKeys)
            {
                if (RegExStatements.Base64.Match(data[key]).Success)
                {
                    data[key] = GeneralHelper.Base64Decode(data[key]);
                }
            }
        }
        internal Dictionary<string, string> ExportContent()
        {
            Dictionary<string, string> returnData = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> pair in data)
            {
                for (int i = 0; i < Base64EncodedDictionaryKeys.Length; i++)
                {
                    string key = pair.Key;
                    string value = pair.Value;
                    if (Base64EncodedDictionaryKeys[i] == pair.Key)
                    {
                        value = GeneralHelper.Base64Encode(pair.Value);
                    }
                    returnData.Add(key, value);
                }
            }

            return returnData;
        }

        public void ReadFromStream(SerializationReader sr)
        {
            var dict = new Dictionary<string, string>();
            dict.Add(@"username", sr.ReadString());
            dict.Add(@"passphrase", sr.ReadString());
            dict.Add(@"createdAt", sr.ReadString());
            dict.Add(@"updatedAt", sr.ReadString());
            dict.Add(@"label", sr.ReadString());

            ImportDictionary(dict);
        }

        public void WriteToStream(SerializationWriter sw)
        {
            var targetData = ExportContent();
            sw.Write(targetData[@"username"]);
            sw.Write(targetData[@"passphrase"]);
            sw.Write(targetData[@"createdAt"]);
            sw.Write(targetData[@"updatedAt"]);
            sw.Write(targetData[@"label"]);
        }
    }
}
