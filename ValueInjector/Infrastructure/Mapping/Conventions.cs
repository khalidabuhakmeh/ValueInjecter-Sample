using System;
using System.Linq;
using Omu.ValueInjecter;
using ValueInjector.Models;

namespace ValueInjector.Infrastructure.Mapping
{
    public class IgnoreAudit : ConventionInjection
    {
        private static readonly string[] AuditNames = typeof (IAudit).GetProperties().Select(p => p.Name).ToArray();

        protected override bool Match(ConventionInfo c) {
            var result = AuditNames.Contains(c.TargetProp.Name);
            return result;
        }

        protected override object SetValue(ConventionInfo c) {
            // don't override these values
            return c.TargetProp.Value;
        }
    }

    // all below are from http://valueinjecter.codeplex.com/wikipage?title=Useful%20injections&referringTitle=Home
    public class EnumToInt : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                c.SourceProp.Type.IsSubclassOf(typeof(Enum)) && c.TargetProp.Type == typeof(int);
        }
    }

    public class IntToEnum : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                c.SourceProp.Type == typeof(int) && c.TargetProp.Type.IsSubclassOf(typeof(Enum));
        }
    }

    //e.g. int? -> int
    public class NullablesToNormal : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                   Nullable.GetUnderlyingType(c.SourceProp.Type) == c.TargetProp.Type;
        }
    }
    //e.g. int -> int?
    public class NormalToNullables : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                   c.SourceProp.Type == Nullable.GetUnderlyingType(c.TargetProp.Type);
        }
    } 

}