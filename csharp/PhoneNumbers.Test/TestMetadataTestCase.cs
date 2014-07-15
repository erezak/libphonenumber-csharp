﻿/*
 * Copyright (C) 2012 The Libphonenumber Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PhoneNumbers.Test
{
    /**
    * Root class for PhoneNumberUtil tests that depend on the test metadata file.
    * <p>
    * Note since tests that extend this class do not use the normal metadata file, they should not be
    * used for regression test purposes.
    *
    * @author Shaopeng Jia
    * @author Lara Rennie
    */
    class TestMetadataTestCase
    {
        public const String TEST_META_DATA_FILE_PREFIX = "PhoneNumberMetadataForTestingProto";

        protected PhoneNumberUtil phoneUtil;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            phoneUtil = InitializePhoneUtilForTesting();
        }

        static PhoneNumberUtil InitializePhoneUtilForTesting()
        {
            PhoneNumberUtil.ResetInstance();
            return PhoneNumberUtil.GetInstance(
                TEST_META_DATA_FILE_PREFIX,
                CountryCodeToRegionCodeMapForTesting.GetCountryCodeToRegionCodeMap());
        }
    }
}
