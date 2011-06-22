using System;
using Omu.ValueInjecter;
using ValueInjector.Infrastructure.Mapping;
using ValueInjector.Models;

namespace ValueInjector.Infrastructure
{
    public static class Extensions
    {
        public static T ToDomain<T>(this object source, T domain = default(T)) 
            where T: class, new()
        {
            if (domain == null)
                domain = new T();

            if (source == null)
                return domain;

            domain.InjectFrom(source)
                .InjectFrom<IgnoreAudit>(source)
                .InjectFrom<FlatLoopValueInjection>(source)
                .InjectFrom<UnflatLoopValueInjection>(source);

            return domain;
        }

        public static T ToViewModel<T>(this object source, T viewmodel = default(T)) 
            where T : class, new()
        {
            if (viewmodel == null)
                viewmodel = new T();

            if (source == null)
                return viewmodel;

            viewmodel.InjectFrom(source)
                .InjectFrom<FlatLoopValueInjection>(source)
                .InjectFrom<UnflatLoopValueInjection>(source)
                .InjectFrom<NullablesToNormal>(source)
                .InjectFrom<NormalToNullables>(source)
                .InjectFrom<IntToEnum>(source)
                .InjectFrom<EnumToInt>(source);

            return viewmodel;
        }

        public static T Audit<T>( this IAudit<T> target, string user = "system")
        {
            if (!target.CreatedAt.HasValue) {
                target.CreatedAt = DateTime.UtcNow;
                target.CreatedBy = user;
            }

            target.UpdatedAt = DateTime.UtcNow;
            target.UpdatedBy = user;

            return (T) target;
        }

    }
}