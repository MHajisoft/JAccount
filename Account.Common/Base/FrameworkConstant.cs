using System.Globalization;

namespace Account.Common.Base;

public class FrameworkConstant
{
    public class Config
    {
        public class AppSetting
        {
            public const string SubSystem = nameof(SubSystem);
            public const string MainRoute = nameof(MainRoute);
            public const string SoftwareId = nameof(SoftwareId);
            public const string AuthenticationType = nameof(AuthenticationType);
            public const string LogChangeHistory = nameof(LogChangeHistory);
            public const string SpringConfigFile = nameof(SpringConfigFile);
            public const string HbmAssemblies = "HBM_ASSEMBLIES";
            public const string ServiceSubSystem = nameof(ServiceSubSystem);
            public const string IsWindowsClient = nameof(IsWindowsClient);
            public const string IsNewVersion = nameof(IsNewVersion);
            public const string UseNewLogin = nameof(UseNewLogin);
            public const string UseEntityFramework = nameof(UseEntityFramework);
            public const string NeedToCaptcha = nameof(NeedToCaptcha);
            public const string NeedToHashPassword = nameof(NeedToHashPassword);
            public const string NeedToCheckAuthenticationBySession = nameof(NeedToCheckAuthenticationBySession);
            public const string NeedToOnlyOneActiveSession = nameof(NeedToOnlyOneActiveSession);
            //Prov: بررسی جهت ادامه استفاد از این بیزینس برای جلوگیری از افزایش حجم بی رویه حجم دیتابیس از طریق لاگ
            public const string LogCount = nameof(LogCount);
            // علت وجود این فلگ اینه که برخی از سامانه ها دارای قسمت کور نمی باشند و امکان ثبت انتیتی رفرنس کلا وجود ندارد
            public const string IgnoreAutoAddEntityReferenceInRepository = nameof(IgnoreAutoAddEntityReferenceInRepository);

            public const string Prov_NeedToEncryption = nameof(Prov_NeedToEncryption);

            /// <summary>
            /// نمایش متن خطاهای ناشی از پیاده سازی به کاربر
            /// </summary>
            public const string ShowImplementationBusinessException = nameof(ShowImplementationBusinessException);

            public const string IsLeftToRight = nameof(IsLeftToRight);
            public const string HasSSL = nameof(HasSSL);
            //Prov: این کانفیگ با توجه به اعلام نیاز مبین مبنی بر ذخیره تصاویر با حجم بالاتر از 500 کیلو در پیوست اضافه شده است
            public const string ProvIgnoreImageSizeValidation = nameof(ProvIgnoreImageSizeValidation);
            // Prov: این مورد به خاطر نیازمندی یکی از سامانه ها گذاشته شده است، پس از حذف پروژه مذکور باید این خط و استفاده آن حذف شود
            public const string NeedToScanExeForWcf = nameof(NeedToScanExeForWcf);

            public const string UseHashColumn = nameof(UseHashColumn);
        }

        public class Section
        {
            public const string ConnectionStrings = "connectionStrings";
            public const string Services = "system.serviceModel/services";
        }

        public class Encryption
        {
            public const string DataProtectionConfigurationProvider = nameof(DataProtectionConfigurationProvider);
            public const string InvalidConnectionString = @"data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true";
        }
    }

    public class ErrorCode
    {
        public const string ErrorPrefix = "Error:";

        //Prov: این موارد باید به یک کلاس منتقل
        public const string NullArgument = "";
        public const string InvalidArgument = "";
        public const string DateIsNotValid = "";
        public const string InvalidClassName = "Invalid class name";
        public const string InputIsNotSuitableForMethod = "";
        public const string EncryptValueIsNotValid = "";
        public const string FileIsNotValid = "";
        public const string NotImplementedYet = "2";

        public const string NationalCodeIsNotInvalid = "";
        public const string FromDateBigerThanToDate = "";

        public class KnownException //00
        {
            public const string NotImplementedException = "0001";
            public const string StringFormatHasShortage = "0002";
            public const string InputStringWasNotInACorrectFormat = "0003";
            public const string AmbiguousMatchFound = "0004";
            public const string AutoMapperMappingExceptionTryingToMapStringToInt = "0005";
            public const string AutoMapperMappingExceptionNotSetMappingInAutoMapperConfigurator = "0006";
            public const string ViolationOfUniqueKeyConstraint = "0007";
            public const string ViolationOfPrimaryKeyConstraint = "0008";
            public const string StringOrBinaryDataWouldBeTruncatedTheStatementHasBeenTerminated = "0009";
            public const string UpdateStatementFailedBecauseDataCannotBeUpdatedInATableThatHasANonclusteredColumnstoreIndex = "0009/1";
            public const string CannotInsertTheValueNullIntoColumn = "0009/2";
            public const string CouldNotInsert = "0010";
            public const string CouldNotUpdate = "0011";
            public const string CouldNotDelete = "0012";
            public const string SpecifiedCastIsNotValid = "0013";
            public const string CouldNotExecuteQuery = "0014";
            public const string DefaultGenericAdoException = "0015";
            public const string SqlDateTimeOverflow = "0016";
            public const string NoRowWithTheGivenIdentifierExists = "0017";
            public const string NotSupportedExceptionEqualsIsNotSuitableForObjectInLinqQuery = "0018";
            public const string NotSupportedExceptionIsLikeIsNotSuitableForObjectInLinqQuery = "0019";
            public const string NotSupportedExceptionIsNullOrEmptyIsNotSuitableForObjectInLinqQuery = "0020";
            public const string NotSupportedExceptionSpecifiedMethodIsNotSupported = "0020/1"; //Prov:
            public const string IsNotSupportedOnThisProxyThisCanHappenIfTheMethodIsNotMarkedWithOperationContractAttributeOrIfTheInterfaceTypeIsNotMarkedWithServiceContractAttribute = "0020/2"; //Prov:
            public const string ObjectReferenceNotSetToAnInstanceOfAnObject = "0021";
            public const string ObjectReferencesAnUnsavedTransientInstance = "0022";
            public const string NotNullPropertyReferencesANullOrTransient = "0024";
            public const string NoPersisterFor = "0025";
            public const string NhibernateImplementationHasError = "0026";
            public const string ACollectionWithCascadeAllDeleteOrphanWasNoLongerReferencedByTheOwningEntityInstance = "0027";
            public const string ValueCannotBeNull = "0028";
            public const string ArgumentOutOfRangeException = "0029";
            public const string TheFollowingTypesMayNotBeUsedAsProxies = "0030";
            public const string UnknownException = "0031";
            public const string NullIdentifier = "0032";
            public const string ResourceDoesNotContainADefinitionFor = "0033";
            public const string DefaultHttpCompileException = "0034";
            public const string BeginFailedWithSqlException = "0035";
            public const string TransactionNotConnectedOrWasDisconnected = "0035/1";
            public const string TheLengthOfTheByteArrayValueExceedsTheLengthConfiguredInTheMappingParameter = "0036";
            public const string ThereWasAnErrorWhileTryingToSerializeParameter = "0037";
            public const string ThereWasAnErrorWhileTryingToDeserializeParameter = "0038";
            public const string AdapterBaseCommunicationException = "0039";
            public const string UnableToCastObjectOfType = "0040";
            public const string RowWasUpdatedOrDeletedByAnotherTransaction = "0041";
            public const string DidNotReceiveAReplyWithinTheConfiguredTimeout = "0042";
            public const string AnExistingConnectionWasForciblyClosedByTheRemoteHost = "0043";
            public const string NoConnectionCouldBeMadeBecauseTheTargetMachineActivelyRefusedIt = "0044";
            public const string CouldNotConnectToNetTcp = "0045";
            public const string SequenceContainsNoMatchingElement = "0046";
            public const string CouldNotFindDefaultEndpointElementThatReferencesContract = "0047";
            public const string AnItemWithTheSameKeyHasAlreadyBeenAdded = "0048";
            public const string UnableToConnectToSqlServerDatabase = "0049";
            public const string ANetworkRelatedOrInstanceSpecificErrorOccurredWhileEstablishingAConnectionToSqlServer = "0050";
            public const string CannotOpenDatabase = "0051";
            public const string LoginFailedForUser = "0052";
            public const string OnlyOneUsageOfEachSocketAddressProtocolNetworkAddressPortIsNormallyPermitted = "0053";
            public const string TheGivenKeyWasNotPresentInTheDictionary = "0054";
            public const string ThisIsUsuallyATemporaryErrorDuringHostnameResolutionAndMeansThatTheLocalServerDidNotReceiveAResponseFromAnAuthoritativeServer = "0055";
            public const string NoConnectionCouldBeMadeBecauseTheTargetMachineActivelyRefusedItFFFF = "0056";
            public const string LoginFailed = "0057";
            public const string SslHasError = "0058";
            public const string NoSuchHostIsKnown = "0059";
            public const string TheRequiredAntiForgeryCookieIsNotPresent = "0060";
            public const string TheProvidedAntiForgeryTokenWasMeantForUser = "0061";
            public const string TheDatasourceDoesntContainADataMemberWithThe = "0062";
            public const string RequestHasTooManyParameters = "0063";
            public const string SequenceContainsMoreThanOneMatchingElement = "0064";
            public const string NullableObjectMustHaveAValue = "0065";
            public const string APotentiallyDangerousRequestFormValueWasDetectedFromTheClient = "0066";
            public const string CouldNotFindAPartOfThePath = "0067";
            public const string CouldNotFindFile = "0068";
            public const string APotentiallyDangerousRequestQueryStringValueWasDetectedFromTheClient = "0069";
            public const string APublicActionMethodWasNotFoundOnController = "0070";
            public const string TheParametersDictionaryContainsANullEntryForParameterOfNonNullableType = "0071";
            public const string TheControllerForPathWasNotFoundOrDoesNotImplementIController = "0072";
            public const string TheParameterConversionFromTypeFailedOrInputStringWasNotInACorrectFormat = "0073";
            public const string ErrorDuringSerializationOrDeserializationUsingTheJsonJavaScriptSerializerTheLengthOfTheStringExceedsTheValueSetOnTheMaxJsonLengthProperty = "0074";
            public const string InvalidColumnName = "0075";
            public const string ThereWasNoEndpointListeningAtThatCouldAcceptTheMessage = "0076";
            public const string CannotRetrievePropertyNameBecauseLocalizationFailed = "0077";
            public const string UnableToConnectToTheRemoteServerNoConnectionCouldBeMadeBecauseTheTargetMachineActivelyRefusedIt = "0078";
            public const string MethodNotFound = "0079";
            public const string MethodNotFoundModel = "0080";
            public const string ErrorDehydratingPropertyValueFor = "0081";
            public const string TheLengthOfTheStringValueExceedsTheLengthConfiguredInTheMappingParameter = "0082";
            public const string CouldNotFindStoredProcedure = "0083";
            public const string AccessToThePathIsDenied = "0084";
            public const string CanNotWriteToNHibernateReadOnlyCache = "0085";
            public const string InvalidNetTcpBindingConfigurationName = "0086";
            public const string TheTypeInitializerForNHibernateCfgEnvironmentThrewAnException = "0087";
        }

        public class Exception //01
        {
            public const string InvalidLicenceKey = "0101";
            public const string StaleObject = "0102";
            public const string InterfaceByThisTypeWasNotImplementedYet = "0103";
            public const string TargetInvocationExceptionNotImplementationForMethodByThisName = "0104";
            public const string TargetParameterCountExceptionParameterCountMismatch = "0105";
            public const string LoadEntityByZeroIdIsNotValid = "0106";
            //Prov: روی اسم کانستانت و ریسورس هم باید تجدید نظر شود
            public const string ObjectNotFound = "0107";
            public const string InvalidRepositoryLocatorConfig = "0108";
            public const string NHibernateMappingIsInvalidForThisEntityInThisProperty = "0109";
            public const string PersistItemIsNotValid = "0110";
            public const string IsNotUnique = "0111";
            public const string IsNotUniqueById = "0112";
            public const string ChangePropertyIsNotValid = "0113";
            public const string AccessDenied = "0114";
            public const string CurrentUserRequired = "0115";
            public const string HbmAssembliesNotSetInConfigAppSetting = "0116";
            public const string EntityTypeIsNotValid = "0118";
            public const string SizeIsLargerOfValidSize = "0119";
            public const string SessionExpire = "0120";
            public const string InvalidLicenceKeyFormat = "0121";
            public const string DuplicateRequest = "0122";
            public const string ValidationProperty = "0123";
            public const string ValidationPropertyById = "0124";
            public const string NothingFound = "0125";
            public const string IsDuplicateItem = "0126";
            public const string IsDuplicateItemByTitle = "0127";
            public const string IsDuplicateSelection = "0128";
            public const string PropertyIsNotValid = "0129";
            public const string NoRowSelected = "0130";
        }

        public class UserMembership //02
        {
            public const string UseInternalMembershipIsInvalidByAnotherAuthenticationType = "0201";
            public const string IpIsNoValid = "0202";
        }

        public class Util //03
        {
            public class Sql //01
            {
                public const string PagingIsNotValid = "030101";
                public const string ColumnNameForAgreagateOperatorIsNotValid = "030102";
            }

            public class Image //02
            {
                public const string BulkScanIsNotValid = "030201";
                public const string ExtensionIsNotValid = "030202";
                public const string FileSizeIsNotValid = "030203";
                public const string FileWithZeroSizeIsNotValid = "030204";
            }

            public class Configuration //03
            {
                public const string AppSettingIsRequired = "030301";
            }

            //Prov: بررسی جهت ادامه استفاد از این بیزینس برای جلوگیری از افزایش حجم بی رویه حجم دیتابیس از طریق لاگ
            public class Log //04
            {
                public const string LogCountIsNotValid = "030401";
            }
        }

        public class QueryDto //04
        {
            public const string QueryDtoIsNotValid = "0401";
        }
    }

    public class Util
    {
        public class Common
        {
            public const string InterNetwork = nameof(InterNetwork);
            public const string InterNetworkV6 = nameof(InterNetworkV6);
            public const string Dto = nameof(Dto);
        }

        public class Validation
        {
            public const int NvarcharMax = 1037741823; //Prov: به نظرم این عدد باید مطابق دیتابیس یعنی 4000 ست شود
            public const string DateTimeMin = "1800-01-01T00:00:00";
            public const string DateTimeMax = "4000-12-29T00:00:00";

        }

        public class Email
        {
            public const string Sent = "sent";
        }

        public class UtilDateTime
        {
            public const string Date = nameof(Date);
            public const string DefaultValue = "00:00"; //Provisional : این مورد باید به یکجای بهتری منتقل شود

            //Prov:ایجاد اینام از جنس اینامریشن کور
            public class DateTimeFormat
            {
                public const string YyyyMmDd = "yyyyMMdd"; // 20190930
                public const string YyyyMmDdWithDash = "yyyy-MM-dd"; // 2019-09-30

                public const string YyyyMmDdHhMmSs = "yyyyMMddHHmmss"; // به علت استفاده در نام فایل از : استفاده نشده است
                public const string YyyyMmDdHhMmSsWithDash = "yyyy-MM-dd HH:mm:ss";
                public const string YyyyMmDdHhMmSsWithColon = "yyyyMMdd HH:mm:ss";
                public const string YyyyMmDdHhMmSsWithSlash = "yyyy/MM/dd HH:mm:ss";

                public const string YyyyMmDdWithSlash = "yyyy/MM/dd"; // جهت ایجاد مسیر تو در تو - کنترل تاریخ بدون تایم
                public const string MmDdYyyy = "MM/dd/yyyy"; // کنترل تاریخ بدون تایم

                public const string MmDdYyyyHhMm = "MM/dd/yyyy HH:mm"; // کنترل تاریخ با تایم
                public const string YyyyMmDdHhMm = "yyyy/MM/dd HH:mm"; // کنترل تاریخ با تایم

                public const string HhMmSsByDash = "HH-mm-ss"; // برای نام فایل
                public const string HhMmSsByColon = "HH:mm:ss"; // برای چاپ یا نمایش

                public const string HhMm = "HH:mm"; // برای چاپ یا نمایش
            }
        }

        public class UtilString
        {
            public const string ThreeDots = "...";
            public const string TwoDigit = "0#";
            public const string NoSelect = "---";
        }

        public class UtilLong
        {
            public const string MoneyFormat = "{0:#,#}";
            public const char Zero = '0';
        }

        public class Sql
        {
            public const string From = "FROM "; // برای استفاده در خطا حتما باید یک اسپیس داشته باشد
            public const string InsertInto = "INSERT INTO "; // برای استفاده در خطا حتما باید یک اسپیس داشته باشد
            public const string Update = "UPDATE "; // برای استفاده در خطا حتما باید یک اسپیس داشته باشد
            public const string UqWithDoubleUnderLineQuotation = "'UQــ";
            public const string InvalidColumnName = "Invalid column name '";
            public const string IntoColumn = "into column '";
            public const string DatabaseName = nameof(DatabaseName);
        }

        public class UtilFile
        {
            public class Path
            {
                //public const string Temp = nameof(Temp);
                public const string Files = nameof(Files);
            }

            public class Extension
            {
                public const string Jpg = "jpg";
                public const string Jpeg = "jpeg";
                public const string Png = "png";
                public const string Gif = "gif";
                public const string Bmp = "bmp";
                public const string Tif = "tif";
                public const string Tiff = "tiff";
                public const string Svg = "svg";

                public const string XML = "xml";
                public const string Repx = "repx";
                public const string Mrt = "mrt";

                public const string Txt = "txt";
                public const string Log = "log";
                public const string Rtf = "rtf";
                public const string Pdf = "pdf";
                public const string Doc = "doc";
                public const string Docx = "docx";
                public const string Xls = "xls";
                public const string Xlsx = "xlsx";
                public const string Csv = "csv";
                public const string Ppt = "ppt";
                public const string Pptx = "pptx";

                public const string Zip = "zip";
                public const string Rar = "rar";

                public const string Htm = "htm";
                public const string Html = "html";
                public const string Mht = "mht";
                public const string Email = "eml";

                public const string Mp3 = "mp3";
                public const string Wma = "wma";
                public const string Wav = "wav";

                public const string Mp4 = "mp4";
                public const string Wmv = "wmv";
                public const string Mov = "mov";

                public const string Exe = "exe";
                public const string Dll = "dll";
                public const string Bat = "bat";
                public const string NoExtension = "NoExt";
            }

            public const string Unknown = nameof(Unknown);
            public const string Untitled = nameof(Untitled);

            public static readonly List<string> InvalidExtensions = new List<string> { Extension.Dll, Extension.Exe, Extension.Bat };
        }

        public class UtilCache
        {
            public const int Min30 = 30;
        }

        public class Reflection
        {
            public class MethodName
            {
                public const string ParseByValue = nameof(ParseByValue);
            }
        }

        public class Wcf
        {
            public const string ServiceAssemblySuffix = "*Services.dll";

            public const string Host = nameof(Host);
        }

        public class Log
        {
            public const string TableLog = "Log";
            public const string TableUserActivity = "Core_Log_UserActivity";
        }
    }

    public class UserActivity
    {
        public class Activity
        {
            public class RootEntityBase
            {
                public const string Add = nameof(Add);
                public const string Delete = nameof(Delete);
            }
        }
    }

    public class ExtendedProperty
    {
        public class ChangeHistory
        {
            public const string Id = nameof(Id);
        }

        public class Log
        {
            public const string FullMessage = nameof(FullMessage);
            public const string StackTrace = nameof(StackTrace);
        }
    }

    public class Paging
    {
        public const int DefaultSearchCount = 50;

        public class Size
        {
            public const int Size10 = 10;
        }
    }

    public class Property
    {
        //Prov: بقیه کانستنت‌های این مدلی هم باید به اینجا منتقل شوند
        public const string Id = nameof(Id);
        public const string ErrorMessageString = nameof(ErrorMessageString);
        // این مورد به خاطر نیازمندی به دست آوردن نام پراپرتی های مرتبط با اینام در کوئری دی-تی-او ها از طریق انتیتی می باشد
        // البته با توجه به قرارداد فلت نویسی برای به دست آوردن مقدار ولیو یک اینام
        public const string Value = nameof(Value);

        public const string FilePath = nameof(FilePath);
        public const string OriginalFile = nameof(OriginalFile);
        //Prov: بررسی محل کانستنت
        public const string Other = nameof(Other);
    }

    public class Culture
    {
        public static readonly CultureInfo Persian = new CultureInfo("fa-IR");
        public static readonly CultureInfo English = new CultureInfo("en-US");
    }

    public class Font
    {
        //Prov: بررسی امکان اضافه کردن این فونت‌ها به صورت مستقیم در پروژه
        public const string IRANSansFaNum = "IRANSans(FaNum)";
    }

    public class XtraReportUtil // مورد استفاده گزارشات لیستی
    {
        public const string Image = nameof(Image);
        public const string Text = nameof(Text);
        public const string Checked = nameof(Checked);
        public const string DetailTable = nameof(DetailTable);
        public const string HeaderTable = nameof(HeaderTable);
        public const string HeaderRow = nameof(HeaderRow);
        public const string DetailRow = nameof(DetailRow);
    }
    
    public class Log
    {
        public class PropertyName
        {
            public const string Code = nameof(Code);
            public const string ClassName = nameof(ClassName);
            public const string Method = nameof(Method);
            public const string FullMessage = nameof(FullMessage);
            public const string StackTrace = nameof(StackTrace);
            public const string SourceContext = nameof(SourceContext);
            public const string Ip = nameof(Ip);
            public const string CreateUser = nameof(CreateUser);
        }
    }
}
