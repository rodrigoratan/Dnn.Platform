﻿// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Settings;
using Moq;
using NUnit.Framework;

namespace DotNetNuke.Tests.Core.Entities.Modules.Settings
{
    using System.Runtime.Remoting.Channels;

    [TestFixture]
    public class TabModuleSettingsTests : BaseSettingsTests
    {
        public class MyTabModuleSettings
        {
            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public string StringProperty { get; set; } = "";

            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public int IntegerProperty { get; set; }

            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public double DoubleProperty { get; set; }

            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public bool BooleanProperty { get; set; }

            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public DateTime DateTimeProperty { get; set; } = DateTime.Now;

            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public TimeSpan TimeSpanProperty { get; set; } = TimeSpan.Zero;

            [TabModuleSetting(Prefix = SettingNamePrefix)]
            public TestingEnum EnumProperty { get; set; } = TestingEnum.Value1;

            [TabModuleSetting(Prefix = SettingNamePrefix, Serializer = "DotNetNuke.Tests.Core.Entities.Modules.Settings.ComplexTypeSerializer,DotNetNuke.Tests.Core")]
            public ComplexType ComplexProperty { get; set; } = new ComplexType(20, 25);
        }

        public class MyTabModuleSettingsRepository : SettingsRepository<MyTabModuleSettings> { }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("ar-JO")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_ar_JO(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("ca-ES")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_ca_ES(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("zh-CN")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_zh_CN(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("en-US")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_en_US(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("fr-FR")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_fr_FR(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("he-IL")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_he_IL(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("ru-RU")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_ru_RU(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("tr-TR")]
        public void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters_tr_TR(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        private void SaveSettings_CallsUpdateTabModuleSetting_WithRightParameters(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            //Arrange
            var moduleInfo = GetModuleInfo;
            var settings = new MyTabModuleSettings
            {
                StringProperty = stringValue,
                IntegerProperty = integerValue,
                DoubleProperty = doubleValue,
                BooleanProperty = booleanValue,
                DateTimeProperty = datetimeValue,
                TimeSpanProperty = timeSpanValue,
                EnumProperty = enumValue,
                ComplexProperty = complexValue,
            };

            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "StringProperty", stringValue));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "IntegerProperty", integerValue.ToString()));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "DoubleProperty", doubleValue.ToString(CultureInfo.InvariantCulture)));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "BooleanProperty", booleanValue.ToString()));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "DateTimeProperty", datetimeValue.ToString("o", CultureInfo.InvariantCulture)));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "TimeSpanProperty", timeSpanValue.ToString("c", CultureInfo.InvariantCulture)));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "EnumProperty", enumValue.ToString()));
            MockModuleController.Setup(mc => mc.UpdateTabModuleSetting(TabModuleId, SettingNamePrefix + "ComplexProperty", $"{complexValue.X} | {complexValue.Y}"));

            var settingsRepository = new MyTabModuleSettingsRepository();

            //Act
            settingsRepository.SaveSettings(moduleInfo, settings);

            //Assert
            MockRepository.VerifyAll();
        }

        [Test]
        public void SaveSettings_UpdatesCache()
        {
            //Arrange
            var moduleInfo = GetModuleInfo;
            var settings = new MyTabModuleSettings();

            MockCache.Setup(c => c.Insert(CacheKey(moduleInfo), settings));
            var settingsRepository = new MyTabModuleSettingsRepository();

            //Act
            settingsRepository.SaveSettings(moduleInfo, settings);

            //Assert
            MockRepository.VerifyAll();
        }

        [Test]
        public void GetSettings_CallsGetCachedObject()
        {
            //Arrange
            var moduleInfo = GetModuleInfo;

            MockCache.Setup(c => c.GetItem("DNN_" + CacheKey(moduleInfo))).Returns(new MyTabModuleSettings());
            var settingsRepository = new MyTabModuleSettingsRepository();

            //Act
            settingsRepository.GetSettings(moduleInfo);

            //Assert
            MockRepository.VerifyAll();
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("ar-JO")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_ar_JO(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("ca-ES")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_ca_ES(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("zh-CN")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_zh_CN(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("en-US")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_en_US(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("fr-FR")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_fr_FR(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("he-IL")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_he_IL(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("ru-RU")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_ru_RU(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        [Test]
        [TestCaseSource(nameof(SettingsCases))]
        [SetCulture("tr-TR")]
        public void GetSettings_GetsValuesFrom_ModuleSettingsCollection_tr_TR(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            GetSettings_GetsValuesFrom_ModuleSettingsCollection(stringValue, integerValue, doubleValue, booleanValue, datetimeValue, timeSpanValue, enumValue, complexValue);
        }

        private void GetSettings_GetsValuesFrom_ModuleSettingsCollection(string stringValue, int integerValue, double doubleValue, bool booleanValue, DateTime datetimeValue, TimeSpan timeSpanValue, TestingEnum enumValue, ComplexType complexValue)
        {
            //Arrange
            var moduleInfo = GetModuleInfo;
            var tabModuleSettings = new Hashtable
                                    {
                                        { SettingNamePrefix + "StringProperty", stringValue },
                                        { SettingNamePrefix + "IntegerProperty", integerValue.ToString() },
                                        { SettingNamePrefix + "DoubleProperty", doubleValue.ToString(CultureInfo.InvariantCulture) },
                                        { SettingNamePrefix + "BooleanProperty", booleanValue.ToString() },
                                        { SettingNamePrefix + "DateTimeProperty", datetimeValue.ToString("o", CultureInfo.InvariantCulture) },
                                        { SettingNamePrefix + "TimeSpanProperty", timeSpanValue.ToString("c", CultureInfo.InvariantCulture) },
                                        { SettingNamePrefix + "EnumProperty", enumValue.ToString() },
                                        { SettingNamePrefix + "ComplexProperty", $"{complexValue.X} | {complexValue.Y}" },
                                    };

            MockTabModuleSettings(moduleInfo, tabModuleSettings);

            var settingsRepository = new MyTabModuleSettingsRepository();

            //Act
            var settings = settingsRepository.GetSettings(moduleInfo);

            //Assert
            Assert.AreEqual(stringValue, settings.StringProperty, "The retrieved string property value is not equal to the stored one");
            Assert.AreEqual(integerValue, settings.IntegerProperty, "The retrieved integer property value is not equal to the stored one");
            Assert.AreEqual(doubleValue, settings.DoubleProperty, "The retrieved double property value is not equal to the stored one");
            Assert.AreEqual(booleanValue, settings.BooleanProperty, "The retrieved boolean property value is not equal to the stored one");
            Assert.AreEqual(datetimeValue, settings.DateTimeProperty, "The retrieved datetime property value is not equal to the stored one");
            Assert.AreEqual(timeSpanValue, settings.TimeSpanProperty, "The retrieved timespan property value is not equal to the stored one");
            Assert.AreEqual(enumValue, settings.EnumProperty, "The retrieved enum property value is not equal to the stored one");
            Assert.AreEqual(complexValue, settings.ComplexProperty, "The retrieved complex property value is not equal to the stored one");
            MockRepository.VerifyAll();
        }
    }
}
