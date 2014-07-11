REM This script is used to generate Phonemetadata.cs and Phonenumber.cs
REM from their protocol buffers definitions.

protogen -namespace=PhoneNumbers -cls_compliance=false --proto_path=..\..\resources ..\..\resources\phonemetadata.proto ..\..\resources\phonenumber.proto -output_directory=..\PhoneNumbers\

PhoneNumbersConverter.exe ..\..\resources\PhoneNumberMetadata.xml ..\PhoneNumbers\res PhoneNumberMetadataProto
PhoneNumbersConverter.exe ..\..\resources\PhoneNumberAlternateFormats.xml ..\PhoneNumbers\res PhoneNumberAlternateFormatsProto

PhoneNumbersConverter.exe ..\..\resources\PhoneNumberMetadata.xml ..\PhoneNumbers\CountryCodeToRegionCodeMap.cs
PhoneNumbersConverter.exe ..\..\resources\PhoneNumberAlternateFormats.xml ..\PhoneNumbers\AlternateFormatsCountryCodeToRegionCodeMap.cs

PhoneNumbersConverter.exe ..\..\resources\PhoneNumberMetadataForTesting.xml ..\PhoneNumbers\res PhoneNumberMetadataForTestingProto
PhoneNumbersConverter.exe ..\..\resources\PhoneNumberMetadataForTesting.xml ..\PhoneNumbers.Test\CountryCodeToRegionCodeMapForTesting.cs


