using ACC.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFS.Helpers
{
    public enum Privileges
    {
        TransPrptyAssessment,
        TransPrptySubdivision,
        TransPrptyConsolidation,
        TransTrnsferSgrgation,
        TransReclassification,
        TransReassessment,
        TransGeneralRevision,

        MngUsers,
        MngRolesPriveleges,
        MngBarangays,
        MngClassificationCodes,
        MngActualUseCodes,
        MngTransactionCodes,
        MngOwners,
        MngOwnerTypes,
        MngSignatories,
        MngSmv,

        RprtOwnershipRcrdCard,
        RprtTaxMapCtrlRoll,
        RprtAssmntRoll,
        RprtRcrdAssmnt,
        RprtNoticeAssmnt,
        RprtMrrpa,
        RprtQrrpa,
    }

    public static class PrivilegesHelper
    {
        private static Dictionary<Privileges, string> DictPriviledges()
        {
            return new Dictionary<Privileges, string>()
            {
                {Privileges.TransPrptyAssessment, "Transactions > Property Assessment" },
                {Privileges.TransPrptyConsolidation, "Transactions > Property Consolidation" },
                {Privileges.TransPrptySubdivision, "Transactions > Property Subdivision" },
                {Privileges.TransTrnsferSgrgation, "Transactions > Transfer/Segregation"},
                {Privileges.TransReclassification, "Transactions > Reclassification"},
                {Privileges.TransReassessment, "Transactions > Reassessment"},
                {Privileges.TransGeneralRevision, "Transactions > General Revision"},

                {Privileges.MngUsers, "Manage > Users"},
                {Privileges.MngRolesPriveleges, "Manage > Roles & Priveleges"},
                {Privileges.MngBarangays, "Manage > Barangays"},
                {Privileges.MngClassificationCodes, "Manage > Classification Codes"},
                {Privileges.MngActualUseCodes, "Manage > Actual Use Codes"},
                {Privileges.MngTransactionCodes, "Manage > Transaction Codes"},
                {Privileges.MngOwners, "Manage > Owners"},
                {Privileges.MngOwnerTypes, "Manage > Owner Types"},
                {Privileges.MngSignatories, "Manage > Signatories"},
                {Privileges.MngSmv, "Manage > Schedule of Market Values (SMV)"},

                {Privileges.RprtOwnershipRcrdCard, "Reports > Ownership Record Card"},
                {Privileges.RprtTaxMapCtrlRoll, "Reports > Tax Map Control Roll"},
                {Privileges.RprtAssmntRoll, "Reports > Assessment Roll"},
                {Privileges.RprtRcrdAssmnt, "Reports > Record of Assessment"},
                {Privileges.RprtNoticeAssmnt, "Reports > Notice of Assessment"},
                {Privileges.RprtMrrpa, "Reports > Monthly Report of Real Property Asessment (MRRPA)"},
                {Privileges.RprtQrrpa, "Reports > Quarterly Report of Real Property Assessment (QRRPA)"},
            };
        }

        internal static bool HasPrivilege(Privileges priviledges)
        {
            string privilegeVal = DictPriviledges()[priviledges];
            return UserPrivileges(UserHelper.loggedUser.RoleId).Contains(privilegeVal);
        }

        internal static string[] UserPrivileges(int rolesId)
        {
            var dtUserPriviledges = AccFactory.RolesPermissionsRepository().GetViewRecordsByRoleId(rolesId);
            return dtUserPriviledges
                                 .AsEnumerable()
                                 .Select(row => row.Field<string>("permission_name"))
                                 .ToArray();
        }
    }
}