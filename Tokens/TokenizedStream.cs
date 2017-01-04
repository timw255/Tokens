using SitefinityWebApp.Tokens.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.Tokens
{
    public class TokenizedStream : Stream
    {
        TokensConfig tokenConfig = Config.Get<TokensConfig>();

        private Stream _stream;
        private long _length;
        private long _position;        

        public TokenizedStream(Stream stream)
        {
            _stream = stream;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Close()
        {
            _stream.Close();
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override long Length
        {
            get { return _length; }
        }

        public override long Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _length = value;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Encoding encoding = HttpContext.Current.Response.ContentEncoding;
            string output = encoding.GetString(buffer);

            var tokens = new List<string>();

            Regex regex = new Regex(@"\{\{(.+?)\}\}");
            foreach (Match match in regex.Matches(output))
            {
                tokens.Add(match.Groups[0].Value);
            }

            if (tokens.Count > 0)
            {
                var modified = false;

                for (var i = 0; i < tokens.Count; i++)
                {
                    var token = tokenConfig.Tokens.Values.Where(t => t.Key == tokens[i]).FirstOrDefault();

                    if (token != null)
                    {
                        output = output.Replace(tokens[i], token.Value);
                        modified = true;
                    }
                }

                if (modified)
                {
                    buffer = Encoding.ASCII.GetBytes(output);
                }
            }

            _stream.Write(buffer, offset, buffer.Length);
        }
    }
}