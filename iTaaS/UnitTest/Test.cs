using System;
using System.Collections.Generic;
using System.IO;
using iTaaS.Helpers;
using iTaaS.Models;
using Xunit;

namespace Test
{
    public class Test
    {
        private string sourceURI = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";

        [Fact]
        public void SourceLogIsNotEmpty()
        {
            var mINHACDNParser = new MINHACDNParser();
            var logs = mINHACDNParser.GetLogs(sourceURI);

            Assert.True(logs.Count > 0);
        }

        [Fact]
        public void AgoraLogIsBeingStreamed()
        {
            var stream = getStream();

            Assert.NotNull(stream);
        }

        [Fact]
        public void ValidateVersion()
        {
            decimal appVersion = 0;
            var version = new iTaaS.Helpers.Version();
            appVersion = version.GetAssemblyVersion<Test>(appVersion);

            Assert.Equal("1.0", appVersion.ToString());
        }

				[Fact]
        public void ValidateNewFormat()
        {
            var streamedFile = getStream();
						var io = new IO();
            var document = io.ReadFile(streamedFile);

            var splitLog = new SplitLog();
            var line = splitLog.ListLogLines(document)[0];

						bool isValid = line.Contains("\"") || line.Contains(" ") ? false : true;

						Assert.True(isValid);
        }

        private Stream getStream()
        {
            var io = new IO();
            var normalize = new Normalize();
            var filePath = normalize.ValidateURL(sourceURI);
            var stream = io.StreamFile(filePath.ToString());

            return stream;
        }
    }
}
