using System;
using System.Globalization;
using System.IO;
using PhoneNumbers;

namespace PhoneNumbersConverter
{
    class Program
    {
        private static void GenerateProtofBuf(string inputFileName, string outputFileName)
        {
            var file = File.OpenRead(inputFileName);
            var meta = BuildMetadataFromXml.BuildPhoneMetadataCollection(file, false);

            var countryCodeToRegionCodeMap = BuildMetadataFromXml.BuildCountryCodeToRegionCodeMap(meta);

            var className = Path.GetFileNameWithoutExtension(outputFileName);

            var generator = new CountryCodeToRegionCodeMapGenerator("PhoneNumbers", className, countryCodeToRegionCodeMap);
            var code = generator.TransformText();

            File.WriteAllText(outputFileName, code);
        }

        private static void GenerateCountryCodeToRegionCodeMap(string inputFileName, string outputDirectory, string filePrefix)
        {
            Directory.CreateDirectory(outputDirectory);

            var file = File.OpenRead(inputFileName);
            var meta = BuildMetadataFromXml.BuildPhoneMetadataCollection(file, false);
            for (var i = 0; i < meta.MetadataCount; ++i)
            {
                var data = meta.GetMetadata(i);
                var regionCode = data.Id;

                if (string.IsNullOrEmpty(regionCode) || regionCode.Equals("001"))
                {
                    regionCode = data.CountryCode.ToString(CultureInfo.InvariantCulture);
                }

                var outMetadataCollection = new PhoneMetadataCollection();
                outMetadataCollection.MetadataList.Add(data);

                var outputFileName = Path.Combine(outputDirectory, filePrefix + "_" + regionCode);

                var outputForRegion = File.OpenWrite(outputFileName);
                outMetadataCollection.WriteTo(outputForRegion);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                GenerateCountryCodeToRegionCodeMap(args[0], args[1], args[2]);
            }
            else if (args.Length == 2)
            {
                GenerateProtofBuf(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("Usage: PhoneNumbersConverter input_file output_directory output_prefix");
                Console.WriteLine("Usage: PhoneNumbersConverter input_file countrycode_to_regioncode_output_file");
            }
        }
    }
}
