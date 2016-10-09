using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.devunion.entities;

namespace ys.samples.devunion.persistence {
    internal class EntityMapper {
        public static readonly Type [] entityTypes = typeof(DataContext).Assembly.GetTypes().Where( x => typeof(IPersistentEntity).IsAssignableFrom( x ) && ! x.IsAbstract ).ToArray();

        private static readonly EntityMapper singleton = new EntityMapper();
        Dictionary<Type,Type> _mappedEntities;
        private EntityMapper( ) {
            _mappedEntities = new Dictionary<Type, Type>();
        }
        private Type doGetImplementorType( Type entityType ) {
            lock ( this ) {
                if ( !_mappedEntities.ContainsKey(entityType) ) {
                    var actualType = entityTypes.Where(x => x.GetInterfaces().Contains(entityType)).FirstOrDefault();
                    _mappedEntities[entityType] = actualType;
                }
                return _mappedEntities[entityType];
            }
        }
        public static Type GetImplementorType( Type entityType ) {
            return singleton.doGetImplementorType(entityType);
        }
    }
}
