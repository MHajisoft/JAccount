namespace Account.Common.Base;

public class CoreConstant
{
    public const string CorsPolicy = nameof(CorsPolicy);

    public class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }

    public class Domain
    {
        public class Attachment
        {
            public class FileSize
            {
                public const int B4000 = 4000;
                public const int Kb50 = 50;
                public const int Kb100 = 100;
                public const int Kb300 = 300;
                public const int Kb500 = 500;
                public const int Mb1 = 1024;
                public const int Mb5 = 5120;
                public const int Mb10 = 10240;
                public const int Mb50 = 51200; // این مقدار برای یک استفاده خاص گذاشته شده و بهتر است که استفاده نگردد
            }

            public class Document
            {
                public const string Url = "/Core/Document/Info/";
            }

            public class Announcement
            {
                public const string Url = "/Core/Announcement/Info/";
            }
        }

        public class Common
        {
            public class ComissionType
            {
                public const string Up = nameof(Up);
                public const string Same = nameof(Same);
                public const string Self = nameof(Self);
                public const string Down = nameof(Down);

                public const string OrgUnit = nameof(OrgUnit);
                public const string ChildOrgUnit = nameof(ChildOrgUnit);
                public const string TagOrgUnit = nameof(TagOrgUnit);
            }

            public class Enum
            {
                public const string Custom = nameof(Custom);
            }

            public const int DefaultCode = 100000;
        }

        public class Person
        {
            public const string Date13680101 = "1989-03-21";
        }

        public class Party
        {
            public const string SystemUserName = "system";

            public const string ThemeBase = nameof(ThemeBase); //Prov: بعد از نهایی شدن بحث تم محل کانستنت اصلاح شود
            public const string PageSize = nameof(PageSize);
            public const string IsPin = nameof(IsPin);

            //Prov ldap
            public const string DefaultPassword = "Mellat@1";
        }

        public class OrgUnit
        {
            public const string FirstLevelCode = "1";
            public const string SecondLevelCode = "001";
            public const string ThirdLevelCode = "01";
        }

        public class GeneralType
        {
            public const string FirstLevelCode = "101";
            public const string OtherLevelCode = "001";

            public class Property
            {
                public const string OldId = nameof(OldId);
                public const string NewId = nameof(NewId);
            }

            public class StoredProcedure
            {
                public const string Merge = "SP_GeneralType_Merge";
            }
        }

        public class Setting
        {
            public const string ComissionDashboard = nameof(ComissionDashboard);

            public class Report
            {
                public class ChartReport
                {
                    public const string SubTitle = nameof(SubTitle);
                    public const string ChartType = nameof(ChartType);
                    public const string ShowLegend = nameof(ShowLegend);
                    public const string XAxisTitle = nameof(XAxisTitle);
                    public const string YAxisTitle = nameof(YAxisTitle);
                    public const string SeriesTitle1 = nameof(SeriesTitle1);
                    public const string SeriesTitle2 = nameof(SeriesTitle2);
                    public const string SeriesTitle3 = nameof(SeriesTitle3);
                    public const string SeriesTitle4 = nameof(SeriesTitle4);
                    public const string SeriesTitle5 = nameof(SeriesTitle5);
                    public const string DecimalDigitsCount = nameof(DecimalDigitsCount);
                }

                public class StatisticChartReport
                {
                    public const string ThresholdPercent = nameof(ThresholdPercent);
                    public const string TopNCount = nameof(TopNCount);
                }

                public class TableReport
                {
                    public const string ExportImageColumn = nameof(ExportImageColumn);
                    public const string ExportImageFileName = nameof(ExportImageFileName);
                    public const string HasExportImage = nameof(HasExportImage);
                }
            }

            public class StateMachine
            {
                public class LevelType
                {
                    public const string Expert = nameof(Expert);
                    public const string Group = nameof(Group);
                }

                public const string Level = nameof(Level);
                public const string StateFlowLevel = nameof(StateFlowLevel);
                public const string StateFlowLevel2 = nameof(StateFlowLevel2);

                public const string Init = nameof(Init);
                public const string Correction = nameof(Correction);

                public const string Deny = nameof(Deny);
            }

            public class Dashboard
            {
                public const string Url = "/Core/Dashboard/Info/";
            }
        }

        public class Tile
        {
            public const string FaraIcon = "faraicon-";

            public const string BackColor = "bg-";
            //public const string ForeColor = "fg-";
            //public const string OutlineColor = "ol-";
        }

        public class NotificationLog
        {
            public const string EmailIdPostfix = "@fara.com";
        }
    }

    public class Enterprise
    {
        public class Party
        {
            public const string SubSystem = nameof(SubSystem);
        }
    }

    public class Group
    {
        public const string Admin = nameof(Admin);

        public const string Admin2 = nameof(Admin2);

        public const string Foundation = nameof(Foundation);

        public const string View = nameof(View);

        public const string Report = nameof(Report);

        public const string Log = nameof(Log);

        public class Attachment
        {
            public class Announcement
            {
                public const string Edit = "AttachmentAnnouncementEdit";
            }

            public class Document
            {
                public const string Admin = "AttachmentDocumentAdmin";
                public const string View = "AttachmentDocumentView";
            }
        }

        public class Genaral
        {
            public const string Comment = nameof(Comment);
            public const string AlternateEdit = nameof(AlternateEdit);
            public const string ComissionTypeEdit = nameof(ComissionTypeEdit);
        }

        public class Enterprise
        {
            public class Foundation
            {
                public const string Editor = "EnterpriseFoundationEditor";
            }

            public class Person
            {
                public const string Editor = "EnterprisePersonEditor";
            }

            public class Party
            {
                public const string Editor = "EnterprisePartyEditor";
                public const string GroupEditor = "EnterprisePartyGroupEditor";
            }

            public class OrgUnit
            {
                public const string Viewer = "EnterpriseOrgUnitViewer";
            }

            public class Contact
            {
                public const string Editor = "EnterpriseContactEditor";
            }
        }

        public class Membership
        {
            public class OrgUnitMembership
            {
                public const string Editor = "MembershipOrgUnitMembershipEditor";
            }
        }

        public class Schema
        {
            public class Group
            {
                public const string Editor = "SchemaGroupEditor";
            }
        }

        public class Setting
        {
            public const string Editor = "SettingEditor";

            public class Report
            {
                public const string Editor = "SettingReportEditor";
            }
        }
    }

    public class General
    {
        public class GeneralType
        {
            public const string DocumentType = nameof(DocumentType);
            public const string ContactType = nameof(ContactType);
            public const string DocumentTypeGeneral = "DocumentType_General";
            public const string OrganizationType = nameof(OrganizationType);
            public const string Priority = nameof(Priority);
            public const string FaqType = nameof(FaqType);
            public const string AcademicDiscipline = nameof(AcademicDiscipline);
            public const string University = nameof(University);
        }

        public class GeneralMap
        {
            public const string EntityType = nameof(EntityType);
        }

        public class Tag
        {
            public class OrgUnit
            {
                public const string AlternateManager = nameof(AlternateManager);
            }

            public class GeneralType
            {
                public class ContactType
                {
                    public const string Unique = nameof(Unique);
                }

                public const string NeedToProvince = nameof(NeedToProvince);
                public const string NeedToCountry = nameof(NeedToCountry);
            }
        }

        public class CustomProperty
        {
            public const string Extra = nameof(Extra);
        }
    }

    public class UserActivity
    {
        public class Category
        {
            public const string Crud = "CRUD";
        }

        public class ExtendedProperty
        {
            public const string Entity = nameof(Entity);
            public const string Id = nameof(Id);
            public const string Ip = nameof(Ip);
            public const string UserName = "username";
        }
    }

    public class Setting
    {
        //Prov: ادغام با کلاس موجود در کلاس دامین
        public class Report
        {
            public class ChartReport
            {
                public const int DefaultTopNCount = 30;
                public const float DefaultThresholdPercent = 1;
            }

            public class Code
            {
                public const string EntityByState = nameof(EntityByState);
                public const string EntityByPeriod = nameof(EntityByPeriod);
                public const string EntityByInitLevel = nameof(EntityByInitLevel);
                public const string EntityByFinalLevel = nameof(EntityByFinalLevel);
            }
        }

        public class ActionState
        {
            public class GetList
            {
                public const string Current = nameof(Current);
                public const string Final = nameof(Final);
            }
        }
    }

    public class ExtendedProperty { }

    public class Cache
    {
        public class RequestContext
        {
            /// <summary>
            /// فضای نوتیفایر
            /// </summary>
            public const string Notifier = nameof(Notifier);

            /// <summary>
            /// نام کاربری
            /// </summary>
            public const string CurrentUser = nameof(CurrentUser);

            /// <summary>
            /// کاربر جاری
            /// </summary>
            public const string CurrentParty = nameof(CurrentParty);

            /// <summary>
            /// دسترسی های کاربر ضمن رعایت ارث بری
            /// </summary>
            public const string PartyGroups = nameof(PartyGroups);

            /// <summary>
            /// واحدهای سازمانی در دسترس کاربر
            /// </summary>
            public const string PartyPermissions = nameof(PartyPermissions);
        }

        public class Expire
        {
            public const string LongExpire = nameof(LongExpire);
            public const string ShortExpire = nameof(ShortExpire);
        }

        public class GeneralCache
        {
            public const string PartyCount = nameof(PartyCount);
            public const string ExpireDate = nameof(ExpireDate);
            public const string LastCode = nameof(LastCode);
        }
    }

    public class ReportParameter
    {
        public const string CurrentDate = nameof(CurrentDate);

        public const string CurrentUser = nameof(CurrentUser);

        public const string Title = nameof(Title);

        public const string QueryValue = nameof(QueryValue);

        public const string Logo = nameof(Logo);

        public const string ExtraTitle = nameof(ExtraTitle);

        public const string DynamicColumn = nameof(DynamicColumn);
    }
}
