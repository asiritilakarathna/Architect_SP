
using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Claims;
using Microsoft.SharePoint.WebControls;

namespace Architect_SP.ClaimsProvider
{
    class SqlClaimsProvider : SPClaimProvider
    {
        public SqlClaimsProvider(string displayName) : base(displayName)
        {
        }
        private string[] Confidentialities = new string[] {"public","official","confidential","secret"  };
        internal static string ProviderDisplayName
        {
            get
            {
                return "Architect_SP Provider";
            }
        }


        internal static string ProviderInternalName
        {
            get
            {
                return "ArchitectSPProvider";
            }
        }

        private static string SqlClaimType
        {
            get
            {
                return "http://schema.architectsp.local/roles";
      }
        }

        private static string SqlClaimValueType
        {
            get
            {
                return Microsoft.IdentityModel.Claims.ClaimValueTypes.String;
            }
        }

        public override string Name
        {
            get
            {
                return ProviderInternalName;
            }
        }

        public override bool SupportsEntityInformation
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsHierarchy
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsResolve
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsSearch
        {
            get
            {
                return true;
            }
        }

        protected override void FillClaimsForEntity(Uri context, SPClaim entity, List<SPClaim> claims)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (claims == null)
                throw new ArgumentNullException("claims");

            //figure out who the user is so we know what team to add to their claim
            //the entity.Value from the input parameter contains the name of the
            //authenticated user.  for a SQL FBA user, it looks something like
            // 0#.f|sqlmembership|user1; for a Windows claims user it looks something
            //like 0#.w|steve\\wilmaf
            //I’ll skip some boring code here to look at that name and figure out
            //if it’s an FBA user or Windows user, and if it’s an FBA user figure
            //out what the number part of the name is after "user"

            string confidentiality = string.Empty;
            int userID = 0;

            //after the boring code, "userID" will equal -1 if it’s a Windows user,
            //or if it’s an FBA user then it will contain the number after "user"

            //figure out what the user’s favorite team is
            if (userID > 0)
            {
                //plug in the appropriate team
                if (userID > 30)
                    confidentiality = Confidentialities[2];
                else if (userID > 15)
                    confidentiality = Confidentialities[1];
                else
                    confidentiality = Confidentialities[0];
            }
            else
                confidentiality = Confidentialities[1];
            //if they’re not one of our FBA users then make their favorite team DVK

            //add the claim
            claims.Add(CreateClaim(SqlClaimType, confidentiality, SqlClaimValueType));
        }

        protected override void FillClaimTypes(List<string> claimTypes)
        {
            throw new NotImplementedException();
        }

        protected override void FillClaimValueTypes(List<string> claimValueTypes)
        {
            throw new NotImplementedException();
        }

        protected override void FillEntityTypes(List<string> entityTypes)
        {
            throw new NotImplementedException();
        }

        protected override void FillHierarchy(Uri context, string[] entityTypes, string hierarchyNodeID, int numberOfLevels, SPProviderHierarchyTree hierarchy)
        {
            throw new NotImplementedException();
        }

        protected override void FillResolve(Uri context, string[] entityTypes, SPClaim resolveInput, List<PickerEntity> resolved)
        {
            throw new NotImplementedException();
        }

        protected override void FillResolve(Uri context, string[] entityTypes, string resolveInput, List<PickerEntity> resolved)
        {
            throw new NotImplementedException();
        }

        protected override void FillSchema(SPProviderSchema schema)
        {
            throw new NotImplementedException();
        }

        protected override void FillSearch(Uri context, string[] entityTypes, string searchPattern, string hierarchyNodeID, int maxCount, SPProviderHierarchyTree searchTree)
        {
            throw new NotImplementedException();

        }
    }
}
