﻿
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
        private string[] Confidentiality = new string[] {"public","official","confidential","secret"  };
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
            throw new NotImplementedException();
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
