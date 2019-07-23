﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ApprovalTests.Core;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Namers
{
    public class ApprovalsFilename
    {
        public static ApprovalsFilename Parse(string fullFilepath)
        {
            var info = new ApprovalsFilename();
            info.Directory = Path.GetDirectoryName(fullFilepath);
            var parts = Path.GetFileName(fullFilepath).Split('.');
            info.ClassName = parts[0];
            info.MethodName = parts[1];
            for (int i = 2; i < parts.Length; i++)
            {
                if (i == parts.Length - 2)
                {
                    info.ApprovedStatus = parts[i];
                }
                else if (i == parts.Length - 1)
                {
                    info.Extension = parts[i];
                }
                else
                {
                    info.AdditionalInformation.Add(parts[i]);
                }
            }

            return info;
        }

        public List<string> AdditionalInformation = new List<string>();

        public string Extension { get; set; }

        public string ApprovedStatus { get; set; }

        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public string Directory { get; set; }
        public bool IsMachineSpecific => 0 < AdditionalInformation.Count;


        public ApprovalsFilename ForApproved()
        {
            if (ApprovedStatus == "approved")
            {
                return this;
            }

            return new ApprovalsFilename
            {
                AdditionalInformation = AdditionalInformation,
                ApprovedStatus = "approved",
                ClassName = ClassName,
                Directory = Directory,
                Extension = Extension,
                MethodName = MethodName
            };
        }

        public bool IsEmptyFile()
        {
            return !File.Exists(GetFullPath) || 10 < new FileInfo(GetFullPath).Length;
        }

        public string GetFullPath
        {
            get
            {
                var additional = AdditionalInformation.Select(s => '.' + s).JoinWith("");
                return $"{Directory}{Path.DirectorySeparatorChar}{ClassName}.{MethodName}{additional}.{ApprovedStatus}.{Extension}";
            }
        }

        public override string ToString()
        {
            return $@"{nameof(GetFullPath)}: {GetFullPath}
{nameof(Directory)}: {Directory}
{nameof(ClassName)}: {ClassName}
{nameof(MethodName)}: {MethodName}
{nameof(AdditionalInformation)}: {AdditionalInformation.ToReadableString()}
{nameof(ApprovedStatus)}: {ApprovedStatus}
{ nameof(Extension)}: { Extension}";
        }
    }
}