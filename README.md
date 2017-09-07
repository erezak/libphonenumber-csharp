# Overview

# libphonenumber-csharp

Cloned from [https://bitbucket.org/pmezard/libphonenumber-csharp](https://bitbucket.org/pmezard/libphonenumber-csharp).

* The library is now working out of the box on a Windows Phone
* The library is now available for consumption in UWP on Windows 10 devices


# From the original WIKI
## Conversion Notes

C# port of Google's libphonenumber library:

  [[http://code.google.com/p/libphonenumber/]]

  The code was rewritten from the Java source mostly unchanged, please refer to the original documentation for sample code and API documentation.

  The original Apache License 2.0 was preserved.

  See [[https://bitbucket.org/pmezard/libphonenumber-csharp/src/tip/csharp/README.txt|csharp/README.txt]] for details about the port.
## Examples
```
using libphonenumber;
...

string germanNumberStr = "089123456";
PhoneNumber number;
try
{
    number = PhoneNumberUtil.Instance.Parse(germanNumberStr, "DE");
}
catch (NumberParseException e)
{
    throw;
}

if (number.IsValidNumber)
{
    // Produces "+49 89 123456"
    Debug.WriteLine(number.Format(PhoneNumberUtil.PhoneNumberFormat.INTERNATIONAL));
    // Produces "089 123456"
    Debug.WriteLine(number.Format(PhoneNumberUtil.PhoneNumberFormat.NATIONAL));
    // Produces "+4989123456"
    Debug.WriteLine(number.Format(PhoneNumberUtil.PhoneNumberFormat.E164));

    // Produces "011 49 89 123456", the number when it is dialed in the United States.
    Debug.WriteLine(number.FormatOutOfCountryCallingNumber("US"));
}

// Outputs "Munich"
Debug.WriteLine(number.GetDescriptionForNumber(Locale.ENGLISH));
// Outputs "München"
Debug.WriteLine(number.GetDescriptionForNumber(Locale.GERMAN));
// Outputs "Munich"
Debug.WriteLine(number.GetDescriptionForNumber(Locale.ITALIAN));
```

```
AsYouTypeFormatter formatter = PhoneNumberUtil.Instance.GetAsYouTypeFormatter("DE");
Debug.WriteLine(formatter.InputDigit('0'));  // Outputs "0"
Debug.WriteLine(formatter.InputDigit('8'));  // Outputs "08"
Debug.WriteLine(formatter.InputDigit('9'));  // Outputs "089"
Debug.WriteLine(formatter.InputDigit('1'));  // Outputs "089 1"
Debug.WriteLine(formatter.InputDigit('2'));  // Outputs "089 12"
Debug.WriteLine(formatter.InputDigit('3'));  // Outputs "089 123"
Debug.WriteLine(formatter.InputDigit('4'));  // Outputs "089 1234"
Debug.WriteLine(formatter.InputDigit('5'));  // Outputs "089 12345"
Debug.WriteLine(formatter.InputDigit('6'));  // Outputs "089 123456"
```

## Features

  * Parsing/formatting/validating phone numbers for all countries/regions of the world.
  * GetNumberType - gets the type of the number based on the number itself; able to distinguish Fixed-line, Mobile, Toll-free, Premium Rate, Shared Cost, VoIP and Personal Numbers (whenever feasible).
  * IsNumberMatch - gets a confidence level on whether two numbers could be the same.
  * GetExampleNumber/GetExampleNumberByType - provides valid example numbers for 218 countries/regions, with the option of specifying which type of example phone number is needed.
  * IsPossibleNumber - quickly guessing whether a number is a possible phonenumber by using only the length information, much faster than a full validation.
  * AsYouTypeFormatter - formats phone numbers on-the-fly when users enter each digit.
  * FindNumbers - finds numbers in text input 

