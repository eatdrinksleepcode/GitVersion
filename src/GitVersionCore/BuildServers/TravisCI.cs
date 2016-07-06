﻿using System;
namespace GitVersion
{
	public class TravisCI : BuildServerBase
	{
		public override bool CanApplyToCurrentContext ()
		{
			return "true".Equals(Environment.GetEnvironmentVariable ("TRAVIS")) && "true".Equals(Environment.GetEnvironmentVariable("CI"));
		}

		public override string GenerateSetVersionMessage(VersionVariables variables)
		{
			return variables.FullSemVer;
		}

		public override string[] GenerateSetParameterMessage(string name, string value)
		{
			return new[]
			{
				string.Format("GitVersion_{0}={1}", name, value)
			};
		}

		public override bool PreventFetch ()
		{
			return true;
		}
	}
}
