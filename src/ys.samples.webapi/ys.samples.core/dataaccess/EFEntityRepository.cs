using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public class EFEntityRepository<EntityT> : IEntityRepository
        where EntityT : class, IPersistentEntity {
        private DbSet<EntityT> _entitySet;
        private Action<EntityT> _setModifiled;
        public EFEntityRepository( IPersistenceContext persistentContext ) {
            var ef = persistentContext.GetUnderlyingSession() as DbContext;
            _entitySet = ef.Set<EntityT>();
            _setModifiled = ( e ) => {
                ef.Entry(e).State = EntityState.Modified;
            };
        }

        public void Delete( EntityT entity ) {
            _entitySet.Remove(entity);
        }
        void IEntityRepository.Delete( IPersistentEntity entity ) {
            this.Delete(entity as EntityT);
        }
        public IQueryable<EntityT> GetAll( Paging paging ) {
            int actualPage = paging.page ?? 0;
            int actualSize = paging.pageSize ?? 0;
            if ( actualPage > 0 && actualSize > 0 ) {
                return _entitySet.Skip(( actualPage - 1 ) * actualSize).Take(actualSize);
            } else {
                return _entitySet.AsQueryable();
            }
        }
        IQueryable<IPersistentEntity> IEntityRepository.GetAll( Paging paging ) {
            return this.GetAll(paging);
        }
        public EntityT GetById( string id ) {
            return _entitySet.Find(id);
        }
        IPersistentEntity IEntityRepository.GetById( string id ) {
            return this.GetById(id);
        }

        public void Update( EntityT entity ) {
            _entitySet.Attach(entity);
            entity.dateUpdated = DateTime.Now;
            _setModifiled(entity);
        }
        void IEntityRepository.Update( IPersistentEntity entity ) {
            this.Update(entity as EntityT);
        }

        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");

        protected Expression<Func<EntityT, bool>> aggregateClause( Expression<Func<EntityT, bool>> bodyClause,
                                                Expression currentClause,
                                                ParameterExpression paramExpr,
                                                Filtering.LogicalOperator nextConjugate ) {
            if ( bodyClause == null ) {
                return Expression.Lambda<Func<EntityT, bool>>(currentClause, paramExpr);
            } else {
                //Aggregate
                var nextClause = Expression.Lambda<Func<EntityT, bool>>(currentClause, paramExpr);
                if ( nextConjugate == Filtering.LogicalOperator.None ) {
                    return nextClause;
                } else if ( nextConjugate == Filtering.LogicalOperator.Or ) {
                    return Expression.Lambda<Func<EntityT, bool>>(Expression.Or(bodyClause.Body, nextClause.Body));
                } else {
                    return Expression.Lambda<Func<EntityT, bool>>(Expression.AndAlso(bodyClause.Body, nextClause.Body));
                }
            }
        }
        protected Expression<Func<EntityT, bool>> filterToExpression( Filtering filter ) {
            Expression<Func<EntityT, bool>> whereClause = null;
            if ( filter.Conditions != null ) {
                for ( var ix = 0; ix < filter.Conditions.Length; ix++ ) {
                    var condition = filter.Conditions[ix];

                    var paramExpr = Expression.Parameter(typeof(EntityT), condition.Name);
                    var valueExpr = Expression.Constant(condition.Value);
                    switch ( condition.Operator ) {
                        case Filtering.ConditionOperator.Equal: {
                                var conditionClause = Expression.Equal(paramExpr, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.NotEqual: {
                                var conditionClause = Expression.NotEqual(paramExpr, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.LessThan: {
                                var conditionClause = Expression.LessThan(paramExpr, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.LessEqualThan: {
                                var conditionClause = Expression.LessThanOrEqual(paramExpr, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.GreaterThan: {
                                var conditionClause = Expression.GreaterThan(paramExpr, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.GreaterEqualThan: {
                                var conditionClause = Expression.GreaterThanOrEqual(paramExpr, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.Contains: {
                                var conditionClause = Expression.Call(paramExpr, containsMethod, valueExpr);
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                        case Filtering.ConditionOperator.NotContains: {
                                var conditionClause = Expression.Not(Expression.Call(paramExpr, containsMethod, valueExpr));
                                whereClause = aggregateClause(whereClause, conditionClause, paramExpr, ix < ( filter.Conditions.Length - 1 ) ? condition.NextConjugation : Filtering.LogicalOperator.None);
                            }
                            break;
                    }

                }
            }
            return whereClause;
        }
        public IQueryable<EntityT> GetByFilter( Filtering filter, Paging paging ) {
            var whereClauses = filterToExpression(filter);
            var query = _entitySet.AsQueryable();
            if ( query != null ) {
                query = query.Where(whereClauses);
            }
            int actualPage = paging.page ?? 0;
            int actualSize = paging.pageSize ?? 0;
            if ( actualPage > 0 && actualSize > 0 ) {
                query = query.Skip(( actualPage - 1 ) * actualSize).Take(actualSize);
            }
            return query;
        }
        IQueryable<IPersistentEntity> IEntityRepository.GetByFilter( Filtering filter, Paging paging ) {
            return this.GetByFilter(filter, paging);
        }

        public EntityT Insert( EntityT entity ) {
            entity.makeUnique();
            entity.dateInserted = DateTime.Now;
            return _entitySet.Add(entity);
        }
        public IEnumerable<EntityT> InsertMany( IEnumerable<EntityT> entities ) {
            foreach ( var e in entities ) {
                e.dateInserted = DateTime.Now;
                e.makeUnique();
            }
            return _entitySet.AddRange(entities);
        }
        IPersistentEntity IEntityRepository.Insert( IPersistentEntity entity ) {
            return this.Insert( (EntityT) entity);
        }

        IEnumerable<IPersistentEntity> IEntityRepository.InsertMany( IEnumerable<IPersistentEntity> entities ) {
            return this.InsertMany(entities.Cast<EntityT>());
        }
    }
}
